///作成日：2017.1.11
///作成者：柏
///作成内容：静態メソッド管理クラス
///最後修正内容：。。。
///最後修正者：。。。
///最後修正日：。。。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using _2016RPGTeamWork.GameObjects.EnemyManagers;
using Microsoft.Xna.Framework;

namespace _2016RPGTeamWork.Def
{
    static class Method
    {
        //(enum)eEnemyの順番通りenemyを保存する配列を取得  by柏 2017.1.9
        public static int[,] EnemyData = DataLoader.DataLoad("Enemy");

        /// <summary>
        /// (enum)eTrick_Eの順番通り敵の技を保存するListを取得  
        /// by柏 2017.1.10
        /// </summary>
        /// <returns>技のリスト</returns>
        public static List<int[]> GetTrickList() {
            int[,] trickData = DataLoader.DataLoad("Trick_E");
            List<int[]> trickList = new List<int[]>();

            for (int i = 0; i < trickData.GetLength(0); i++) {
                trickList.Add(new int[] {
                    trickData[i, (int)eMTParameter.Offence],
                    trickData[i, (int)eMTParameter.Defence],
                    trickData[i, (int)eMTParameter.MagicOffence],
                    trickData[i, (int)eMTParameter.MagicDefence],
                    trickData[i, (int)eMTParameter.Speed]
                });
            }
            return trickList;
        }

        /// <summary>
        /// (enum)eMagic_Eの順番通り敵の魔法を保存するListを取得
        ///  by柏 2017.1.10
        /// </summary>
        /// <returns>魔法のリスト</returns>
        public static List<int[]> GetMagicList() {
            int[,] magicData = DataLoader.DataLoad("Magic_E");
            List<int[]> magicList = new List<int[]>();
            for (int i = 0; i < magicData.GetLength(0); i++) {
                magicList.Add(new int[] {
                    magicData[i, (int)eMTParameter.Offence],
                    magicData[i, (int)eMTParameter.Defence],
                    magicData[i, (int)eMTParameter.MagicOffence],
                    magicData[i, (int)eMTParameter.MagicDefence],
                    magicData[i, (int)eMTParameter.Speed]
                });
            }
            return magicList;
        }

        /// <summary>
        /// 当たり判定　by柏　2017.1.11
        /// </summary>
        /// <param name="other">判定対象</param>
        /// <returns></returns>
        public static bool IsCollision(Rectangle obj1, Rectangle obj2)
        {
            return obj1.Intersects(obj2);
        }



    }
}
