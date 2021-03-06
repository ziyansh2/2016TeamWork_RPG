﻿///作成日：2016.12.19
///作成者：岡本
///作成内容：MP3,WAV管理クラス
///最後修正内容：注釈追加
///最後修正日：柏

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;//WAV
using Microsoft.Xna.Framework.Media;//MP3
using System.Diagnostics;

namespace _2016RPGTeamWork.Device
{
    class Sound
    {
        private ContentManager contentManager;

        private Dictionary<string, Song> bgms;//MP3管理用
        private Dictionary<string, SoundEffect> soundEffects;//WAV管理用
        private Dictionary<string, SoundEffectInstance> seInstances;//WAVインスタンス管理用
        private List<SoundEffectInstance> sePlayList;//WAVインスタンス再生リスト

        private string currentBGM;//現在再生中のアセット名

        public Sound(ContentManager content)
        {
            contentManager = content;

            //BGMは繰り返し再生
            MediaPlayer.IsRepeating = true;

            //各Dictionaryの実体生成
            bgms = new Dictionary<string, Song>();
            soundEffects = new Dictionary<string, SoundEffect>();
            seInstances = new Dictionary<string, SoundEffectInstance>();
            sePlayList = new List<SoundEffectInstance>();

            //何も再生していないのでnull初期化
            currentBGM = null;
        }

        /// <summary>
        /// エラーのメセッジ
        /// </summary>
        /// <param name="name">ファイル名</param>
        /// <returns></returns>
        private string ErrorMessage(string name)
        {
            return "再生する音データのアセット名（" + name + "）がありません\n" +
                "アセット名の確認、Dictionaryに登録されているか確認してください\n";
        }

        #region BGM関連処理

        /// <summary>
        /// ＢＧＭファイル読込
        /// </summary>
        /// <param name="name">ファイル名</param>
        /// <param name="filepath">ファイルアドレス</param>
        public void LoadBGM(string name, string filepath = "./")
        {
            if (bgms.ContainsKey(name))
            {
                return;
            }

            bgms.Add(name, contentManager.Load<Song>(filepath + name));
        }

        /// <summary>
        /// ＢＧＭの再生が中止中かどうか
        /// </summary>
        /// <returns></returns>
        public bool IsStoppedBGM()
        {
            return (MediaPlayer.State == MediaState.Stopped);
        }


        /// <summary>
        /// ＢＧＭ再生中かどうか
        /// </summary>
        /// <returns></returns>
        public bool IsPlayingBGM()
        {
            return (MediaPlayer.State == MediaState.Playing);
        }

        /// <summary>
        /// ＢＧＭ再生一時停止
        /// </summary>
        /// <returns></returns>
        public bool IsPausedBGM()
        {
            return (MediaPlayer.State == MediaState.Paused);
        }

        /// <summary>
        /// ＢＧＭ再生中止
        /// </summary>
        public void StopBGM()
        {
            MediaPlayer.Stop();
            currentBGM = null;
        }


        /// <summary>
        /// ＢＧＭ再生
        /// </summary>
        /// <param name="name"></param>
        public void PlayBGM(string name)
        {
            Debug.Assert(bgms.ContainsKey(name), ErrorMessage(name));

            if (currentBGM == name)
            {
                return;
            }

            if (IsPlayingBGM())
            {
                StopBGM();
            }

            MediaPlayer.Volume = 0.5f;

            currentBGM = name;

            MediaPlayer.Play(bgms[currentBGM]);
        }

        /// <summary>
        /// ＢＧＭの再生のループ設定
        /// </summary>
        /// <param name="loopFlag"></param>
        public void ChangeBGMLoopFlag(bool loopFlag)
        {
            MediaPlayer.IsRepeating = loopFlag;
        }
        #endregion


        #region WAV関連

        /// <summary>
        /// ＳＥファイルを読み込み
        /// </summary>
        /// <param name="name">ファイル名</param>
        /// <param name="filepath">ファイルアドレス</param>
        public void LoadSE(string name, string filepath = "./")
        {
            if (soundEffects.ContainsKey(name))
            {
                return;
            }

            soundEffects.Add(name, contentManager.Load<SoundEffect>(filepath + name));
        }

        /// <summary>
        /// ＳＥの再生リストをニューする
        /// </summary>
        /// <param name="name">ファイル名</param>
        public void CreateSEInstance(string name)
        {
            if (seInstances.ContainsKey(name))
            {
                return;
            }

            Debug.Assert(
                soundEffects.ContainsKey(name),
                "先に" + name + "の読み込み処理をしてください");

            seInstances.Add(name, soundEffects[name].CreateInstance());
        }

        /// <summary>
        /// ＳＥを再生
        /// </summary>
        /// <param name="name"></param>
        public void PlaySE(string name)
        {
            Debug.Assert(soundEffects.ContainsKey(name), ErrorMessage(name));

            soundEffects[name].Play();
        }

        /// <summary>
        /// ＳＥＬｉｓｔを再生
        /// </summary>
        /// <param name="name">ファイルめ</param>
        /// <param name="loopFlag">ループ設定</param>
        public void PlaySEInstance(string name, bool loopFlag = false)
        {
            Debug.Assert(seInstances.ContainsKey(name), ErrorMessage(name));

            var data = seInstances[name];
            data.IsLooped = loopFlag;
            data.Play();
            sePlayList.Add(data);

        }

        /// <summary>
        /// ＳＥ再生中止
        /// </summary>
        public void StoppedSE()
        {
            foreach (var se in sePlayList)
            {
                if (se.State == SoundState.Playing)
                {
                    se.Stop();
                }
            }
        }

        /// <summary>
        /// ＳＥを一時停止
        /// </summary>
        public void PauseSE()
        {
            foreach (var se in sePlayList)
            {
                if (se.State == SoundState.Playing)
                {
                    se.Pause();
                }
            }
        }

        /// <summary>
        /// ＳＥを削除
        /// </summary>
        public void RemoveSE()
        {
            sePlayList.RemoveAll(se => (se.State == SoundState.Stopped));
        }

        #endregion

        /// <summary>
        /// 音声関連Ｌｉｓｔをクリア
        /// </summary>
        public void Unload()
        {
            bgms.Clear();
            soundEffects.Clear();
            sePlayList.Clear();
        }
    }
}