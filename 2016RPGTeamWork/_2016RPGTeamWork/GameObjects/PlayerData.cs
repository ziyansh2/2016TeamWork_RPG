///制作日：2016.12.20
///制作者：ホームズ
///政策内容：プレイヤー情報（静的の実体）
///最後修正内容：…
///最後修正日：…
///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2016RPGTeamWork.GameObjects
{
    static class PlayerData
    {
        static CharacterInfo P1 =
            new CharacterInfo("Player 1", 100, 100, 10, 10, 10, 10, 10);

        static CharacterInfo P2 =
            new CharacterInfo("Player 2", 70, 90, 16, 7, 9, 8, 16);

        static CharacterInfo P3 =
            new CharacterInfo("Player 3", 125, 110, 8, 12, 9, 15, 5);

        static CharacterInfo P4 =
            new CharacterInfo("Player 4", 90, 150, 4, 6, 20, 14, 12);
    }
}
