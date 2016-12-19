///作成日：2016.12.19
///作成者：岡山
///作成内容：ＢＧＭロード用
///最後修正内容：注釈追加
///最後修正者：柏
///最後修正日：2016.12.19

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2016RPGTeamWork.Device
{
    class BGMLoader : Loader
    {
        private Sound sound;

        public BGMLoader(Sound sound, string[,] resources)
            : base(resources)
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
                sound.LoadBGM(resources[counter, 0], resources[counter, 1]);
                counter += 1;
                endFlag = false;
            }
        }
    }
}
