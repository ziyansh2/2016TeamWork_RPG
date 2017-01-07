///作成日：2016.12.14
///作成者：柏
///作成内容：敵クラス
///最後修正内容：描画できた
///最後修正者：柏
///最後修正日：2017.1.8

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using _2016RPGTeamWork.Def;
using _2016RPGTeamWork.GameObjects.EnemyManagers;
using _2016RPGTeamWork.Device;
using Microsoft.Xna.Framework;

namespace _2016RPGTeamWork.GameObjects
{
    

    class Enemy : Character
    {
        private EnemyRadio enemyRadio;
        private Dictionary<eAction, int> actionRadio;
        private static Random rnd = new Random();
        private eEnemy enemyType;
        private Vector2 position;
        private List<Rectangle> resouseList;

        public Enemy(eEnemy enemyType, Vector2 position, CharacterInfo ci, EnemyRadio enemyRadio)
            : base(ci)
        {
            this.enemyRadio = enemyRadio;
            actionRadio = enemyRadio.GetActionRadio();
            this.enemyType = enemyType;
            this.position = position;
            resouseList = new List<Rectangle>();
        }



        public void Initialize() {
            for (int i = 0; i < 12; i++) {
                resouseList.Add( new Rectangle(i % 4, i / 4, Parameter.TileSize, Parameter.TileSize) );
            }
        }

        public void Update()
        {
            
        }

        public void Draw(Renderer renderer)
        {
            renderer.DrawTexture("enemy", position, resouseList[(int)enemyType]);
        }

        public void Action(Character other)
        {
            int act = rnd.Next(Parameter.MaxActionPercent);
            switch (CheckAction(act))
            {
                case eAction.Attack: Attack(this, other); break;
                case eAction.Defence: Defence(this, other); break;
                case eAction.Escape: Escape(this, other); break;
                case eAction.Magic: Magic(this, other); break;
                case eAction.Trick: Trick(this, other); break;
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


        private void Attack(Character this_E, Character other) { }
        private void Magic(Character this_E, Character other) { }
        private void Trick(Character this_E, Character other) { }
        private void Escape(Character this_E, Character other) { }
        private void Defence(Character this_E, Character other) { }


    }
}
