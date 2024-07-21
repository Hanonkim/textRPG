using study.textRPG.Data;
using study.textRPG.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
/*
 * 주석은 나중에
 */
namespace study.textRPG
{
    internal class Prac_textRPG
    {
        static void Main(string[] args)
        {
            SceneLobby lobby = new SceneLobby(); //로비 생성
            PlayerData playerData = new PlayerData(); //실행 중일 때 유지될 플레이어 캐릭터 생성

            lobby.ChooseAction(ref playerData);

        }
    }
}
