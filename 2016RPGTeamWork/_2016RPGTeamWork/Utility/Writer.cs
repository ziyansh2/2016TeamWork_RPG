///作成日：2016.12.20
///作成者：柏
///作成内容：文字列の表示クラス
///最後修正内容：ＲＰＧっぽいの会話表示できた
///最後修正者：柏
///最後修正日：2016.12.25

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _2016RPGTeamWork.Device;
using _2016RPGTeamWork.Def;
using Microsoft.Xna.Framework;

namespace _2016RPGTeamWork.Utility
{
    class Writer
    {
        private string textData;
        private Timer timer;
        private int currentNum;
        private Vector2 position;
        public Writer() {
            timer = new Timer(0.15f);
            currentNum = 0;
            position = Parameter.TalkTextPosition;
        }

        public void Initialize() {
            textData = null;
            currentNum = 0;
            timer.Initialize();
        }

        public void SetData(string text) {
            textData = text;
        }

        public void Draw(Renderer renderer) {
            if (textData == null) { return; }
            timer.Update();
            if (timer.IsTime) {
                if (currentNum < textData.Length - 1) {
                    timer.Initialize();
                    currentNum++;
                }
                
                else if (currentNum >= textData.Length) {
                    Initialize();
                    return;
                }
            }

            int textHeight = Parameter.TalkTextHeight;
            int textWidth = Parameter.TalkTextWidth;
            Vector2 startPosition = Parameter.TalkTextPosition;
            position = startPosition;
            
            for (int i = 0; i <= currentNum; i++)
            {
                if (textData[i] == '@') {
                    if (i == currentNum) { return; }
                    i++;
                    position.X = startPosition.X;
                    position.Y += textHeight;
                }
                else {
                    position.X += textWidth;
                }
                renderer.DrawString(textData[i].ToString(), position);
            }
        }
    }
}
