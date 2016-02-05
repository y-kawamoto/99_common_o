namespace KIPS_Common_o

{
    public class DbAccess
    {

        /// <summary>
        /// VBでのCS_ポストフィックス定数
        /// </summary>
        public const int SHORT_STR = 1;       // 短縮形
        public const int LONG_STR = 0;        // 通常文字列

        public const string NORMAL_LOG = "0";    // 通常操作
        public const string ERROR_LOG = "1";     // ｴﾗｰﾒｯｾｰｼﾞ

        public const int PROCESS = 1;         // 工程管理(実績)
        public const int P_ACCEPT = 2;        // 受入(製品)
        public const int Z_ACCEPT = 3;        // 受入(材料)

        public const int ORDER_TOUROKU = 0;   // 製品・部品在庫月次登録
        public const int ORDER_SYUKA = 1;     // 出荷

        public const string NYUKO_KBN = "1";     // 入庫区分
        public const string SYUKO_KBN = "2";     // 出庫区分

        public const string IN_CHECK_ERR = @"'(ｼﾝｸﾞﾙｸｫｰﾄ)又は、""(ﾀﾞﾌﾞﾙｸｫｰﾄ)は、入力できません。";

        /// <summary>
        /// 指示区分(文字列)を取得する
        /// </summary>
        /// <param name="dspSw">0:正式文字列、1:短縮文字列</param>
        /// <param name="sijiKbn">ＤＢの生指示区分文字列</param>
        /// <returns></returns>
        static public string GetSijiKbn(int dspSw, string sijiKbn)
        {
            string retSijiKbn = string.Empty;

            switch(dspSw)
            {
            case 0:
                switch(sijiKbn)
                {
                case "A":
                    retSijiKbn = "自動計画(月次計画)";
                    break;
                case "M":
                    retSijiKbn = "マニュアル手配";
                    break;
                default:
                    retSijiKbn = "";
                    break;
                }
                break;
           default:
                switch(sijiKbn)
                {
                case "A":
                    retSijiKbn = "月次";
                    break;
                case "M":
                    retSijiKbn = "マニュアル";
                    break;
                default:
                    retSijiKbn = "";
                    break;
                }
                break;
            }
            return retSijiKbn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dspSw"></param>
        /// <param name="seihinKbn"></param>
        /// <returns></returns>
        static public string GetSeihinKbn(int dspSw, string seihinKbn)
        {
            string retSeihinKbn = string.Empty;

            switch (dspSw)
            {
            case 0:
                switch (seihinKbn)
                {
                case "1":
                    retSeihinKbn = "製品";
                    break;
                default:
                    retSeihinKbn = "部品";
                    break;
                }
                break;
            default:
                switch (seihinKbn)
                {
                case "1":
                    retSeihinKbn = "製品";
                    break;
                default:
                    retSeihinKbn = "部品";
                    break;
                }
                break;
            }
            return retSeihinKbn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dspSw"></param>
        /// <param name="seihinKbn"></param>
        /// <returns></returns>
        static public string GetPreqFlg(int dspSw, string preqFlg)
        {
            string retPreqFlg = string.Empty;

            switch (dspSw)
            {
                case 0:
                    switch (preqFlg)
                    {
                        case "1":
                            retPreqFlg = "済";
                            break;
                        default:
                            retPreqFlg = "";
                            break;
                    }
                    break;
                default:
                    switch (preqFlg)
                    {
                        case "1":
                            retPreqFlg = "済";
                            break;
                        default:
                            retPreqFlg = "";
                            break;
                    }
                    break;
            }
            return retPreqFlg;
        }


        /// <summary>
        /// 部品種別(文字列)を取得する
        /// </summary>
        /// <param name="dspSw">取得文字列(0:正式文字列、1:短縮文字列)</param>
        /// <param name="buhinSyu">部品種別</param>
        /// <returns>取得した値</returns>
        static public string GetBuhinSyu(int dspSw, string buhinSyu)
        {
                        string retBuhinSyu = string.Empty;

            switch (dspSw) {
                
            case 0:
                switch (buhinSyu)
                {
                case "A":
                    retBuhinSyu = "組立";
                    break;
                case "P":
                    retBuhinSyu = "プレス";
                    break;
                case "S":
                    retBuhinSyu = "STD/NES";
                    break;
                case "J":
                    retBuhinSyu = "受給品";
                    break;
                case "9":
                    retBuhinSyu = "その他";
                    break;
                default:
                    retBuhinSyu = "";
                    break;
                }
                break;
            default:
                switch (buhinSyu)
                {
                case "A":
                    retBuhinSyu = "組立";
                    break;
                case "P":
                    retBuhinSyu = "プレス";
                    break;
                case "S":
                    retBuhinSyu = "STD/NES";
                    break;
                case "J":
                    retBuhinSyu = "受給品";
                    break;
                case "9":
                    retBuhinSyu = "その他";
                    break;
                default:
                    retBuhinSyu = "";
                    break;
                }
                break;
            }        
            return retBuhinSyu;
        }

    }
}
