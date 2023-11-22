using System;
using System.Numerics;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace TeamTextRPG
{
    internal class Start
    {
        // 메인 실행
        static void Main()
        {
            Item.ItemList();
            Display.DisplayGameLogo();
            Display.DisplayCharacterGenaration();
            Display.DisplayGameIntro();
        }
    }
}