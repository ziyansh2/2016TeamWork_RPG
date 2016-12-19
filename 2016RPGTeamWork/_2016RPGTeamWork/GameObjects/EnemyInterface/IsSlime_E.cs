///作成日：2016.12.14
///作成者：柏
///作成内容：敵スライムのクラス
///最後修正内容：。。
///最後修正日：。。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using _2016RPGTeamWork.GameObjects.EnemyManager;
using _2016RPGTeamWork.GameObjects.EnemyManager.Magic_E_List;
using _2016RPGTeamWork.GameObjects.EnemyManager.Trick_E_List;

namespace _2016RPGTeamWork.GameObjects.EnemyInterface
{
    class IsSlime_E : IsEnemy
    {
        private MagicManager_E m_Manager;   //magicの管理クラスを宣言
        private TrickManager_E t_Manager;   //magicの管理クラスを宣言

        private Dictionary<eAction, int> actionRadio;   //行動の比率管理用

        private Dictionary<eMagic_E, Magic_E> magicList;   //使えるマジックの管理用
        private Dictionary<eTrick_E, Trick_E> trickList;   //使える技の管理用

        public IsSlime_E()
        {
            actionRadio = new Dictionary<eAction, int>();
            magicList = new Dictionary<eMagic_E, Magic_E>();
            trickList = new Dictionary<eTrick_E, Trick_E>();
        }

        public void Initialize()
        {
            magicList.Add(eMagic_E.magic1, new Magic1());
            trickList.Add(eTrick_E.trick1, new Trick1());

            //全部のActの比の合計は100
            actionRadio[eAction.Attack] = 20;
            actionRadio[eAction.Defence] = 20;
            actionRadio[eAction.Escape] = 20;
            actionRadio[eAction.Magic] = 20;
            actionRadio[eAction.Trick] = 20;
        }

        public void Update()
        {

        }

        public void Draw()
        {

        }


        public void Attack(Character this_E, Character other)
        {

        }

        public void Defence(Character this_E, Character other)
        {

        }

        public void Magic(Character thisE, Character other)
        {

            int _offence = magicList[eMagic_E.magic1].Offence;
            int _defence = magicList[eMagic_E.magic1].Defence;
            int _magicOffence = magicList[eMagic_E.magic1].MagicOffence;
            int _magicDefence = magicList[eMagic_E.magic1].MagicDefence;
            int _speed = magicList[eMagic_E.magic1].Speed;
        }

        public void Trick(Character this_E, Character other)
        {

        }

        public void Escape(Character this_E, Character other)
        {

        }

        public Dictionary<eAction, int> GetActionRadio()
        {
            return actionRadio;
        }
    }
}
