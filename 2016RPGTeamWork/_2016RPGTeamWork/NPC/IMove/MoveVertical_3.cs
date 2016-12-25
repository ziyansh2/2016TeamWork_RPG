///作成日：2016.12.20
///作成者：柏
///作成内容：縦移動クラス
///最後修正内容：。。
///最後修正者：。。
///最後修正日：。。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _2016RPGTeamWork.Def;
using _2016RPGTeamWork.Utility;
using Microsoft.Xna.Framework;

namespace _2016RPGTeamWork.NPC.IMove
{
    class MoveVertical_3 : MoveAble
    {
        public MoveVertical_3()
            :base(){
            velocity = new Vector2(0, Parameter.NPCSpeed);
            timer = new Timer(Parameter.TileSize * 3 / Parameter.NPCSpeed);
        }

    }
}
