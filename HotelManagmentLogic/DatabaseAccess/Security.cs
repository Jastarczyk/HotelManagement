using System;
using System.Text;
using System.Security.Cryptography;

namespace HotelManagmentLogic.DatabaseAccess
{
    internal class Security
    {
        Random random = new Random();

        public Tuple<string, byte[]> HashPasswordSHA256(string password)
        {
            HashAlgorithm sha256m = new SHA256Managed();

            var saltValue = GenerateSaltValue(10);
            return new Tuple<string, byte[]>(saltValue, sha256m.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password + saltValue)));
        }

        public byte[] ValidateHashedPasswordSHA256(string password, string saltValue)
        {
            HashAlgorithm sha256m = new SHA256Managed();
            return sha256m.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password + saltValue));
        }

        private string GenerateSaltValue(int length)
        {
            string saltValue = string.Empty;

            char[] generatedTable = GenerateASCIITableByRange(Convert.ToInt32('!'), Convert.ToInt32('z'));

            for(int i = 0; i <= length; i++)
            {
                saltValue += generatedTable[random.Next(0, generatedTable.Length)];
            }

            return saltValue;
        }


        private char[] GenerateASCIITableByRange(int firstIndex, int lastIndex)
        {
            int asciiTablerange = lastIndex - firstIndex;
            char[] asciiTableValues = new char[asciiTablerange + 1];

            if (asciiTablerange <= 0)
            {
                return asciiTableValues;
            }

            for (int i = 0; i <= asciiTablerange; i++)
            {
                asciiTableValues[i] = Convert.ToChar(firstIndex + i);
            }

            return asciiTableValues;
        }
    }
}
