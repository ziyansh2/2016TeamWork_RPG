///作成日：2016.12.19
///作成者：柏
///作成内容：シーンのインターフェースクラス
///最後修正内容：。。
///最後修正者：。。
///最後修正日：。。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _2016RPGTeamWork.Device;

namespace _2016RPGTeamWork.Scene
{
    interface IsScene
    {
        void Initialize();
        void Update();
        eScene ToNext();
        bool IsEnd();
        void Draw(Renderer renderer);
    }
}
