﻿///作成日：2016.12.19
///作成者：柏
///作成内容：ゲームプレーシーン
///最後修正内容：Stageクラスを宣言して描画、文字表示追加
///最後修正者：柏
///最後修正日：2016.12.20

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using _2016RPGTeamWork.Device;
using _2016RPGTeamWork.Utility;

namespace _2016RPGTeamWork.Scene
{
    class GamePlay : IsScene
    {
        bool endFlag;
        bool battleFlag;
        private InputState input;
        private Motion motion;      //アニメーション用
        private Stage stage;    //2016.12.20 by柏　stage描画用
        private Dictionary<int,string> textData;    //2016.12.20 by柏　文字表示用
        private int textNum;    //2016.12.20 by柏　文字表示用
        public GamePlay(GameDevice gameDevice)
        {
            endFlag = false;
            battleFlag = false;
            input = gameDevice.GetInputState();
            stage = new Stage();    //2016.12.20 by柏　stage描画用
            Initialize();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            endFlag = false;
            battleFlag = false;
            stage.Initialize();    //2016.12.20 by柏　stage描画用
            textData = stage.GetTextData;
            textNum = -1;

            //アニメーション用クラスを生成してから初期化
            motion = new Motion();
            for (int i = 0; i < 6; i++) {
                motion.Add(i, new Rectangle(64 * i, 0, 64, 64));
            }
            motion.Initialize(new Range(0, 5), new Timer(0.1f));
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            if (input.IsKeyDown(Keys.Space)) { endFlag = true; }
            else if (input.IsKeyDown(Keys.Z)) { battleFlag = !battleFlag; }
            else if (input.IsKeyDown(Keys.X)) { TextUpdate(); }

            motion.Update();    //アニメーション更新
        }

        private void TextUpdate() {
            textNum++;
            if (!textData.ContainsKey(textNum))
            {
                textNum = -1;
            }
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer) {
            stage.Draw(renderer);    //2016.12.20 by柏　stage描画用
            renderer.DrawTexture("gameplay", Vector2.Zero);
            renderer.DrawTexture("puddle", Vector2.One * 550, motion.DrawRange());
            if (textNum < 0) { return; }
            renderer.DrawString(textData[textNum], new Vector2(50, 400),2.0f);
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
        public eScene ToBattle()
        {
            return eScene.BATTLE;
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
