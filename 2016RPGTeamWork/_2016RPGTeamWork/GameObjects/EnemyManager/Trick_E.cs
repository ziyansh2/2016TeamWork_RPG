using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2016RPGTeamWork.GameObjects.EnemyManager
{
    abstract class Trick_E
    {
        protected int offence;        //攻撃力
        protected int defence;        //防御力
        protected int magicOffence;   //魔法の威力
        protected int magicDefence;   //魔法に対する防御
        protected int speed;          //素早さ
        public Trick_E()
        {
            offence = 0;
            defence = 0;
            magicOffence = 0;
            magicDefence = 0;
            speed = 0;
        }


        public int Offence
        {
            get { return offence; }
        }

        public int Defence
        {
            get { return defence; }
        }

        public int MagicOffence
        {
            get { return magicDefence; }
        }

        public int MagicDefence
        {
            get { return magicDefence; }
        }

        public int Speed
        {
            get { return speed; }
        }


    }
}
