using study.textRPG.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.textRPG.Scene
{
    public struct ScenePlayerInfo
    {
        //플레이어 데이터 출력하는 함수
        public void PrintPlayerData(ref PlayerData player)
        {
            ItemData itemData = new ItemData();

            player.UpdatePlayerSpec(); //출력전 생명력, 공격력 갱신

            Console.Clear();
            Console.WriteLine("[알림]화이팅!");
            Console.WriteLine("=====플레이어 정보창=====");
            Console.WriteLine($"> 체력 = {player.CON}");
            Console.WriteLine($"> 무력 = {player.STR}");
            Console.WriteLine($"> 최대생명력 = {player.CON * GlobalConst.inflationCONCOE}");
            Console.WriteLine($"> 피해량 = {(ushort)(player.STR * player.minPowerCOE * GlobalConst.inflationSTRCOE)} ~ {(ushort)(player.STR * player.maxPowerCOE * GlobalConst.inflationSTRCOE)}");
            Console.WriteLine($"> 보유 돈 = {player.currentMoney}");
            Console.WriteLine("> 인벤토리 : ");

            for (int i = 0; i < player.inventory.Length; i++)
            {
                Console.WriteLine($"{i + 1} {itemData.item[player.inventory[i]].itemName}");
            }

            //장비 제거
            Console.WriteLine("1.장비 제거\t2.로비 복귀");

            int input = 0;
            bool checkCorrectInput = false;
            checkCorrectInput = int.TryParse(Console.ReadLine(), out input);
            while (!checkCorrectInput || input < 1 || input > 2)
            {
                Console.WriteLine("오입력!");
                checkCorrectInput = int.TryParse(Console.ReadLine(), out input);
            }

            if(input == 1)
            {
                Console.Write("->제거할 장비 번호 입력: ");
                int input2 = int.Parse(Console.ReadLine());
                if (input2 > 0 && input2 <= player.inventory.Length)
                {
                    player.inventory[input2 - 1] = 0;
                    player.UpdatePlayerSpec(); // 장비 제거 후 생명력, 공격력 갱신
                }
                else
                {
                    Console.WriteLine("잘못된 번호입니다.");
                }
            }
            if(input == 2)
            {
                Console.Clear();
                return;
            }
            Console.Clear();
        }

    }
}
