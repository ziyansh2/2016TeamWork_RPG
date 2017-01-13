///作成日：2016.12.13
///作成者：ホームズ
///作成内容：キャラクターの抽象クラス
///最後修正内容：あたり判定追加
///最後修正者：柏
///最後修正日：2016.1.11

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using _2016RPGTeamWork.Device;
using Microsoft.Xna.Framework;
using _2016RPGTeamWork.Def;

namespace _2016RPGTeamWork.GameObjects
{
    enum eAction
    {
        Attack,
        Defence,
        Escape,
        Magic,
        Trick,
    }

    abstract class Character
    {
        private CharacterInfo characterInfo;

        int hp; //残っているヒットポイント
        int mp; //残っている魔法ポイント

        int offenceModifier; //ゲーム中の攻撃力へのバフ・デバフの等
        int defenceModifier; //…防御力
        int moModifier; //…魔法攻撃力
        int mdModifier; //…魔法防御宇力
        int speedModifier; //…素早さ

        protected bool isDead;        //死亡フラグ    2017.1.9 by柏
        protected bool isEscape;      //逃走フラグ    2017.1.9 by柏
        protected bool isDefence;     //防御フラグ    2017.1.9 by柏
        protected static Random rnd = new Random();     //2017.1.9 by柏
        protected Vector2 position;   //Charaの位置(画像の中心)   2017.1.11 by柏

        public Character(CharacterInfo ci)
        {
            characterInfo = ci;
            hp = characterInfo.MaxHP;
            mp = characterInfo.MaxMP;
            isDead = false;
            isEscape = false;
            isDefence = false;
        }

        // by柏　2017.1.10
        public abstract void Update();
        // by柏　2017.1.10
        public abstract void Initialize();
        // by柏　2017.1.10
        public abstract void Draw(Renderer renderer);

        public void Damage(int amount) {
            if (isDefence) { amount /= 2; } //防御中ダメージ半減　by柏　2017.1.9
            isDefence = false;
            hp -= amount;
            HpClip();
        }


        /// <summary>
        /// 物理攻撃
        /// by柏　2017.1.9
        /// </summary>
        /// <param name="other">向こうのキャラ</param>
        protected virtual void Attack(Character other) {
            int damage = GetOffence - other.GetDefence;
            damage = damage > 0 ? damage : 1;
            other.Damage(damage);
        }

        // by柏　2017.1.9
        protected virtual void Magic(Character other) {

        }

        // by柏　2017.1.9
        protected virtual void Trick(Character other) {

        }

        /// <summary>
        /// 自分と向こうのレベルによって逃走できる比率確定し逃げる
        /// by柏　2017.1.9
        /// </summary>
        /// <param name="other">向こうのキャラ</param>
        protected virtual void Escape(Character other) {
            float canEscRadio = 1 - (other.GetLevel - GetLevel) * 0.1f;
            Math.Min(canEscRadio, 0.2f);
            Math.Max(canEscRadio, 0.8f);
            isEscape = rnd.Next(100) < canEscRadio * 100 ? true : false;
        }
        protected virtual void Defence(Character other) {
            isDefence = true;
        }


        /// <summary>
        /// ヒットポイントが最大値を超えたり、ゼロより少なくなったりしないようにするメソッド
        /// </summary>
        private void HpClip()
        {
            if (hp > GetMaxHP) hp = GetMaxHP;
            else if (hp < 0) hp = 0;
        }

        /// <summary>
        /// マナポイントが最大値を超えたり、ゼロより少なくなったりしないようにするメソッド
        /// </summary>
        private void MpClip()
        {
            if (mp > GetMaxMP) mp = GetMaxMP;
            else if (mp < 0) mp = 0;
        }

        public int GetMaxHP { get { return characterInfo.MaxHP; } }
        public int GetMaxMP { get { return characterInfo.MaxMP; } }
        public int GetOffence { get { return characterInfo.Offence; } }
        public int GetDefence { get { return characterInfo.Defence; } }
        public int GetMagicOffence { get { return characterInfo.MagicOffence; } }
        public int GetMagicDefence { get { return characterInfo.MagicDefence; } }
        public int GetSpeed { get { return characterInfo.Speed; } }


        // 2017.1.9 by柏
        public int GetLevel { get { return characterInfo.Level; } }

        //2017.1.12 by柏
        public Vector2 Position { get { return position; } }

        /// <summary>
        /// 自分の当たり範囲を出す　by柏　2017.1.11
        /// </summary>
        /// <returns></returns>
        public Rectangle GetRect() {
            int x = (int)(position.X);
            int y = (int)(position.Y);
            Rectangle thisRect = new Rectangle(x, y, Parameter.TileSize, Parameter.TileSize);
            return thisRect;
        }



    }
}
