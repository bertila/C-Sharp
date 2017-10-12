using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_C_ver2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "";
            string input = Console.ReadLine();
            int antal = Convert.ToInt32(input);

            for (int i = 1; i <= antal*18; i++)
            {
                input = Console.ReadLine();
                text = text + input;
                if (input == "")
                    i--;
            }

            // int pos = text.IndexOf("\n");
            // int rowCount = Convert.ToInt16(text.Substring(0, pos));
            // sSudoko = text.Substring(pos + 1).Replace("\n", "");

            for (int curr = 0; curr < antal; curr++)
            {
                string sSudoko1 = text.Substring(curr * 162, 81);
                string sSudoko2 = text.Substring(curr * 162 + 81, 81);
            
                string binary = "";
                string sInput = "";

                bool ok = false;

                // Test 1 Rotate Right
                string sTest1 = RotateRight(sSudoko1);
                ok = Same(sTest1, sSudoko2);
                if (ok == true)
                    goto Finish;

                // Test 2 Rotate Left
                string sTest2 = RotateLeft(sSudoko1);
                ok = Same(sTest2, sSudoko2);
                if (ok == true)
                    goto Finish;

                // Test 3 Switch RowSegment 1 & 2
                string sTest3 = SwitchRowSegment(sSudoko1, 1, 2);
                ok = Same(sTest3, sSudoko2);
                if (ok == true)
                    goto Finish;

                // Test 4 Switch RowSegment 1 & 3
                string sTest4 = SwitchRowSegment(sSudoko1, 1, 3);
                ok = Same(sTest4, sSudoko2);
                if (ok == true)
                    goto Finish;

                // Test 5 Switch RowSegment 2 & 3
                string sTest5 = SwitchRowSegment(sSudoko1, 2, 3);
                ok = Same(sTest5, sSudoko2);
                if (ok == true)
                    goto Finish;


                string sTmp = "";
                string sRot = RotateRight(sSudoko1);

                // Test 6 Switch ColSegment 1 & 2
                sTmp = SwitchRowSegment(sRot, 1, 2);
                string sTest6 = RotateLeft(sTmp);
                ok = Same(sTest6, sSudoko2);
                if (ok == true)
                    goto Finish;

                // Test 7 Switch ColSegment 1 & 3
                sTmp = SwitchRowSegment(sRot, 1, 3);
                string sTest7 = RotateLeft(sTmp);
                ok = Same(sTest7, sSudoko2);
                if (ok == true)
                    goto Finish;

                // Test 8 Switch ColSegment 2 & 3
                sTmp = SwitchRowSegment(sRot, 2, 3);
                string sTest8 = RotateLeft(sTmp);
                ok = Same(sTest8, sSudoko2);
                if (ok == true)
                    goto Finish;

                // Test 9 Switch Many Rows
                string sTest9 = "";
                for (int i = 1; i <= 63; i++)
                {
                    binary = "000000" + Convert.ToString(i, 2);
                    sInput = binary.Substring(binary.Length - 6, 6);

                    sTest9 = SwitchRow(sSudoko1, sInput);

                    ok = Same(sTest9, sSudoko2);
                    if (ok == true)
                        goto Finish;
                }

            Finish:

                if (ok == true)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }

            }
            // Console.ReadLine();
        }

        public static string RotateRight(string sinput)
        {
            string newFormat = "";
            for (int x = 0; x <= 8; x++)
            {
                for (int y = 8; y >= 0; y--)
                {
                    newFormat = newFormat + sinput.Substring(y * 9 + x, 1);
                }
            }
            return newFormat;
        }

        public static string RotateLeft(string sinput)
        {
            string newFormat = "";
            for (int x = 8; x >= 0; x--)
            {
                for (int y = 0; y <= 8; y++)
                {
                    newFormat = newFormat + sinput.Substring(y * 9 + x, 1);
                }
            }
            return newFormat;
        }

        public static string SwitchRow(string sInput, string rowSwitch)
        {
            string sOutput = sInput;

            for (int j = 0; j < 3; j++)
            {
                string sQuadrant = rowSwitch.Substring(4 - j * 2, 2);
                string sResult = sOutput.Substring(0, 27 * j);

                switch (sQuadrant)
                {
                    case "00":
                        break;

                    case "01":
                        // Switch Row 1 & 2
                        sOutput = sResult + sOutput.Substring(j * 27 + 9, 9) + sOutput.Substring(j * 27, 9) + sOutput.Substring(j * 27 + 18, 9) + sOutput.Substring(j * 27 + 27);
                        break;

                    case "10":
                        // Switch Row 1 & 3
                        sOutput = sResult + sOutput.Substring(j * 27 + 18, 9) + sOutput.Substring(j * 27 + 9, 9) + sOutput.Substring(j * 27, 9) + sOutput.Substring(j * 27 + 27);
                        break;

                    case "11":
                        // Switch Row 2 & 3
                        sOutput = sResult + sOutput.Substring(j * 27, 9) + sOutput.Substring(j * 27 + 18, 9) + sOutput.Substring(j * 27 + 9, 9) + sOutput.Substring(j * 27 + 27);
                        break;
                }
            }
            return sOutput;
        }

        public static string SwitchRowSegment(string sInput, int row1, int row2)
        {
            string newFormat = "";
            string Row = row1.ToString() + row2.ToString();

            if (!((row1 >= 1 && row1 <= 3) && (row2 >= 1 && row2 <= 3)) && (row1 != row2))
            {
                return sInput;
            }

            switch (Row)
            {
                case "12":
                    newFormat = sInput.Substring(27, 27) + sInput.Substring(0, 27) + sInput.Substring(54, 27);
                    break;
                case "13":
                    newFormat = sInput.Substring(54, 27) + sInput.Substring(27, 27) + sInput.Substring(0, 27);
                    break;
                case "23":
                    newFormat = sInput.Substring(0, 27) + sInput.Substring(54, 27) + sInput.Substring(27, 27);
                    break;
            }
            return newFormat;
        }

        public static bool Same(string sInput1, string sInput2)
        {
            bool ok = true;
            string character = "";

            for (int i = 0; i < 81; i++)
            {
                character = sInput2.Substring(i, 1);
                if (character != "0")
                {
                    if (!(sInput1.Substring(i, 1) == sInput2.Substring(i, 1)))
                    {
                        ok = false;
                        break;
                    }
                }
            }
            return ok;
        }
    }
}
