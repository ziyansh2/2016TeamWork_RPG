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
        private Vector2 playerPosition; //2017.1.14 by柏 PLAYER中心スクリーン範囲描画するため

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

        public void SetPlayerPosition(Vector2 playerPosition) {
            this.playerPosition = playerPosition;
        }
        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize() {
            mapData = DataLoader.MapLoad(currentStage);

            //2016.12.20 by柏 文字データを読み取る
            textData = DataLoader.TextLoad(currentStage);

            //2016.12.20 by柏 NPCデータを読み取る
            int[,] dialogueCorData = DataLoader.DataLoad("dialogueCor_Text");
            int[,] dialogueMapData = DataLoader.DialogueMapLoad(currentStage);
            int[,] npcMapData      = DataLoader.NpcMapLoad(currentStage);

            //2017.1.8 by柏 NPC生成
            npcList = new List<NoPlayChara>();
            CreatNpc(dialogueCorData, dialogueMapData, npcMapData);
        }

        /// <summary>
        /// npc生成
        /// </summary>
        /// <param name="dialogueCorData">セリフの段落</param>
        /// <param name="dialogueMapData">npcのマップ位置対応</param>
        private void CreatNpc(int[,] dialogueCorData, int[,] dialogueMapData, int[,] npcMapData) {
            for (int y = 0; y < npcMapData.GetLength(0); y++) {
                for (int x = 0; x < npcMapData.GetLength(1); x++) {
                    switch (npcMapData[y, x]) {
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
        /// 範囲描画
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer, Vector2 offset) {
            int size = Parameter.TileSize;
            Vector2 playerXP = GetMapXY(playerPosition);
            Vector2 scaleMin = playerXP - GetVeiwScale();
            Vector2 scaleMax = playerXP + GetVeiwScale();
            for (int j = (int)scaleMin.Y; j < (int)scaleMax.Y; j++) {
                for (int i = (int)scaleMin.X; i < (int)scaleMax.X; i++) {
                    if (!IsInStage(i,j)) { continue; }
                    Rectangle rect = new Rectangle((mapData[j, i] % 4) * size, (mapData[j, i] / 4) * size, size, size);
                    renderer.DrawTexture("mapsource", new Vector2(i * size, j * size) + offset,rect);
                }
            }
        }

        /// <summary>
        /// Map座標の取得  by柏　2017.1.14　範囲描画のために追加
        /// </summary>
        /// <param name="position">位置</param>
        /// <returns></returns>
        private Vector2 GetMapXY(Vector2 position) {
            int size = Parameter.TileSize;
            int X = (int)position.X / size;
            int Y = (int)position.Y / size;
            return new Vector2(X, Y);
        }

        /// <summary>
        /// 描画範囲の取得  by柏　2017.1.14　範囲描画のために追加
        /// </summary>
        /// <returns></returns>
        private Vector2 GetVeiwScale() {
            int size = Parameter.TileSize;
            int screenHalfW = Parameter.ScreenWidth / size / 2;
            int screenHalfH = Parameter.ScreenHeight / size / 2;
            return new Vector2(screenHalfW, screenHalfH);   //範囲はスクリーンの半分
        }

        private bool IsInStage(int X,int Y) {
            if (Y < 0 || X < 0) { return false; }
            if (Y >= mapData.GetLength(0) || X >= mapData.GetLength(1)) { return false; }
            return true;
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

        public Vector2 GetStageScale() {
            int width = mapData.GetLength(1) * Parameter.TileSize;
            int height = mapData.GetLength(0) * Parameter.TileSize;
            return new Vector2(width, height);
        }

        public int[,] GetMapData() {
            return mapData;
        }
    }
}
