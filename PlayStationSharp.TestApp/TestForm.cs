using System;
using System.Windows.Forms;
using PlayStationSharp.API;
using PlayStationSharp.Model;
using PlayStationSharp.Model.ProfileJsonTypes;

namespace PlayStationSharp.TestApp
{
	public partial class TestForm : Form
	{
        private Account Account { get; set; }

        public TestForm()
		{
			InitializeComponent();
		}

        private void PopulateFields()
        {
            lblOnlineId.Text = Account.OnlineId;
        }

        private void SetupLogin(bool needsLogin)
		{
			btnLogin.Visible = needsLogin;

			lblOnlineId.Visible = !needsLogin;
            wakeUpGrpBox.Visible = !needsLogin;
            queryAccountGrpBox.Visible = !needsLogin;
        }

		private void TestForm_Load(object sender, EventArgs e)
		{
			try
			{
                Account = TokenHandler.Check();
				SetupLogin(false);
                PopulateFields();
            }
			catch (Exception)
			{
				SetupLogin(true);
			}
            accountIdResult.KeyPress += accountIdResult_KeyPress;
            accountIdResultBase64.KeyPress += accountIdResult_KeyPress;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var account = Auth.CreateLogin(this.checkBoxBrowserEngine.Checked);

            if (account == null) return;

            this.Account = account;
            TokenHandler.Write(account.Client.Tokens);

            SetupLogin(false);
            PopulateFields();
        }

        private void buttonQueryAccountId_Click(object sender, EventArgs e)
        {
            string userName = userNameTxtBox.Text;
            if (userName != string.Empty)
            {
                try
                {
                    errorLabel.Visible = false;
                    errorLabel2.Visible = false;
                    User user = Account.FindUser(userName);
                    Profile profile = user.GetInfo(userName);
                    ProfileModel profileModel = profile.Information;
                    accountIdResult.Text = profileModel.AccountId;

                    long value = Convert.ToInt64(profileModel.AccountId);
                    byte[] accountIdBuffer = ByteUtil.ToLittleEndian(value);
                    accountIdResultBase64.Text = Convert.ToBase64String(accountIdBuffer);
                }
                catch (Exception)
                {
                    accountIdResult.Text = string.Empty;
                    accountIdResultBase64.Text = string.Empty;
                    errorLabel.Visible = true;
                    errorLabel2.Visible = true;
                }
            }
        }

        private readonly Timer _ps4WakeupTimer = new Timer();

        private void wakeUpPS4_Click(object sender, EventArgs e)
        {
            if (Account != null)
            {
                try
                {
                    _ps4WakeupTimer.Interval = 30_000;
                    _ps4WakeupTimer.Tick += timer_Tick_PS4;
                    _ps4WakeupTimer.Start();
                    wakeUp.Enabled = false;
                    Account?.WakeUpPs4Console(Account.OnlineId);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        void timer_Tick_PS4(object sender, EventArgs e)
        {
            wakeUp.Enabled = true;
            _ps4WakeupTimer.Stop();
        }

        private readonly Timer _ps5WakeupTimer = new Timer();

        private void wakeUpPS5_Click(object sender, EventArgs e)
        {
            if (Account != null)
            {
                try
                {
                    _ps5WakeupTimer.Interval = 30_000;
                    _ps5WakeupTimer.Tick += timer_Tick_PS5;
                    _ps5WakeupTimer.Start();
                    wakeUpPS5.Enabled = false;
                    Account?.WakeUpPs5Console(Account.OnlineId, Account.AccountId);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        void timer_Tick_PS5(object sender, System.EventArgs e)
        {
            wakeUpPS5.Enabled = true;
            _ps4WakeupTimer.Stop();
        }

        private void accountIdResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void checkBoxExperimental_CheckedChanged(object sender, EventArgs e)
        {
            wakeUp.Visible = checkBoxExperimental.Checked;
            wakeUpPS5.Visible = checkBoxExperimental.Checked;
        }
    }
}
