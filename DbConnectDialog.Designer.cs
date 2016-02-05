namespace KIPS_Common_o
{
    partial class DbConnectDialog
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.aConnectButton = new System.Windows.Forms.Button();
            this.aCancelButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.aDsnLabel = new System.Windows.Forms.Label();
            this.aPwdLabel = new System.Windows.Forms.Label();
            this.aUidLabel = new System.Windows.Forms.Label();
            this.aDsnTextBox = new System.Windows.Forms.TextBox();
            this.aPwdTextBox = new System.Windows.Forms.TextBox();
            this.aUidTextBox = new System.Windows.Forms.TextBox();
            this.aRetTextBox = new System.Windows.Forms.TextBox();
            this.aInfoTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // aConnectButton
            // 
            this.aConnectButton.Location = new System.Drawing.Point(52, 217);
            this.aConnectButton.Name = "aConnectButton";
            this.aConnectButton.Size = new System.Drawing.Size(75, 23);
            this.aConnectButton.TabIndex = 0;
            this.aConnectButton.Text = "接続";
            this.aConnectButton.UseVisualStyleBackColor = true;
            this.aConnectButton.Click += new System.EventHandler(this.aConnectButton_Click);
            // 
            // aCancelButton
            // 
            this.aCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.aCancelButton.Location = new System.Drawing.Point(161, 217);
            this.aCancelButton.Name = "aCancelButton";
            this.aCancelButton.Size = new System.Drawing.Size(75, 23);
            this.aCancelButton.TabIndex = 1;
            this.aCancelButton.Text = "キャンセル";
            this.aCancelButton.UseVisualStyleBackColor = true;
            this.aCancelButton.Click += new System.EventHandler(this.aCancelButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.aDsnLabel);
            this.panel1.Controls.Add(this.aPwdLabel);
            this.panel1.Controls.Add(this.aUidLabel);
            this.panel1.Controls.Add(this.aDsnTextBox);
            this.panel1.Controls.Add(this.aPwdTextBox);
            this.panel1.Controls.Add(this.aUidTextBox);
            this.panel1.Location = new System.Drawing.Point(13, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 120);
            this.panel1.TabIndex = 2;
            // 
            // aDsnLabel
            // 
            this.aDsnLabel.AutoSize = true;
            this.aDsnLabel.Location = new System.Drawing.Point(33, 89);
            this.aDsnLabel.Name = "aDsnLabel";
            this.aDsnLabel.Size = new System.Drawing.Size(80, 12);
            this.aDsnLabel.TabIndex = 6;
            this.aDsnLabel.Text = "データベース名：";
            // 
            // aPwdLabel
            // 
            this.aPwdLabel.AutoSize = true;
            this.aPwdLabel.Location = new System.Drawing.Point(33, 54);
            this.aPwdLabel.Name = "aPwdLabel";
            this.aPwdLabel.Size = new System.Drawing.Size(58, 12);
            this.aPwdLabel.TabIndex = 5;
            this.aPwdLabel.Text = "パスワード：";
            // 
            // aUidLabel
            // 
            this.aUidLabel.AutoSize = true;
            this.aUidLabel.Location = new System.Drawing.Point(33, 17);
            this.aUidLabel.Name = "aUidLabel";
            this.aUidLabel.Size = new System.Drawing.Size(53, 12);
            this.aUidLabel.TabIndex = 3;
            this.aUidLabel.Text = "ユーザ名：";
            // 
            // aDsnTextBox
            // 
            this.aDsnTextBox.Location = new System.Drawing.Point(115, 86);
            this.aDsnTextBox.Name = "aDsnTextBox";
            this.aDsnTextBox.Size = new System.Drawing.Size(122, 19);
            this.aDsnTextBox.TabIndex = 2;
            this.aDsnTextBox.TextChanged += new System.EventHandler(this.aDsnTextBox_TextChanged);
            // 
            // aPwdTextBox
            // 
            this.aPwdTextBox.Location = new System.Drawing.Point(115, 51);
            this.aPwdTextBox.Name = "aPwdTextBox";
            this.aPwdTextBox.PasswordChar = '*';
            this.aPwdTextBox.Size = new System.Drawing.Size(122, 19);
            this.aPwdTextBox.TabIndex = 1;
            this.aPwdTextBox.TextChanged += new System.EventHandler(this.aPwdTextBox_TextChanged);
            // 
            // aUidTextBox
            // 
            this.aUidTextBox.Location = new System.Drawing.Point(116, 17);
            this.aUidTextBox.Name = "aUidTextBox";
            this.aUidTextBox.Size = new System.Drawing.Size(121, 19);
            this.aUidTextBox.TabIndex = 0;
            this.aUidTextBox.TextChanged += new System.EventHandler(this.aUidTextBox_TextChanged);
            // 
            // aRetTextBox
            // 
            this.aRetTextBox.Location = new System.Drawing.Point(242, 221);
            this.aRetTextBox.Name = "aRetTextBox";
            this.aRetTextBox.Size = new System.Drawing.Size(47, 19);
            this.aRetTextBox.TabIndex = 4;
            this.aRetTextBox.Visible = false;
            // 
            // aInfoTextBox
            // 
            this.aInfoTextBox.Location = new System.Drawing.Point(13, 13);
            this.aInfoTextBox.Multiline = true;
            this.aInfoTextBox.Name = "aInfoTextBox";
            this.aInfoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.aInfoTextBox.Size = new System.Drawing.Size(267, 72);
            this.aInfoTextBox.TabIndex = 5;
            this.aInfoTextBox.WordWrap = false;
            // 
            // DbConnectForm
            // 
            this.AcceptButton = this.aConnectButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.aCancelButton;
            this.ClientSize = new System.Drawing.Size(292, 248);
            this.ControlBox = false;
            this.Controls.Add(this.aInfoTextBox);
            this.Controls.Add(this.aRetTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.aCancelButton);
            this.Controls.Add(this.aConnectButton);
            this.Name = "DbConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "データベース接続";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DbConnectForm_FormClosing);
            this.Load += new System.EventHandler(this.DbConnectForm_Load);
            this.Shown += new System.EventHandler(this.DbConnectForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aConnectButton;
        private System.Windows.Forms.Button aCancelButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox aDsnTextBox;
        private System.Windows.Forms.TextBox aPwdTextBox;
        private System.Windows.Forms.TextBox aUidTextBox;
        private System.Windows.Forms.Label aDsnLabel;
        private System.Windows.Forms.Label aPwdLabel;
        private System.Windows.Forms.Label aUidLabel;
        protected System.Windows.Forms.TextBox aRetTextBox;
        private System.Windows.Forms.TextBox aInfoTextBox;
    }
}