namespace KIPS_Common_o
{
    public class Ginit
    {
        public bool State { get; protected set; }
         //public static string Dsn { get; } //''  データソース名
        //public static string Uid { get; }//''  ユーザID
        //public static string Pwd { get; }//''  パスワード

        //public static string Dsn2 { get; }//''  データソース名
        //public static string Uid2 { get; }//''  ユーザID
        //public static string Pwd2 { get; }//''  パスワード
        
        protected IniFile aIniFile;
        protected DbConnectDialog aDbForm;
        protected OracleOdp aOraFunc;


        public Ginit()
        {
            aOraFunc = new OracleOdp();


            aDbForm = new DbConnectDialog();
            aDbForm.ShowDialog();
            if (aDbForm.RetStr == "")
            {
                State = true;
            }
            else
            {
                State = false;
            }
        }

        ~Ginit()
        {
            //aDbForm.Close();
            //aOraFunc.DbClose();
        }

       

    }
}
