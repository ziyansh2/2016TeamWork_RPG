///作成日：2016.12.13
///作成者：ホームズ
///作成内容：キャラクターの基礎情報を格納するクラス
///最後修正内容：各メソッド、アクセスモディファイヤに説明を追加しました。
///最後修正日：2016.12.19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2016RPGTeamWork.GameObjects
{
    /// <summary>
    /// このクラスは、キャラクター事のゲーム中に変わらない値を格納します。
    /// </summary>
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
        int level; //レベル

        /// <summary>
        /// コンストラクター（デフォルトレベル＝１）
        /// </summary>
        /// <param name="name">キャラ名</param>
        /// <param name="maxHP">最大HP</param>
        /// <param name="maxMP">最大MP</param>
        /// <param name="offence">攻撃（物理用）</param>
        /// <param name="defence">防御（物理用）</param>
        /// <param name="magicOffence">攻撃（魔法用）</param>
        /// <param name="magicDefence">防御（魔法用）</param>
        /// <param name="speed">素早さ</param>
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

        /// <summary>
        /// コンストラクター（初期レベルを設定できるオーバーロード）
        /// </summary>
        /// <param name="name">キャラ名</param>
        /// <param name="maxHP">最大HP</param>
        /// <param name="maxMP">最大MP</param>
        /// <param name="offence">攻撃（物理用）</param>
        /// <param name="defence">防御（物理用）</param>
        /// <param name="magicOffence">攻撃（魔法用）</param>
        /// <param name="magicDefence">防御（魔法用）</param>
        /// <param name="speed">素早さ</param>
        /// <param name="level">レベル</param>
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

        /// <summary>
        /// 最大ヒットポイントのアクセスモディファイヤ
        /// </summary>
        public int MaxHP
        {
            get { return maxHP; }
            set { maxHP = value; }
        }
        /// <summary>
        /// 最大マナポイントのアクセスモディファイヤ
        /// </summary>
        public int MaxMP
        {
            get { return maxMP; }
            set { maxMP = value; }
        }
        /// <summary>
        /// 基礎の（物理）攻撃力のアクセスモディファイヤ
        /// </summary>
        public int Offence
        {
            get { return offence; }
            set { offence = value; }
        }
        /// <summary>
        /// 基礎の（物理）防御力のアクセスモディファイヤ
        /// </summary>
        public int Defence
        {
            get { return defence; }
            set { defence = value; }
        }
        /// <summary>
        /// 基礎の魔法攻撃力のアクセスモディファイヤ
        /// </summary>
        public int MagicOffence
        {
            get { return magicOffence; }
            set { magicOffence = value; }
        }
        /// <summary>
        /// 基礎の魔法防御力のアクセスモディファイヤ
        /// </summary>
        public int MagicDefence
        {
            get { return magicDefence; }
            set { magicDefence = value; }
        }
        /// <summary>
        /// 基礎の素早さのアクセスモディファイヤ
        /// </summary>
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }
}
