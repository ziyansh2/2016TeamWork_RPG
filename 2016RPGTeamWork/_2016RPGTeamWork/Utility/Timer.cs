///作成日：2016.12.19
///作成者：柏
///作成内容：タイマクラス
///最後修正内容：今の時間を設定できるようになった
///最後修正者：柏
///最後修正日：2017.1.8


using System;

namespace _2016RPGTeamWork.Utility
{
    class Timer
    {
        int limitTime;
        int currentTime;
        bool isTime;
        public Timer() {
            limitTime = 60; //デフォルトは1秒で初期化  1秒 = 60フレーム
        }

        public Timer(float second) {
            limitTime = (int)(second * 60);
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize() {
            currentTime = 0;
            isTime = false;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update() {
            if (isTime) { return; }
            currentTime++;
            if (currentTime > limitTime) { isTime = true; }
        }

        /// <summary>
        /// 過ぎた時間の比率
        /// </summary>
        /// <returns></returns>
        public float Rate() {
            return Math.Min(currentTime / limitTime, limitTime);
        }

        /// <summary>
        /// 時間になったかどうか
        /// </summary>
        public bool IsTime {
            get { return isTime; }
        }

        public void SetCurrentTime(float time){
            currentTime = (int)(time * 60);
        }

    }
}
