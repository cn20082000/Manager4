using System.Text.RegularExpressions;

namespace Manager4.util.value
{
    public class Reg
    {
        public static readonly Regex Name = new Regex("^([a-zA-ZÀ-ÍÒ-ÕÙÚÝà-ãè-êìíò-õùúýĂăĐđĨĩŨũƠơƯưẠ-ỹ]\\s?)+$");
        public static readonly Regex Address = new Regex("^([a-zA-ZÀ-ÍÒ-ÕÙÚÝà-ãè-êìíò-õùúýĂăĐđĨĩŨũƠơƯưẠ-ỹ0-9]([\\s\\\\\\/\\-,]*))+$");
        public static readonly Regex PhoneNumber = new Regex("^\\+?([0-9]+\\-?)+$");
        public static readonly Regex Username = new Regex("^(?=.{4,32}$)[a-zA-Z0-9._]+$");
        public static readonly Regex Password = new Regex("^[A-Za-z\\d@$!%*#?&]{4,32}$");
        public static readonly Regex Key = new Regex("^\\d{10}$");
        public static readonly Regex KeySearch = new Regex("^[mM]\\d{1,10}$");
    }
}
