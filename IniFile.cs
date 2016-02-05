/** IniFile 読み書き クラス */
using System.Collections.Specialized;
//using System.Windows.Forms;


namespace KIPS_Common_o
{

    #region　IniFile クラス

    /// ---------------------------------------------------------------------------------------
    /// <summary>
    ///     IniFile の読み込み、または書き込みを提供します。
    /// </summary>
    /// ---------------------------------------------------------------------------------------

    public sealed class IniFile
    {

        #region　メンバの定義

        // 定数の定義
        private const int MAX_LINE = 1024;
        private const string DOUBLE_QUOTE = "\"";

        #endregion


        #region　コンストラクタ (+3)

        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したファイル用の Jeanne.Ini.IniFile
        ///     クラスの新しいインスタンスを初期化します。</summary>
        /// <param name="filePath">
        ///     読み込まれる構成設定ファイルのパス。</param>
        /// ---------------------------------------------------------------------------------------
        public IniFile(string filePath)
            : this(filePath, System.Text.Encoding.Default)
        {

        }


        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したファイル用の Jeanne.Ini.IniFile
        ///     クラスの新しいインスタンスを、エンコーディングを指定して初期化します。</summary>
        /// <param name="filePath">
        ///     読み込まれる構成設定ファイルのパス。</param>
        /// <param name="encoding">
        ///     読み込みに使用する文字エンコーディング。</param>
        /// ---------------------------------------------------------------------------------------
        public IniFile(string filePath, System.Text.Encoding encoding)
            : this(filePath, null, encoding)
        {

        }


        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したファイル用の Jeanne.Ini.IniFile
        ///     クラスの新しいインスタンスを、初期値を指定して初期化します。</summary>
        /// <param name="filePath">
        ///     読み込まれる構成設定ファイルのパス。</param>
        /// <param name="defaultValue">
        ///     読み込みに失敗した場合に返される値。</param>
        /// ---------------------------------------------------------------------------------------
        public IniFile(string filePath, string defaultValue)
            : this(filePath, defaultValue, System.Text.Encoding.Default)
        {

        }


        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したファイル用の System.IO.IniFile
        ///     クラスの新しいインスタンスを、初期値とエンコーディング初期化します。</summary>
        /// <param name="filePath">
        ///     読み込まれる構成設定ファイルのパス。</param>
        /// <param name="defaultValue">
        ///     読み込みに失敗した場合に返される値。</param>
        /// <param name="encoding">
        ///     読み込みに使用する文字エンコーディング。</param>
        /// ---------------------------------------------------------------------------------------
        public IniFile(string filePath, string defaultValue, System.Text.Encoding encoding)
        {
            this.FilePath = filePath;
            this.Section = string.Empty;
            this.DefaultValue = defaultValue;
            this.Encoding = encoding;
        }

        #endregion


        // Public

        #region　ReadString メソッド (+2)

        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したセクションとキーの場所にある値を読み込みます。</summary>
        /// <param name="key">
        ///     読み込みに使用するキー。</param>
        /// <returns>
        ///     指定したセクションとキーに格納された値。失敗時は DefaultValue。</returns>
        /// ---------------------------------------------------------------------------------------
        public string ReadString(string key)
        {
            return ReadIniFileValue(this.FilePath, this.Section, key, this.DefaultValue, this.Encoding);
        }


        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したセクションとキーの場所にある値を読み込みます。</summary>
        /// <param name="section">
        ///     読み込みに使用するセクション。</param>
        /// <param name="key">
        ///     読み込みに使用するキー。</param>
        /// <returns>
        ///     指定したセクションとキーに格納された値。失敗時は DefaultValue。</returns>
        /// ---------------------------------------------------------------------------------------
        public string ReadString(string section, string key)
        {
            return ReadIniFileValue(this.FilePath, section, key, this.DefaultValue, this.Encoding);
        }


        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したセクションとキーの場所にある値を読み込みます。</summary>
        /// <param name="section">
        ///     読み込みに使用するセクション。</param>
        /// <param name="key">
        ///     読み込みに使用するキー。</param>
        /// <param name="defaultValue">
        ///     読み込みに失敗した場合に返される値。</param>
        /// <returns>
        ///     指定したセクションとキーに格納された値。失敗時は DefaultValue。</returns>
        /// ---------------------------------------------------------------------------------------
        public string ReadString(string section, string key, string defaultValue)
        {
            return ReadIniFileValue(this.FilePath, section, key, defaultValue, this.Encoding);
        }

        #endregion


        #region　ReadInteger メソッド (+2)

        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したセクションとキーの場所にある値を読み込みます。</summary>
        /// <param name="key">
        ///     読み込みに使用するキー。</param>
        /// <returns>
        ///     指定したセクションとキーに格納された値。失敗時は DefaultValue。</returns>
        /// ---------------------------------------------------------------------------------------
        public int ReadInteger(string key)
        {
            return ToInt32(ReadIniFileValue(this.FilePath, this.Section, key, this.DefaultValue, this.Encoding));
        }


        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したセクションとキーの場所にある値を読み込みます。</summary>
        /// <param name="section">
        ///     読み込みに使用するセクション。</param>
        /// <param name="key">
        ///     読み込みに使用するキー。</param>
        /// <returns>
        ///     指定したセクションとキーに格納された値。失敗時は DefaultValue。</returns>
        /// ---------------------------------------------------------------------------------------
        public int ReadInteger(string section, string key)
        {
            return ToInt32(ReadIniFileValue(this.FilePath, section, key, this.DefaultValue, this.Encoding));
        }


        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したセクションとキーの場所にある値を読み込みます。</summary>
        /// <param name="section">
        ///     読み込みに使用するセクション。</param>
        /// <param name="key">
        ///     読み込みに使用するキー。</param>
        /// <param name="defaultValue">
        ///     読み込みに失敗した場合に返される値。</param>
        /// <returns>
        ///     指定したセクションとキーに格納された値。失敗時は DefaultValue。</returns>
        /// ---------------------------------------------------------------------------------------
        public int ReadInteger(string section, string key, int defaultValue)
        {
            return ToInt32(ReadIniFileValue(this.FilePath, section, key, defaultValue.ToString(), this.Encoding));
        }

        #endregion


        #region　ReadDouble メソッド (+2)

        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したセクションとキーの場所にある値を読み込みます。</summary>
        /// <param name="key">
        ///     読み込みに使用するキー。</param>
        /// <returns>
        ///     指定したセクションとキーに格納された値。失敗時は Default に指定した値。</returns>
        /// ---------------------------------------------------------------------------------------
        public double ReadDouble(string key)
        {
            return ToDouble(ReadIniFileValue(this.FilePath, this.Section, key, this.DefaultValue, this.Encoding));
        }


        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したセクションとキーの場所にある値を読み込みます。</summary>
        /// <param name="section">
        ///     読み込みに使用するセクション。</param>
        /// <param name="key">
        ///     読み込みに使用するキー。</param>
        /// <returns>
        ///     指定したセクションとキーに格納された値。失敗時は Default に指定した値。</returns>
        /// ---------------------------------------------------------------------------------------
        public double ReadDouble(string section, string key)
        {
            return ToDouble(ReadIniFileValue(this.FilePath, section, key, this.DefaultValue, this.Encoding));
        }


        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したセクションとキーの場所にある値を読み込みます。</summary>
        /// <param name="section">
        ///     読み込みに使用するセクション。</param>
        /// <param name="key">
        ///     読み込みに使用するキー。</param>
        /// <param name="dDefault">
        ///     読み込みに失敗した場合に返される値。</param>
        /// <returns>
        ///     指定したセクションとキーに格納された値。失敗時は iDefault。</returns>
        /// ---------------------------------------------------------------------------------------
        public double ReadDouble(string section, string key, double dDefault)
        {
            return ToDouble(ReadIniFileValue(this.FilePath, section, key, dDefault.ToString(), this.Encoding));
        }

        #endregion


        #region　ReadSection メソッド (+1)

        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したセクションにあるキーと値をすべて読み込みます。</summary>
        /// <returns>
        ///     セクションの構造を表す IniSection オブジェクト。</returns>
        /// ---------------------------------------------------------------------------------------
        public IniSection ReadSection()
        {
            return ReadIniFileSection(this.FilePath, this.Section, this.Encoding);
        }


        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したセクションにあるキーと値をすべて読み込みます。</summary>
        /// <param name="section">
        ///     読み込みに使用するセクション。</param>
        /// <returns>
        ///     セクションの構造を表す IniSection オブジェクト。</returns>
        /// ---------------------------------------------------------------------------------------
        public IniSection ReadSection(string section)
        {
            return ReadIniFileSection(this.FilePath, section, this.Encoding);
        }

        #endregion


        #region　WriteString メソッド (+1)

        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したセクションとキーの場所に指定した値を書き込みます。</summary>
        /// <param name="key">
        ///     書き込みに使用するキー。</param>
        /// <param name="writeValue">
        ///     書き込みに使用する値。</param>
        /// ---------------------------------------------------------------------------------------
        public void WriteString(string key, string writeValue)
        {
            WriteIniFileValue(this.FilePath, this.Section, key, writeValue, this.Encoding);
        }


        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したセクションとキーの場所に指定した値を書き込みます。</summary>
        /// <param name="section">
        ///     書き込みに使用するセクション。</param>
        /// <param name="key">
        ///     書き込みに使用するキー。</param>
        /// <param name="writeValue">
        ///     書き込みに使用する値。</param>
        /// ---------------------------------------------------------------------------------------
        public void WriteString(string section, string key, string writeValue)
        {
            WriteIniFileValue(this.FilePath, section, key, writeValue, this.Encoding);
        }

        #endregion


        #region　WriteInteger メソッド (+1)

        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したセクションとキーの場所に指定した値を書き込みます。</summary>
        /// <param name="key">
        ///     書き込みに使用するキー。</param>
        /// <param name="writeValue">
        ///     書き込みに使用する値。</param>
        /// ---------------------------------------------------------------------------------------
        public void WriteInteger(string key, int writeValue)
        {
            WriteIniFileValue(this.FilePath, this.Section, key, writeValue.ToString(), this.Encoding);
        }


        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したセクションとキーの場所に指定した値を書き込みます。</summary>
        /// <param name="section">
        ///     書き込みに使用するセクション。</param>
        /// <param name="key">
        ///     書き込みに使用するキー。</param>
        /// <param name="writeValue">
        ///     書き込みに使用する値。</param>
        /// ---------------------------------------------------------------------------------------
        public void WriteInteger(string section, string key, int writeValue)
        {
            WriteIniFileValue(this.FilePath, section, key, writeValue.ToString(), this.Encoding);
        }

        #endregion


        #region　WriteDouble メソッド (+1)

        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したセクションとキーの場所に指定した値を書き込みます。</summary>
        /// <param name="key">
        ///     書き込みに使用するキー。</param>
        /// <param name="writeValue">
        ///     書き込みに使用する値。</param>
        /// ---------------------------------------------------------------------------------------
        public void WriteDouble(string key, double writeValue)
        {
            WriteIniFileValue(this.FilePath, this.Section, key, writeValue.ToString(), this.Encoding);
        }


        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したセクションとキーの場所に指定した値を書き込みます。</summary>
        /// <param name="section">
        ///     書き込みに使用するセクション。</param>
        /// <param name="key">
        ///     書き込みに使用するキー。</param>
        /// <param name="writeValue">
        ///     書き込みに使用する値。</param>
        /// ---------------------------------------------------------------------------------------
        public void WriteDouble(string section, string key, double writeValue)
        {
            WriteIniFileValue(this.FilePath, section, key, writeValue.ToString(), this.Encoding);
        }

        #endregion


        #region　WriteSection メソッド (+1)

        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したセクションに IniSection のキーと値を書き込みます。</summary>
        /// <param name="hSection">
        ///     セクションの構造を表す IniSection オブジェクト。</param>
        /// ---------------------------------------------------------------------------------------
        public void WriteSection(IniSection hSection)
        {
            WriteIniFileSection(this.FilePath, this.Section, hSection, this.Encoding);
        }


        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したセクションに IniSection のキーと値を書き込みます。</summary>
        /// <param name="section">
        ///     書き込みに使用するセクション。</param>
        /// <param name="hSection">
        ///     セクションの構造を表す IniSection オブジェクト。</param>
        /// ---------------------------------------------------------------------------------------
        public void WriteSection(string section, IniSection hSection)
        {
            WriteIniFileSection(this.FilePath, section, hSection, this.Encoding);
        }

        #endregion


        #region　FilePath プロパティ

        private string _FilePath;

        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     読み込みに使用するファイル パスを取得または設定します。
        /// </summary>
        /// ---------------------------------------------------------------------------------------
        public string FilePath
        {
            get
            {
                return _FilePath;
            }

            set
            {
                _FilePath = value;
            }
        }

        #endregion


        #region　Section プロパティ

        private string _Section;

        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     読み込みに使用するセクションを取得または設定します。
        /// </summary>
        /// ---------------------------------------------------------------------------------------
        public string Section
        {
            get
            {
                return _Section;
            }

            set
            {
                _Section = value;
            }
        }

        #endregion


        #region　DefaultValue プロパティ

        private string _DefaultValue;

        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     読み込みに失敗した場合に返される値を取得または設定します。
        /// </summary>
        /// ---------------------------------------------------------------------------------------
        public string DefaultValue
        {
            get
            {
                return _DefaultValue;
            }

            set
            {
                _DefaultValue = value;
            }
        }

        #endregion


        #region　Encoding プロパティ

        private System.Text.Encoding _Encoding;

        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     読み込みに使用する文字エンコーディングを取得または設定します。
        /// </summary>
        /// ---------------------------------------------------------------------------------------
        public System.Text.Encoding Encoding
        {
            get
            {
                return _Encoding;
            }

            set
            {
                _Encoding = value;
            }
        }

        #endregion


        // Private

        #region　ReadIniFileValue メソッド

        private static string ReadIniFileValue(string filePath, string iSection, string iKey, string defaultValue, System.Text.Encoding encoding)
        {
            string key;
            string section;

            section = iSection.Trim().ToLower();
            key = iKey.Trim().ToLower();

            // ファイル名・セクション名・キー名がない場合はデフォルト値を返す
            if (filePath == string.Empty || section == string.Empty || key == string.Empty)
            {
                return defaultValue;
            }

            // 指定したファイルが存在しない場合はデフォルト値を返す
            if (!System.IO.File.Exists(filePath))
            {
                return defaultValue;
            }

            using (System.IO.StreamReader cReader = new System.IO.StreamReader(filePath, encoding))
            {
                try
                {
                    while (cReader.Peek() > -1)
                    {
                        //string target = cReader.ReadLine().TrimStart();
                        string target = cReader.ReadLine().Trim();

                        // セクションの始まりかどうか判断する
                        if (IsSectionBegin(target, section))
                        {
                            while (cReader.Peek() > -1)
                            {
                                //target = cReader.ReadLine().TrimStart();
                                target = cReader.ReadLine().Trim();


                                // セクションの終わりかどうか判断する
                                if (IsSectionEnd(target))
                                {
                                    return defaultValue;
                                }

                                // キーが合致している場合は格納された値が返される
                                string nReturn = GetValueOfMatchKey(target, key);

                                if (nReturn != null)
                                {
                                    return nReturn;
                                }
                            }

                            return defaultValue;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw;
                }
                finally
                {
                    if (cReader != null)
                    {
                        cReader.Close();
                    }
                }
            }

            return defaultValue;
        }

        #endregion


        #region　WriteIniFileValue メソッド

        private static void WriteIniFileValue(string filePath, string section, string key, string writeValue, System.Text.Encoding encoding)
        {
            section = section.Trim();
            key = key.Trim();

            // ファイル名・セクション名・キー名がない場合は終了する
            if (filePath == string.Empty || section == string.Empty || key == string.Empty)
            {
                return;
            }

            // 既存ファイルがあれば中身をすべて取得する
            StringCollection hStrings = GetFileContents(filePath, encoding);

            // 既存ファイルがない場合は終了する
            if (hStrings == null)
            {
                return;
            }

            // 最大行数とセクションのLowerを取得
            int iMaxCount = hStrings.Count - 1;
            //string nSecLower = section.ToLower();
            string nSecLower = section.Trim().ToLower();
 
            // 最大要素数まで 1 要素ずつ読み込む
            for (int i = 0; i <= iMaxCount; i++)
            {
                //hStrings[i] = hStrings[i].TrimStart();
                hStrings[i] = hStrings[i].Trim();

                // セクションの始まりかどうか判断する
                if (IsSectionBegin(hStrings[i], nSecLower))
                {
                    int iRow;

                    for (iRow = i + 1; i <= iMaxCount; i++,iRow++)
                    {
                        // セクションの終わりかどうか判断する
                        //if (IsSectionEnd(hStrings[iRow].TrimStart()))
                        if (IsSectionEnd(hStrings[iRow].Trim()))
                        {
                            WriteInsertKeyValue(filePath, key, writeValue, hStrings, iRow - 1, encoding);
                            return;
                        }

                        // キーが合致している場合は書き込まれるべき文字列を返す
                        string nUpdate = GetUpdateWriteLine(hStrings[iRow], key, writeValue);

                        if (nUpdate != null)
                        {
                            WriteUpdateValue(filePath, nUpdate, hStrings, iRow - 1, encoding);
                            return;
                        }
                    }

                    // EOF を発見した場合は挿入する
                    WriteInsertKeyValue(filePath, key, writeValue, hStrings, iRow - 1, encoding);
                    return;
                }
            }

            // セクションがなかった場合はセクションも作成する
            WriteInsertSectionKeyValue(filePath, section, key, writeValue, hStrings, encoding);
        }

        #endregion


        #region　ReadIniFileSection メソッド

        private static IniSection ReadIniFileSection(string filePath, string section, System.Text.Encoding encoding)
        {
            section = section.Trim().ToLower();

            // ファイル名・セクション名がない場合は終了する
            if (filePath == string.Empty || section == string.Empty)
            {
                return null;
            }

            // 指定したファイルが存在しない場合は Null を返す
            if (!System.IO.File.Exists(filePath))
            {
                return null;
            }

            using (System.IO.StreamReader cReader = new System.IO.StreamReader(filePath, encoding))
            {
                try
                {
                    while (cReader.Peek() > -1)
                    {
                        //string target = cReader.ReadLine().TrimStart();
                        string target = cReader.ReadLine().Trim();

                        // セクションの始まりかどうか判断する
                        if (IsSectionBegin(target, section))
                        {
                            IniSection hSection = new IniSection();

                            while (cReader.Peek() > -1)
                            {
                                //target = cReader.ReadLine().TrimStart();
                                target = cReader.ReadLine().Trim();
                                
                                // セクションの終わりかどうか判断する
                                if (IsSectionEnd(target))
                                {
                                    return hSection;
                                }

                                // イコールがあるかどうか判断する
                                int iLength = target.IndexOf('=');

                                if (iLength >= 1)
                                {
                                    //string key = target.Substring(0, iLength - 1).TrimEnd();
                                    string key = target.Substring(0, iLength - 1).Trim();

                                    string value = TrimDoubleQuote(target.Substring(iLength + 1).Trim());
                                    hSection.Add(new IniItem(key, value));
                                }
                            }

                            return hSection;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw;
                }
                finally
                {
                    if (cReader != null)
                    {
                        cReader.Close();
                    }
                }
            }

            return null;
        }

        #endregion


        #region　WriteIniFileSection メソッド

        private static void WriteIniFileSection(string filePath, string section, IniSection hSection, System.Text.Encoding encoding)
        {
            section = section.Trim();

            // ファイル名・セクション名・キー名がない場合は終了する
            if (filePath == string.Empty || section == string.Empty || hSection == null)
            {
                return;
            }

            // 既存ファイルがあれば中身をすべて取得する
            StringCollection hStrings = GetFileContents(filePath, encoding);

            // 既存ファイルがない場合は終了する
            if (hStrings == null)
            {
                return;
            }

            // 最大行数と小文字化したセクションを取得する
            int iMaxCount = hStrings.Count - 1;
            //string nSecLower = section.ToLower();
            string nSecLower = section.Trim().ToLower();

            // 最大要素数まで 1 要素ずつ読み込む
            for (int i = 0; i <= iMaxCount; i++)
            {
                //hStrings[i] = hStrings[i].TrimStart();
                hStrings[i] = hStrings[i].Trim();

                // セクションの始まりかどうか判断する
                if (IsSectionBegin(hStrings[i], nSecLower))
                {
                    int iRow;

                    // セクションの終わりを発見した場合は挿入する
                    for (iRow = i + 1; iRow <= iMaxCount; iRow++)
                    {
                        //if (IsSectionEnd(hStrings[iRow].TrimStart()))
                        if (IsSectionEnd(hStrings[iRow].Trim()))
                        {
                            StringCollection hInserts = GetInsertAllPairOfSection(hStrings, hSection, i + 1, iRow - 1);
                            WriteInsertKeyValue(filePath, hInserts, hStrings, i, iRow, encoding);
                            return;
                        }
                    }

                    // EOF を発見した場合は挿入する
                    StringCollection hEofInserts = GetInsertAllPairOfSection(hStrings, hSection, i + 1, iMaxCount);
                    WriteInsertKeyValue(filePath, hEofInserts, hStrings, i, iRow, encoding);
                    return;
                }
            }

            // セクションがなかった場合はセクションも作成する
            WriteInsertSectionKeyValue(filePath, section, hSection, hStrings, encoding);
        }

        #endregion


        #region　GetValueOfMatchKey メソッド

        private static string GetValueOfMatchKey(string target, string key)
        {
            int iEqual = target.IndexOf('=');

            if (iEqual <= 0)
            {
                return null;
            }

            if (target.Length < key.Length)
            {
                return null;
            }

            //if (target.Substring(0, iEqual).TrimEnd().ToLower() != key)
            if (target.Substring(0, iEqual).Trim().ToLower() != key)
            {
                return null;
            }

            return TrimDoubleQuote(target.Substring(iEqual + 1).Trim());
        }

        #endregion


        #region　GetUpdateWriteLine メソッド

        private static string GetUpdateWriteLine(string source, string key, string writeValue)
        {
            //MessageBox.Show("S:" + source + "\r\n" + "K:" + key + "\r\n" + "V:" + writeValue);
            //string target = source.TrimStart();
            string target = source.Trim();
            int iEqual = target.IndexOf('=');

            if (iEqual <= 0)
            {
                return null;
            }

            if (target.Length < key.Length)
            {
                return null;
            }

            //if (target.Substring(0, iEqual).TrimEnd().ToLower() == key.ToLower())
            if (target.Substring(0, iEqual).Trim().ToLower() == key.Trim().ToLower())
            {
                int iMargin = (source.Length - target.Length) + (iEqual + 1);
                target = target.Substring(iEqual + 1);
                iMargin += target.Length;
                target = target.TrimStart();
                iMargin -= target.Length;
                target = target.TrimEnd();
                int iLength = target.Length;

                if (iLength >= 2)
                {
                    if (target.Substring(0, 1) == DOUBLE_QUOTE)
                    {
                        if (target.Substring(iLength - 1) == DOUBLE_QUOTE)
                        {
                            return source.Substring(0, iMargin) + DOUBLE_QUOTE + writeValue + DOUBLE_QUOTE;
                        }
                    }
                }

                return source.Substring(0, iMargin) + writeValue;
            }

            return null;
        }

        #endregion


        #region　GetInsertAllPairOfSection メソッド

        private static StringCollection GetInsertAllPairOfSection(StringCollection hSources, IniSection hSection, int iBegin, int iEnd)
        {
            int iBrank = 0;
            StringCollection hStrings = new StringCollection();

            for (int i = iBegin; i <= iEnd; i++)
            {
                hStrings.Add(hSources[i]);

                if (hSources[i] == string.Empty)
                {
                    iBrank++;
                }
                else
                {
                    iBrank = 0;
                }
            }

            for (int i = 0; i <= hSection.Count - 1; i++)
            {
                int iRow;

                for (iRow = 0; iRow <= iEnd - iBegin - iBrank; iRow++)
                {
                    string nUpdate = GetUpdateWriteLine(hStrings[iRow], hSection[i].Key.Trim(), hSection[i].Value.Trim());

                    if (nUpdate != null)
                    {
                        hStrings[iRow] = nUpdate;
                        break;
                    }
                }

                if (iRow > iEnd - iBegin - iBrank)
                {
                    iEnd++;

                    if (iEnd - iBegin - iBrank <= hStrings.Count - 1)
                    {
                        hStrings[iEnd - iBegin - iBrank] = hSection[i].Key.Trim() + " = " + hSection[i].Value.Trim();
                        hStrings.Add(string.Empty);
                    }
                    else
                    {
                        hStrings.Add(hSection[i].Key.Trim() + " = " + hSection[i].Value.Trim());
                    }
                }
            }

            return hStrings;
        }

        #endregion


        #region　WriteUpdateValue メソッド

        private static void WriteUpdateValue(string filePath, string writeValue, StringCollection hStrings, int iCurrent, System.Text.Encoding encoding)
        {
            using (System.IO.StreamWriter hWriter = new System.IO.StreamWriter(filePath, false, encoding))
            {
                try
                {
                    for (int i = 0; i <= iCurrent; i++)
                    {
                        hWriter.WriteLine(hStrings[i]);
                    }

                    hWriter.WriteLine(writeValue);

                    for (int i = iCurrent + 2; i <= hStrings.Count - 1; i++)
                    {
                        hWriter.WriteLine(hStrings[i]);
                    }
                }
                catch (System.Exception ex)
                {
                    throw;
                }
                finally
                {
                    if (hWriter != null)
                    {
                        hWriter.Close();
                    }
                }
            }
        }

        #endregion


        #region　WriteInsertKeyValue メソッド (+1)

        private static void WriteInsertKeyValue(string filePath, string key, string writeValue, StringCollection hStrings, int iCurrent, System.Text.Encoding encoding)
        {
            int iBegin;

            for (iBegin = iCurrent; iBegin >= 0; iBegin--)
            {
                if (hStrings[iBegin] != string.Empty)
                {
                    break;
                }
            }

            using (System.IO.StreamWriter hWriter = new System.IO.StreamWriter(filePath, false, encoding))
            {
                try
                {
                    for (int i = 0; i <= iBegin; i++)
                    {
                        hWriter.WriteLine(hStrings[i]);
                    }

                    hWriter.WriteLine(key.Trim() + " = " + writeValue.Trim());

                    for (int i = iBegin + 1; i <= hStrings.Count - 1; i++)
                    {
                        hWriter.WriteLine(hStrings[i]);
                    }
                }
                catch (System.Exception ex)
                {
                    throw;
                }
                finally
                {
                    if (hWriter != null)
                    {
                        hWriter.Close();
                    }
                }
            }
        }


        private static void WriteInsertKeyValue(string filePath, StringCollection hInserts, StringCollection hSources, int iBegin, int iEnd, System.Text.Encoding encoding)
        {
            using (System.IO.StreamWriter hWriter = new System.IO.StreamWriter(filePath, false, encoding))
            {
                try
                {
                    for (int i = 0; i <= iBegin; i++)
                    {
                        hWriter.WriteLine(hSources[i]);
                    }

                    for (int i = 0; i <= hInserts.Count - 1; i++)
                    {
                        hWriter.WriteLine(hInserts[i]);
                    }

                    for (int i = iEnd; i <= hSources.Count - 1; i++)
                    {
                        hWriter.WriteLine(hSources[i]);
                    }
                }
                catch (System.Exception ex)
                {
                    throw;
                }
                finally
                {
                    if (hWriter != null)
                    {
                        hWriter.Close();
                    }
                }
            }
        }

        #endregion


        #region　WriteInsertSectionKeyValue メソッド (+1)

        private static void WriteInsertSectionKeyValue(string filePath, string section, string key, string writeValue, StringCollection hSources, System.Text.Encoding encoding)
        {
            if (hSources == null)
            {
                return;
            }

            using (System.IO.StreamWriter hWriter = new System.IO.StreamWriter(filePath, false, encoding))
            {
                try
                {
                    int iLast;

                    for (iLast = 0; iLast <= hSources.Count - 1; iLast++)
                    {
                        hWriter.WriteLine(hSources[iLast]);
                    }

                    if (iLast > 0)
                    {
                        if (hSources[iLast - 1] != string.Empty)
                        {
                            hWriter.WriteLine();
                        }
                    }

                    hWriter.WriteLine("[" + section + "]");
                    hWriter.WriteLine(key + " = " + writeValue.Trim());
                }
                catch (System.Exception ex)
                {
                    throw;
                }
                finally
                {
                    if (hWriter != null)
                    {
                        hWriter.Close();
                    }
                }
            }
        }


        private static void WriteInsertSectionKeyValue(string filePath, string section, IniSection hSection, StringCollection hSources, System.Text.Encoding encoding)
        {
            if (hSources == null)
            {
                return;
            }

            using (System.IO.StreamWriter hWriter = new System.IO.StreamWriter(filePath, false, encoding))
            {
                try
                {
                    int iLast;

                    for (iLast = 0; iLast <= hSources.Count - 1; iLast++)
                    {
                        hWriter.WriteLine(hSources[iLast]);
                    }

                    if (iLast > 0)
                    {
                        if (hSources[iLast - 1] != string.Empty)
                        {
                            hWriter.WriteLine();
                        }
                    }

                    hWriter.WriteLine("[" + section + "]");

                    for (int i = 0; i <= hSection.Count - 1; i++)
                    {
                        hWriter.WriteLine(hSection[i].Key.Trim() + " = " + hSection[i].Value.Trim());
                    }
                }
                catch (System.Exception ex)
                {
                    throw;
                }
                finally
                {
                    if (hWriter != null)
                    {
                        hWriter.Close();
                    }
                }
            }
        }

        #endregion


        #region　IsSectionBegin メソッド

        private static bool IsSectionBegin(string target, string section)
        {
            if (target == string.Empty || target.Substring(0, 1) != "[")
            {
                return false;
            }

            //target = target.Substring(1).TrimStart();
            target = target.Substring(1).Trim();
            int iLength = section.Length;

            if (target.Length < iLength)
            {
                return false;
            }

            //if (target.Substring(0, iLength).ToLower() == section)
            if (target.Substring(0, iLength).Trim().ToLower() == section)
            {
                //target = target.Substring(iLength).TrimStart();
                target = target.Substring(iLength).Trim();

                if (target == string.Empty || target.Substring(0, 1) == "]")
                {
                    return true;
                }
            }

            return false;
        }

        #endregion


        #region　IsSectionEnd メソッド

        private static bool IsSectionEnd(string target)
        {
            if (target != string.Empty && target.Substring(0, 1) == "[")
            {
                return true;
            }

            return false;
        }

        #endregion


        #region　GetFileContents メソッド

        private static StringCollection GetFileContents(string filePath, System.Text.Encoding encoding)
        {
            if (!System.IO.File.Exists(filePath))
            {
                return null;
            }

            using (System.IO.StreamReader cReader = new System.IO.StreamReader(filePath, encoding))
            {
                try
                {
                    StringCollection hStrings = new StringCollection();

                    for (int i = 0; i <= MAX_LINE; i++)
                    {
                        if (cReader.Peek() < 0)
                        {
                            break;
                        }

                        hStrings.Add(cReader.ReadLine());
                    }
                    
                    return hStrings;
                }
                catch (System.Exception ex)
                {
                    throw;
                }
                finally
                {
                    if (cReader != null)
                    {
                        cReader.Close();
                    }
                }
            }
        }

        #endregion


        #region　TrimDoubleQuote メソッド

        private static string TrimDoubleQuote(string target)
        {
            int iLength = target.Length;

            if (iLength >= 2)
            {
                if (target.Substring(0, 1) == DOUBLE_QUOTE)
                {
                    if (target.Substring(iLength - 1) == DOUBLE_QUOTE)
                    {
                        target = target.Substring(1, iLength - 2);
                    }
                }
            }

            return target;
        }

        #endregion


        #region　ToDouble メソッド

        private static double ToDouble(string target)
        {
            double result;

            if (double.TryParse(
                target,
                System.Globalization.NumberStyles.Number,
                null,
                out result)
            )
            {
                return result;
            }
            else
            {
                return 0D;
            }
        }

        #endregion


        #region　ToInt32 メソッド

        private static int ToInt32(string target)
        {
            double result;

            if (double.TryParse(
                target,
                System.Globalization.NumberStyles.Number,
                null,
                out result)
            )
            {
                return result >= 0 ? (int)System.Math.Floor(result) :
                                     (int)System.Math.Ceiling(result);
            }
            else
            {
                return 0;
            }
        }

        #endregion

    }

    #endregion


    #region　IniItem クラス

    /// --------------------------------------------------------------------------------
    /// <summary>
    ///     INI ファイルのセクション内にある Key と Value が対になったアイテムを表します。
    /// </summary>
    /// --------------------------------------------------------------------------------

    public class IniItem
    {

        #region　コンストラクタ

        /// --------------------------------------------------------------------------------
        /// <summary>
        ///     Jeanne.Ini.IniItem の新しいインスタンスを初期化します。</summary>
        /// <param name="key">
        ///     値との組み合わせで定義されているキー。</param>
        /// <param name="value">
        ///     キーに関連付けられている値</param>
        /// --------------------------------------------------------------------------------
        public IniItem(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        #endregion


        #region　Key プロパティ

        private string _Key;

        /// --------------------------------------------------------------------------------
        /// <summary>
        ///     キーと値の組み合わせ内のキーを取得または設定します。
        /// </summary>
        /// --------------------------------------------------------------------------------
        public string Key
        {
            get
            {
                return _Key;
            }

            set
            {
                _Key = value;
            }
        }

        #endregion


        #region　Value プロパティ

        private string _Value;

        /// --------------------------------------------------------------------------------
        /// <summary>
        ///     キーと値の組み合わせ内の値を取得または設定します。
        /// </summary>
        /// --------------------------------------------------------------------------------
        public string Value
        {
            get
            {
                return _Value;
            }

            set
            {
                _Value = value;
            }
        }

        #endregion

    }

    #endregion


    #region　IniSection クラス

    /// --------------------------------------------------------------------------------
    /// <summary>
    ///     Jeanne.Ini.IniItem を複数格納しているセクションを表します。
    /// </summary>
    /// --------------------------------------------------------------------------------

    public class IniSection : System.Collections.ArrayList
    {

        #region　Item インデクサ

        /// --------------------------------------------------------------------------------
        /// <summary>
        ///     コレクション内のアイテムを表すインデクサです。
        /// </summary>
        /// --------------------------------------------------------------------------------
        public new IniItem this[int index]
        {
            get
            {
                return (IniItem)base[index];
            }

            set
            {
                base[index] = value;
            }
        }

        #endregion


        #region　Add メソッド

        /// --------------------------------------------------------------------------------
        /// <summary>
        ///     Jeanne.Ini.IniSection の末尾に、IniItem オブジェクトを追加します。</summary>
        /// <param name="value">
        ///     末尾に追加する System.Ini.IniItem。</param>
        /// <returns>
        ///     追加された位置の Jeanne.Ini.IniSection インデックス。</returns>
        /// --------------------------------------------------------------------------------
        public int Add(IniItem value)
        {
            return base.Add(value);
        }

        #endregion

    }

    #endregion


    #region　IniSectionCollection クラス

    /// --------------------------------------------------------------------------------
    /// <summary>
    ///     Jeanne.Ini.IniSection のコレクションを表します。
    /// </summary>
    /// --------------------------------------------------------------------------------

    public class IniSectionCollection : System.Collections.ArrayList
    {

        #region　Item インデクサ

        /// --------------------------------------------------------------------------------
        /// <summary>
        ///     コレクション内のアイテムを表すインデクサです。
        /// </summary>
        /// --------------------------------------------------------------------------------
        public new IniSection this[int index]
        {
            get
            {
                return (IniSection)base[index];
            }

            set
            {
                base[index] = value;
            }
        }

        #endregion


        #region　Add メソッド

        /// --------------------------------------------------------------------------------
        /// <summary>
        ///     Jeanne.Ini.IniSectionCollection の末尾に、IniSection オブジェクトを追加します。</summary>
        /// <param name="value">
        ///     末尾に追加する System.Ini.IniSection。</param>
        /// <returns>
        ///     追加された位置の Jeanne.Ini.IniSectionCollection インデックス。</returns>
        /// --------------------------------------------------------------------------------
        public int Add(IniSection value)
        {
            return base.Add(value);
        }

        #endregion

    }

    #endregion

}

