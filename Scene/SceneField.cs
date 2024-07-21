using study.textRPG.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.textRPG.Scene
{
    //필드에서 발생하는 이벤트 처리
    public struct SceneField
    {
        public string fieldName;
        public int[] fieldMobList;
        public ushort needPower;
        public short needMaxHealth;

        //필드 선택
        public void ChooseField(ref PlayerData player)
        {
            int selected = int.MaxValue;
            bool isCorrectInput = false;
            FieldData fieldData = new FieldData();
            SceneField field = new SceneField();            
            MobData mobData = new MobData();
            SceneLobby sceneLobby = new SceneLobby();

            Console.Clear();
            Console.WriteLine("[알림]");
            Console.WriteLine("=====사냥터 선택=====");
            for (int i = 0; i < fieldData.fields.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {fieldData.fields[i].fieldName}");
            }
            Console.Write("선택: ");
            Console.WriteLine("0 입력시 로비 복귀");

            isCorrectInput = int.TryParse(Console.ReadLine(), out selected);
            while (!isCorrectInput || selected < 0 || selected > 4) 
            {
                Console.WriteLine("오입력!");
                isCorrectInput = int.TryParse(Console.ReadLine(), out selected);
                
            }
            if (selected == 0)
            {
                Console.Clear();
                sceneLobby.ChooseAction(ref player);
            }

            string fieldName;
            int[] mobList;
            ushort needPower;
            short needHealth;
            Battle battle = new Battle();

            //선택된 필드의 정보 출력
            Console.Clear();
            fieldData.LoadData(selected - 1, out fieldName, out mobList, out needPower, out needHealth);
            Console.WriteLine($"필드 이름 = {fieldName}");
            Console.WriteLine($"요구 최대생명력 = {needHealth}");
            Console.WriteLine($"요구 공격력 = {needPower}");

            bool checkCorrectInput = false;
            while (!checkCorrectInput)
            {
                Console.WriteLine("입장하시겠습니까? 1. 입장    2.퇴장"); //입력 예외처리 필요
                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1: //전투 처리 루틴으로 이동
                        battle.ProcBattle(ref player, selected - 1);
                        checkCorrectInput = true;
                        break;
                    case 2: //로비로 이동
                        Console.Clear();
                        sceneLobby.ChooseAction(ref player);
                        checkCorrectInput = true;
                        break;
                    default:
                        Console.WriteLine("1 또는 2를 입력하세요.");
                        break;
                }
            }
        }
    }
}
