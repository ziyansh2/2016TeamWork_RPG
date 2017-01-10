///作成日：2016.12.19
///作成者：柏
///作成内容：バトルシーン
///最後修正内容：player追加
///最後修正者：柏
///最後修正日：2017.1.10

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using _2016RPGTeamWork.GameObjects.EnemyManagers;
using _2016RPGTeamWork.Device;
using _2016RPGTeamWork.GameObjects;

namespace _2016RPGTeamWork.Scene
{
    class Battle : IsScene
    {
        bool endFlag;
        private InputState input;
        private GamePlay gamePlay;
        private EnemyManager enemyManager;    //2017.1.8 by柏　battleのenemy追加
        private List<Character> players;       //2017.1.10 by柏　players取得
        private int trun;

        public Battle(GameDevice gameDevice, GamePlay gamePlay)
        {
            enemyManager = new EnemyManager();

            this.gamePlay = gamePlay;
            input = gameDevice.GetInputState();
            players = gamePlay.GetPlayers;
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            endFlag = false;
            enemyManager.AddEnemy(eEnemy.Slime);
            enemyManager.InitEnemy();
            trun = 0;
        }

        /// <summary>
        /// 次のシーンに行く
        /// </summary>
        /// <returns></returns>
        public eScene ToNext()
        {
            return eScene.GAMEPLAY;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update() {
            if (input.IsKeyDown(Keys.Z)) {
                enemyManager.ClearEnemyList();
                gamePlay.IsBattle = false;
                endFlag = true;
                players.ForEach(n => ((Player)n).IsBattle = false);
            }

            trun++;
            enemyManager.Update();
            players.ForEach(n => ((Player)n).Battle());
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer)
        {
            gamePlay.Draw(renderer);
            renderer.DrawTexture("battle", Vector2.One * 300);
            enemyManager.Draw(renderer);     //2017.1.8　by柏　enemy描画
        }


        /// <summary>
        /// エンドフラッグをとる
        /// </summary>
        /// <returns></returns>
        public bool IsEnd()
        {
            return endFlag;
        }
    }
}
