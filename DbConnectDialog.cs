using System;
using System.IO;
using System.Windows.Forms;

namespace KIPS_Common_o
{
    public partial class DbConnectDialog : Form
    {
        static IniFile aIniFile;
        static protected string aDsn;
        static protected string aUid;
        static protected string aPwd;

        //static protected OracleOdbc O_;



        public DbConnectDialog()
        {
            InitializeComponent();
        }

        //public DialogResult ShowForm(OracleOdbc o_)
        public DialogResult ShowForm()
        {
            //O_ = o_;

            this.ShowDialog();

            //this.Close();

            return this.DialogResult;
        }

        protected string Dsn {
            get { return aDsn; }
            set { aDsn = value; aDsnTextBox.Text = value; }

        }

        protected string Pwd
        {
            get { return aPwd; }
            set { aPwd = value; aPwdTextBox.Text = value; }

        }

        protected string Uid
        {
            get { return aUid; }
            set { aUid = value; aUidTextBox.Text = value; }

        }


        public string RetStr
        {
            get { return this.aRetTextBox.Text;}
            set { aRetTextBox.Text = value; }
        }


        private void aCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aConnectButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DbConnectForm_Load(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            string filePath = curDir + "\\hips.ini";
            aIniFile = new IniFile(filePath);

            Dsn = aIniFile.ReadString("DataBase", "DSN", "").Trim();
            Uid = aIniFile.ReadString("DataBase", "UID", "").Trim();
            Pwd = aIniFile.ReadString("DataBase", "PWD", "").Trim();

        }

        private void DbConnectForm_Shown(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();   //一回目は自動でコネクトを試みる
        }

        private bool DbOpen()
        {
            bool rinf = false;
            string retStr;

            aInfoTextBox.Text = "データベース接続中です\n\rしばらくお待ちください";

            Application.DoEvents();

            retStr = OracleOdp.DbOpen(Dsn, Uid, Pwd);

            if (retStr == "")
            {
                RetStr = "";
                rinf = true;
            }
            else
            {
                MessageBox.Show(retStr);
                aInfoTextBox.Text = retStr;
                aRetTextBox.Text = "Error";
            }
            //MessageBox.Show(retStr);
            return rinf;
        }


        private void DbConnectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                bool rinf;

                rinf = this.DbOpen();// OKならINIファイルを更新して抜ける

                if (rinf != true)
                {
                    //NGだからダイアログを閉じない
                    e.Cancel = true;
                }
                else
                {
                    //OKだからINIファイル更新
                    aIniFile.WriteString("DataBase", "DSN", Dsn.Trim());
                    aIniFile.WriteString("DataBase", "UID", Uid.Trim());
                    aIniFile.WriteString("DataBase", "PWD", Pwd.Trim());
                }
            }

        }

        private void aUidTextBox_TextChanged(object sender, EventArgs e)
        {
            Uid = aUidTextBox.Text.Trim();
        }

        private void aPwdTextBox_TextChanged(object sender, EventArgs e)
        {
            Pwd = aPwdTextBox.Text.Trim();

        }

        private void aDsnTextBox_TextChanged(object sender, EventArgs e)
        {
            Dsn = aDsnTextBox.Text.Trim();
        }

    }
}
