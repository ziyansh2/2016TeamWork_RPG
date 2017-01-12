///作成日：2016.12.26
///作成者：柏
///作成内容：敵まとめ管理用
///最後修正内容：敵のbattle行動完成
///最後修正者：柏
///最後修正日：2017.1.9

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using _2016RPGTeamWork.Device;
using _2016RPGTeamWork.Def;

namespace _2016RPGTeamWork.GameObjects.EnemyManagers
{
    enum eEnemyData
    {
        Name,
        Level,
        MaxHP,
        MaxMP,
        Offence,
        Defence,
        MagicOffence,
        MagicDefence,
        Speed,
        AttackRadio,
        DefenceRadio,
        MagicRadio,
        TrickRadio,
        EscapeRadio,
        MagicNum,
        TrickNum,
    }

    enum eMagic_E
    {
        Magic0,
        Magic1,
        Magic2,
        Magic3,
        Magic4,
        Magic5,
        Magic6,
        Magic7,
        Magic8,
        Magic9,
    }

    enum eTrick_E
    {
        Trick0,
        Trick1,
        Trick2,
        Trick3,
        Trick4,
        Trick5,
        Trick6,
        Trick7,
        Trick8,
        Trick9,
    }



    enum eMTParameter
    {
        Offence,
        Defence,
        MagicOffence,
        MagicDefence,
        Speed,
    }

    enum eEnemy
    {
        Slime,
    }

    class EnemyManager
    {
        private List<Enemy> enemyList;
        private Vector2 basePosition;
        private Vector2 offsetPosition;

        public EnemyManager()
        {
            enemyList = new List<Enemy>();    //Listの初期化
            basePosition = new Vector2(200, 100);
            offsetPosition = new Vector2(200, 0);
        }

        public void AddEnemy(eEnemy enemy) {
            int[,] enemyData = Method.EnemyData;

            CharacterInfo info = GetEnemyInfo(enemy, enemyData);
            EnemyRadio radio = GetEnemyRadio(enemy, enemyData);
            Vector2 position = basePosition + enemyList.Count * offsetPosition;
            Enemy newEnemy = new Enemy(enemy, position, info, radio);

            newEnemy.SetMagic((eMagic_E)enemyData[(int)enemy, (int)eEnemyData.MagicNum]);
            newEnemy.SetTrick((eTrick_E)enemyData[(int)enemy, (int)eEnemyData.TrickNum]);
            enemyList.Add(newEnemy);
        }

        public void InitEnemy() {
            enemyList.ForEach(e => e.Initialize());
        }

        public void ClearEnemyList() {
            enemyList.Clear();
        }

        public void Update() {
            enemyList.ForEach(e => e.Update());
        }

        public void Draw(Renderer renderer) {
            enemyList.ForEach(e => e.Draw(renderer));
        }

        public void GetPlayers(List<Character> players) {
            enemyList.ForEach(e => e.GetPlayerList(players));
        }

        /// <summary>
        /// エネミーのタイプによって、初期値取得 by柏 2017.1.9
        /// </summary>
        /// <param name="enemy">エネミータイプ</param>
        /// <param name="enemyData">エネミー初期データ</param>
        /// <returns></returns>
        private CharacterInfo GetEnemyInfo(eEnemy enemy, int[,] enemyData) {
            CharacterInfo info = new CharacterInfo(
                ((eEnemy)enemyData[(int)enemy, (int)eEnemyData.Name]).ToString(),
                enemyData[(int)enemy, (int)eEnemyData.Level],
                enemyData[(int)enemy, (int)eEnemyData.MaxHP],
                enemyData[(int)enemy, (int)eEnemyData.MaxMP],
                enemyData[(int)enemy, (int)eEnemyData.Offence],
                enemyData[(int)enemy, (int)eEnemyData.Defence],
                enemyData[(int)enemy, (int)eEnemyData.MagicOffence],
                enemyData[(int)enemy, (int)eEnemyData.MagicDefence],
                enemyData[(int)enemy, (int)eEnemyData.Speed]
            );
            return info;
        }

        /// <summary>
        /// エネミーのタイプによって、行動比率取得 by柏 2017.1.9
        /// </summary>
        /// <param name="enemy">エネミータイプ</param>
        /// <param name="enemyData">エネミー初期データ</param>
        /// <returns></returns>
        private EnemyRadio GetEnemyRadio(eEnemy enemy, int[,] enemyData) {
            EnemyRadio radio = new EnemyRadio(
                enemyData[(int)enemy, (int)eEnemyData.AttackRadio],
                enemyData[(int)enemy, (int)eEnemyData.DefenceRadio],
                enemyData[(int)enemy, (int)eEnemyData.MagicRadio],
                enemyData[(int)enemy, (int)eEnemyData.TrickRadio],
                enemyData[(int)enemy, (int)eEnemyData.EscapeRadio]
            );
            return radio;
        }
    }
}
