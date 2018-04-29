using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/*
 * Author: Shawn M. Crawford [sleepy]
 * sleepy3d@gmail.com
 * 2018+
 */
namespace FaxanaduShopPriceEditor
{
    class Backend
    {
        int textFlag = 0;
        string path;

        public Backend(string gamePath)
        {
            path = gamePath;
        }

        public string getPrice(int offset)
        {
            // Price is stored in little endian format
            string price1 = getHexStringFromFile(offset + 1, 1);
            string price2 = getHexStringFromFile(offset, 1);
            string priceCombined = price1 + price2;
            string priceDec = convertHexToDecFourChar(priceCombined);
            string prettyPriceFinal = priceDec.TrimStart('0');

            if (prettyPriceFinal == "")
            {
                prettyPriceFinal = "0";
            }

            return prettyPriceFinal;
        }

        public string getROMText(int length, int offset, int decodeOption)
        {

            string romCodeString = "";
            string asciiOut = "";
            string tempHexString = "";
            int x = 0;
            using (FileStream fileStream = new FileStream(@path, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    fileStream.Seek(offset, SeekOrigin.Begin);

                    while (x < length)
                    {
                        romCodeString = fileStream.ReadByte().ToString("X");
                        //if length is single digit add a 0 ( 1 now is 01)
                        if (romCodeString.Length == 1)
                        {
                            romCodeString = "0" + romCodeString;
                        }
                        tempHexString = romCodeString;
                        if (decodeOption == 0)
                        {
                            decodeRomText0(tempHexString);
                            if (textFlag == 0)
                            {
                                asciiOut += decodeRomText0(tempHexString);
                            }
                        }
                        x++;
                    }
                    fileStream.Close();
                }
                catch (Exception e)
                {
                    // TODO: Bubble up the error message
                    // MessageBox.Show("Error: " + e, "Dragon Warrior Text Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return asciiOut;
        }

        private string decodeRomText0(string tempHexString)
        {
            string asciiValue = "";
            textFlag = 0;

            switch (tempHexString)
            {
                case "20":
                    asciiValue += " ";
                    break;
                case "21":
                    asciiValue += "!";
                    break;
                case "22":
                    asciiValue += "\"";
                    break;
                case "23":
                    asciiValue += "#";
                    break;
                case "24":
                    asciiValue += "$";
                    break;
                case "25":
                    asciiValue += "%";
                    break;
                case "26":
                    asciiValue += "&";
                    break;
                case "27":
                    asciiValue += "'";
                    break;
                case "28":
                    asciiValue += "(";
                    break;
                case "29":
                    asciiValue += ")";
                    break;
                case "2A":
                    asciiValue += "*";
                    break;
                case "2B":
                    asciiValue += "+";
                    break;
                case "2C":
                    asciiValue += ",";
                    break;
                case "2D":
                    asciiValue += "-";
                    break;
                case "2E":
                    asciiValue += ".";
                    break;
                case "2F":
                    asciiValue += "/";
                    break;
                case "30":
                    asciiValue += "0";
                    break;
                case "31":
                    asciiValue += "1";
                    break;
                case "32":
                    asciiValue += "2";
                    break;
                case "33":
                    asciiValue += "3";
                    break;
                case "34":
                    asciiValue += "4";
                    break;
                case "35":
                    asciiValue += "5";
                    break;
                case "36":
                    asciiValue += "6";
                    break;
                case "37":
                    asciiValue += "7";
                    break;
                case "38":
                    asciiValue += "8";
                    break;
                case "39":
                    asciiValue += "9";
                    break;
                case "3A":
                    asciiValue += ":";
                    break;
                case "3B":
                    asciiValue += ";";
                    break;
                case "3C":
                    asciiValue += "<";
                    break;
                case "3D":
                    asciiValue += "=";
                    break;
                case "3E":
                    asciiValue += ">";
                    break;
                case "3F":
                    asciiValue += "?";
                    break;
                case "40":
                    asciiValue += "@";
                    break;
                case "41":
                    asciiValue += "A";
                    break;
                case "42":
                    asciiValue += "B";
                    break;
                case "43":
                    asciiValue += "C";
                    break;
                case "44":
                    asciiValue += "D";
                    break;
                case "45":
                    asciiValue += "E";
                    break;
                case "46":
                    asciiValue += "F";
                    break;
                case "47":
                    asciiValue += "G";
                    break;
                case "48":
                    asciiValue += "H";
                    break;
                case "49":
                    asciiValue += "I";
                    break;
                case "4A":
                    asciiValue += "J";
                    break;
                case "4B":
                    asciiValue += "K";
                    break;
                case "4C":
                    asciiValue += "L";
                    break;
                case "4D":
                    asciiValue += "M";
                    break;
                case "4E":
                    asciiValue += "N";
                    break;
                case "4F":
                    asciiValue += "O";
                    break;
                case "50":
                    asciiValue += "P";
                    break;
                case "51":
                    asciiValue += "Q";
                    break;
                case "52":
                    asciiValue += "R";
                    break;
                case "53":
                    asciiValue += "S";
                    break;
                case "54":
                    asciiValue += "T";
                    break;
                case "55":
                    asciiValue += "U";
                    break;
                case "56":
                    asciiValue += "V";
                    break;
                case "57":
                    asciiValue += "W";
                    break;
                case "58":
                    asciiValue += "X";
                    break;
                case "59":
                    asciiValue += "Y";
                    break;
                case "5A":
                    asciiValue += "Z";
                    break;
                case "5B":
                    asciiValue += "[";
                    break;
                case "5C":
                    asciiValue += "\\";
                    break;
                case "5D":
                    asciiValue += "]";
                    break;
                case "5E":
                    asciiValue += "^";
                    break;
                case "5F":
                    asciiValue += "_";
                    break;
                case "60":
                    asciiValue += "`";
                    break;
                case "61":
                    asciiValue += "a";
                    break;
                case "62":
                    asciiValue += "b";
                    break;
                case "63":
                    asciiValue += "c";
                    break;
                case "64":
                    asciiValue += "d";
                    break;
                case "65":
                    asciiValue += "e";
                    break;
                case "66":
                    asciiValue += "f";
                    break;
                case "67":
                    asciiValue += "g";
                    break;
                case "68":
                    asciiValue += "h";
                    break;
                case "69":
                    asciiValue += "i";
                    break;
                case "6A":
                    asciiValue += "j";
                    break;
                case "6B":
                    asciiValue += "k";
                    break;
                case "6C":
                    asciiValue += "l";
                    break;
                case "6D":
                    asciiValue += "m";
                    break;
                case "6E":
                    asciiValue += "n";
                    break;
                case "6F":
                    asciiValue += "o";
                    break;
                case "70":
                    asciiValue += "p";
                    break;
                case "71":
                    asciiValue += "q";
                    break;
                case "72":
                    asciiValue += "r";
                    break;
                case "73":
                    asciiValue += "s";
                    break;
                case "74":
                    asciiValue += "t";
                    break;
                case "75":
                    asciiValue += "u";
                    break;
                case "76":
                    asciiValue += "v";
                    break;
                case "77":
                    asciiValue += "w";
                    break;
                case "78":
                    asciiValue += "x";
                    break;
                case "79":
                    asciiValue += "y";
                    break;
                case "7A":
                    asciiValue += "z";
                    break;
                case "7B":
                    asciiValue += "{";
                    break;
                case "7C":
                    asciiValue += "|";
                    break;
                case "7D":
                    asciiValue += "}";
                    break;
                case "7E":
                    asciiValue += "~";
                    break;


                //case "FC":
                case "FD": // space
                    asciiValue += " ";
                    break;
                //case "FE": // Newline
                //    asciiValue += " ";
                //    break;
                //case "FF": // Seperator between dialogs
                //    asciiValue += " ";
                //    break;
                default:
                    asciiValue += " ";
                    textFlag = 1;
                    break;
            }

            return asciiValue;
        }

        public string encodeRomText0(string tempascii)
        {
            string hexValue = "";

            switch (tempascii)
            {
                case " ":
                    // hexValue += "20";
                    hexValue += "FD";
                    break;
                case "!":
                    hexValue += "21";
                    break;
                case "\"":
                    hexValue += "22";
                    break;
                case "#":
                    hexValue += "23";
                    break;
                case "$":
                    hexValue += "24";
                    break;
                case "%":
                    hexValue += "25";
                    break;
                case "&":
                    hexValue += "26";
                    break;
                case "'":
                    hexValue += "27";
                    break;
                case "(":
                    hexValue += "28";
                    break;
                case ")":
                    hexValue += "29";
                    break;
                case "*":
                    hexValue += "2A";
                    break;
                case "+":
                    hexValue += "2B";
                    break;
                case ",":
                    hexValue += "2C";
                    break;
                case "-":
                    hexValue += "2D";
                    break;
                case ".":
                    hexValue += "2E";
                    break;
                case "/":
                    hexValue += "2F";
                    break;
                case "0":
                    hexValue += "30";
                    break;
                case "1":
                    hexValue += "31";
                    break;
                case "2":
                    hexValue += "32";
                    break;
                case "3":
                    hexValue += "33";
                    break;
                case "4":
                    hexValue += "34";
                    break;
                case "5":
                    hexValue += "35";
                    break;
                case "6":
                    hexValue += "36";
                    break;
                case "7":
                    hexValue += "37";
                    break;
                case "8":
                    hexValue += "38";
                    break;
                case "9":
                    hexValue += "39";
                    break;
                case ":":
                    hexValue += "3A";
                    break;
                case ";":
                    hexValue += "3B";
                    break;
                case "<":
                    hexValue += "3C";
                    break;
                case "=":
                    hexValue += "3D";
                    break;
                case ">":
                    hexValue += "3E";
                    break;
                case "?":
                    hexValue += "3F";
                    break;
                case "@":
                    hexValue += "40";
                    break;
                case "A":
                    hexValue += "41";
                    break;
                case "B":
                    hexValue += "42";
                    break;
                case "C":
                    hexValue += "43";
                    break;
                case "D":
                    hexValue += "44";
                    break;
                case "E":
                    hexValue += "45";
                    break;
                case "F":
                    hexValue += "46";
                    break;
                case "G":
                    hexValue += "47";
                    break;
                case "H":
                    hexValue += "48";
                    break;
                case "I":
                    hexValue += "49";
                    break;
                case "J":
                    hexValue += "4A";
                    break;
                case "K":
                    hexValue += "4B";
                    break;
                case "L":
                    hexValue += "4C";
                    break;
                case "M":
                    hexValue += "4D";
                    break;
                case "N":
                    hexValue += "4E";
                    break;
                case "O":
                    hexValue += "4F";
                    break;
                case "P":
                    hexValue += "50";
                    break;
                case "Q":
                    hexValue += "51";
                    break;
                case "R":
                    hexValue += "52";
                    break;
                case "S":
                    hexValue += "53";
                    break;
                case "T":
                    hexValue += "54";
                    break;
                case "U":
                    hexValue += "55";
                    break;
                case "V":
                    hexValue += "56";
                    break;
                case "W":
                    hexValue += "57";
                    break;
                case "X":
                    hexValue += "58";
                    break;
                case "Y":
                    hexValue += "59";
                    break;
                case "Z":
                    hexValue += "5A";
                    break;
                case "[":
                    hexValue += "5B";
                    break;
                case "\\":
                    hexValue += "5C";
                    break;
                case "]":
                    hexValue += "5D";
                    break;
                case "^":
                    hexValue += "5E";
                    break;
                case "_":
                    hexValue += "5F";
                    break;
                case "`":
                    hexValue += "60";
                    break;
                case "a":
                    hexValue += "61";
                    break;
                case "b":
                    hexValue += "62";
                    break;
                case "c":
                    hexValue += "63";
                    break;
                case "d":
                    hexValue += "64";
                    break;
                case "e":
                    hexValue += "65";
                    break;
                case "f":
                    hexValue += "66";
                    break;
                case "g":
                    hexValue += "67";
                    break;
                case "h":
                    hexValue += "68";
                    break;
                case "i":
                    hexValue += "69";
                    break;
                case "j":
                    hexValue += "6A";
                    break;
                case "k":
                    hexValue += "6B";
                    break;
                case "l":
                    hexValue += "6C";
                    break;
                case "m":
                    hexValue += "6D";
                    break;
                case "n":
                    hexValue += "6E";
                    break;
                case "o":
                    hexValue += "6F";
                    break;
                case "p":
                    hexValue += "70";
                    break;
                case "q":
                    hexValue += "71";
                    break;
                case "r":
                    hexValue += "72";
                    break;
                case "s":
                    hexValue += "73";
                    break;
                case "t":
                    hexValue += "74";
                    break;
                case "u":
                    hexValue += "75";
                    break;
                case "v":
                    hexValue += "76";
                    break;
                case "w":
                    hexValue += "77";
                    break;
                case "x":
                    hexValue += "78";
                    break;
                case "y":
                    hexValue += "79";
                    break;
                case "z":
                    hexValue += "7A";
                    break;
                case "{":
                    hexValue += "7B";
                    break;
                case "|":
                    hexValue += "7C";
                    break;
                case "}":
                    hexValue += "7D";
                    break;
                case "~":
                    hexValue += "7E";
                    break;
                default:
                    hexValue += "FD"; // space
                    break;
            }

            return hexValue;
        }

        public bool setPrice(int offset, string price)
        {
            if (String.IsNullOrEmpty(price))
            {
                price = "0";
            }

            string hexValue = convertDecToHex(price);
            hexValue = hexValue.PadLeft(0x4, '0');
            string hexValueSubstring1 = hexValue.Substring(0, 2);
            string hexValueSubstring2 = hexValue.Substring(2, 2);
            string newHexValue = hexValueSubstring2 + hexValueSubstring1;

            return writeByteArrayToFile(this.path, offset, StringToByteArray(newHexValue));
        }

        public void updateROMText(int length, string newString, int offset, int encodeOption)
        {
            newString = newString.PadRight(length);

            string hexReturn = "";
            string tempascii = "";
            string[] newStringArray = new string[length];
            byte[] newStringByteArray = new byte[length];
            int[] newDecimal = new int[length];
            string[] final = new string[length];
            string[] s = new string[length];

            int x = 0;
            while (x < length)
            {
                newStringArray[x] = newString[x].ToString();
                tempascii = newStringArray[x];
                if (encodeOption == 0)
                {
                    hexReturn += encodeRomText0(tempascii);
                }

                x++;
            }

            int i = 0;
            int j = 0;
            while (i < length)
            {
                s[i] = hexReturn[j].ToString() + hexReturn[j + 1].ToString();
                i++;
                j += 2;
            }

            int q = 0;
            while (q < length)
            {
                newDecimal[q] = int.Parse(s[q], System.Globalization.NumberStyles.HexNumber);
                final[q] = newDecimal[q].ToString();
                newStringByteArray[q] = byte.Parse(final[q]);
                q++;
            }

            using (FileStream fileStream = new FileStream(@path, FileMode.Open, FileAccess.Write))
            {
                fileStream.Seek(offset, SeekOrigin.Begin);
                q = 0;
                while (q < length)
                {
                    fileStream.WriteByte(newStringByteArray[q]);
                    q++;
                }
            }
        }

        #region common methods

        private static string ConvertHex(String hexString)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 2)
                {
                    String hs = string.Empty;

                    hs = hexString.Substring(i, 2);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    char character = System.Convert.ToChar(decval);
                    ascii += character;

                }

                return ascii;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return string.Empty;
        }

        private static string convertHexToDecFourChar(String hexString)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 4)
                {
                    String hs = string.Empty;

                    hs = hexString.Substring(i, 4);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    // char character = System.Convert.ToChar(decval);
                    ascii += decval;

                }

                return ascii;
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
            }

            return string.Empty;
        }

        private static string convertHexToDecTwoChar(String hexString)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 2)
                {
                    String hs = string.Empty;

                    hs = hexString.Substring(i, 2);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    // char character = System.Convert.ToChar(decval);
                    ascii += decval;

                }

                return ascii;
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
            }

            return string.Empty;
        }

        private static string convertDecToHex(String decString)
        {
            int value = Convert.ToInt32(decString);
            string hexValue = String.Format("{0:X}", value);

            return hexValue;
        }

        private string getHexStringFromFile(int startPoint, int length)
        {
            string hexString = "";
            using (FileStream fileStream = new FileStream(@path, FileMode.Open, FileAccess.Read))
            {
                long offset = fileStream.Seek(startPoint, SeekOrigin.Begin);

                for (int x = 0; x < length; x++)
                {
                    hexString += fileStream.ReadByte().ToString("X2");
                }

            }

            return hexString;
        }

        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private bool writeByteArrayToFile(string fileName, int startPoint, byte[] byteArray)
        {
            bool result = false;
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    fs.Position = startPoint;
                    fs.Write(byteArray, 0, byteArray.Length);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error writing file: {0}", ex);
                result = false;
            }

            return result;
        }
        #endregion
    }
}
