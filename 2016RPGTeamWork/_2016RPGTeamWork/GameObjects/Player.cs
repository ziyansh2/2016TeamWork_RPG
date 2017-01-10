///作成日：2016.12.19
///作成者：ホームズ
///作成内容：プレイヤークラス
///最後修正内容：移動、描画、アニメーション、バトル
///最後修正者：柏
///最後修正日：2017.1.10

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using _2016RPGTeamWork.Def;
using _2016RPGTeamWork.Device;
using _2016RPGTeamWork.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace _2016RPGTeamWork.GameObjects
{
    class Player : Character
    {
        private Motion motion;
        private Vector2 position;
        private Vector2 battlePosition; //by柏　戦闘用追加
        private InputState input;
        private bool isBattle; //by柏　戦闘用追加

        public Player(CharacterInfo ci, GameDevice gameDevice) : base(ci)
        {
            position = Vector2.Zero;
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

        //by柏　戦闘　2017.1.10
        public void Battle() {

        }

        /// <summary>
        /// 移動　by柏　2017.1.10
        /// </summary>
        /// <param name="keyState">キーボード入力</param>
        private void Move(KeyboardState keyState) {
            if (keyState.IsKeyDown(Keys.Right)) {
                position.X += 3;
            }
            else if (keyState.IsKeyDown(Keys.Left)) {
                position.X -= 3;
            }
            else if (keyState.IsKeyDown(Keys.Up)) {
                position.Y -= 3;
            }
            else if (keyState.IsKeyDown(Keys.Down)) {
                position.Y += 3;
            }
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
        public override void Draw(Renderer renderer)
        {
            if (isBattle) {
                renderer.DrawTexture("player1", battlePosition, motion.DrawRange());
                return;
            }
            renderer.DrawTexture("player1", position, motion.DrawRange());
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
    }
}
