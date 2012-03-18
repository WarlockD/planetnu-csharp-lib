using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace PlanetNuLib
{
    class Program
    {
        static void QuickSave(string filename, string s)
        {
            StreamWriter sw = new StreamWriter("games.json");
             sw.Write(PlanetNu.GetGameList());
            sw.Close();
        }
        static void Main(string[] args)
        {
            //StreamWriter sw = new StreamWriter("games.json");
           // sw.Write(PlanetNu.GetGameList());
            //sw.Close();
            //StreamReader sw = new StreamReader("games.json");
           // string s = sw.ReadToEnd();
           // sw.Close();
            string s = PlanetNu.GetTurnData(815, 3);
            QuickSave("turn.json", s);
            object test = JSON.JsonDecode(s);

           // Console.WriteLine(PlanetNu.GetGameList());
           // Console.WriteLine(key);
            Console.WriteLine("End of Line");
        }
    }
}
