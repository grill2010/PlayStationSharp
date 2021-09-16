using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using PlayStationSharp.Exceptions;
using PlayStationSharp.Exceptions.Auth;
using PlayStationSharp.Extensions;
using PlayStationSharp.Forms;
using PlayStationSharp.Model;

namespace PlayStationSharp.API
{
	public class Auth
	{
		public static class AuthorizationBearer
		{
            public const string ClientId = "ba495a24-818c-472b-b12d-ff231c1b5745"; // client id for remote play windows
            public const string ClientSecret = "mvaiZkRsAsI1IBkY"; // client secret for remote play windows
            public const string GrantType = "authorization_code";
            public const string RefreshType = "refresh_token";
            public const string Scope = "psn%3Aclientapp+referenceDataService%3AcountryConfig.read+pushNotification%3AwebSocket.desktop.connect+sessionManager%3AremotePlaySession.system.update";
			public const string RedirectUri = "https://remoteplay.dl.playstation.net/remoteplay/redirect&";

            public const string Ps5ProfileUrl = "https://web.np.playstation.net";
            public const string Ps5WakeupPostQuery = "/api/cloudAssistedNavigation/v1/users/me/commands";
        }

		public static Account CreateLogin(bool useWindows10WebEngine)
		{
			var dialog = new LoginForm(useWindows10WebEngine);

			OAuthTokens tokens = null;

			dialog.FormClosing += delegate (object sender, FormClosingEventArgs args)
			{
				var grant = dialog.GrantCode;

				if (grant == null) return;

				try
				{
                    byte[] iso88591data = Encoding.GetEncoding("ISO-8859-1").GetBytes(AuthorizationBearer.ClientId + ":" + AuthorizationBearer.ClientSecret);
                    string authorization = "Basic " + Convert.ToBase64String(iso88591data);
                    Dictionary<string, string> headers = new Dictionary<string, string>
                    {
                        {"Authorization", authorization},
                        {"Content-Type", "application/x-www-form-urlencoded"}
                    };
                    string bodyValue = "grant_type=" + AuthorizationBearer.GrantType + "&code=" + grant + "&redirect_uri=" + AuthorizationBearer.RedirectUri + "&";

                    var result = Request.SendPostRequest<OAuthTokenModel>(APIEndpoints.OAUTH_URL, bodyValue, "", headers);

                    tokens = new OAuthTokens(result);
				}
				catch (PlayStationApiException ex)
				{
					switch (ex.Error.Code)
					{
						case 4159:
							throw new InvalidRefreshTokenException(ex.Error.Message);
						default:
							throw;
					}
				}

			};

			dialog.ShowDialog();

			return tokens == default(OAuthTokens) ? null : new Account(tokens);
		}

		public static Account Login(string refreshToken)
		{
			var tokens = new OAuthTokens(refreshToken);
			return new Account(tokens);
		}
	}
}