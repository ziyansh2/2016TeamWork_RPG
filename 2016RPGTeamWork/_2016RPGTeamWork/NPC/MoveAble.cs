///作成日：2016.12.20
///作成者：柏
///作成内容：NPCの移動を管理するインターフェースクラス
///最後修正内容：。。
///最後修正者：。。
///最後修正日：。。

using _2016RPGTeamWork.Utility;
using Microsoft.Xna.Framework;

namespace _2016RPGTeamWork.NPC
{
    abstract class MoveAble
    {
        protected Vector2 velocity;
        protected Timer timer;

        public MoveAble() {
            velocity = Vector2.Zero;
            timer = new Timer();
        }
        public virtual Vector2 Move() {
            timer.Update();
            if (timer.IsTime)
            {
                timer.Initialize();
                Turn();
            }
            return velocity;
        }
        protected virtual void Turn() {
            velocity *= -1;
        }

        public Vector2 Velocity {
            get { return velocity; }
        }
    }
}
