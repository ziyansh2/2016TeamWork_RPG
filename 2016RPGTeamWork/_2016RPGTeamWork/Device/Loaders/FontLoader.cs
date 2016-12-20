///作成日：2016.12.20
///作成者：柏
///作成内容：フォントの読み込みクラス
///最後修正内容：。。
///最後修正者：。。
///最後修正日：。。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2016RPGTeamWork.Device
{

    class FontLoader : Loader
    {
        //描画オブジェクト
        private Renderer renderer;

        public FontLoader(Renderer renderer, string[,] resouces) :
            base(resouces)//親クラスで初期化
        {
            this.renderer = renderer;
            Initialize();//Loaderクラスの初期化処理を呼び出す
        }


        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            //まずは終了フラグを有効にして
            endFlag = true;
            //カウンタが最大に達してないか？
            if (counter < maxNum)
            {
                //画像の読み込み
                renderer.LoadFont(
                    resources[counter, 0], resources[counter, 1]);
                counter += 1;
                //読み込むものがあったので終了フラグを継続に設定
                endFlag = false;
            }
        }
    }
}
