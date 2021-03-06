﻿///作成日：2016.12.19
///作成者：柏
///作成内容：タイトルシーン
///最後修正内容：。。
///最後修正者：。。
///最後修正日：。。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _2016RPGTeamWork.Device;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace _2016RPGTeamWork.Scene
{
    class Title : IsScene
    {
        bool endFlag;
        private InputState input;
        public Title(GameDevice gameDevice) {
            endFlag = false;
            input = gameDevice.GetInputState();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            endFlag = false;
        }

        /// <summary>
        /// 次のシーンに行く
        /// </summary>
        /// <returns></returns>
        public eScene ToNext()
        {
            return eScene.GAMEPLAY;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            if (input.IsKeyDown(Keys.Space)) { endFlag = true; }
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer) {
            renderer.DrawTexture("title", Vector2.Zero);
        }


        /// <summary>
        /// エンドフラッグをとる
        /// </summary>
        /// <returns></returns>
        public bool IsEnd()
        {
            return endFlag;
        }
    }
}
