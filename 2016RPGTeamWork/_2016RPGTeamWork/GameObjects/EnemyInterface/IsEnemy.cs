///作成日：2016.12.14
///作成者：柏
///作成内容：敵のインターフェースクラス
///最後修正内容：。。
///最後修正日：。。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2016RPGTeamWork.GameObjects.EnemyInterface
{
    enum eMagic_E
    {
        magic1 = 1,
        magic2,
        magic3,
    }

    enum eTrick_E
    {
        trick1 = 1,
        trick2,
        trick3,
    }

    enum eAction
    {
        Attack,
        Defence,
        Escape,
        Magic,
        Trick,
    }

    interface IsEnemy
    {
        void Initialize();
        void Update();
        void Draw();

        void Attack(Character this_E, Character other);
        void Magic(Character this_E, Character other);
        void Trick(Character this_E, Character other);
        void Escape(Character this_E, Character other);
        void Defence(Character this_E, Character other);
        Dictionary<eAction, int> GetActionRadio();
    }
}
