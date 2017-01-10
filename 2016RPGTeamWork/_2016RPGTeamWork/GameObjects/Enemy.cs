///作成日：2016.12.14
///作成者：柏
///作成内容：敵クラス
///最後修正内容：敵のbattle行動完成
///最後修正者：柏
///最後修正日：2017.1.9

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
        private eEnemy enemyType;
        private Vector2 position;
        private List<Rectangle> resouseList;
        private List<Character> playerList;
        private eMagic_E magic;
        private eTrick_E trick;

        public Enemy(eEnemy enemyType, Vector2 position, CharacterInfo ci, EnemyRadio enemyRadio)
            : base(ci)
        {
            this.enemyRadio = enemyRadio;
            actionRadio = enemyRadio.GetActionRadio();
            this.enemyType = enemyType;
            this.position = position;
            resouseList = new List<Rectangle>();
            playerList = new List<Character>();
        }

        public override void Initialize() {
            for (int i = 0; i < 12; i++) {
                resouseList.Add( new Rectangle(i % 4, i / 4, Parameter.TileSize, Parameter.TileSize) );
            }
        }

        public override void Update() {
            if (playerList.Count == 0) { return; }
            Action(GetTarget(playerList));
        }


        public override void Draw(Renderer renderer) {
            renderer.DrawTexture("enemy", position, resouseList[(int)enemyType]);
        }

        private void Action(Character other) {
            int act = rnd.Next(Parameter.MaxActionPercent);
            switch (CheckAction(act)) {
                case eAction.Attack: Attack(other); break;
                case eAction.Defence: Defence(other); break;
                case eAction.Escape: Escape(other); break;
                case eAction.Magic: Magic(other); break;
                case eAction.Trick: Trick(other); break;
            }
        }

        public void SetMagic(eMagic_E magic) {
            this.magic = magic;
        }

        public void SetTrick(eTrick_E trick) {
            this.trick = trick;
        }

        public void GetPlayerList(List<Character> playerList) {
            this.playerList = playerList;
        }

        private Character GetTarget(List<Character> playerList) {
            if (playerList.Count == 0) { return null; }
            return playerList[rnd.Next(playerList.Count)];
        }

        private eAction CheckAction(int act) {
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


        protected override void Attack(Character other) {
            base.Attack(other);
        }

        protected override void Magic(Character other) {
            int m_offence = DataManager.EnemyMagicData[(int)magic, (int)eMTParameter.Offence];
            int m_magicOffence = DataManager.EnemyMagicData[(int)magic, (int)eMTParameter.MagicOffence];

            int damageOffence = m_offence == 0 ? 0 : GetOffence + m_offence - other.GetDefence;
            int damageMagicOffence = m_magicOffence == 0 ? 0 : GetMagicOffence + m_magicOffence - other.GetMagicDefence;

            other.Damage(damageOffence); 
            other.Damage(damageMagicOffence); 
        }

        protected override void Trick(Character other) {
            int t_offence = DataManager.EnemyTrickData[(int)magic, (int)eMTParameter.Offence];
            int t_magicOffence = DataManager.EnemyTrickData[(int)magic, (int)eMTParameter.MagicOffence];

            int damageOffence = t_offence == 0 ? 0 : GetOffence + t_offence - other.GetDefence;
            int damageMagicOffence = t_magicOffence == 0 ? 0 : GetMagicOffence + t_magicOffence - other.GetMagicDefence;

            other.Damage(damageOffence);
            other.Damage(damageMagicOffence);
        }

        protected override void Escape(Character other) {
            base.Escape(other);
        }

        protected override void Defence(Character other) {
            base.Defence(other);
        }


    }
}
