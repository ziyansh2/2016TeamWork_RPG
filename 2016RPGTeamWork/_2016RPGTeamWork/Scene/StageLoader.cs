///作成日：2016.12.20
///作成者：柏
///作成内容：ステージのロード専用クラス
///最後修正内容：。。
///最後修正者：。。
///最後修正日：。。

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _2016RPGTeamWork.Scene
{
    class StageLoader
    {
        public StageLoader() { }

        /// <summary>
        /// ステージマップデータをロード
        /// </summary>
        /// <param name="stage">ステージの種類</param>
        /// <returns></returns>
        public int[,] MapLoad(eStage stage) {
            int[,] mapData;
            List<string> lines = null;
            StreamReader streamReader = null;
            try {
                streamReader = new StreamReader("Content/CSV/Stage_" + stage + ".csv", Encoding.GetEncoding("Shift_JIS"));
                lines = new List<string>();
                while (streamReader.Peek() >= 0) {
                    lines.Add(streamReader.ReadLine());
                }
            }
            catch (FileNotFoundException ffe){
                return new int[0, 0];
            }

            string[] splitLine = lines[0].Split(',');
            mapData = new int[GetInt(splitLine[1]), GetInt(splitLine[0])];
            lines.RemoveAt(0);

            for (int y = 0; y < mapData.GetLength(0); y++) {
                splitLine = lines[y].Split(',');
                for (int x = 0; x < mapData.GetLength(1); x++) {
                    mapData[y, x] = GetInt(splitLine[x]);
                }
            }
            streamReader.Close();
            return mapData;
        }

        /// <summary>
        /// CSVファイルから読み取ったstringデータをintに変換
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private int GetInt(string data) {
            int data_int;
            int.TryParse(data, out data_int);
            return data_int > 0 ? data_int : 0;
        }

    }
}
