using Oracle.DataAccess.Client;
using System.Windows.Forms;
//using System.Data.Odbc;
//using System.Data.OleDb;

namespace KIPS_Common_o
{
    public class Gval
    {
        public Gval()
        {
            Init();
        }

        //public  static OraFunc O_;
        public const bool TarceFlag = false;
        public const bool IsDebug = false;


        public const bool IsColorMode1 = true;              // カラー表示モード１フラグ  ( True:ON / False:OFF )
        public const string GcPlanTraceFn = "PLAN_LOG.TXT";  // 計画ログファイル

        public const string DelChar = "打切";

        //------------------------------------------------------------------------
        // グローバル（パブリック）変数定義
        //------------------------------------------------------------------------
        // システム共通変数
        // 印刷用変数
        public string PrintHinCd
        {
            get;
            set;
        }

        static public string ComputerName
        {
            get { return System.Net.Dns.GetHostName().ToUpper().Trim(); }
        }

        static public string Logo
        {
            get { return "HIPS"; }
        }

        static public string CompanyName   //コンピュータ名
        {
            get;
            protected set;
        }

        static public string SystemName       // 生産管理システム名称
        {
            get;
            protected set;
        }

        static public string SubSysName       // サブシステム（業務）名
        {
            get;
            set;
        }

        static public string DataOutDir      // 各種データ出力ディレクトリ
        {
            get;
            protected set;
        }

        static public string SvClientAplDir  // サーバ上の端末アプリ格納場所
        {
            get;
            protected set;
        }

        static public int PRODUCT_GOBACK_DAY // 製品日別展開遡り日数
        {
            get;
            protected set;
        }

        static public int PARTS_GOBACK_DAY   // 部品・材料日別展開遡り日数
        {
            get;
            protected set;
        }
        static public int ZAIRYO_LEAD_TM     // 材料調達リードタイム（日）
        {
            get;
            protected set;
        }

        public int Init()
        {
            //O_ = oraFunc;

            //DataOutDir = App.Path + "\data"        // データ出力用のディレクトリ

    
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //@ システムテーブルから取得する、項目の設定
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            string sqlStr;


            try
            {

                OracleCommand cmd;
                OracleDataReader reader;

                cmd = new OracleCommand();
                cmd.Connection = OracleOdp.Cnn;

	            sqlStr = "select * from M_SYSTEM_INFO";

                cmd.CommandText = sqlStr;
                //MessageBox.Show("Connected");

                reader = cmd.ExecuteReader();

                cmd.Dispose();

                //このＤＢは１レコード
                if (reader.Read() == false)
                {
	                MessageBox.Show("ＤＢ：" + OracleOdbc.Dsn + "ユーザ：" + OracleOdbc.Uid + "よりシステム情報を取得できませんでした。");
	                reader.Close();
	                reader.Dispose();

	                return -1;


                }

	            CompanyName = reader["company_nam1"].ToString();	//会社名称
	            SystemName = reader["system_nam"].ToString();          // システム名称（日本語）
	            PRODUCT_GOBACK_DAY = int.Parse(reader["product_goback_day"].ToString());                       // 製品日別展開遡り日
	            PARTS_GOBACK_DAY = int.Parse(reader["parts_goback_day"].ToString());                             // 部品日別展開遡り日
	            ZAIRYO_LEAD_TM = int.Parse(reader["zairyo_lead_tm"].ToString());                                // 材料リードタイム（日）

                reader.Close();
                reader.Dispose();
            }

            catch (OracleException exp)
            {
                //MessageBox.Show("Catch!");
                string msg = "";
                for (int i = 0; i < exp.Errors.Count; i++)
                {
                    msg += "ERR" + i + ":" + exp.Errors[i].Message + "\r\n";
                }
                System.Console.WriteLine(msg);
                MessageBox.Show(msg);

                return -1;
            }

            // システム情報テーブルより、システム情報を取得
                                         // 材料リードタイム（日）
    
            // サーバ上の最新端末モジュールの格納場所 ＠＠＠現在ダミー
            SvClientAplDir = "\\\\htsv\\HIPS\\CLI_APL";
    
            if (CompanyName == "")
            {
                MessageBox.Show("システム情報の会社名が不正です。" + "\r\n" + "（ＤＢ：" + OracleOdbc.Dsn + "ユーザ：" + OracleOdbc.Uid + "）");
                CompanyName = "会社名：不明";
            }
        
            if ( SystemName == "" )
            {
                MessageBox.Show("システム情報のシステム名が不正です。" + "\r\n" + "（ＤＢ：" + OracleOdbc.Dsn + "ユーザ：" + OracleOdbc.Uid + "）");
                SystemName = "システム名：不明";
            }
    
            if ( PRODUCT_GOBACK_DAY < 1 ||  PRODUCT_GOBACK_DAY > 5 )
            {
                MessageBox.Show("システム情報の製品指示遡り日が不正です。(" + PRODUCT_GOBACK_DAY + ")" + "\r\n" +
                            "（ＤＢ：" + OracleOdbc.Dsn + "ユーザ：" + OracleOdbc.Uid + "）" + "\r\n" +
                            "製品指示遡り日を強制的に３日に設定します。");
                PRODUCT_GOBACK_DAY = 3;
            }
    
    
            if ( PARTS_GOBACK_DAY < 1 ||  PARTS_GOBACK_DAY > 5 )
            {
                MessageBox.Show("システム情報の部品指示最大遡り日が不正です。(" + PARTS_GOBACK_DAY + ")" + "\r\n" +
                            "（ＤＢ：" + OracleOdbc.Dsn + "ユーザ：" + OracleOdbc.Uid + "）" + "\r\n" +
                            "部品指示最大遡り日を強制的に５日に設定します。");
                PARTS_GOBACK_DAY = 5;
            }
   
            if ( ZAIRYO_LEAD_TM < 1 ||  ZAIRYO_LEAD_TM > 3 )
            {
                MessageBox.Show("システム情報の材料指示最大遡り日が不正です。(" + ZAIRYO_LEAD_TM + ")" + "\r\n" +
                            "（ＤＢ：" + OracleOdbc.Dsn + "ユーザ：" + OracleOdbc.Uid + "）" + "\r\n" +
                            "材料指示最大遡り日を強制的に２日に設定します。");
                ZAIRYO_LEAD_TM = 2;
            }
            ZAIRYO_LEAD_TM = 7;     // 材料指示最大遡り日を強制的に７日に設定        2005/04 Ver 2.1
    
            return 0;

        }



    }
}
