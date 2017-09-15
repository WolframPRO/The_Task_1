using System;
using System.IO;

namespace The_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] INPUT = File.ReadAllLines("INPUT.TXT");
            string[] size = INPUT[0].Split(' ');
            int kor = 0;
            Int32.TryParse(size[1], out kor);

            int[,] lab = new int[kor, 3];

            string[] Temp = new string[3];
            for (int i = 0; i < kor; i++)
            {
                Temp = INPUT[i + 1].Split(' ');
                Int32.TryParse(Temp[0], out lab[i, 0]);
                Int32.TryParse(Temp[1], out lab[i, 1]);
                Int32.TryParse(Temp[2], out lab[i, 2]);
            }

            Temp = INPUT[INPUT.Length - 1].Split(' ');

            int TempKom = 1;
            int Color = 0;


            bool ok = false;
            for (int i = 0; i < Temp.Length; i++) // идем по цветам коридора
            {
                Int32.TryParse(Temp[i], out Color);
                for (int n = 0; n < kor; n++)
                {
                    if (lab[n, 2] == Color && lab[n, 0] == TempKom)
                        {
                            TempKom = lab[n, 1];
                            ok = false;
                            break;
                        
                    } else if (lab[n, 2] == Color && lab[n, 1] == TempKom) {
                            TempKom = lab[n, 0];
                            ok = false;
                            break;
                        }
                    else
                    {
                        ok = true;   
                    }
                }
                if (ok)
                {
                    File.WriteAllText("OUTPUT.TXT", "INCORRECT");
                    goto x;
                }
            }

            File.WriteAllText("OUTPUT.TXT", TempKom.ToString());
            x:
            int o;


        }
    }
}
