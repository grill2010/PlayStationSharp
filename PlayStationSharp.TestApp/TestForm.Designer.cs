namespace PlayStationSharp.TestApp
{
	partial class TestForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblOnlineId = new System.Windows.Forms.Label();
            this.colorBackgroundColor = new System.Windows.Forms.ColorDialog();
            this.queryAccountGrpBox = new System.Windows.Forms.GroupBox();
            this.wakeUpPS5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.accountIdResultBase64 = new System.Windows.Forms.TextBox();
            this.wakeUp = new System.Windows.Forms.Button();
            this.errorLabel2 = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.accountIdResult = new System.Windows.Forms.TextBox();
            this.buttonQueryAccountId = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.userNameTxtBox = new System.Windows.Forms.TextBox();
            this.checkBoxBrowserEngine = new System.Windows.Forms.CheckBox();
            this.wakeUpGrpBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxExperimental = new System.Windows.Forms.CheckBox();
            this.queryAccountGrpBox.SuspendLayout();
            this.wakeUpGrpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(191, 163);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(130, 37);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "PSN Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblOnlineId
            // 
            this.lblOnlineId.AutoSize = true;
            this.lblOnlineId.Location = new System.Drawing.Point(12, 9);
            this.lblOnlineId.Name = "lblOnlineId";
            this.lblOnlineId.Size = new System.Drawing.Size(58, 13);
            this.lblOnlineId.TabIndex = 1;
            this.lblOnlineId.Text = "User name";
            this.lblOnlineId.Visible = false;
            // 
            // queryAccountGrpBox
            // 
            this.queryAccountGrpBox.Controls.Add(this.label3);
            this.queryAccountGrpBox.Controls.Add(this.label2);
            this.queryAccountGrpBox.Controls.Add(this.accountIdResultBase64);
            this.queryAccountGrpBox.Controls.Add(this.errorLabel2);
            this.queryAccountGrpBox.Controls.Add(this.errorLabel);
            this.queryAccountGrpBox.Controls.Add(this.accountIdResult);
            this.queryAccountGrpBox.Controls.Add(this.buttonQueryAccountId);
            this.queryAccountGrpBox.Controls.Add(this.label1);
            this.queryAccountGrpBox.Controls.Add(this.userNameTxtBox);
            this.queryAccountGrpBox.Location = new System.Drawing.Point(15, 39);
            this.queryAccountGrpBox.Name = "queryAccountGrpBox";
            this.queryAccountGrpBox.Size = new System.Drawing.Size(487, 255);
            this.queryAccountGrpBox.TabIndex = 2;
            this.queryAccountGrpBox.TabStop = false;
            this.queryAccountGrpBox.Text = "Query Account-Id";
            // 
            // wakeUpPS5
            // 
            this.wakeUpPS5.Location = new System.Drawing.Point(337, 44);
            this.wakeUpPS5.Name = "wakeUpPS5";
            this.wakeUpPS5.Size = new System.Drawing.Size(141, 36);
            this.wakeUpPS5.TabIndex = 10;
            this.wakeUpPS5.Text = "Wake Up My Own PS5";
            this.wakeUpPS5.UseVisualStyleBackColor = true;
            this.wakeUpPS5.Visible = false;
            this.wakeUpPS5.Click += new System.EventHandler(this.wakeUpPS5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Account-Id Base64 (Chiaki):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Account-Id (PSPlay):";
            // 
            // accountIdResultBase64
            // 
            this.accountIdResultBase64.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.accountIdResultBase64.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountIdResultBase64.ForeColor = System.Drawing.Color.Green;
            this.accountIdResultBase64.Location = new System.Drawing.Point(131, 138);
            this.accountIdResultBase64.Name = "accountIdResultBase64";
            this.accountIdResultBase64.Size = new System.Drawing.Size(218, 16);
            this.accountIdResultBase64.TabIndex = 7;
            this.accountIdResultBase64.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // wakeUp
            // 
            this.wakeUp.Location = new System.Drawing.Point(6, 44);
            this.wakeUp.Name = "wakeUp";
            this.wakeUp.Size = new System.Drawing.Size(141, 36);
            this.wakeUp.TabIndex = 6;
            this.wakeUp.Text = "Wake Up My Own PS4";
            this.wakeUp.UseVisualStyleBackColor = true;
            this.wakeUp.Visible = false;
            this.wakeUp.Click += new System.EventHandler(this.wakeUpPS4_Click);
            // 
            // errorLabel2
            // 
            this.errorLabel2.AutoSize = true;
            this.errorLabel2.ForeColor = System.Drawing.Color.Red;
            this.errorLabel2.Location = new System.Drawing.Point(153, 180);
            this.errorLabel2.Name = "errorLabel2";
            this.errorLabel2.Size = new System.Drawing.Size(171, 13);
            this.errorLabel2.TabIndex = 5;
            this.errorLabel2.Text = "Be sure the PSN-User-Name exists";
            this.errorLabel2.Visible = false;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(190, 163);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(89, 13);
            this.errorLabel.TabIndex = 4;
            this.errorLabel.Text = "An error occurred";
            this.errorLabel.Visible = false;
            // 
            // accountIdResult
            // 
            this.accountIdResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.accountIdResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountIdResult.ForeColor = System.Drawing.Color.Green;
            this.accountIdResult.Location = new System.Drawing.Point(131, 102);
            this.accountIdResult.Name = "accountIdResult";
            this.accountIdResult.Size = new System.Drawing.Size(218, 16);
            this.accountIdResult.TabIndex = 3;
            this.accountIdResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonQueryAccountId
            // 
            this.buttonQueryAccountId.Location = new System.Drawing.Point(129, 207);
            this.buttonQueryAccountId.Name = "buttonQueryAccountId";
            this.buttonQueryAccountId.Size = new System.Drawing.Size(219, 36);
            this.buttonQueryAccountId.TabIndex = 2;
            this.buttonQueryAccountId.Text = "Query Account-ID";
            this.buttonQueryAccountId.UseVisualStyleBackColor = true;
            this.buttonQueryAccountId.Click += new System.EventHandler(this.buttonQueryAccountId_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter the PSN-User-Name:";
            // 
            // userNameTxtBox
            // 
            this.userNameTxtBox.Location = new System.Drawing.Point(131, 39);
            this.userNameTxtBox.Name = "userNameTxtBox";
            this.userNameTxtBox.Size = new System.Drawing.Size(217, 20);
            this.userNameTxtBox.TabIndex = 0;
            // 
            // checkBoxBrowserEngine
            // 
            this.checkBoxBrowserEngine.AutoSize = true;
            this.checkBoxBrowserEngine.Location = new System.Drawing.Point(164, 238);
            this.checkBoxBrowserEngine.Name = "checkBoxBrowserEngine";
            this.checkBoxBrowserEngine.Size = new System.Drawing.Size(182, 17);
            this.checkBoxBrowserEngine.TabIndex = 3;
            this.checkBoxBrowserEngine.Text = "Use Windows 10 browser engine";
            this.checkBoxBrowserEngine.UseVisualStyleBackColor = true;
            // 
            // wakeUpGrpBox
            // 
            this.wakeUpGrpBox.Controls.Add(this.checkBoxExperimental);
            this.wakeUpGrpBox.Controls.Add(this.wakeUpPS5);
            this.wakeUpGrpBox.Controls.Add(this.wakeUp);
            this.wakeUpGrpBox.Location = new System.Drawing.Point(15, 300);
            this.wakeUpGrpBox.Name = "wakeUpGrpBox";
            this.wakeUpGrpBox.Size = new System.Drawing.Size(484, 112);
            this.wakeUpGrpBox.TabIndex = 4;
            this.wakeUpGrpBox.TabStop = false;
            this.wakeUpGrpBox.Text = "Experimental PSN features";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Activate this if you have login problems";
            // 
            // checkBoxExperimental
            // 
            this.checkBoxExperimental.AutoSize = true;
            this.checkBoxExperimental.Location = new System.Drawing.Point(158, 55);
            this.checkBoxExperimental.Name = "checkBoxExperimental";
            this.checkBoxExperimental.Size = new System.Drawing.Size(168, 17);
            this.checkBoxExperimental.TabIndex = 11;
            this.checkBoxExperimental.Text = "Activate experimental features";
            this.checkBoxExperimental.UseVisualStyleBackColor = true;
            this.checkBoxExperimental.CheckedChanged += new System.EventHandler(this.checkBoxExperimental_CheckedChanged);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 420);
            this.Controls.Add(this.wakeUpGrpBox);
            this.Controls.Add(this.queryAccountGrpBox);
            this.Controls.Add(this.lblOnlineId);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.checkBoxBrowserEngine);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TestForm";
            this.Text = "PSN-Account Query";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.queryAccountGrpBox.ResumeLayout(false);
            this.queryAccountGrpBox.PerformLayout();
            this.wakeUpGrpBox.ResumeLayout(false);
            this.wakeUpGrpBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Label lblOnlineId;
		private System.Windows.Forms.ColorDialog colorBackgroundColor;
        private System.Windows.Forms.GroupBox queryAccountGrpBox;
        private System.Windows.Forms.Button buttonQueryAccountId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userNameTxtBox;
        private System.Windows.Forms.TextBox accountIdResult;
        private System.Windows.Forms.Label errorLabel2;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.CheckBox checkBoxBrowserEngine;
        private System.Windows.Forms.Button wakeUp;
        private System.Windows.Forms.TextBox accountIdResultBase64;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button wakeUpPS5;
        private System.Windows.Forms.GroupBox wakeUpGrpBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxExperimental;
    }
}

