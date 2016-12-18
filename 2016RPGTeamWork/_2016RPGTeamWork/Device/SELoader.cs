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
