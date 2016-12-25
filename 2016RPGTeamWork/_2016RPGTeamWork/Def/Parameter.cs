
using Microsoft.Xna.Framework;
///作成日：2016.12.13
///作成者：柏
///作成内容：常数の管理クラス
///最後修正内容：マップチップサイズ追加
///修正者：柏
///最後修正日：2016.12.20
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2016RPGTeamWork.Def
{
    static class Parameter
    {
        //以下、追加by　柏　2016.12.19
        public const int ScreenWidth = 1024;
        public const int ScreenHeight = 704;
        public const int MaxActionPercent = 100;

        //以下、追加by　柏　2016.12.20
        public const int TileSize = 64;
        public const int NPCSpeed = 5;
        public static readonly Vector2 TalkTextPosition = new Vector2(100, 500);
        public const int TalkTextHeight = 30;
        public const int TalkTextWidth = 20;
    }
}
