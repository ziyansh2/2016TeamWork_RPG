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
            isMoved_P.X = (Parameter.ScreenWidth - Parameter.TileSize) / 2 - viewPort.X;
            isMoved_P.Y = (Parameter.ScreenHeight - Parameter.TileSize) / 2 - viewPort.Y;
            CheckCamera(viewPort);
        }

        private void CheckCamera(Vector2 viewPort)
        {
            Vector2 stageScale = stage.GetStageScale();

            if (viewPort.X - (Parameter.ScreenWidth - Parameter.TileSize) / 2 < 0)
            {
                isMoved_P.X = 0 ;
            }
            if (viewPort.X + (Parameter.ScreenWidth + Parameter.TileSize) / 2 > stageScale.X)
            {
                isMoved_P.X = Parameter.ScreenWidth - stageScale.X;
            }
            if (viewPort.Y - (Parameter.ScreenHeight - Parameter.TileSize) / 2 < 0)
            {
                isMoved_P.Y = 0;
            }
            if (viewPort.Y + (Parameter.ScreenHeight + Parameter.TileSize) / 2> stageScale.Y)
            {
                isMoved_P.Y = Parameter.ScreenHeight - stageScale.Y;
            }
        }

        public Vector2 GetIsMoved_P{
            get{ return isMoved_P; }
        }


    }
}
