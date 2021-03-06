﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2016RPGTeamWork.Device
{

    class TextureLoader : Loader
    {
        //描画オブジェクト
        private Renderer renderer;

        public TextureLoader(Renderer renderer, string[,] resouces) :
            base(resouces)//親クラスで初期化
        {
            this.renderer = renderer;
            Initialize();//Loaderクラスの初期化処理を呼び出す
        }

        public override void Update()
        {
            //まずは終了フラグを有効にして
            endFlag = true;
            //カウンタが最大に達してないか？
            if (counter < maxNum)
            {
                //画像の読み込み
                renderer.LoadTexture(
                    resources[counter, 0],
                    resources[counter, 1]);
                counter += 1;
                //読み込むものがあったので終了フラグを継続に設定
                endFlag = false;
            }
        }
    }
}
