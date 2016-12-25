///作成日：2016.12.20
///作成者：柏
///作成内容：NPCクラス
///最後修正内容：。。
///最後修正者：。。
///最後修正日：。。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _2016RPGTeamWork.Utility;
using Microsoft.Xna.Framework;
using _2016RPGTeamWork.Device;

namespace _2016RPGTeamWork.NPC
{
    class NPC
    {
        private Range range;
        private Vector2 position;
        private Vector2 startPosition;
        private Vector2 velocity;
        public NPC(Vector2 position, Range range, MoveAble moveAble) {
            this.range = range;
            startPosition = position;
        }

        public void Initialize() {
            position = startPosition;
        }

        public void Update() { }


        public void Draw(Renderer renderer) { }

    }
}
