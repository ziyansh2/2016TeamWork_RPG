///作成日：2016.12.26
///作成者：柏
///作成内容：敵まとめ管理用
///最後修正内容：StageLoader改善によって調整、敵生成から描画の部分完成
///最後修正者：柏
///最後修正日：2016.1.8


using _2016RPGTeamWork.Device;
using _2016RPGTeamWork.Scene;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    enum eAction
    {
        Attack,
        Defence,
        Escape,
        Magic,
        Trick,
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

        private List<Enemy> enemyList;     //(enum)eMagic_Eの順番通りmagicを保存するList
        private int[,] enemyData;
        private Vector2 basePosition;
        private Vector2 offsetPosition;

        public EnemyManager()
        {
            enemyList = new List<Enemy>();    //Listの初期化
            enemyData = StageLoader.DataLoad("Enemy");
            basePosition = new Vector2(200, 300);
            offsetPosition = new Vector2(100, 0);
        }

        public void AddEnemy(eEnemy enemy) {
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
            EnemyRadio radio = new EnemyRadio(
                enemyData[(int)enemy, (int)eEnemyData.AttackRadio],
                enemyData[(int)enemy, (int)eEnemyData.DefenceRadio],
                enemyData[(int)enemy, (int)eEnemyData.MagicRadio],
                enemyData[(int)enemy, (int)eEnemyData.TrickRadio],
                enemyData[(int)enemy, (int)eEnemyData.EscapeRadio]
            );
            enemyList.Add(new Enemy(enemy, basePosition + enemyList.Count * offsetPosition, info, radio));
        }

        public void Initialize() {
            enemyList.ForEach(e => e.Initialize());
        }

        public void ClearEnemyList() {
            enemyList.Clear();
        }

        public void Draw(Renderer renderer) {
            enemyList.ForEach(e => e.Draw(renderer));
        }

    }
}
