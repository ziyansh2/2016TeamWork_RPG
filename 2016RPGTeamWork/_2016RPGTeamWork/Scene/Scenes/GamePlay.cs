﻿///作成日：2016.12.19
///作成者：柏
///作成内容：ゲームプレーシーン
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
    class GamePlay : IsScene
    {
        bool endFlag;
        bool battleFlag;
        private InputState input;
        public GamePlay(GameDevice gameDevice)
        {
            endFlag = false;
            battleFlag = false;
            input = gameDevice.GetInputState();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            endFlag = false;
            battleFlag = false;
        }

        /// <summary>
        /// 次のシーンに行く
        /// </summary>
        /// <returns></returns>
        public eScene ToNext()
        {
            return eScene.TITLE;
        }

        /// <summary>
        /// バトルシーンに遷移
        /// </summary>
        /// <returns></returns>
        public eScene ToBattle() {
            return eScene.BATTLE;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            if (input.IsKeyDown(Keys.Space)) { endFlag = true; }
            else if (input.IsKeyDown(Keys.Z)) { battleFlag = !battleFlag; }
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer) {
            renderer.DrawTexture("gameplay", Vector2.Zero);
        }


        /// <summary>
        /// エンドフラッグをとる
        /// </summary>
        /// <returns></returns>
        public bool IsEnd()
        {
            return endFlag;
        }

        /// <summary>
        /// バトルフラッグのゲットセット
        /// </summary>
        public bool IsBattle {
            get { return battleFlag; }
            set { battleFlag = value; }
        }

    }
}