///作成日：2016.12.20
///作成者：柏
///作成内容：ステージのロード専用クラス
///最後修正内容：static classに変更、セリフデータ読込の追加
///最後修正者：柏
///最後修正日：2017.1.8

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace _2016RPGTeamWork.Scene
{
    static class StageLoader
    {
        /// <summary>
        /// ステージテキストをロード    2016.12.20
        /// </summary>
        /// <param name="stage">ステージの種類</param>
        /// <returns></returns>
        public static Dictionary<int,string> TextLoad(eStage stage)
        {
            Dictionary<int, string> TextData = new Dictionary<int, string>();
            string[] splitLine = null;

            try {
                splitLine = File.ReadAllLines("Content/CSV/Stage_" + stage + "_Text.csv", Encoding.GetEncoding("Shift_JIS"));
            }
            catch (FileNotFoundException ffe) {
                return new Dictionary<int, string>();
            }

            for (int i = 0; i < splitLine.Length; i++) {
                string[] data = splitLine[i].Split('`');
                Debug.Assert(data.Length == 2,
                    "Stage_" + stage + "_Text.csvファイルをチェックしてください。" +
                    i +　"番のデータが読み込めません。"
                    );
                TextData.Add(GetInt(data[0]), data[1]);
            }
            return TextData;
        }

        /// <summary>
        /// ステージマップデータをロード  2016.12.20
        /// </summary>
        /// <param name="stage">ステージの種類</param>
        /// <returns></returns>
        public static int[,] MapLoad(eStage stage) {
            int[,] mapData;
            List<string> lines = null;

            string[] splitLine;
            try {
                splitLine = File.ReadAllLines("Content/CSV/Stage_" + stage + ".csv", Encoding.GetEncoding("Shift_JIS"));
            }
            catch (FileNotFoundException ffe) {
                
                return new int[0, 0];
            }
            lines = splitLine.ToList();

            splitLine = lines[0].Split(',');
            mapData = new int[GetInt(splitLine[1]), GetInt(splitLine[0])];
            lines.RemoveAt(0);

            for (int y = 0; y < mapData.GetLength(0); y++) {
                splitLine = lines[y].Split(',');
                for (int x = 0; x < mapData.GetLength(1); x++) {
                    mapData[y, x] = GetInt(splitLine[x]);
                }
            }
            return mapData;
        }

        /// <summary>
        /// ステージのセリフデータをロード 2017.1.8
        /// </summary>
        /// <param name="stage">ステージの種類</param>
        /// <returns></returns>
        public static int[,] DialogueMapLoad(eStage stage)
        {
            int[,] mapData;
            List<string> lines = null;

            string[] splitLine;
            try
            {
                splitLine = File.ReadAllLines("Content/CSV/Stage_" + stage + "_DiaMap.csv", Encoding.GetEncoding("Shift_JIS"));
            }
            catch (FileNotFoundException ffe)
            {
                return new int[0, 0];
            }
            lines = splitLine.ToList();

            splitLine = lines[0].Split(',');
            mapData = new int[GetInt(splitLine[1]), GetInt(splitLine[0])];
            lines.RemoveAt(0);

            for (int y = 0; y < mapData.GetLength(0); y++)
            {
                splitLine = lines[y].Split(',');
                for (int x = 0; x < mapData.GetLength(1); x++)
                {
                    mapData[y, x] = GetInt(splitLine[x]);
                }
            }
            return mapData;
        }


        /// <summary>
        /// データ（エネミー、技、マジックなど）をロード  2016.12.20
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        public static int[,] DataLoad(string fileName)
        {
            int[,] data;
            List<string> lines = null;

            string[] splitLine;
            try
            {
                splitLine = File.ReadAllLines("Content/CSV/" + fileName + ".csv", Encoding.GetEncoding("Shift_JIS"));
            }
            catch (FileNotFoundException ffe)
            {
                return new int[0, 0];
            }
            lines = splitLine.ToList();

            splitLine = lines[0].Split(',');
            data = new int[GetInt(splitLine[1]), GetInt(splitLine[0])];
            lines.RemoveAt(0);

            for (int y = 0; y < data.GetLength(0); y++)
            {
                splitLine = lines[y].Split(',');
                for (int x = 0; x < data.GetLength(1); x++)
                {
                    data[y, x] = GetInt(splitLine[x]);
                }
            }
            return data;
        }

        /// <summary>
        /// CSVファイルから読み取ったstringデータをintに変換  2016.12.20
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static int GetInt(string data) {
            int data_int;
            int.TryParse(data, out data_int);
            return data_int > 0 ? data_int : 0;
        }

    }
}
