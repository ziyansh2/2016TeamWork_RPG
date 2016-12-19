///作成日：2016.12.19
///作成者：岡本
///作成内容：デバイス統合クラス
///最後修正内容：Sound管理の追加
///最後修正者：柏
///最後修正日：2016.12.19

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace _2016RPGTeamWork.Device
{
    class GameDevice
    {
        private Renderer renderer;  //描画オブジェクト
        private InputState input;   //入力用オブジェクト
        private Sound sound;    //音声管理用　by柏　2016.12.19

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="content"></param>
        /// <param name="graphics"></param>
        public GameDevice(ContentManager content, GraphicsDevice graphics)
        {
            //フィールドの実体を生成
            renderer = new Renderer(content, graphics);
            input = new InputState();
            sound = new Sound(content); //音声管理用　by柏　2016.12.19
        }

        /// <summary>
        /// リソースの読み込み
        /// </summary>
        public void LoadContent()
        {
            //ゲーム開始時に必要な最小限のリソースを読み込む
            renderer.LoadTexture("load", "./Texture/");     //2016.12.19 by柏 Loadシーン追加によって内容変更
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update(GameTime gameTime)
        {
            //必ずUpdateしなければならないものを更新
            input.Update();
        }

        /// <summary>
        /// リソースの解放
        /// </summary>
        public void UnloadContent()
        {
            renderer.Unload();
        }

        /// <summary>
        /// 描画オブジェクトの取得
        /// </summary>
        /// <returns></returns>
        public Renderer GetRenderer()
        {
            return renderer;
        }

        /// <summary>
        /// 入力オブジェクトの取得
        /// </summary>
        /// <returns></returns>
        public InputState GetInputState()
        {
            return input;
        }

        /// <summary>
        /// 音声オブジェクトの取得 by柏　2016.12.19
        /// </summary>
        /// <returns></returns>
        public Sound GetSound() {
            return sound;
        }
    }
}
