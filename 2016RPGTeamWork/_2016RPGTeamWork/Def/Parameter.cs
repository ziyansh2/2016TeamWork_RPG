///作成日：2016.12.13
///作成者：柏
///作成内容：常数の管理クラス
///最後修正内容：描画中心調整用常数を用意する
///修正者：柏
///最後修正日：2017.1.10

using Microsoft.Xna.Framework;

namespace _2016RPGTeamWork.Def
{
    static class Parameter
    {
        //以下、追加 by柏 2016.12.19
        public const int ScreenWidth = 1024;
        public const int ScreenHeight = 704;
        public const int MaxActionPercent = 100;

        //以下、追加 by柏 2016.12.20
        public const int TileSize = 64;
        public static readonly Vector2 TalkTextPosition = new Vector2(100, 500);
        public const int TalkTextHeight = 30;
        public const int TalkTextWidth = 20;

        public const int NPCSpeed = 2;  //2016.1.8 by柏 npc速度調整
        public const int PlayerSpeed = 4; //2016.1.10 by柏 player速度追加(あたり判定に合わせて64の約数にする)

        //2016.1.10 by柏 描画中心を調整するため
        public static readonly Vector2 CharaCenterOffset = new Vector2(-TileSize / 2, -TileSize / 2);
    }
}
