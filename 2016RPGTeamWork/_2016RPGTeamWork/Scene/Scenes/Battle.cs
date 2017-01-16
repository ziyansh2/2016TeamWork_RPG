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
        enum InputMode //2017年1月15日（ホームズ）プレイヤー入力のフェーズ
        {
            Off,
            ActionSelect,
            TargetSelect,
        }
        bool endFlag;
        private InputState input;
        private GamePlay gamePlay;
        private EnemyManager enemyManager;    //2017.1.8 by柏　battleのenemy追加
        private List<Character> players;       //2017.1.10 by柏　players取得
        private int trun;

        private int actionSelector = 0; //2017年1月12日（ホームズ）プレイヤーのアクション選択
        private int enemySelect = 0; //2017年1月12日（ホームズ）プレイヤーの敵選択
        private InputMode im = InputMode.Off; //2017年1月15日（ホームズ）プレイヤーからの入力を待っているかどうか？
        private Player controlFocus; //2017年1月15日（ホームズ）現在操作するプレイヤー

        private Character SelectedEnemy //2017年1月12日（ホームズ）選択中のターゲット敵
        {
            get
            {
                List<Enemy> enemies = enemyManager.GetEnemyList();
                if (enemies.Count <= 0) return null;
                if(enemySelect > enemies.Count)
                {
                    enemySelect = 0;
                }
                else if(enemySelect < 0)
                {
                    enemySelect = enemies.Count - 1;
                }
                return EnemyManager.GetEnemyList()[enemySelect];
            }
        }

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

            if (im == InputMode.ActionSelect)
            {
                if (input.IsKeyDown(Keys.Right))
                {
                    actionSelector++;
                    while (actionSelector >= 5) actionSelector -= 5;
                }
                else if (input.IsKeyDown(Keys.Left))
                {
                    actionSelector--;
                    while (actionSelector < 0) actionSelector += 5;
                }
                if (input.IsKeyDown(Keys.Enter))
                {
                    im = InputMode.TargetSelect;
                }
                return;
            }

            else if(im == InputMode.TargetSelect)
            {
                //int numEnemies = enemyManager.GetEnemyList().Count;
                if (input.IsKeyDown(Keys.Right))
                {
                    enemySelect ++;
                    int numEnemies = enemyManager.GetEnemyList().Count;
                    while (enemySelect >= numEnemies) enemySelect -= numEnemies;
                    //SelectedEnemy = enemyManager.GetEnemyList()[enemySelect];
                }
                else if (input.IsKeyDown(Keys.Left))
                {
                    enemySelect--;
                    int numEnemies = enemyManager.GetEnemyList().Count;
                    while (enemySelect < 0) enemySelect += numEnemies;
                }
                if (input.IsKeyDown(Keys.Enter))
                {
                    controlFocus.Action((eAction)actionSelector, SelectedEnemy);
                    im = InputMode.Off;
                }
                if (input.IsKeyDown(Keys.Back))
                {
                    im = InputMode.ActionSelect;
                }
                return;
            }

            trun++;
            enemyManager.Update();
            //2017年1月12日（ホームズ）
            foreach (var p in players)
            {

            }
            controlFocus = (Player)players[0];
            im = InputMode.ActionSelect;
            
            //players.ForEach(n => ((Player)n).Battle(this));
            //以上
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
            if(im == InputMode.ActionSelect)
            {
                renderer.DrawTexture("puddle",
                    new Vector2(100 + ((int)actionSelector * 100), 300),
                    new Rectangle(0, 0, 64, 64));
            }
            else if(im == InputMode.TargetSelect)
            {
                renderer.DrawTexture("puddle",
                    new Vector2(100 + ((int)enemySelect * 100), 100),
                    new Rectangle(0, 0, 64, 64));
            }
        }


        /// <summary>
        /// エンドフラッグをとる
        /// </summary>
        /// <returns></returns>
        public bool IsEnd()
        {
            return endFlag;
        }

        //2017年1月12日（ホームズ）
        public EnemyManager EnemyManager
        {
            get { return enemyManager; }
        }
    }
}
