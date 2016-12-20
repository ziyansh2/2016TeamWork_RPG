///作成日：2016.12.20
///作成者：柏
///作成内容：Stage生成クラス
///最後修正内容：。。
///最後修正者：。。
///最後修正日：。。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _2016RPGTeamWork.Device;
using Microsoft.Xna.Framework;
using _2016RPGTeamWork.Def;

namespace _2016RPGTeamWork.Scene
{
    enum eStage {
        WORLDMAP,
        CAVE,
        FOREST,
        TOWN,
        NONE,
    }
    class Stage
    {
        private eStage currentStage;
        private int[,] mapData;
        private Dictionary<int, string> textData;    //2016.12.20 by柏 読み取った文字データ保存用
        private StageLoader stageLoader;

        public Stage() {
            stageLoader = new StageLoader();
            currentStage = eStage.WORLDMAP;
        }

        /// <summary>
        /// ステージを設定
        /// </summary>
        /// <param name="stage"></param>
        public void SetStage(eStage stage) {
            currentStage = stage;
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize() {
            mapData = stageLoader.MapLoad(currentStage);

            //2016.12.20 by柏 文字データを読み取る
            textData = stageLoader.TextLoad(currentStage);
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer) {
            for (int y = 0; y < mapData.GetLength(0); y++)
            {
                for (int x = 0; x < mapData.GetLength(1); x++)
                {
                    renderer.DrawTexture("mapsource",
                        new Vector2(x * Parameter.TileSize, y * Parameter.TileSize),
                        new Rectangle(0, Parameter.TileSize * 2, Parameter.TileSize, Parameter.TileSize));
                }
            }
        }

        /// <summary>
        /// 読み取った文字データを出す
        /// </summary>
        public Dictionary<int,string> GetTextData {
            get { return textData; }
        }
    }
}
