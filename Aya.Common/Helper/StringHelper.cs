using System.Globalization;

namespace Aya.Common.Helper
{
    public static class StringHelper
    {
        public static string ToVietNamDong(this decimal amount, bool withFormat = true)
        {
            var culture = CultureInfo.GetCultureInfo("vi-VN");
            return withFormat
                ? amount == 0 ? "0 ₫" : amount.ToString("#,### ₫", culture.NumberFormat)
                : amount == 0 ? "0" : amount.ToString("#,###", culture.NumberFormat);
        }
    }
}