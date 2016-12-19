///作成日：2016.12.19
///作成者：柏
///作成内容：シーン管理クラス
///最後修正内容：。。
///修正者：。。
///最後修正日：。。

using System.Collections.Generic;
using System.Linq;
using System.Text;
using _2016RPGTeamWork.Device;

namespace _2016RPGTeamWork.Scene
{
    class SceneManager
    {
        private Dictionary<eScene, IsScene> scenes;     //シーンをまとめて保存そして管理
        private eScene currentScene;
        public SceneManager() {
            scenes = new Dictionary<eScene, IsScene>();
            currentScene = eScene.NONE;
        }

        /// <summary>
        /// 今のシーンを初期化する
        /// </summary>
        public void Initialize() {
            if (currentScene == eScene.NONE) { return; }
            scenes[currentScene].Initialize();
        }

        /// <summary>
        /// 管理されるシーンを追加
        /// </summary>
        /// <param name="sceneName">追加するシーンの名前</param>
        /// <param name="scene">追加するシーンのクラス</param>
        public void AddScene(eScene sceneName,IsScene scene) {
            scenes.Add(sceneName, scene);
        }
        /// <summary>
        /// 今のシーンを更新
        /// </summary>
        public void Update() {
            if (currentScene == eScene.NONE) { return; }
            scenes[currentScene].Update();

            ToBattle();
            ToNext();
        }

        /// <summary>
        /// 今のシーンを描画
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer) {
            if (currentScene == eScene.NONE) { return; }
            scenes[currentScene].Draw(renderer);
        }

        /// <summary>
        /// 今のシーンを変更
        /// </summary>
        /// <param name="sceneName">変更先のシーンの名前</param>
        public void ChangeScene(eScene sceneName) {
            currentScene = sceneName;
        }

        /// <summary>
        /// 次のシーンに遷移
        /// </summary>
        public void ToNext() {
            if (!scenes[currentScene].IsEnd()) { return; }

            scenes[currentScene].Initialize();
            currentScene = scenes[currentScene].ToNext();            
        }

        /// <summary>
        /// バトルシーンに遷移
        /// </summary>
        public void ToBattle() {
            if (currentScene != eScene.GAMEPLAY) { return; }

            if (((GamePlay)scenes[currentScene]).IsBattle) {
                currentScene = eScene.BATTLE;
            }
        }


        /// <summary>
        /// GamePlayシーンオブジェクトをとる
        /// </summary>
        /// <returns></returns>
        public GamePlay GetGamePlay() {
            return (GamePlay)scenes[eScene.GAMEPLAY];
        }

    }
}
