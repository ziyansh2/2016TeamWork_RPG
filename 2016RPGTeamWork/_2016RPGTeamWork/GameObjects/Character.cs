///作成日：2016.12.13
///作成者：ホームズ
///作成内容：キャラクターの抽象クラス
///最後修正内容：マナポイントに範囲外の値を防ぐメソッドの追加、各メソッドに説明の追加
///最後修正日：2016.12.19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2016RPGTeamWork.GameObjects
{
    public abstract class Character
    {
        private CharacterInfo characterInfo;

        int hp; //残っているヒットポイント
        int mp; //残っている魔法ポイント

        int offenceModifier; //ゲーム中の攻撃力へのバフ・デバフの等
        int defenceModifier; //…防御力
        int moModifier; //…魔法攻撃力
        int mdModifier; //…魔法防御宇力
        int speedModifier; //…素早さ

        public Character(CharacterInfo ci)
        {
            characterInfo = ci;
            hp = characterInfo.MaxHP;
            mp = characterInfo.MaxMP;
        }

        public void Damage(int amount)
        {
            hp -= amount;
            HpClip();
        }

        /// <summary>
        /// ヒットポイントが最大値を超えたり、ゼロより少なくなったりしないようにするメソッド
        /// </summary>
        private void HpClip()
        {
            if (hp > MaxHP) hp = MaxHP;
            else if (hp < 0) hp = 0;
        }

        /// <summary>
        /// マナポイントが最大値を超えたり、ゼロより少なくなったりしないようにするメソッド
        /// </summary>
        private void MpClip()
        {
            if (mp > MaxMP) mp = MaxMP;
            else if (mp < 0) mp = 0;
        }

        public int MaxHP { get { return characterInfo.MaxHP; } }
        public int MaxMP { get { return characterInfo.MaxMP; } }
        public int Offence { get { return characterInfo.Offence; } }
        public int Defence { get { return characterInfo.Defence; } }
        public int MagicOffence { get { return characterInfo.MagicOffence; } }
        public int MagicDefence { get { return characterInfo.MagicDefence; } }
        public int Speed { get { return characterInfo.Speed; } }
    }
}
