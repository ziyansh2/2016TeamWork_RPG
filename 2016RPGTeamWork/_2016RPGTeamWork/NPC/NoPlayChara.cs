﻿///作成日：2016.12.20
///作成者：柏
///作成内容：NPCクラス
///最後修正内容：アニメーション、　セリフ、位置、移動の情報をもって生成する
///最後修正者：柏
///最後修正日：2017.1.8

using Microsoft.Xna.Framework;

using _2016RPGTeamWork.Utility;
using _2016RPGTeamWork.Device;
using _2016RPGTeamWork.Def;

namespace _2016RPGTeamWork.NPC
{
    class NoPlayChara
    {
        private Range dialogueCor;  //セリフ内容保存
        private Vector2 position;
        private Vector2 startPosition;
        private Motion motion;      //アニメーション用
        private MoveAble moveAble;   //移動パタン（移動無、左右、上下など）
        private bool isMove;
        private Timer reStartMove;

        public NoPlayChara(Vector2 position, Range dialogueCor, MoveAble moveAble) {
            this.dialogueCor = dialogueCor;
            startPosition = position;
            this.moveAble = moveAble;
            reStartMove = new Timer(1.0f);
            reStartMove.SetCurrentTime(1.0f);
            isMove = true;
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize() {
            position = startPosition;

            //アニメーション用クラスを生成してから初期化
            motion = new Motion();
            for (int i = 0; i < 6; i++) {
                motion.Add(i, new Rectangle(64 * i, 0, 64, 64));
            }
            motion.Initialize(new Range(0, 5), new Timer(0.1f));
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update() {
            motion.Update();    //アニメーション更新
            reStartMove.Update();

            if (!isMove) { return; }
            if (reStartMove.IsTime) {
                position += moveAble.Move();
            }
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer">描画管理</param>
        public void Draw(Renderer renderer, Vector2 offset) {
            renderer.DrawTexture("puddle", position + offset, motion.DrawRange());
        }

        public Rectangle GetRect(Vector2 offset) {
            int x = (int)(position.X + offset.X);
            int y = (int)(position.Y + offset.Y);
            Rectangle thisRect = new Rectangle(x, y, Parameter.TileSize, Parameter.TileSize);
            return thisRect;
        }

        public bool IsMove {
            set {
                if (isMove == value) { return; }
                if (value == true) { reStartMove.Initialize(); }
                isMove = value;
            }
        }

        public Vector2 Velocity {
            get { return moveAble.Velocity; }
        }
        public Vector2 Position {
            get { return position; }
        }
    }
}
