///作成日：2016.12.14
///作成者：柏
///作成内容：敵のマジック管理クラス
///最後修正内容：。。
///最後修正日：。。
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using _2016RPGTeamWork.GameObjects.EnemyInterface;
using _2016RPGTeamWork.GameObjects.EnemyManager.Magic_E_List;

namespace _2016RPGTeamWork.GameObjects.EnemyManager
{
    class MagicManager_E
    {
        public List<Magic_E> magicList;     //(enum)eMagic_Eの順番通りmagicを保存するList

        public MagicManager_E()
        {
            magicList = new List<Magic_E>();    //Listの初期化
        }

        /// <summary>
        /// magicを全部入れとく
        /// </summary>
        public void Initialize()
        {
            magicList.Add(new Magic1());
        }

        /// <summary>
        /// 要求通りmagicを提供する
        /// </summary>
        /// <param name="magic">enumのmagic</param>
        /// <returns></returns>
        public Magic_E GetMagic(eMagic_E magic)
        {
            return magicList[(int)magic];
        }

    }
}
