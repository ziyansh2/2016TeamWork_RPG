///作成日：2016.12.26
///作成者：柏
///作成内容：敵の行動比率管理
///最後修正内容：..
///最後修正者：..
///最後修正日：..

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _2016RPGTeamWork.GameObjects.EnemyManagers;

namespace _2016RPGTeamWork.GameObjects
{
    class EnemyRadio
    {
        Dictionary<eAction, int> actionRadio;

        public EnemyRadio(int attackRadio, int defenceRadio, int magicOffence, int trickRadio, int escapeRadio) {
            actionRadio = new Dictionary<eAction, int>() {
                { eAction.Attack, attackRadio },
                { eAction.Defence, defenceRadio },
                { eAction.Magic, magicOffence },
                { eAction.Trick, trickRadio },
                { eAction.Escape, escapeRadio },

            };
        }

        public Dictionary<eAction, int> GetActionRadio() {
            return actionRadio;
        }


    }
}
