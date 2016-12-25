///作成日：2016.12.14
///作成者：柏
///作成内容：敵のマジック管理クラス
///最後修正内容：ファイル読込に合わせて修正
///最後修正者：柏
///最後修正日：2016.12.25

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using _2016RPGTeamWork.GameObjects.EnemyInterface;
using _2016RPGTeamWork.Scene;

namespace _2016RPGTeamWork.GameObjects.EnemyManager
{
    class MagicManager_E
    {
        private List<int[]> magicList;     //(enum)eMagic_Eの順番通りmagicを保存するList
        private StageLoader stageLoader;
        private int[,] magicData;

        public MagicManager_E()
        {
            magicList = new List<int[]>();    //Listの初期化
            stageLoader = new StageLoader();
        }

        /// <summary>
        /// magicを全部入れとく
        /// </summary>
        public void Initialize()
        {
            magicData = stageLoader.DataLoad("Magic_E");
            for (int i = 0; i < magicData.GetLength(0); i++)
            {
                magicList.Add(new int[] {
                    magicData[i, (int)eMTParameter.Offence],
                    magicData[i, (int)eMTParameter.Defence],
                    magicData[i, (int)eMTParameter.MagicOffence],
                    magicData[i, (int)eMTParameter.MagicDefence],
                    magicData[i, (int)eMTParameter.Speed]
                });
            }
        }

        /// <summary>
        /// 要求通りmagicを提供する
        /// </summary>
        /// <param name="magic">enumのmagic</param>
        /// <returns></returns>
        public int[] GetMagic(eMagic_E magic)
        {
            return magicList[(int)magic];
        }

    }
}
