///作成日：2016.12.19
///作成者：ホームズ
///作成内容：プレイヤークラス
///最後修正内容：npcとのあたり判定実装
///最後修正者：柏
///最後修正日：2017.1.18

using _2016RPGTeamWork.Def;
using _2016RPGTeamWork.Device;
using _2016RPGTeamWork.NPC;
using _2016RPGTeamWork.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace _2016RPGTeamWork.GameObjects
{
    class Player : Character
    {
        private Motion motion;
        private Vector2 position;
        private Vector2 battlePosition; //by柏　戦闘用追加
        private Vector2 direction;   //by柏　移動用追加
        private InputState input;
        private bool isBattle; //by柏　戦闘用追加
        private int[,] mapData; //by柏　マップとの当たり判定用
        private List<NoPlayChara> npcList;  //by 柏　npcとの当たり判定用

        public Player(CharacterInfo ci, GameDevice gameDevice) : base(ci)
        {
            position = new Vector2(100, 100);
            direction = Vector2.Zero;
            input = gameDevice.GetInputState();
            isBattle = false;
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public override void Initialize()
        {
            //2017.1.10 by柏　アニメーション関連
            motion = new Motion();
            for (int i = 0; i < 12; i++) {
                Rectangle rect = new Rectangle((i % 3) * Parameter.TileSize, (i / 3) * Parameter.TileSize, Parameter.TileSize, Parameter.TileSize);
                motion.Add(i, rect);
            }
            motion.Initialize(new Range(0, 2), new Timer(0.2f));
        }

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            //2017.1.10 by柏　移動更新
            KeyboardState keyState = Keyboard.GetState();
            Move(keyState);

            //2017.1.10 by柏　アニメーション更新
            motion.Update(); 
        }

        /// <summary>
        /// npcList獲得
        /// </summary>
        /// <param name="npcList">npc管理用リスト</param>
        public void SetNPC(List<NoPlayChara> npcList) { this.npcList = npcList; }


        /// <summary>
        /// NPCとのあたり判定　by柏　2017.1.18
        /// </summary>
        /// <returns></returns>
        public bool NPCCollision()
        {
            bool isCollision = false;   //playerとの当たり判定用
            bool isNPC = false;     //npcはplayerの1.5マス範囲内に入ったかどうかチェック用
            int size = Parameter.TileSize;
            int x = (int)(position.X - size / 2);
            int y = (int)(position.Y - size / 2);
            Rectangle checkRect = new Rectangle(x, y, size * 2, size * 2);
            Vector2 velocity = direction * Parameter.PlayerSpeed;

            //player周り2マス以内のnpcをとる
            List<NoPlayChara> checkNPC = npcList.FindAll(n =>
            n.Position.X < position.X + size * 2 &&
            n.Position.X > position.X - size * 2 &&
            n.Position.Y < position.Y + size * 2 &&
            n.Position.Y > position.Y - size * 2
            );

            foreach (var n in checkNPC) {
                //playerとのあたり判定
                isCollision = isCollision ? true : Method.IsCollision(GetRect(position + velocity), n.GetRect(n.Velocity));

                //npcはplayerの1.5マス範囲内に入ると動きが止まる
                isNPC = isNPC ? true : Method.IsCollision(checkRect, n.GetRect(n.Velocity));
                n.IsMove = !isNPC;
            }
            return isCollision;
        }




        /// <summary>
        /// マップとのあたり判定　by柏　2017.1.14
        /// </summary>
        /// <param name="direction">移動方向取得</param>
        /// <returns></returns>
        public bool StageCollision(Vector2 direction) {
            int size = Parameter.TileSize;
            Vector2 velocity = direction * Parameter.PlayerSpeed;
            Vector2 centerOffset = new Vector2(Parameter.TileSize / 2, Parameter.TileSize / 2);
            Vector2 mapXY = Method.GetMapXY(position + centerOffset);
            int otherX = (int)mapXY.X + (int)direction.X;
            int otherY = (int)mapXY.Y + (int)direction.Y;
            Rectangle other;

            if (!Method.IsInStage(otherX, otherY, mapData)) { return true ; }
            if (direction.X != 0) {
                for (int i = otherY - 1; i <= otherY + 1; i++) {
                    if (mapData[i, otherX] > 384) {
                        other = new Rectangle(otherX * size, i * size, size, size);
                        if (Method.IsCollision(GetRect(position + velocity), other)) { return true; }
                    }
                }
            }
            else if (direction.Y != 0) {
                for (int i = otherX - 1; i <= otherX + 1; i++) {
                    if (mapData[otherY, i] > 384) {
                        other = new Rectangle(i * size, otherY * size, size, size);
                        if (Method.IsCollision(GetRect(velocity + position), other)) { return true; }
                    }
                }
            }
            return false;
        }


        //by柏　戦闘　2017.1.10
        public void Battle(Scene.Battle b) {
            //2017年1月12日（ホームズ）

            //List<Enemy> enemyList = b.EnemyManager.GetEnemyList();
            //if (enemyList.Count == 0) return;
            //不要かな…？
        }

        /// <summary>
        /// 移動　by柏　2017.1.10
        /// </summary>
        /// <param name="keyState">キーボード入力</param>
        private void Move(KeyboardState keyState) {
            if (keyState.IsKeyDown(Keys.Right)) {
                direction = StageCollision(new Vector2( 1, 0)) ? Vector2.Zero : new Vector2( 1, 0);
            }
            else if (keyState.IsKeyDown(Keys.Left)) {
                direction = StageCollision(new Vector2(-1, 0)) ? Vector2.Zero : new Vector2(-1, 0);
            }
            else if (keyState.IsKeyDown(Keys.Up)) {
                direction = StageCollision(new Vector2(0, -1)) ? Vector2.Zero : new Vector2(0, -1);
            }
            else if (keyState.IsKeyDown(Keys.Down)) {
                direction = StageCollision(new Vector2(0,  1)) ? Vector2.Zero : new Vector2(0,  1);
            }
            else { direction = Vector2.Zero; }

            if (NPCCollision()) { direction = Vector2.Zero; }
            position += direction * Parameter.PlayerSpeed;
        }

        /// <summary>
        /// 戦闘コマンドによって行動　by柏　2017.1.10
        /// </summary>
        /// <param name="action">コマンド</param>
        /// <param name="other">対象</param>
        public void Action(eAction action, Character other) {
            switch (action) {
                case eAction.Attack: Attack(other); break;
                case eAction.Defence: Defence(other); break;
                case eAction.Escape: Escape(other); break;
                case eAction.Magic: Magic(other); break;
                case eAction.Trick: Trick(other); break;
            }
        }

        /// <summary>
        /// 描画
        /// </summary>
        public override void Draw(Renderer renderer, Vector2 offset)
        {
            if (isBattle) {
                renderer.DrawTexture("player1", battlePosition, motion.DrawRange());
                return;
            }
            renderer.DrawTexture("player1", position + offset, motion.DrawRange());
        }

        /// <summary>
        /// バトルフラグget、set
        /// </summary>
        public bool IsBattle {
            get { return isBattle; }
            set { isBattle = value; }
        }

        public void SetBattlePosition(int index) {
            battlePosition = new Vector2(200, 500);
            int offsetX = index * 200;
            battlePosition.X += offsetX;
        }

        /// <summary>
        /// 位置の取得　by柏　2017.1.10
        /// </summary>
        public Vector2 Position { get { return position; } }

        public Vector2 GetDirection { get { return direction; } }

        public void SetMapData(int[,] mapData) {
            this.mapData = mapData;
        }

    }
}
