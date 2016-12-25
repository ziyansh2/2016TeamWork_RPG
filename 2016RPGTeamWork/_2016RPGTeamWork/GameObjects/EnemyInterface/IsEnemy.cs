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
        Magic0,
        Magic1,
        Magic2,
        Magic3,
        Magic4,
        Magic5,
        Magic6,
        Magic7,
        Magic8,
        Magic9,
    }

    enum eTrick_E
    {
        Trick0,
        Trick1,
        Trick2,
        Trick3,
        Trick4,
        Trick5,
        Trick6,
        Trick7,
        Trick8,
        Trick9,
    }

    enum eAction
    {
        Attack,
        Defence,
        Escape,
        Magic,
        Trick,
    }

    enum eMTParameter {
        Offence,
        Defence,
        MagicOffence,
        MagicDefence,
        Speed,
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
