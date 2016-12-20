///作成日：2016.12.19
///作成者：岡本
///作成内容：描画管理クラス
///最後修正内容：文字データを描画するためフォント管理追加
///最後修正者：柏
///最後修正日：2016.12.20

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;//Assert用

namespace _2016RPGTeamWork.Device
{
    class Renderer
    {
        private ContentManager contentManager;
        private SpriteBatch spriteBatch;

        //複数画像管理
        private Dictionary<string, Texture2D> textures;   //初期化位置調整　by柏　2016.12.19

        //複数のフォント管理追加
        private Dictionary<string, SpriteFont> fonts;   //2016.12.20 by柏　フォントの管理用

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="content">内容管理デバイス</param>
        /// <param name="graphics">画像管理デバイス</param>
        public Renderer(ContentManager content, GraphicsDevice graphics)
        {
            textures = new Dictionary<string, Texture2D>();     //初期化位置調整　by柏　2016.12.19
            fonts = new Dictionary<string, SpriteFont>();   //2016.12.20 by柏　フォントの管理用
            contentManager = content;
            spriteBatch = new SpriteBatch(graphics);
        }

        /// <summary>
        /// 画像の読み込み
        /// </summary>
        /// <param name="name">ファイル名</param>
        /// <param name="filepath">ファイルアドレス</param>
        public void LoadTexture(string name, string filepath = "./")
        {
            //ガード節
            //Dictionaryへの2重登録を回避
            if (textures.ContainsKey(name))
            {
#if DEBUG //DEBUGモード時のみ有効
                System.Console.WriteLine("この" + name +
                    "はKeyで、すでに登録されています");
#endif
                //処理終了
                return;
            }
            textures.Add(name, contentManager.Load<Texture2D>(filepath + name));
        }

        /// <summary>
        /// 画像の登録
        /// </summary>
        /// <param name="name">ファイル名</param>
        /// <param name="texture">画像</param>
        public void LoadTexture(string name, Texture2D texture)
        {
            if (textures.ContainsKey(name))
            {
#if DEBUG //DEBUGモードの時のみ有効
                System.Console.WriteLine("この" + name +
                    "はKeyで、すでに登録されています");
#endif
                //処理終了
                return;
            }
            textures.Add(name, texture);
        }

        /// <summary>
        /// フォントの読込　by柏　2016.12.20
        /// </summary>
        /// <param name="fontName">フォントの名前</param>
        /// <param name="filepath">フォントのアドレス</param>
        public void LoadFont(string fontName, string filepath = "./")
        {
            //Debug.Assert(fonts.ContainsKey(fontName),
            //    "アセット名が間違えていませんか？\n" +
            //    "大文字小文字間違っていませんか？\n" +
            //    "LoadFontメソッドで読み込んでいますか？\n" +
            //    "プログラムを確認してください\n");

            fonts.Add(fontName, contentManager.Load<SpriteFont>(filepath + fontName));
        }

        /// <summary>
        /// フォントの読込　by柏　2016.12.20
        /// </summary>
        /// <param name="fontName">フォントの名前</param>
        /// <param name="font">フォント</param>
        public void LoadFont(string fontName, SpriteFont font) {
            Debug.Assert(fonts.ContainsKey(fontName),
                "アセット名が間違えていませんか？\n" +
                "大文字小文字間違っていませんか？\n" +
                "LoadFontメソッドで読み込んでいますか？\n" +
                "プログラムを確認してください\n");

            fonts.Add(fontName, font);
        }






        /// <summary>
        /// 解放
        /// </summary>
        public void Unload()
        {
            textures.Clear();
        }

        /// <summary>
        /// 描画開始
        /// </summary>
        public void Begin()
        {
            spriteBatch.Begin();
        }

        /// <summary>
        /// 描画終了
        /// </summary>
        public void End()
        {
            spriteBatch.End();
        }

        /// <summary>
        /// 画像の描画
        /// </summary>
        /// <param name="name">ファイル名</param>
        /// <param name="position">位置</param>
        /// <param name="alpha">透明度</param>
        public void DrawTexture(string name, Vector2 position, float alpha = 1.0f)
        {
            Debug.Assert(
                textures.ContainsKey(name),
                "アセット名が間違えていませんか？\n" +
                "大文字小文字間違っていませんか？\n" +
                "LoadTextureメソッドで読み込んでいますか？\n" +
                "プログラムを確認してください\n");

            spriteBatch.Draw(textures[name], position, Color.White * alpha);
        }

        /// <summary>
        /// 画像の描画（指定範囲）
        /// </summary>
        /// <param name="name">ファイル名</param>
        /// <param name="position">位置</param>
        /// <param name="rect">リソースの描画範囲</param>
        /// <param name="alpha">透明度</param>
        public void DrawTexture(string name, Vector2 position, Rectangle rect, float alpha = 1.0f)
        {
            Debug.Assert(
                textures.ContainsKey(name),
                "アセット名が間違えていませんか？\n" +
                "大文字小文字間違っていませんか？\n" +
                "LoadTextureメソッドで読み込んでいますか？\n" +
                "プログラムを確認してください\n");

            spriteBatch.Draw(
                textures[name],  //画像
                position,        //位置
                rect,            //矩形の指定範囲（左上の座標x, y, 幅、高さ）
                Color.White * alpha);
        }

        /// <summary>
        /// （拡大縮小対応版）画像の描画
        /// </summary>
        /// <param name="name">ファイル</param>
        /// <param name="position">位置</param>
        /// <param name="scale">大きさ</param>
        /// <param name="alpha">透明度</param>
        public void DrawTexture(string name, Vector2 position, Vector2 scale, float alpha = 1.0f)
        {
            Debug.Assert(
                textures.ContainsKey(name),
                "アセット名が間違えていませんか？\n" +
                "大文字小文字間違っていませんか？\n" +
                "LoadTextureメソッドで読み込んでいますか？\n" +
                "プログラムを確認してください\n");

            spriteBatch.Draw(
                textures[name],  //画像
                position,        //位置
                null,            //切り取り範囲
                Color.White * alpha, //透過
                0.0f,            //回転
                Vector2.Zero,    //回転軸の位置
                scale,           //拡大縮小
                SpriteEffects.None,//表示反転効果
                0.0f             //スプライト表示深度
                );
        }

        /// <summary>
        /// 数字の描画（整数版、簡易）
        /// </summary>
        /// <param name="name">アセット名</param>
        /// <param name="position">位置</param>
        /// <param name="number">描画したい数字</param>
        /// <param name="alpha">透明値</param>
        public void DrawNumber(string name, Vector2 position, int number, float alpha = 1.0f)
        {
            Debug.Assert(
                textures.ContainsKey(name),
                "アセット名が間違えていませんか？\n" +
                "大文字小文字間違っていませんか？\n" +
                "LoadTextureメソッドで読み込んでいますか？\n" +
                "プログラムを確認してください\n");

            number = Math.Max(number, 0);

            foreach (var n in number.ToString())
            {
                spriteBatch.Draw(
                    textures[name],
                    position,
                    new Rectangle((n - '0') * 32, 0, 32, 64),
                    Color.White);
                //1桁ずらす
                position.X += 32;
            }

        }

        /// <summary>
        /// 数字の描画（詳細版：桁数指定　＋　小数対応）
        /// </summary>
        /// <param name="name">ファイル</param>
        /// <param name="position">位置</param>
        /// <param name="number">描画したい数字</param>
        /// <param name="digit">描画したい桁数</param>
        /// <param name="alpha">透明度</param>
        public void DrawNumber(string name, Vector2 position, string number, int digit, float alpha = 1.0f)
        {
            Debug.Assert(
                textures.ContainsKey(name),
                "アセット名が間違えていませんか？\n" +
                "大文字小文字間違っていませんか？\n" +
                "LoadTextureメソッドで読み込んでいますか？\n" +
                "プログラムを確認してください\n");

            for (int i = 0; i < digit; i++)
            {
                if (number[i] == '.')
                {
                    spriteBatch.Draw(
                        textures[name],
                        position,
                        new Rectangle(10 * 32, 0, 32, 64),
                        Color.White);
                }
                else
                {
                    //1文字分の数値文字を取得
                    char n = number[i];

                    spriteBatch.Draw(
                        textures[name],
                        position,
                        new Rectangle((n - '0') * 32, 0, 32, 64),
                        Color.White);
                }

                position.X += 32;
            }
        }

        /// <summary>
        /// 数字描画（桁数　＋　整数）
        /// </summary>
        /// <param name="name">ファイル名</param>
        /// <param name="position">位置</param>
        /// <param name="number">描画したい数字</param>
        /// <param name="digit">描画したい桁数</param>
        /// <param name="alpha">透明度</param>
        public void DrawNumber(string name, Vector2 position, int number, int digit, float alpha = 1.0f)
        {
            Debug.Assert(textures.ContainsKey(name),
                "アセット名が間違えていませんか？\n" +
                "大文字小文字間違っていませんか？\n" +
                "LoadTextureメソッドで読み込んでいますか？\n" +
                "プログラムを確認してください\n");
            //マイナスの数は０
            number = Math.Max(number, 0);

            foreach (var n in number.ToString().PadLeft(digit, '0'))
            {
                spriteBatch.Draw(
                    textures[name],
                    position,
                    new Rectangle((n - '0') * 32, 0, 32, 64),
                    Color.White * alpha);
                position.X = position.X + 32;//横幅32ビット
            }
        }

        /// <summary>
        /// 文字表示用 by柏　2016.12.20
        /// </summary>
        /// <param name="data">表示したい文字</param>
        /// <param name="position">表示位置</param>
        public void DrawString(string data, Vector2 position, float scale = 1.0f)
        {
            string fontName = "ＭＳ Ｐゴシック";

            Debug.Assert(fonts.ContainsKey(fontName),
                "アセット名が間違えていませんか？\n" +
                "大文字小文字間違っていませんか？\n" +
                "LoadFontメソッドで読み込んでいますか？\n" +
                "プログラムを確認してください\n");

            spriteBatch.DrawString(fonts[fontName], data, position, Color.Yellow, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }

        /// <summary>
        /// 文字表示用 by柏　2016.12.20
        /// </summary>
        /// <param name="fontName">フォント</param>
        /// <param name="data">表示したい文字</param>
        /// <param name="position">表示位置</param>
        /// <param name="color">色</param>
        /// <param name="scale">大きさ</param>
        public void DrawString(string fontName, string data, Vector2 position, Color color, float scale = 1.0f)
        {
            Debug.Assert(fonts.ContainsKey(fontName),
                "アセット名が間違えていませんか？\n" +
                "大文字小文字間違っていませんか？\n" +
                "LoadFontメソッドで読み込んでいますか？\n" +
                "プログラムを確認してください\n");

            spriteBatch.DrawString(fonts[fontName], data, position, color, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }

        

    }
}