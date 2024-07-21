using study.textRPG.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace study.textRPG
{
    public struct Battle
    {
        //플레이어 기본속성 일괄 로딩하는 함수. 추후 컨텐츠 추가 시 편의를 위한 함수
        public void GetPlayerData(out ushort playerMaxHealth, out ushort playerPower, out float playerMinPowerCOE, out float playerMaxPowerCOE)
        {
            PlayerData playerData = new PlayerData();
            playerMaxHealth = playerData.CON;
            playerPower = playerData.STR;
            playerMinPowerCOE = playerData.minPowerCOE;
            playerMaxPowerCOE = playerData.maxPowerCOE;
        }
        //무작위 몬스터 설정
        private int SelectMob(int[] mobList)
        {
            Random rand = new Random();
            int selected = rand.Next(0, mobList.Length);
            Console.WriteLine($"{selected}번째 몬스터 선택 {mobList[selected]}");
            return mobList[selected];
        }
        //미사용 함수
        private void SetBattle(int selectedField)
        {
            string fieldName;
            int[] mobList;
            ushort needPower;
            short needMaxHealth;
            Random random = new Random();
            int selectedMob = (selectedField - 1) * 3 + random.Next(1, 4);
        }
        //전투 처리 함수
        public void ProcBattle(ref PlayerData player, int selected)
        {
            Random random = new Random();
            FieldData fieldData = new FieldData();
            MobData mob = new MobData();
            int selectedMobId;

            selectedMobId = SelectMob(fieldData.fields[selected].fieldMobList); //무작위 몹 출현
 
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"주변을 서성이던 [{mob.mobs[selectedMobId].mobName}] 이/가 출현했습니다!");
            Console.BackgroundColor = ConsoleColor.Black;

            short playerHP = (short)(player.CON * GlobalConst.inflationCONCOE); //음수일 수 있으므로 ushort가 아님
            ushort playerMinDamage = (ushort)(player.STR * player.minPowerCOE * GlobalConst.inflationSTRCOE);
            ushort playerMaxDamage = (ushort)(player.STR * player.maxPowerCOE * GlobalConst.inflationSTRCOE);

            short mobHP = (short)(mob.mobs[selectedMobId].CON * GlobalConst.inflationCONCOE);
            ushort mobMinDamage = (ushort)(mob.mobs[selectedMobId].STR * mob.mobs[selectedMobId].minPowerCOE * GlobalConst.inflationSTRCOE);
            ushort mobMaxDamage = (ushort)(mob.mobs[selectedMobId].STR * mob.mobs[selectedMobId].maxPowerCOE * GlobalConst.inflationSTRCOE);

            ushort playerDamage, mobDamage;

            int battleCount = 0;
            int selectAction = 0;
            while (playerHP > 0 && mobHP > 0) //둘 중 어느 하나가 죽을 때까지
            {
                Console.Clear();
                Console.WriteLine($"======{battleCount}회차 전투=====");
                Console.WriteLine($"내 생명력 = {playerHP}\t적 생명력 = {mobHP}");
                Console.Write("행동 입력(1. 전투하기   2. 도망가기): ");

                bool checkCorrectInput = false; //변수부를 위에 일괄정의하는게 좋은가? 아니면 해당 변수를 사용할 시점에 정의하는게 좋은가?
                checkCorrectInput = int.TryParse(Console.ReadLine(), out selectAction);
                while (!checkCorrectInput || selectAction < 0 || selectAction > 2) 
                {
                    Console.WriteLine("오입력!");
                    checkCorrectInput = int.TryParse(Console.ReadLine(), out selectAction);
                }

                if (selectAction == 2)
                {
                    Console.WriteLine("전투패배! 도망갔습니다!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    return;
                }
                //교전 실행
                else if (selectAction == 1)
                {
                    playerDamage = (ushort)random.Next(playerMinDamage, playerMaxDamage);
                    mobDamage = (ushort)random.Next(mobMinDamage, mobMaxDamage);
                    
                    playerHP -= (short)mobDamage;
                    mobHP -= (short)playerDamage;

                    Console.WriteLine($"플레이어는 {mob.mobs[selectedMobId].mobName}에게 {playerDamage}만큼의 피해를 입었습니다.");
                    Console.WriteLine($"몬스터는 플레이어에게 {mobDamage}만큼의 피해를 입었습니다.");
                    Thread.Sleep(1500);
                    battleCount++;
                }
                else
                {
                    Console.WriteLine("이럴 경우가 없지 않나?"); //이미 모든 경우의 수가 다 걸러진거같아서 이 case에 올 분기는 없어보여도 그래도 혹시모르니 예외처리해야 안전한가? 아니면 자명하면 안해도되는가
                }
            }
            if (playerHP > 0)
            {
                player.currentMoney += mob.mobs[selectedMobId].rewardMoney;
                Console.WriteLine($"전투승리! {mob.mobs[selectedMobId].rewardMoney}만큼의 돈을 획득했습니다");
                Thread.Sleep(1500);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("전투패배!");
                Thread.Sleep(1500);
                Console.Clear();
            }
        }
    }
}
