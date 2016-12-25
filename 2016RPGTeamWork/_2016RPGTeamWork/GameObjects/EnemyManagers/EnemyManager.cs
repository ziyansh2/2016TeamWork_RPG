using _2016RPGTeamWork.Scene;
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
        private StageLoader stageLoader;
        private int[,] enemyData;

        public EnemyManager()
        {
            enemyList = new List<Enemy>();    //Listの初期化
            stageLoader = new StageLoader();
            enemyData = stageLoader.DataLoad("Magic_E");
        }

        public void AddEnemy(eEnemy enemy) {
            CharacterInfo info = new CharacterInfo(
                ((eEnemy)enemyData[(int)enemy, (int)eEnemyData.Name]).ToString(),
                enemyData[(int)enemy, (int)eEnemyData.MaxHP],
                enemyData[(int)enemy, (int)eEnemyData.MaxMP],
                enemyData[(int)enemy, (int)eEnemyData.Offence],
                enemyData[(int)enemy, (int)eEnemyData.Defence],
                enemyData[(int)enemy, (int)eEnemyData.MagicOffence],
                enemyData[(int)enemy, (int)eEnemyData.MagicDefence],
                enemyData[(int)enemy, (int)eEnemyData.Speed],
                enemyData[(int)enemy, (int)eEnemyData.Level]
            );
            EnemyRadio radio = new EnemyRadio(
                enemyData[(int)enemy, (int)eEnemyData.AttackRadio],
                enemyData[(int)enemy, (int)eEnemyData.DefenceRadio],
                enemyData[(int)enemy, (int)eEnemyData.MagicOffence],
                enemyData[(int)enemy, (int)eEnemyData.TrickRadio],
                enemyData[(int)enemy, (int)eEnemyData.EscapeRadio]
            );
            enemyList.Add(new Enemy(info, radio));
        }




    }
}
