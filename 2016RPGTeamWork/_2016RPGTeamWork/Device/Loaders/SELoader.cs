///作成日：2016.12.19
///作成者：岡本
///作成内容：SEの読み込みクラス
///最後修正内容：注釈追加
///最後修正日：柏

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2016RPGTeamWork.Device
{
    class SELoader : Loader
    {
        private Sound sound;

        public SELoader(Sound sound, string[,] resouces)
            : base(resouces)
        {
            this.sound = sound;
            Initialize();
        }

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            endFlag = true;
            if (counter < maxNum)
            {
                sound.LoadSE
                (resources[counter, 0], resources[counter, 1]);
                counter += 1;
                endFlag = false;
            }
        }
    }
}
