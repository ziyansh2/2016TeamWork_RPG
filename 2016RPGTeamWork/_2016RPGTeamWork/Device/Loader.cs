///作成日：2016.12.19
///作成者：岡本
///作成内容：リソースの読み込み親クラス
///最後修正内容：注釈追加
///最後修正者：柏
///最後修正日：2016.12.19

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2016RPGTeamWork.Device
{
    abstract class Loader
    {
        protected string[,] resources;//リソースアセット名群
        protected int counter;//カウンタ
        protected int maxNum;//リソース最大数
        protected bool endFlag;//終了フラグ

        public Loader(string[,] resouces)
        {
            this.resources = resouces;
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            counter = 0;
            endFlag = false;
            maxNum = 0;
            if (resources != null)
            {
                maxNum = resources.GetLength(0);
            }
        }

        /// <summary>
        /// リソースの数を出す
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return maxNum;
        }

        /// <summary>
        /// 今ロード中のリソースの番号
        /// </summary>
        /// <returns></returns>
        public int CurrentCount()
        {
            return counter;
        }

        /// <summary>
        /// ロード完了かどうか
        /// </summary>
        /// <returns></returns>
        public bool IsEnd()
        {
            return endFlag;
        }

        /// <summary>
        /// 抽象更新メソッド
        /// </summary>
        public abstract void Update();
    }
}
