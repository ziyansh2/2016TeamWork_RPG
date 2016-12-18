using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2016RPGTeamWork.Device
{
    class GameDevice
    {
        private Renderer renderer;//描画オブジェクト
        private InputState input;//入力用オブジェクト

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
        }

        /// <summary>
        /// リソースの読み込み
        /// </summary>
        public void LoadContent()
        {
            //ゲーム開始時に必要な最小限のリソースを読み込む
            renderer.LoadTexture("title", "./Texture/");
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
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
    }
}
