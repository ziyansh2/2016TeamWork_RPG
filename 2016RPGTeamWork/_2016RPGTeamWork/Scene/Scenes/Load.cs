///作成日：2016.12.19
///作成者：柏
///作成内容：ロードシーン
///最後修正内容：player,enemyリソース追加
///最後修正者：柏
///最後修正日：2017.1.8

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
        private Loader fontLoader;  //by柏　2016.12.20　フォントロード用

        /// <summary>
        /// 画像ソースリストを出す
        /// </summary>
        /// <returns></returns>
        private string[,] GetTextureList() {
            string path = "./Texture/";
            string[,] list = new string[,] {
                { "title", path },
                { "gameplay", path },
                { "battle", path },
                { "puddle", path },
                { "mapsource", path },  //2016.12.20 by柏 maptip描画テスト追加
                { "player1", path},  //2017.1.8 by柏 playerリソース追加
                { "enemy", path},  //2017.1.8 by柏 enemy描画テスト追加
            };
            return list;
        }

        /// <summary>
        /// ＳＥソースリストを出す
        /// </summary>
        /// <returns></returns>
        private string[,] GetSE_List() {
            string path = "./SE/";
            string[,] list = new string[,] {
                { "title", path },
            };
            return list;
        }

        /// <summary>
        /// ＢＧＭソースリストを出す
        /// </summary>
        /// <returns></returns>
        private string[,] GetBGM_List() {
            string path = "./BGM/";
            string[,] list = new string[,] {
                { "title", path },
            };
            return list;
        }
        /// <summary>
        /// フォントリストを出す  by柏　2016.12.20
        /// </summary>
        /// <returns></returns>
        private string[,] GetFont_List() {
            string path = "./Font/";
            string[,] list = new string[,] {
                { "ＭＳ Ｐゴシック", path },
                { "HGS行書体",path },
            };
            return list;
        }

        /// <summary>
        /// 実際のロード処理
        /// </summary>
        /// <param name="gameDevice">デバイス管理クラス</param>
        public Load(GameDevice gameDevice)
        {
            endFlag = false;

            seLoader = new SELoader(gameDevice.GetSound(), GetSE_List());
            bgmLoader = new BGMLoader(gameDevice.GetSound(), GetBGM_List());
            textureLoader = new TextureLoader(gameDevice.GetRenderer(), GetTextureList());

            //by柏　2016.12.20　フォントロード用
            fontLoader = new FontLoader(gameDevice.GetRenderer(), GetFont_List());
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
            fontLoader.Initialize();    //by柏　2016.12.20　フォントロード用
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            if (!textureLoader.IsEnd()) { textureLoader.Update(); }
            else if (!seLoader.IsEnd()) { seLoader.Update(); }
            else if (!bgmLoader.IsEnd()){ bgmLoader.Update(); }

            //by柏　2016.12.20　フォントロード用
            else if (!fontLoader.IsEnd()) { fontLoader.Update(); }
            else { endFlag = true; }
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
