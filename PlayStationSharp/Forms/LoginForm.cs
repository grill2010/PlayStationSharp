using System;
using System.Windows.Forms;
using Microsoft.Toolkit.Forms.UI.Controls;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using PlayStationSharp.API;

namespace PlayStationSharp.Forms
{
	public partial class LoginForm : Form
	{
		public string GrantCode { get; private set; }

        private string _loginUrl => "https://auth.api.sonyentertainmentnetwork.com/2.0/oauth/authorize?service_entity=urn:service-entity:psn&response_type=code&client_id=" + Auth.AuthorizationBearer.ClientId + "&redirect_uri=https://remoteplay.dl.playstation.net/remoteplay/redirect&scope=" + Auth.AuthorizationBearer.Scope + "&request_locale =en_US&ui=pr&service_logo=ps&layout_type=popup&smcid=remoteplay&prompt=always&PlatformPrivacyWs1=minimal&";

		// Okay, so the deal with this stuff is for some reason, the WebView control throws an exception for certain people.
		// Since I couldn't repro the issue, the library will fallback to the built in .NET webBrowser control and use that instead.
		// It's pretty horrible, but it'll have to do until I can find out why the WebView crashes.
		public LoginForm(bool useWindows10WebEngine)
		{
			InitializeComponent();
            if (useWindows10WebEngine)
            {
                try
                {
                    UseWindows10WebEngine();
                }
                catch (Exception)
                {
                    UseStandardWebEngine();
                }
            }
            else
            {
                UseStandardWebEngine();
            }
        }

        private void UseWindows10WebEngine()
        {
            var webViewLogin = new WebView
            {
                Dock = DockStyle.Fill,
                Location = new System.Drawing.Point(0, 0),
                MinimumSize = new System.Drawing.Size(20, 20),
                Name = "webLogin",
                Size = new System.Drawing.Size(574, 636),
                Source = new System.Uri(this._loginUrl, System.UriKind.Absolute),
                TabIndex = 0,
                Visible = true
            };
            webViewLogin.NavigationStarting += webViewLogin_NavigationStarting;

            this.Controls.Add(webViewLogin);
        }

        private void UseStandardWebEngine()
        {
            var webBrowserLogin = new WebBrowser
            {
                Dock = DockStyle.Fill,
                Location = new System.Drawing.Point(0, 0),
                MinimumSize = new System.Drawing.Size(20, 20),
                Name = "webLogin",
                Size = new System.Drawing.Size(574, 636),
                Url = new System.Uri(this._loginUrl, System.UriKind.Absolute),
                TabIndex = 0,
                Visible = true,
                ScriptErrorsSuppressed = true
            };

            webBrowserLogin.Navigated += webBrowserLogin_Navigated;

            this.Controls.Add(webBrowserLogin);
        }

		private void webViewLogin_NavigationStarting(object sender, WebViewControlNavigationStartingEventArgs e)
		{
			var url = Uri.UnescapeDataString(e.Uri.ToString());

			if (!url.StartsWith("https://auth.api.sonyentertainmentnetwork.com/mobile-success.jsp")) return;

			var paramName = "code=";
			var code = url.Remove(0, url.IndexOf(paramName, StringComparison.Ordinal) + paramName.Length);
			GrantCode = code.Substring(0, code.IndexOf("&", StringComparison.Ordinal));
			this.Close();
		}

		private void webBrowserLogin_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
			var url = Uri.UnescapeDataString(e.Url.ToString());

			if (!url.StartsWith("https://remoteplay.dl.playstation.net/remoteplay/redirect?code=")) return;

			var paramName = "code=";
			var code = url.Remove(0, url.IndexOf(paramName, StringComparison.Ordinal) + paramName.Length);
			GrantCode = code.Substring(0, code.IndexOf("&", StringComparison.Ordinal));
			this.Close();
		}
	}
}