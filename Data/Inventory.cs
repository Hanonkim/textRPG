using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.textRPG.Data
{
    public struct Inventory
    {
        public int[] idList;

        public Inventory()
        {
            idList = new int[5];
        }
        //혹시 몰라 만들어둔 편의성 함수
        public void PrintInventory()
        {
            for (int i = 0; i < idList.Length; i++)
            {
                Console.WriteLine(idList[i]);
            }
        }
        //혹시 몰라 만들어둔 편의성 함수
        public void DeleteItem(int id)
        {
            for (int i = 0; i < idList.Length; i++)
            {
                if(idList[i] == id)
                {
                    idList[i] = 0;
                }
            }
        }
        //혹시 몰라 만들어둔 편의성 함수
        public void InsertItem(int id)
        {
            for (int i = 0; i < idList.Length; i++)
            {
                if(idList[i] == 0)
                {
                    idList[i] = id;
                }
            }
        }
    }
}
