///作成日：2016.12.20
///作成者：柏
///作成内容：NPCクラス
///最後修正内容：アニメーション、　セリフ、位置、移動の情報をもって生成する
///最後修正者：柏
///最後修正日：2017.1.8

using Microsoft.Xna.Framework;

using _2016RPGTeamWork.Utility;
using _2016RPGTeamWork.Device;

namespace _2016RPGTeamWork.NPC
{
    class NoPlayChara
    {
        private Range dialogueCor;  //セリフ内容保存
        private Vector2 position;
        private Vector2 startPosition;
        private Motion motion;      //アニメーション用
        private MoveAble moveAble;   //移動パタン（移動無、左右、上下など）

        public NoPlayChara(Vector2 position, Range dialogueCor, MoveAble moveAble) {
            this.dialogueCor = dialogueCor;
            startPosition = position;
            this.moveAble = moveAble;
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
            position += moveAble.GetVelocity;
            moveAble.Move();
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer">描画管理</param>
        public void Draw(Renderer renderer, Vector2 offset) {
            renderer.DrawTexture("puddle", position + offset, motion.DrawRange());
        }

    }
}
