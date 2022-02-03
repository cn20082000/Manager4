namespace Manager4.util.ext
{
    public static class FloatExtension
    {
        public static string ToPrint(this float num)
        {
            if (num == 0)
            {
                return "0.00";
            }
            if (num > 0)
            {
                return "+" + string.Format("{0:0.00}", num);
            }
            return string.Format("{0:0.00}", num);
        }
    }
}
