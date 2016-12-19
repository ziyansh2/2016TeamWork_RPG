///作成日：2016.12.19
///作成者：柏
///作成内容：アニメーション用
///最後修正内容：。。
///最後修正者：。。
///最後修正日：。。
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _2016RPGTeamWork.Utility;
using Microsoft.Xna.Framework;

namespace _2016RPGTeamWork.Device
{
    class Motion
    {
        private Range range;    //アニメーション範囲管理用
        private Timer timer;
        private int motionNum;  //今の描画番号
        private bool isRoll;
        private Dictionary<int, Rectangle> motions;     //アニメーション範囲などの情報の保存管理

        public Motion() {
            motions = new Dictionary<int, Rectangle>();
            Initialize(new Range(0, 0), new Timer(0.2f));
            isRoll = true;
        }

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="range">アニメーション範囲</param>
        /// <param name="timer">タイマ</param>
        public void Initialize(Range range, Timer timer) {
            this.range = range;
            this.timer = timer;
            motionNum = range.First;
        }

        /// <summary>
        /// 画像のカットを追加
        /// </summary>
        /// <param name="index">番号</param>
        /// <param name="rect">画像のカット情報</param>
        public void Add(int index, Rectangle rect) {
            if (motions.ContainsKey(index)) { return; }
            motions.Add(index, rect);
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update() {
            if (range.OutOfRange()) { return; }
            timer.Update();

            if (!timer.IsTime) { return; }
            UpdateMotion();
            timer.Initialize();
        }

        /// <summary>
        /// アニメーション描画番号の更新
        /// </summary>
        public void UpdateMotion() {
            motionNum++;
            if (range.IsIn(motionNum)) { return; }
            motionNum = isRoll ? range.First : range.End;
        }

        /// <summary>
        /// 描画の画像カットを出す
        /// </summary>
        /// <returns></returns>
        public Rectangle DrawRange() {
            return motions[motionNum];
        }

        /// <summary>
        /// アニメーションは循環かどうか
        /// </summary>
        public bool IsRoll {
            get { return isRoll; }
            set { isRoll = value; }
        }
    }
}
