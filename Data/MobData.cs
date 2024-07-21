using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.textRPG.Data
{
    public struct MobData
    {
        public Mob[] mobs;

        public MobData()
        {
            mobs = new Mob[10];
            InitData();
        }

        public void InitData()
        {
            for (int i = 0; i < mobs.Length; i++) //구조체는 생성/할당 효율을 위해 자동초기화하기 때문에 기본생성자가 불가하여 초기화하는 메서드를 작성해서 직접 초기화해야함
            {
                mobs[i].Init();
            }

            mobs[0].code = 0;
            mobs[0].mobName = "주술사";
            mobs[0].CON = 65;
            mobs[0].STR = 15;
            mobs[0].rewardMoney = 10;
            mobs[1].code = 1;
            mobs[1].mobName = "전사";
            mobs[1].CON = 150;
            mobs[1].STR = 7;
            mobs[1].rewardMoney = 10;
            mobs[2].code = 2;
            mobs[2].mobName = "감독관";
            mobs[2].CON = 200;
            mobs[2].STR = 12;
            mobs[2].rewardMoney = 10;

            mobs[3].code = 3;
            mobs[3].mobName = "신관";
            mobs[3].CON = 130;
            mobs[3].STR = 30;
            mobs[3].rewardMoney = 20;
            mobs[4].code = 4;
            mobs[4].mobName = "파괴자";
            mobs[4].CON = 300;
            mobs[4].STR = 14;
            mobs[4].rewardMoney = 20;
            mobs[5].code = 5;
            mobs[5].mobName = "도살자";
            mobs[5].CON = 400;
            mobs[5].STR = 24;
            mobs[5].rewardMoney = 20;

            mobs[6].code = 6;
            mobs[6].mobName = "조련사";
            mobs[6].CON = 195;
            mobs[6].STR = 45;
            mobs[6].rewardMoney = 30;
            mobs[7].code = 7;
            mobs[7].mobName = "광전사";
            mobs[7].CON = 450;
            mobs[7].STR = 21;
            mobs[7].rewardMoney = 30;
            mobs[8].code = 8;
            mobs[8].mobName = "다크나이트";
            mobs[8].CON = 600;
            mobs[8].STR = 36;
            mobs[8].rewardMoney = 30;

            mobs[9].code = 9;
            mobs[9].mobName = "흑정령";
            mobs[9].CON = 800;
            mobs[9].STR = 48;
            mobs[9].rewardMoney = 100;
        }
        public void LoadData(int selected, out string mobName, out ushort mobCON, out ushort mobSTR, out ushort mobRewardMoney)
        {
            mobName = mobs[selected].mobName;
            mobCON = mobs[selected].CON;
            mobSTR = mobs[selected].STR;
            mobRewardMoney = mobs[selected].rewardMoney;
        }
    }
}
