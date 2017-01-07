///作成日：2016.12.20
///作成者：柏
///作成内容：Stage生成クラス
///最後修正内容：StageLoader改善によって調整、ＮＰＣ生成
///最後修正者：柏
///最後修正日：2017.1.8

using System.Collections.Generic;

using Microsoft.Xna.Framework;

using _2016RPGTeamWork.Device;
using _2016RPGTeamWork.Def;
using _2016RPGTeamWork.NPC;
using _2016RPGTeamWork.Utility;
using _2016RPGTeamWork.NPC.IMove;

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
        private List<NoPlayChara> npcList;

        public Stage() {
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
            mapData = StageLoader.MapLoad(currentStage);

            //2016.12.20 by柏 文字データを読み取る
            textData = StageLoader.TextLoad(currentStage);

            //2016.12.20 by柏 NPCデータを読み取る
            int[,] dialogueCorData = StageLoader.DataLoad("dialogueCor_Text");
            int[,] dialogueMapData = StageLoader.DialogueMapLoad(currentStage);

            //2017.1.8 by柏 NPC生成
            npcList = new List<NoPlayChara>();
            CreatNpc(dialogueCorData, dialogueMapData);
        }

        /// <summary>
        /// npc生成
        /// </summary>
        /// <param name="dialogueCorData">セリフの段落</param>
        /// <param name="dialogueMapData">npcのマップ位置対応</param>
        private void CreatNpc(int[,] dialogueCorData, int[,] dialogueMapData) {
            for (int y = 0; y < mapData.GetLength(0); y++) {
                for (int x = 0; x < mapData.GetLength(1); x++) {
                    switch (mapData[y, x]) {
                        case 24:
                            CreatNpcOne(x, y, dialogueCorData, dialogueMapData, new MoveNone());
                            break;
                        case 25:
                            CreatNpcOne(x, y, dialogueCorData, dialogueMapData, new MoveHorizonal_3());
                            break;
                        case 26:
                            CreatNpcOne(x, y, dialogueCorData, dialogueMapData, new MoveVertical_3());
                            break;
                    }
                }
            }
        }


        /// <summary>
        /// npc一個ずつ生成
        /// </summary>
        /// <param name="x">マップチップｘ座標</param>
        /// <param name="y">マップチップｙ座標</param>
        /// <param name="dialogueCorData">セリフの段落</param>
        /// <param name="dialogueMapData">npcのマップ位置対応</param>
        /// <param name="move">移動パタン</param>
        private void CreatNpcOne(int x,int y, int[,] dialogueCorData, int[,] dialogueMapData, MoveAble move) {   
            Vector2 position = new Vector2(x * Parameter.TileSize, y * Parameter.TileSize);
            Range dialogueCor = new Range(dialogueCorData[dialogueMapData[y, x], 0], dialogueCorData[dialogueMapData[y, x], 1]);
            npcList.Add(new NoPlayChara(position, dialogueCor, move));
        }


        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer) {
            for (int y = 0; y < mapData.GetLength(0); y++) {
                for (int x = 0; x < mapData.GetLength(1); x++) {
                    renderer.DrawTexture("mapsource",
                        new Vector2(x * Parameter.TileSize, y * Parameter.TileSize),
                        new Rectangle(
                            mapData[y, x] * Parameter.TileSize, 
                            mapData[y, x] * Parameter.TileSize, 
                            Parameter.TileSize, 
                            Parameter.TileSize)
                        );
                }
            }
        }
        
        /// <summary>
        /// npcList提供
        /// </summary>
        public List<NoPlayChara> GetNPC {
            get { return npcList; }
        }

        /// <summary>
        /// 読み取った文字データを出す
        /// </summary>
        public Dictionary<int,string> GetTextData {
            get { return textData; }
        }
    }
}
