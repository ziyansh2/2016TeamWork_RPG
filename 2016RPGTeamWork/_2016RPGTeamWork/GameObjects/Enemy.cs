///作成日：2016.12.14
///作成者：柏
///作成内容：敵クラス
///最後修正内容：。。
///最後修正日：。。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using _2016RPGTeamWork.GameObjects.EnemyInterface;
using _2016RPGTeamWork.Def;

namespace _2016RPGTeamWork.GameObjects
{
    class Enemy : Character
    {
        private IsEnemy isEnemy;
        private Dictionary<eAction, int> actionRadio;
        private static Random rnd = new Random();

        public Enemy(CharacterInfo ci, IsEnemy isEnemy)
            : base(ci)
        {
            this.isEnemy = isEnemy;
            actionRadio = isEnemy.GetActionRadio();
        }

        public void Initialize()
        {
            isEnemy.Initialize();
        }

        public void Update()
        {
            isEnemy.Update();
        }

        public void Draw()
        {
            isEnemy.Draw();
        }

        public void Action(Character other)
        {
            int act = rnd.Next(Parameter.MaxActionPercent);
            switch (CheckAction(act))
            {
                case eAction.Attack: isEnemy.Attack(this, other); break;
                case eAction.Defence: isEnemy.Defence(this, other); break;
                case eAction.Escape: isEnemy.Escape(this, other); break;
                case eAction.Magic: isEnemy.Magic(this, other); break;
                case eAction.Trick: isEnemy.Trick(this, other); break;
            }
        }

        private eAction CheckAction(int act)
        {
            int attack = actionRadio[eAction.Attack];
            int defence = attack + actionRadio[eAction.Defence];
            int escape = defence + actionRadio[eAction.Escape];
            int magic = escape + actionRadio[eAction.Magic];
            //int trick = magic + actionRadio[eAction.Trick];

            if (act > magic) { return eAction.Trick; }
            if (act > escape) { return eAction.Magic; }
            if (act > defence) { return eAction.Escape; }
            if (act > attack) { return eAction.Defence; }
            return eAction.Attack;
        }
    }
}
