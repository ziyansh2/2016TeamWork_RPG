﻿///作成日：2016.12.14
///作成者：柏
///作成内容：敵の技管理クラス
///最後修正内容：。。
///最後修正日：。。
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using _2016RPGTeamWork.GameObjects.EnemyManager.Trick_E_List;

namespace _2016RPGTeamWork.GameObjects.EnemyManager
{
    class TrickManager_E
    {
        public List<Trick_E> trickList;

        public TrickManager_E()
        {
            trickList = new List<Trick_E>();
        }

        public void Initialize()
        {
            trickList.Add(new Trick1());
        }

    }
}
