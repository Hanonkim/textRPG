using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace study.textRPG
{
    public static class GlobalConst
    {
        public const int inflationCONCOE = 12;
        public const int inflationSTRCOE = 20;
    }
    public struct Mob
    {
        public int code;
        public string mobName;
        public ushort CON;
        public ushort STR;
        public ushort rewardMoney;
        public float maxPowerCOE;
        public float minPowerCOE;

        public void Init()
        {
            maxPowerCOE = 1.2f;
            minPowerCOE = 0.8f;
        }
    }


    public struct Item
    {
        public int id;
        public string itemName;
        public ushort itemCON;
        public ushort itemSTR;
        public ushort buyPrice;
        public ushort sellPrice;
    }
}
