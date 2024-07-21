using study.textRPG.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.textRPG.Scene
{
    public struct SceneLobby
    {
        //메인UI 출력하는 함수
        public void ChooseAction(ref PlayerData playerData)
        {
            int input;
            ScenePlayerInfo playerInfo = new ScenePlayerInfo();
            SceneField field = new SceneField();
            Shop shop = new Shop();

            while (true)
            {
                Console.WriteLine("[알림]");
                Console.WriteLine("=======================");
                Console.Write("1. 정보 출력\t");
                Console.Write("2. 사냥 이동\t");
                Console.Write("3. 상점 이동");
                Console.WriteLine();
                Console.Write("행동 선택: ");

                bool correctInput = false;
                correctInput = int.TryParse(Console.ReadLine(), out input);
                while (!correctInput || input <= 0 || input > 3) 
                {
                    Console.WriteLine("오입력!");
                    correctInput = int.TryParse(Console.ReadLine(), out input);
                }

                switch (input)
                {
                    case 1:
                        playerInfo.PrintPlayerData(ref playerData);
                        break;
                    case 2:
                        field.ChooseField(ref playerData);
                        break;
                    case 3:
                        shop.ChooseAction(ref playerData);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
