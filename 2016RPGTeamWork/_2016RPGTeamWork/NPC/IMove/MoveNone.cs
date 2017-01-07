///作成日：2017.1.8
///作成者：柏
///作成内容：移動しない
///最後修正内容：。。
///最後修正者：。。
///最後修正日：。。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using _2016RPGTeamWork.Utility;
using Microsoft.Xna.Framework;

namespace _2016RPGTeamWork.NPC.IMove
{
    class MoveNone : MoveAble
    {
        public MoveNone()
            :base(){
            velocity = new Vector2(0, 0);
            timer = new Timer(0);
        }
    }
}
