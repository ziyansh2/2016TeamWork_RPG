///作成日：2017.1.10
///作成者：柏
///作成内容：カメラ
///最後修正内容：辺境対応
///最後修正者：柏
///最後修正日：2017.1.13

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using _2016RPGTeamWork.Def;
using _2016RPGTeamWork.Scene;

namespace _2016RPGTeamWork.Device
{
    class Camera
    {
        private Vector2 isMoved_P;
        private Stage stage;

        public Camera(Vector2 limitPosition) {
            isMoved_P.X = Parameter.ScreenWidth / 2 - limitPosition.X;
            isMoved_P.Y = Parameter.ScreenWidth / 2 - limitPosition.Y;
        }

        public void SetStage(Stage stage) {
            this.stage = stage;
        }

        public void NextViewPort(Vector2 viewPort) {
            isMoved_P.X = (Parameter.ScreenWidth  - Parameter.TileSize) / 2 - viewPort.X;
            isMoved_P.Y = (Parameter.ScreenHeight - Parameter.TileSize) / 2 - viewPort.Y;
            CheckCamera(viewPort);    //範囲内に収める
        }

        /// <summary>
        /// 映っている範囲の画面外チェック
        /// </summary>
        /// <param name="viewPort">映リたい画面中心</param>
        private void CheckCamera(Vector2 viewPort) {
            Vector2 stageScale = stage.GetStageScale();
            Vector2 viewLT = viewPort - new Vector2((Parameter.ScreenWidth - Parameter.TileSize) / 2, (Parameter.ScreenHeight - Parameter.TileSize) / 2);
            Vector2 viewRB = viewPort + new Vector2((Parameter.ScreenWidth + Parameter.TileSize) / 2, (Parameter.ScreenHeight + Parameter.TileSize) / 2);

            if (viewLT.X < 0) { //Left
                isMoved_P.X = 0 ;
            }
            if (viewLT.Y < 0) { //Top
                isMoved_P.Y = 0;
            }
            if (viewRB.X > stageScale.X) {  //Right
                isMoved_P.X = Parameter.ScreenWidth - stageScale.X;
            }
            if (viewRB.Y > stageScale.Y) {  //Bottom
                isMoved_P.Y = Parameter.ScreenHeight - stageScale.Y;
            }
        }

        public Vector2 GetIsMoved_P{
            get{ return isMoved_P; }
        }


    }
}
