using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2016RPGTeamWork.GameObjects
{
    public struct CharacterInfo
    {
        string name; //名前
        int maxHP; //最高ヒットポイント
        int maxMP; //最高魔法ポイント
        int offence; //攻撃力
        int defence; //防御力
        int magicOffence; //魔法の威力
        int magicDefence; //魔法に対する防御
        int speed; //素早さ
        int level;

        public CharacterInfo(string name, int maxHP, int maxMP, int offence, int defence, int magicOffence, int magicDefence, int speed)
        {
            this.name = name;
            this.maxHP = maxHP;
            this.maxMP = maxMP;
            this.offence = offence;
            this.defence = defence;
            this.magicOffence = magicOffence;
            this.magicDefence = magicDefence;
            this.speed = speed;
            level = 1;
        }

        public CharacterInfo(string name, int maxHP, int maxMP, int offence, int defence, int magicOffence, int magicDefence, int speed, int level)
        {
            this.name = name;
            this.maxHP = maxHP;
            this.maxMP = maxMP;
            this.offence = offence;
            this.defence = defence;
            this.magicOffence = magicOffence;
            this.magicDefence = magicDefence;
            this.speed = speed;
            this.level = level;
        }

        public int MaxHP
        {
            get { return maxHP; }
            set { maxHP = value; }
        }
        public int MaxMP
        {
            get { return maxMP; }
            set { maxMP = value; }
        }
        public int Offence
        {
            get { return offence; }
            set { offence = value; }
        }
        public int Defence
        {
            get { return defence; }
            set { defence = value; }
        }
        public int MagicOffence
        {
            get { return magicOffence; }
            set { magicOffence = value; }
        }
        public int MagicDefence
        {
            get { return magicDefence; }
            set { magicDefence = value; }
        }
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }
}
