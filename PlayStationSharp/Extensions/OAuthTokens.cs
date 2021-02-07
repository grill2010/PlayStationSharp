using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using PlayStationSharp.API;
using PlayStationSharp.Exceptions.Auth;
using PlayStationSharp.Model;

namespace PlayStationSharp.Extensions
{
	public class OAuthTokens
	{
		private OAuthTokenModel _model;

		public string Authorization => _model.AccessToken;
		public string Refresh => _model.RefreshToken;
		public int ExpiresIn => _model.ExpiresIn;

		public OAuthTokens(OAuthTokenModel model)
		{
			this._model = model;
		}

		public OAuthTokens(string refreshToken)
		{
			this._model = new OAuthTokenModel
			{
				RefreshToken = refreshToken
			};
			this.RefreshTokens();
		}

		public OAuthTokens RefreshTokens()
		{
			try
			{
                byte[] iso88591data = Encoding.GetEncoding("ISO-8859-1").GetBytes(Auth.AuthorizationBearer.ClientId + ":" + Auth.AuthorizationBearer.ClientSecret);
                string authorization = "Basic " + Convert.ToBase64String(iso88591data);
                Dictionary<string, string> headers = new Dictionary<string, string>
                {
                    {"Authorization", authorization},
                    {"Content-Type", "application/x-www-form-urlencoded"}
                };
                string bodyValue = "grant_type=" + Auth.AuthorizationBearer.RefreshType + "&refresh_token=" + Refresh +"&scope=" + Auth.AuthorizationBearer.Scope +"&";

                var result = Request.SendPostRequest<OAuthTokenModel>(APIEndpoints.OAUTH_URL, bodyValue, "", headers);

                _model = result;
				return this;
			}
			catch (GenericAuthException ex)
			{
				switch (ex.Error.ErrorCode)
				{
					case 4159:
						throw new InvalidRefreshTokenException(ex.Error.ErrorDescription);
					default:
						throw;
				}
			}
		}
	}
}