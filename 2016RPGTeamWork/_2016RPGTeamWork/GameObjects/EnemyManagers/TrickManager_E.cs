///作成日：2016.12.14
///作成者：柏
///作成内容：敵の技管理クラス
///最後修正内容：ファイル読込に合わせて修正
///最後修正者：柏
///最後修正日：2016.12.25

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using _2016RPGTeamWork.Scene;

namespace _2016RPGTeamWork.GameObjects.EnemyManagers
{
    class TrickManager_E
    {
        private List<int[]> trickList;
        private StageLoader stageLoader;
        private int[,] trickData;

        public TrickManager_E()
        {
            trickList = new List<int[]>();
            stageLoader = new StageLoader();
        }

        /// <summary>
        /// 技を全部入れとく
        /// </summary>
        public void Initialize()
        {
            trickData = stageLoader.DataLoad("Trick_E");
            for (int i = 0; i < trickData.GetLength(0); i++) {
                trickList.Add(new int[] {
                    trickData[i, (int)eMTParameter.Offence], 
                    trickData[i, (int)eMTParameter.Defence], 
                    trickData[i, (int)eMTParameter.MagicOffence], 
                    trickData[i, (int)eMTParameter.MagicDefence], 
                    trickData[i, (int)eMTParameter.Speed]
                });
            }
        }

        /// <summary>
        /// 要求通り技を提供する
        /// </summary>
        /// <param name="trick">enumのtrick</param>
        /// <returns></returns>
        public int[] GetMagic(eTrick_E trick)
        {
            return trickList[(int)trick];
        }

    }
}
