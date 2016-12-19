///作成日：2016.12.19
///作成者：岡本
///作成内容：入力管理クラス
///最後修正内容：注釈追加
///最後修正者：柏
///最後修正日：2016.12.19

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;//Vector2用
using Microsoft.Xna.Framework.Input;//Keyboard用

namespace _2016RPGTeamWork.Device
{
    class InputState
    {
        //移動量
        private Vector2 velocity = Vector2.Zero;

        private KeyboardState currentKey;//現在のキー
        private KeyboardState previousKey;//1フレーム前のキー
        private GamePadState currentPad;//現在のPadの状態
        private GamePadState previousPad;//1フレーム前のPadの状態

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public InputState()
        { }

        /// <summary>
        /// 移動量の取得
        /// </summary>
        /// <returns></returns>
        public Vector2 Velocity()
        {
            return velocity;
        }

        /// <summary>
        /// キーとパッドの押下チェック
        /// </summary>
        /// <param name="key">キーボタン</param>
        /// <param name="button">パッドボタン</param>
        /// <returns></returns>
        public bool CheckDownKey(Keys key, Buttons button)
        {
            //キーボードでチェックしたいキーが押されているか？
            if (currentKey.IsKeyDown(key))
            {
                return true;
            }
            //ゲームパッドでつながっていないか？
            if (!GamePad.GetState(PlayerIndex.One).IsConnected)
            {
                return false;
            }
            //ゲームパッドでチェックしたいキーが押されているか？
            if (GamePad.GetState(PlayerIndex.One).IsButtonDown(button))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 移動量の更新
        /// </summary>
        private void UpdateVelocity()
        {
            //マイループ初期化
            velocity = Vector2.Zero;
            //右
            if (CheckDownKey(Keys.Right, Buttons.DPadRight))
            {
                velocity.X += 1.0f;
            }
            //左
            if (CheckDownKey(Keys.Left, Buttons.DPadLeft))
            {
                velocity.X -= 1.0f;
            }
            //上
            if (CheckDownKey(Keys.Up, Buttons.DPadUp))
            {
                velocity.Y -= 1.0f;
            }
            //下
            if (CheckDownKey(Keys.Down, Buttons.DPadDown))
            {
                velocity.Y += 1.0f;
            }
            //正規化
            if (velocity.Length() != 0)
            {
                velocity.Normalize();
            }
        }

        /// <summary>
        /// キー状態の更新
        /// </summary>
        /// <param name="keyState">キーボタンの状態</param>
        private void UpdateKey(KeyboardState keyState)
        {
            //1フレーム前のキーに現在のキーを
            previousKey = currentKey;
            //現在のキーを最新のものに
            currentKey = keyState;
        }

        /// <summary>
        /// パッド状態の更新
        /// </summary>
        /// <param name="buttonState">パッドボタンの状態</param>
        private void UpdatePad(GamePadState buttonState)
        {
            previousPad = currentPad;
            currentPad = buttonState;
        }

        /// <summary>
        /// 押されたのか？（キーボード版）
        /// </summary>
        /// <param name="key">キーボタン</param>
        /// <returns></returns>
        public bool IsKeyDown(Keys key)
        {
            bool current = currentKey.IsKeyDown(key);
            bool previous = previousKey.IsKeyDown(key);
            return current && !previous;
        }

        /// <summary>
        /// 押されたのか？（パッド版）
        /// </summary>
        /// <param name="button">パッドボタン</param>
        /// <returns></returns>
        public bool IsKeyDown(Buttons button)
        {
            bool current = currentPad.IsButtonDown(button);
            bool previous = previousPad.IsButtonDown(button);
            return current && !previous;
        }

        /// <summary>
        /// 押されたのか？（トリガー判定：キーボード版）
        /// </summary>
        /// <param name="key">キーボタン</param>
        /// <returns></returns>
        public bool GetKeyTrigger(Keys key)
        {
            return IsKeyDown(key);
        }
        /// <summary>
        /// 押されたのか？（ステート判定：パッド版）
        /// </summary>
        /// <param name="button">パッドボタン</param>
        /// <returns></returns>
        public bool GetKeyState(Buttons button)
        {
            return currentPad.IsButtonDown(button);
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            //キーボード処理
            //現在のキーボードの状態を取得
            var keyState = Keyboard.GetState();
            //キーの更新
            UpdateKey(keyState);
            //ゲームパッド処理
            var padState = GamePad.GetState(PlayerIndex.One);
            UpdatePad(padState);
            //移動量の更新
            UpdateVelocity();
        }
    }
}
