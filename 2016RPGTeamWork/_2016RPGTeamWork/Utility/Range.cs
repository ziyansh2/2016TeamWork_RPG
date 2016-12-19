///作成日：2016.12.19
///作成者：柏
///作成内容：アニメーション描画範囲管理用
///最後修正内容：。。
///最後修正者：。。
///最後修正日：。。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2016RPGTeamWork.Utility
{
    class Range
    {
        private int first;
        private int end;
        public Range(int first,int end) {
            this.first = first;
            this.end = end;
        }

        /// <summary>
        /// 指定された番号は範囲内かどうか
        /// </summary>
        /// <param name="num">指定の番号</param>
        /// <returns></returns>
        public bool IsIn(int num) {
            return num >= first && num <= end;
        }

        /// <summary>
        ///生成されたRangeは違法かどうか 
        /// </summary>
        /// <returns></returns>
        public bool OutOfRange() {
            return first > end;
        }

        /// <summary>
        /// 指定された番号は違法かどうか
        /// </summary>
        public bool OutOfRange(int num) {
            return !IsIn(num);
        }

        /// <summary>
        /// 最小番号を出す
        /// </summary>
        public int First {
            get { return first; }
        }

        /// <summary>
        /// 最大番号を出す
        /// </summary>
        public int End {
            get{ return end; }
        }

    }
}
