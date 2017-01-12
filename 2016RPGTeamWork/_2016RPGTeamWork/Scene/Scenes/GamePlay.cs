///作成日：2016.12.19
///作成者：柏
///作成内容：ゲームプレーシーン
///最後修正内容：camera追加
///最後修正者：柏
///最後修正日：2017.1.10

using System.Collections.Generic;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

using _2016RPGTeamWork.Device;
using _2016RPGTeamWork.Utility;
using _2016RPGTeamWork.NPC;
using _2016RPGTeamWork.GameObjects;

namespace _2016RPGTeamWork.Scene
{
    class GamePlay : IsScene
    {
        bool endFlag;
        bool battleFlag;
        private InputState input;
        private Stage stage;    //2016.12.20 by柏　stage描画用
        private Dictionary<int,string> textData;    //2016.12.20 by柏　文字表示用
        private int textNum;    //2016.12.20 by柏　文字表示用
        private Writer writer;    //2016.12.25 by柏　文字改行表示

        private List<NoPlayChara> npcList;    //2017.1.8 by柏　npc生成
        private List<Character> players;    //2017.1.9 by柏　player生成
        private Player player1;
        private Camera camera;    //2017.1.10 by柏　camera生成

        public GamePlay(GameDevice gameDevice) {
            input = gameDevice.GetInputState();
            players = new List<Character>();

            CharacterInfo info = new CharacterInfo(
                "player1", 1, 100, 50, 10, 5, 10, 5, 5 );

            player1 = new Player(info, gameDevice);
            players.Add(player1);
            camera = new Camera(player1.Position);
            Initialize();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize() {
            stage = new Stage();    //2016.12.20 by柏　stage管理
            stage.Initialize();    //2016.12.20 by柏　stage管理
            writer = new Writer();    //2016.12.25 by柏　文字改行表示
            writer.Initialize();    //2016.12.25 by柏　文字改行表示
            npcList = stage.GetNPC;
            npcList.ForEach(n => n.Initialize());
            players.ForEach(n => n.Initialize());
            players.ForEach(n => ((Player)n).SetMapData(stage.GetMapData()));
            camera.SetStage(stage);

            endFlag = false;
            battleFlag = false;
            textData = stage.GetTextData;
            textNum = -1;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update() {
            GameInput();
            players.ForEach(n => n.Update());
            npcList.ForEach(n => n.Update());

            if (players.Count == 0) { return; }
            camera.NextViewPort(player1.Position);
        }

        private void GameInput() {
            if (input.IsKeyDown(Keys.Space)) { endFlag = true; }
            else if (input.IsKeyDown(Keys.Z)) {
                battleFlag = !battleFlag;
                players.ForEach(n => ((Player)n).IsBattle = true);
                SetPlayersPosition();
            }
            else if (input.IsKeyDown(Keys.X)) { TextUpdate(); }
        }

        /// <summary>
        /// セリフの文字ずつ表示
        /// </summary>
        private void TextUpdate() {
            textNum++;
            if (!textData.ContainsKey(textNum)) {
                textNum = -1;
            }
            else {
                writer.Initialize();
                writer.SetData(textData[textNum]);
            }
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer) {
            stage.Draw(renderer, camera.GetIsMoved_P);    //2017.1.10 by柏　camera実装
            renderer.DrawTexture("gameplay", Vector2.Zero);

            npcList.ForEach(n => n.Draw(renderer, camera.GetIsMoved_P)); //2017.1.8　by柏　npc描画
            players.ForEach(n => ((Player)n).Draw(renderer,camera.GetIsMoved_P)); //2017.1.10　by柏　player描画

            if (textNum < 0) { return; }
            writer.Draw(renderer);
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
        public eScene ToBattle() {
            return eScene.BATTLE;
        }

        /// <summary>
        /// エンドフラッグをとる
        /// </summary>
        /// <returns></returns>
        public bool IsEnd() {
            return endFlag;
        }

        /// <summary>
        /// バトルフラッグのゲットセット
        /// </summary>
        public bool IsBattle {
            get { return battleFlag; }
            set { battleFlag = value; }
        }

        /// <summary>
        /// playersの取得
        /// </summary>
        public List<Character> GetPlayers {
            get { return players; }
        }

        /// <summary>
        /// バトルポジションを設定する
        /// </summary>
        private void SetPlayersPosition() {
            for (int i = 0; i < players.Count;i++) {
                ((Player)players[i]).SetBattlePosition(i);
            }
        }
    }
}
