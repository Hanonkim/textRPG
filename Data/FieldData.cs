using study.textRPG.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.textRPG
{
    public struct FieldData
    {
        public SceneField[] fields;

        public FieldData()
        {
            fields = new SceneField[4];
            InitData(); //생성자때에 일괄적으로 데이터 로드. 다 로드시키기 때문에 나중에 데이터많아지면 렉걸리지않을까
        }
        public void InitData()
        {
            //id 기반 탐색이 아니라 인덱스 순으로 순차 탐색. 확장한다면 보완 필요
            fields[0].fieldName = "아크만 사원";
            fields[0].fieldMobList = new int[] { 0, 1, 2 };
            fields[0].needPower = 10;
            fields[0].needMaxHealth = 100;

            fields[1].fieldName = "가이핀 신전";
            fields[1].fieldMobList = new int[] { 3, 4, 5 };
            fields[1].needPower = 20;
            fields[1].needMaxHealth = 200;

            fields[2].fieldName = "생각이 잠든 묘";
            fields[2].fieldMobList = new int[] { 6, 7, 8 };
            fields[2].needPower = 30;
            fields[2].needMaxHealth = 300;

            fields[3].fieldName = "검은 사막";
            fields[3].fieldMobList = new int[] { 9 };
            fields[3].needPower = 40;
            fields[3].needMaxHealth = 400;
        }
        //선택된 필드의 정보 로드
        public void LoadData(int selected, out string fieldName, out int[] mobList, out ushort needPower, out short needMaxHealth)
        {
            fieldName = fields[selected].fieldName;
            mobList = fields[selected].fieldMobList;
            needPower = fields[selected].needPower;
            needMaxHealth = fields[selected].needMaxHealth;
        }
    }
}
