///作成日：2016.12.19
///作成者：柏
///作成内容：ゲームプレーシーン
///最後修正内容：enemyManager追加、npc追加
///最後修正者：柏
///最後修正日：2017.1.8

using System.Collections.Generic;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

using _2016RPGTeamWork.Device;
using _2016RPGTeamWork.Utility;
using _2016RPGTeamWork.GameObjects.EnemyManagers;
using _2016RPGTeamWork.NPC;

namespace _2016RPGTeamWork.Scene
{
    class GamePlay : IsScene
    {
        bool endFlag;
        bool battleFlag;
        private InputState input;
        private Stage stage;    //2016.12.20 by柏　stage描画用
        private Dictionary<int,string> textData;    //2016.12.20 by柏　文字表示用
        private int textNum;    //2016.12.20 by柏　文字表示用
        private Writer writer;    //2016.12.25 by柏　文字改行表示
        private EnemyManager enemyManager;    //2017.1.8 by柏　battleのenemy追加
        private List<NoPlayChara> npcList;    //2017.1.8 by柏　npc生成

        public GamePlay(GameDevice gameDevice)
        {
            input = gameDevice.GetInputState();
            Initialize();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            stage = new Stage();    //2016.12.20 by柏　stage管理
            stage.Initialize();    //2016.12.20 by柏　stage管理
            writer = new Writer();    //2016.12.25 by柏　文字改行表示
            writer.Initialize();    //2016.12.25 by柏　文字改行表示
            enemyManager = new EnemyManager();
            npcList = stage.GetNPC;
            npcList.ForEach(n => n.Initialize());

            endFlag = false;
            battleFlag = false;
            textData = stage.GetTextData;
            textNum = -1;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update() {
            npcList.ForEach(n => n.Update());
            GameInput();
        }

        private void GameInput() {
            if (input.IsKeyDown(Keys.Space)) { endFlag = true; }
            else if (input.IsKeyDown(Keys.Z))
            {
                battleFlag = !battleFlag;
                if (battleFlag)
                {
                    enemyManager.AddEnemy(eEnemy.Slime);
                    enemyManager.Initialize();
                }
                else {
                    enemyManager.ClearEnemyList();
                }
            }
            else if (input.IsKeyDown(Keys.X)) { TextUpdate(); }
        }

        /// <summary>
        /// セリフの文字ずつ表示
        /// </summary>
        private void TextUpdate() {
            textNum++;
            if (!textData.ContainsKey(textNum)) {
                textNum = -1;
            }
            else {
                writer.Initialize();
                writer.SetData(textData[textNum]);
            }
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer) {
            stage.Draw(renderer);    //2016.12.20 by柏　stage描画用
            renderer.DrawTexture("gameplay", Vector2.Zero);

            npcList.ForEach(n => n.Draw(renderer)); //2017.1.8　by柏　npc描画

            enemyManager.Draw(renderer);     //2017.1.8　by柏　enemy描画


            if (textNum < 0) { return; }
            writer.Draw(renderer);
        }


        /// <summary>
        /// 次のシーンに行く
        /// </summary>
        /// <returns></returns>
        public eScene ToNext()
        {
            return eScene.TITLE;
        }

        /// <summary>
        /// バトルシーンに遷移
        /// </summary>
        /// <returns></returns>
        public eScene ToBattle()
        {
            return eScene.BATTLE;
        }

        /// <summary>
        /// エンドフラッグをとる
        /// </summary>
        /// <returns></returns>
        public bool IsEnd()
        {
            return endFlag;
        }

        /// <summary>
        /// バトルフラッグのゲットセット
        /// </summary>
        public bool IsBattle {
            get { return battleFlag; }
            set { battleFlag = value; }
        }

    }
}
