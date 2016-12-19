///�쐬���F2016.12.13
///�쐬�ҁF��
///�쐬���e�F�Q�[�����
///�Ō�C�����e�FGameDivice�ASceneManager����
///�C���ҁF��
///�Ō�C�����F2016.12.19

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
        //�ȉ��A�ǉ�by�@���@2016.12.19
        private GraphicsDeviceManager graphics;
        private GameDevice gameDevice;
        private Renderer renderer;
        private SceneManager sceneManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            //�ȉ��A�ǉ�by�@���@2016.12.19
            graphics.PreferredBackBufferWidth = Parameter.ScreenWidth;
            graphics.PreferredBackBufferHeight = Parameter.ScreenHeight;

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// �Q�[���̏�����
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //�ȉ��A�ǉ�by�@���@2016.12.19
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
            Window.Title = "2016_RPG�`�[������";
            IsMouseVisible = true;
        }

        /// <summary>
        /// �R���e���c�����[�h����
        /// </summary>
        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            //�ȉ��A�ǉ�by�@���@2016.12.19
            gameDevice.LoadContent();
        }

        /// <summary>
        /// ���[�h���ꂽ�R���e���c���폜
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here

            //�ȉ��A�ǉ�by�@���@2016.12.19
            gameDevice.UnloadContent();
        }

        /// <summary>
        /// �Q�[�����X�V
        /// </summary>
        /// <param name="gameTime">�Q�[�����̎���</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            //�ȉ��A�ύXby�@���@2016.12.19  Escape����������Game���������
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();

            // TODO: Add your update logic here

            //�ȉ��A�ǉ�by�@���@2016.12.19
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
            //�ύXby ���@2016.12.19�@�t���b�V���F�̕ύX
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            //�ȉ��A�ǉ�by�@���@2016.12.19
            renderer.Begin();
            sceneManager.Draw(renderer);

            renderer.End();

            base.Draw(gameTime);
        }
    }
}
