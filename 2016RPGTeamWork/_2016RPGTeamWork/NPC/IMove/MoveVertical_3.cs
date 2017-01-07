///作成日：2016.12.20
///作成者：柏
///作成内容：縦移動クラス
///最後修正内容：移動パタン調整
///最後修正者：柏
///最後修正日：2017.1.8

using _2016RPGTeamWork.Def;
using _2016RPGTeamWork.Utility;
using Microsoft.Xna.Framework;

namespace _2016RPGTeamWork.NPC.IMove
{
    class MoveVertical_3 : MoveAble
    {
        public MoveVertical_3()
            : base() {
            velocity = new Vector2(0, Parameter.NPCSpeed);
            float limitTime = Parameter.TileSize * 3 * 2 / Parameter.NPCSpeed / 60;
            timer = new Timer(limitTime);
            timer.SetCurrentTime(limitTime / 2);
        }
    }
}
