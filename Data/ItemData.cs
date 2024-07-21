using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.textRPG.Data
{
    public struct ItemData
    {
        public Item[] item;

        public ItemData()
        {
            item = new Item[10];
            InitData();
        }
    
        public void LoadData(int selected, out string itemName, ushort itemCON, ushort itemSTR, int buyPrice, int sellPrice)
        {
            itemName = item[selected].itemName;
            itemCON = item[selected].itemCON;
            itemSTR = item[selected].itemSTR;
            buyPrice = item[selected].buyPrice;
            sellPrice = item[selected].sellPrice;
        }
        //밸런싱 필요
        public void InitData()
        {
            item[0].id = 0; //혹시 몰라서 최대한 NULL값은 배제시키고자 "비어있는" 상태를 나타내는 아이템 설정
            item[0].itemName = "비어있다";
            item[0].itemCON = 0;
            item[0].itemSTR = 0;
            item[0].buyPrice = 0;
            item[0].sellPrice = 0;

            item[1].id = 1;
            item[1].itemName = "고대의 단검";
            item[1].itemCON = 20;
            item[1].itemSTR = 2;
            item[1].buyPrice = 30;
            item[1].sellPrice = 5;

            item[2].id = 2;
            item[2].itemName = "빅빅 롱소드";
            item[2].itemCON = 20;
            item[2].itemSTR = 2;
            item[2].buyPrice = 30;
            item[2].sellPrice = 5;

            item[3].id = 3;
            item[3].itemName = "큰천 뿔갑옷";
            item[3].itemCON = 20;
            item[3].itemSTR = 2;
            item[3].buyPrice = 30;
            item[3].sellPrice = 5;

            item[4].id = 4;
            item[4].itemName = "토파즈 수정";
            item[4].itemCON = 20;
            item[4].itemSTR = 2;
            item[4].buyPrice = 30;
            item[4].sellPrice = 5;

            item[5].id = 5;
            item[5].itemName = "요정의 부적";
            item[5].itemCON = 20;
            item[5].itemSTR = 2;
            item[5].buyPrice = 30;
            item[5].sellPrice = 5;

            item[6].id = 6;
            item[6].itemName = "이바돈의 모자";
            item[6].itemCON = 40;
            item[6].itemSTR = 4;
            item[6].buyPrice = 60;
            item[6].sellPrice = 10;

            item[7].id = 7;
            item[7].itemName = "스택의 도전";
            item[7].itemCON = 40;
            item[7].itemSTR = 4;
            item[7].buyPrice = 60;
            item[7].sellPrice = 10;

            item[8].id = 8;
            item[8].itemName = "가고일 갑옷";
            item[8].itemCON = 40;
            item[8].itemSTR = 4;
            item[8].buyPrice = 60;
            item[8].sellPrice = 4;

            item[9].id = 9;
            item[9].itemName = "초풍신 작숑";
            item[9].itemCON = 40;
            item[9].itemSTR = 4;
            item[9].buyPrice = 60;
            item[9].sellPrice = 4;

        }
    }
}
