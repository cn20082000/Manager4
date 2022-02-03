using Manager4.util.value;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Manager4.util
{
    public class Security
    {
        private static Random rd = new Random();

        public static string Hash(string raw)
        {
            // ẩn phương thức băm để bảo vệ ứng dụng đã, đang được sử dụng
            return raw;
        }

        public static string GenerateKey(string oldKey)
        {
            // ẩn phương thức sinh mã để bảo vệ ứng dụng đã, đang được sử dụng
            int seed = DecodeKey(oldKey);
            DateTime now = DateTime.Now;
            seed = (seed + 1) % 1000000;
            return now.ToString("yy") + now.ToString("MM") + seed.ToString("000000");
        }

        private static int DecodeKey(string key)
        {
            if (Reg.Key.IsMatch(key))
            {
                int seed = int.Parse(key.Substring(4, 6));
                return seed;
            }
            return 0;
        }
    }
}
