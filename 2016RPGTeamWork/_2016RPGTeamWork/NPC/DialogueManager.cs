///作成日：2016.1.8
///作成者：柏
///作成内容：NPCセリフ管理
///最後修正内容：。。
///最後修正者：。。
///最後修正日：。。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using _2016RPGTeamWork.Def;
using _2016RPGTeamWork.Utility;

namespace _2016RPGTeamWork.NPC
{
    class DialogueManager
    {
        private List<Range> dialogueCor; //dialogueCorrespondenceの略、セリフの対応関係
        public DialogueManager() {
        }

        public void Initialize() {
            int[,] dialogueCorData = DataLoader.DataLoad("dialogueCor_Text");
            for (int i = 0; i < dialogueCorData.GetLength(0); i++) {
                dialogueCor.Add(new Range(dialogueCorData[i,0], dialogueCorData[i,1]));
            }
        }

        public Range GetDialogue(int DialogueCorNum) {
            return dialogueCor[DialogueCorNum];
        }
    }
}
