///作成日：2016.12.13
///作成者：柏
///作成内容：ゲーム基盤
///最後修正内容：GameDivice、SceneManager実装
///修正者：柏
///最後修正日：2016.12.19

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using _2016RPGTeamWork.Device;
using _2016RPGTeamWork.Def;
using _2016RPGTeamWork.Scene;

namespace _2016RPGTeamWork
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        //以下、追加by　柏　2016.12.19
        private GraphicsDeviceManager graphics;
        private GameDevice gameDevice;
        private Renderer renderer;
        private SceneManager sceneManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            //以下、追加by　柏　2016.12.19
            graphics.PreferredBackBufferWidth = Parameter.ScreenWidth;
            graphics.PreferredBackBufferHeight = Parameter.ScreenHeight;

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// ゲームの初期化
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //以下、追加by　柏　2016.12.19
            gameDevice = new GameDevice(Content, GraphicsDevice);
            sceneManager = new SceneManager();
            renderer = gameDevice.GetRenderer();

            sceneManager.AddScene(eScene.LOAD, new Load(gameDevice));
            sceneManager.AddScene(eScene.TITLE, new Title(gameDevice));
            sceneManager.AddScene(eScene.GAMEPLAY, new GamePlay(gameDevice));
            sceneManager.AddScene(eScene.BATTLE, new Battle(gameDevice,sceneManager.GetGamePlay()));
            sceneManager.ChangeScene(eScene.LOAD);
            sceneManager.Initialize();

            base.Initialize();
            Window.Title = "2016_RPGチーム製作";
            IsMouseVisible = true;
        }

        /// <summary>
        /// コンテンツをロードする
        /// </summary>
        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            //以下、追加by　柏　2016.12.19
            gameDevice.LoadContent();
        }

        /// <summary>
        /// ロードされたコンテンツを削除
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here

            //以下、追加by　柏　2016.12.19
            gameDevice.UnloadContent();
        }

        /// <summary>
        /// ゲームを更新
        /// </summary>
        /// <param name="gameTime">ゲーム内の時間</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            //以下、変更by　柏　2016.12.19  Escapeを押したらGame窓口を閉じる
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();

            // TODO: Add your update logic here

            //以下、追加by　柏　2016.12.19
            gameDevice.Update(gameTime);
            sceneManager.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //変更by 柏　2016.12.19　フラッシュ色の変更
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            //以下、追加by　柏　2016.12.19
            renderer.Begin();
            sceneManager.Draw(renderer);

            renderer.End();

            base.Draw(gameTime);
        }
    }
}
