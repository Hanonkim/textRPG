using study.textRPG.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.textRPG.Scene
{
    public struct Shop
    {
        //상점품목을 출력하고 구매하는 함수
        public void ChooseAction(ref PlayerData player)
        {
            bool isCorrectInput = false;
            int input;
            int chooseItemNumber = int.MaxValue;
            int isBuy = -1, isSell = -1;
            SceneLobby sceneLobby = new SceneLobby();
            ItemData itemData = new ItemData();

            Console.Clear();
            Console.WriteLine("[알림]");
            Console.WriteLine("=====상점=====");
            Console.WriteLine("1. 판매품 출력  2. 로비 복귀");
            Console.Write("선택: ");

            isCorrectInput = int.TryParse(Console.ReadLine(), out input);
            while (!isCorrectInput || input > 2 || input < 0)
            {
                Console.WriteLine("오입력!");
                isCorrectInput = int.TryParse(Console.ReadLine(), out input);
            }

            switch (input)
            {
                case 0:
                    break;
                case 1: //출력 및 구매
                    while (chooseItemNumber != 0)
                    {
                        //상점품목 출력
                        PrintItem(ref player, isBuy);

                        Console.WriteLine($"잔액 = {player.currentMoney}");

                        Console.WriteLine("구매할 상점목록 번호 or 판매할 인벤토리 번호 입력(0 입력시 이전으로)");
                        string input2 = Console.ReadLine();

                        if (input2.Length != 1 || !char.IsDigit(input2[0]))
                        {
                            Console.WriteLine("오입력!");
                            continue;
                        }

                        chooseItemNumber = int.Parse(input2); 

                        if (chooseItemNumber == 0)
                        {
                            break;
                        }

                        //구매 처리 루틴
                        isBuy = BuyItem(chooseItemNumber, ref player);
                    }
                    break;
                case 2: //로비 복귀
                    Console.Clear();
                    sceneLobby.ChooseAction(ref player); 
                    break;
                default:
                    break;
            }

            Console.Clear();
        }
        public void PrintItem(ref PlayerData player, int isBuy)
        {
            ItemData itemData = new ItemData();

            //먼저 BuyItem의 결과코드에 따라 알림메시지 출력
            Console.Clear();
            if(isBuy == -1)
            {
                Console.WriteLine("[알림]");
            }
            else if (isBuy == 0)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine($"구매성공! (잔액 = {player.currentMoney})");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (isBuy == 1)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[알림]구매실패! 소지금액이 부족합니다.");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if(isBuy == 2)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[알림]구매실패! 동일한 아이템은 중복 구매할 수 없습니다.");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if(isBuy == 3)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[알림]구매실패! 인벤토리가 가득 찼습니다.");
                Console.BackgroundColor = ConsoleColor.Black;
            }

            //상점품목 출력
            Console.WriteLine("=================상점 물품=================");
            Console.WriteLine("[번호] [아이템명]\t[추가생명력] [추가공격력] [가격]");
            for (int i = 1; itemData.item.Length > i; i++) //0번째 비어있는 것은 스킵
            {
                Console.WriteLine($"{i}    {itemData.item[i].itemName}\t{itemData.item[i].itemCON}\t     {itemData.item[i].itemSTR}\t          {itemData.item[i].buyPrice}");
            }
            Console.WriteLine("");

            //인벤토리 출력
            Console.WriteLine("=================나의 물품=================");
            char j = 'a';
            for (int i = 0; i < player.inventory.Length; i++)
            {
                Console.WriteLine($"{(char)(j+i)}. {itemData.item[player.inventory[i]].itemName}");
            }
        }
        public int BuyItem(int selected, ref PlayerData player)
        {
            ItemData itemData = new ItemData();

            //돈 부족
            if (player.currentMoney < itemData.item[selected].buyPrice)
            {
                return 1;
            }

            //중복 구매
            for (int i = 0; player.inventory.Length > i; i++)
            {
                if (player.inventory[i] == itemData.item[selected].id)
                {
                    return 2;
                }
            }
            //인벤토리 초과
            int isFull = 0;
            for (int i = 0; i < player.inventory.Length; i++)
            {
                if (player.inventory[i] != 0)
                {
                    isFull++;
                }
            }
            if (isFull == player.inventory.Length)
            {
                return 3;
            }

            //구매성공
            for (int i = 0; player.inventory.Length > i; i++) //itemData의 0번은 비어있음을 나타내는 아이템이므로 1부터 정상 index
            {
                if (player.inventory[i] == 0)
                {
                    player.inventory[i] = selected; //같은 이유로 selected에 1 빼지 말고 그대로 저장. 단, player.inventory는 0부터 index함에 유의
                    player.currentMoney -= itemData.item[selected].buyPrice;

                    return 0;
                }
            }
            return -2;
        }
    }
 
}
