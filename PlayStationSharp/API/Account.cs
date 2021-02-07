using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using Flurl.Http;
using PlayStationSharp.Exceptions;
using PlayStationSharp.Exceptions.User;
using PlayStationSharp.Extensions;
using PlayStationSharp.Model;

namespace PlayStationSharp.API
{
    /// <summary>
    /// Contains information for the currently logged in account.
    /// </summary>
    public class Account : AbstractUser
    {
        private readonly Lazy<List<MessageThread>> _messageThreads;

        public List<MessageThread> MessageThreads => _messageThreads.Value;

        public OAuthTokens Tokens => this.Client.Tokens;

        public Account(OAuthTokens tokens)
        {
            Init(new PlayStationClient(tokens, this));

            _messageThreads = new Lazy<List<MessageThread>>(() => GetMessageThreads());
        }

        /// <summary>
        /// Finds a user.
        /// </summary>
        /// <param name="onlineId">Online name of the user.</param>
        /// <returns>New instance of User for the selected player.</returns>
        public User FindUser(string onlineId)
        {
            try
            {
                var profile = Request.SendGetRequest<Profile>(
                    $"{APIEndpoints.USERS_URL}{onlineId}/profile2?fields=npId,onlineId,avatarUrls,plus,aboutMe,languagesUsed,trophySummary(@default,progress,earnedTrophies),isOfficiallyVerified,personalDetail(@default,profilePictureUrls),personalDetailSharing,personalDetailSharingRequestMessageFlag,primaryOnlineStatus,presences(@titleInfo,hasBroadcastData),friendRelation,requestMessageFlag,blocking,mutualFriendsCount,following,followerCount,friendsCount,followingUsersCount&avatarSizes=m,xl&profilePictureSizes=m,xl&languagesUsedLanguageSet=set3&psVitaTitleIcon=circled&titleIconSize=s",
                    this.Client.Tokens.Authorization);

                return new User(Client, profile.Information);
            }
            catch (PlayStationApiException ex)
            {
                switch (ex.Error.Code)
                {
                    case 2105356:
                        throw new UserNotFoundException(ex.Error.Message);
                    default:
                        throw;
                }
            }
        }

        public void WakeUpPs4Console(string onlineId)
        {
            try
            {
                string data1 = GetUniqueKey(16);
                string data2 = GetUniqueKey(16);

                string encodedData1 = Convert.ToBase64String(Encoding.UTF8.GetBytes(data1));
                string encodedData2 = Convert.ToBase64String(Encoding.UTF8.GetBytes(data2));

                Request.SendPostRequestWithJsonContentType<object>("https://at-prof.np.community.playstation.net/userProfile/v1/users/"+ onlineId + "/remoteConsole/wakeUp?platform=PS4", new
                {
                    dataTypeSuffix = "remotePlay",
                    data = new
                    {
                        roomId = 0,
                        clientType = "Windows",
                        data1 = encodedData1,
                        data2 = encodedData2
                    }
                }, this.Client.Tokens.Authorization);
            }
            catch (PlayStationApiException e)
            {
                throw new CouldNotWakeUpPlayStation(e.Error);
            }
        }

        public void WakeUpPs5Console(string onlineId, string accountId)
        {
            try
            {
                Dictionary< string, string> headers = new Dictionary<string, string>();
                headers.Add("Accept-Language", "ja-JP");
                headers.Add("User-Agent", "RpNetHttpUtilImpl");
                headers.Add("Host", "web.np.playstation.net");

                Ps5DevicesModel devices = Request.SendGetRequest<Ps5DevicesModel>("https://web.np.playstation.net/api/cloudAssistedNavigation/v1/users/me/clients?platform=PROSPERO&includeFields=device&limit=5&offset=0", this.Client.Tokens.Authorization, headers);

                if (devices != null && devices.Clients.Count > 0)
                {
                    string duid = devices.Clients[0].Duid; // always take the first one (to do check which one if user has multiple PS5 systems)


                    Random r = new Random();
                    long roomId = (long)(r.NextDouble() * 281000000000000L);
                    string data1 = GetUniqueKey(16);
                    string data2 = GetUniqueKey(16);

                    string encodedData1 = Convert.ToBase64String(Encoding.UTF8.GetBytes(data1));
                    string encodedData2 = Convert.ToBase64String(Encoding.UTF8.GetBytes(data2));

                    string wakeupUrl = Auth.AuthorizationBearer.Ps5ProfileUrl + Auth.AuthorizationBearer.Ps5WakeupPostQuery;
                    

                    string authorization = "Bearer " + this.Client.Tokens.Authorization;
                    headers = new Dictionary<string, string>
                    {
                        {"User-Agent", "RpNetHttpUtilImpl"},
                        {"Authorization", authorization},
                        {"Content-Type", "application/json; charset=utf-8"},
                        {"Host", "web.np.playstation.net"}
                    };
                    // ToDo use proper JSON parsing here...
                    string bodyValue = "{\"commandDetail\":{\"platform\":\"PROSPERO\",\"duid\":\"" + duid + "\",\"commandType\":\"remotePlay\",\"parameters\":{\"initialParams\": {\"accountId\":" + accountId  + ", \"roomId\":" + roomId + ", \"sessionId\":\"\", \"clientType\":\"Windows\", \"data1\":\" " + encodedData1 + "\", \"data2\":\"" + encodedData2 +"\"}},\"messageDestination\":\"SQS\"}}";

                    Request.SendPostRequest<object>(wakeupUrl, bodyValue, this.Client.Tokens.Authorization, headers);
                }
            }
            catch (PlayStationApiException e)
            {
                throw new CouldNotWakeUpPlayStation(e.Error);
            }
        }

        /// <summary>
        /// Finds all message threads (aka groups) you are in with the given onlineId.
        /// </summary>
        /// <param name="onlineId"></param>
        /// <returns></returns>
        public List<MessageThread> FindMessageThreads(string onlineId)
        {
            return this.Client.Account.MessageThreads.Where(a => a.Members.Any(b => b.OnlineId.Equals(onlineId)))
                .ToList();
        }

        /// <summary>
        /// Updates background color for profile.
        /// </summary>
        /// <param name="color">Background color (alpha is ignored).</param>
        public void UpdateBackgroundColor(Color color)
        {
            var colorString = $"{color.R:X2}{color.G:X2}{color.B:X2}";

            try
            {
                Request.SendPatchRequest<object>(
                    "https://profile.api.playstation.com/v1/users/me/profile/backgroundImage",
                    new BackgroundImageModel(new BackgroundImageModel.Operation("replace", "/color", colorString)),
                    this.Client.Tokens.Authorization);
            }
            catch (PlayStationApiException ex)
            {
                switch (ex.Error.Code)
                {
                    case 3288833:
                        throw new InvalidColorException();
                    default:
                        throw;
                }
            }
        }

        /// <summary>
        /// Updates background image for profile.
        /// </summary>
        /// <param name="image">Background image.</param>
        public void UpdateBackgroundImage(Image image)
        {
            var imageData = new ImageConverter().ConvertTo(image, typeof(byte[])) as byte[];

            if (imageData == null) throw new BadImageFormatException();

            var requestBody = new StringBuilder();

            var guid = Guid.NewGuid();

            requestBody.AppendLine("--RNFetchBlob-796778496");
            requestBody.AppendLine($"Content-Disposition: form-data; name=\"file\"; filename=\"{guid}\"");
            requestBody.AppendLine("Content-Type: image/jpeg");
            requestBody.Append(Encoding.UTF8.GetString(imageData));
            requestBody.AppendLine();
            requestBody.AppendLine("--RNFetchBlob-796778496");
            requestBody.AppendLine("Content-Disposition: form-data; name=\"mimeType\"");
            requestBody.AppendLine("Content-Type: text/plain");
            requestBody.AppendLine();
            requestBody.AppendLine("image/jpeg");
            requestBody.AppendLine("--RNFetchBlob-796778496--");

            try
            {
                var data = Request.SendMultiPartPostRequest<UploadImageModel>(
                    $"https://satchel.api.playstation.com/v1/item/generic/permanent/psapp/{guid}", requestBody,
                    "RNFetchBlob-796778496", this.Client.Tokens.Authorization);
                try
                {
                    Request.SendPatchRequest<object>(
                        "https://profile.api.playstation.com/v1/users/me/profile/backgroundImage",
                        new BackgroundImageModel(new BackgroundImageModel.Operation("replace", "/sourceUrl", data.Url)),
                        this.Client.Tokens.Authorization);
                }
                catch (PlayStationApiException)
                {
                    // 
                }
            }
            catch (PlayStationApiException ex)
            {
                switch (ex.Error.Code)
                {
                    case 3215109:
                        throw new EmptyImageException();
                    default:
                        throw;
                }
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == HttpStatusCode.InternalServerError) throw new BadImageFormatException();
            }
        }

        /// <summary>
        /// Gets message threads (aka groups) for the logged in account.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        private List<MessageThread> GetMessageThreads(int offset = 0, int limit = 20)
        {
            var threadModels = Request.SendGetRequest<ThreadsModel>($"https://us-gmsg.np.community.playstation.net/groupMessaging/v1/threads?fields=threadMembers,threadNameDetail,threadThumbnailDetail,threadProperty,latestMessageEventDetail,latestTakedownEventDetail,newArrivalEventDetail&limit={limit}&offset={offset}&sinceReceivedDate=1970-01-01T00:00:00Z",
                this.Client.Tokens.Authorization);

            return threadModels.Threads.Select(thread => new MessageThread(Client, thread)).ToList();
        }

        public static string GetUniqueKey(int size)
        {
            Random random = new Random();
            char[] chars =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567".ToCharArray();
            byte[] data = new byte[size];
            random.NextBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (var b in data)
            {
                result.Append(chars[(b) % (chars.Length)]);
            }

            return result.ToString();
        }
    }
}