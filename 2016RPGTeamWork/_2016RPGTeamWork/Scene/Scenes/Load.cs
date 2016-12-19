///作成日：2016.12.19
///作成者：柏
///作成内容：ロードシーン
///最後修正内容：。。
///最後修正日：。。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using _2016RPGTeamWork.Device;
using Microsoft.Xna.Framework;

namespace _2016RPGTeamWork.Scene
{
    class Load : IsScene
    {
        private bool endFlag;
        private Loader seLoader;
        private Loader bgmLoader;
        private Loader textureLoader;

        private string[,] GetTextureList() {
            string path = "./Texture/";
            string[,] list = new string[,] {
                { "title", path },
                { "gameplay", path },
                { "battle", path },
                { "puddle", path },
            };
            return list;
        }

        private string[,] GetSE_List() {
            string path = "./SE/";
            string[,] list = new string[,] {
                { "title", path },
            };
            return list;
        }


        private string[,] GetBGM_List() {
            string path = "./BGM/";
            string[,] list = new string[,] {
                { "title", path },
            };
            return list;
        }

        public Load(GameDevice gameDevice)
        {
            endFlag = false;

            seLoader = new SELoader(gameDevice.GetSound(), GetSE_List());
            bgmLoader = new BGMLoader(gameDevice.GetSound(), GetBGM_List());
            textureLoader = new TextureLoader(gameDevice.GetRenderer(), GetTextureList());
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            endFlag = false;
            seLoader.Initialize();
            bgmLoader.Initialize();
            textureLoader.Initialize();
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            if (!textureLoader.IsEnd())
            {
                textureLoader.Update();
            }
            else if (!seLoader.IsEnd())
            {
                seLoader.Update();
            }
            else if (!bgmLoader.IsEnd())
            {
                bgmLoader.Update();
            }
            else {
                endFlag = true;
            }
            
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer)
        {
            renderer.DrawTexture("load", Vector2.Zero);
        }


        /// <summary>
        /// 次のシーンに行く
        /// </summary>
        /// <returns></returns>
        public eScene ToNext() { return eScene.TITLE; }

        /// <summary>
        /// エンドフラッグをとる
        /// </summary>
        /// <returns></returns>
        public bool IsEnd() { return endFlag; }
    }
}
