using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.textRPG.Data
{
    public struct PlayerData
    {
        public ushort baseCON;
        public ushort baseSTR;
        public ushort currentMoney;
        public int[] inventory;
        public float maxPowerCOE;
        public float minPowerCOE;

        public ushort CON; // 현재 생명력
        public ushort STR; // 현재 공격력

        public PlayerData()
        {
            baseCON = 100;
            baseSTR = 1;
            currentMoney = 10000;
            inventory = new int[5] { 0, 0, 0, 0, 0 };
            maxPowerCOE = 1.2f;
            minPowerCOE = 0.8f;

            CON = baseCON;
            STR = baseSTR;
        }

        public void UpdatePlayerSpec()
        {
            // 현재 인벤토리 내용에 따라 생명력, 공격력 갱신
            ItemData itemData = new ItemData();
            CON = baseCON;
            STR = baseSTR;

            for (int i = 0; i < inventory.Length; i++)
            {
                CON += itemData.item[inventory[i]].itemCON;
                STR += itemData.item[inventory[i]].itemSTR;
            }
        }
    }
}
