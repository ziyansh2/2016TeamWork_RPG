using _2016RPGTeamWork.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2016RPGTeamWork.Device
{
    static class DataManager
    {
        public static int[,] EnemyData = StageLoader.DataLoad("Enemy");     //(enum)eEnemyの順番通りenemyを保存する配列
        public static int[,] EnemyMagicData = StageLoader.DataLoad("Magic_E");     //(enum)eEnemyの順番通りenemyを保存する配列
        public static int[,] EnemyTrickData = StageLoader.DataLoad("Trick_E");     //(enum)eEnemyの順番通りenemyを保存する配列

    }
}
