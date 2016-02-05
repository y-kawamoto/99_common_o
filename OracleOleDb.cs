using System.Data.OleDb;

namespace KIPS_Common_o
{
    public class OracleOleDb
    {
        static public bool ValidFlag
        {
            get;
            protected set;
        }
        //public abstract int ORADYN_READONLY { get;}
        //public abstract int ORADYN_NOCACHE { get; }
        static public string Dsn
        {
            get;
            protected set;
        }
        static public  string Uid
        {
            get;
            protected set;
        }
        static public string Pwd
        {
            get;
            protected set;
        }


        static public OleDbConnection Cnn
        {
            get;
            protected set;
        }

        public OracleOleDb()
        {
            ValidFlag = false;
            //MessageBox.Show("OraFunc");
        }

        ~OracleOleDb()
        {
            //MessageBox.Show("~OraFunc");
            //this.DbClose();
        }



        //'*******************************************************************
        //'*  プロシジャ名　：OracleDbOpen
        //'*  機能概要　　　：ORACLE Database の接続
        //'*  引数　　　　　：なし
        //'*  戻り値　　　　：終了状態(True/False)
        //'*******************************************************************
        static public string DbOpen(string dsn, string uid, string pwd)
        {
            string retStr;
            //string cnnStr = "Provider=MSDAORA.1;Password=%PWD%;User ID=%UID%;Data Source=%DSN%;";
            
            string cnnStr = "Provider=OraOLEDB.Oracle.1;Password=%PWD%;Persist Security Info=True;User ID=%UID%;Data Source=%DSN%";
            cnnStr = cnnStr.Replace("%DSN%", dsn);
            cnnStr = cnnStr.Replace("%UID%", uid);
            cnnStr = cnnStr.Replace("%PWD%", pwd);

            retStr = "";

            try
            {
                Dsn = dsn;
                Uid = uid;
                Pwd = pwd;

                //MessageBox.Show("try");
                Cnn = new OleDbConnection(cnnStr);
                Cnn.Open();

                ValidFlag = true;

            }
            catch (OleDbException exp)
            {
                //MessageBox.Show("Catch!");
                string msg = "";
                for (int i = 0; i < exp.Errors.Count; i++)
                {
                    msg += "ERR" + i + ":" + exp.Errors[i].Message + "\r\n";
                }
                System.Console.WriteLine(msg);
                retStr = msg;
            }

            finally
            {
                //MessageBox.Show("Finaly![" + retStr + "]");

                //if (Cnn.State != ConnectionState.Closed)
                if (retStr != "")   //Openに失敗したら
                {
                    Cnn.Close();
                    Cnn.Dispose();
                    ValidFlag = false;
                }
            }
            return retStr;
        }



        //'*******************************************************************
        //'*  プロシジャ名　：OracleDbClose
        //'*  機能概要　　　：ORACLE Database の切断
        //'*  引数　　　　　：なし
        //'*  戻り値　　　　：終了状態(True/False)
        //'*******************************************************************
        static public void DbClose()
        {
            //MessageBox.Show("DbClose");
            Cnn.Close();
            Cnn.Dispose();
            ValidFlag = false;
        }
    }
}
