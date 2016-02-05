using System.Data.Odbc;

namespace KIPS_Common_o
{
    public class OracleOdbc
    {
        //public abstract int ORADYN_READONLY { get;}
        //public abstract int ORADYN_NOCACHE { get; }
        public static string Dsn
        {
            get;
            protected set;
        }
        public static string Uid
        {
            get;
            protected set;
        }
        public static string Pwd
        {
            get;
            protected set;
        }


        public static OdbcConnection Cnn { get; protected set; }

        public OracleOdbc()
        {
            //MessageBox.Show("OraFunc");
        }

        ~OracleOdbc()
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
            string cnnStr = "Driver={Microsoft ODBC for Oracle};Server=%DSN%; UID=%UID%; PWD=%PWD%;";

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
                Cnn = new OdbcConnection(cnnStr);
                Cnn.Open();

            }
            catch (OdbcException exp)
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
        public void DbClose()
        {
            //MessageBox.Show("DbClose");

            Cnn.Close();
            Cnn.Dispose();
        }
    }
}
