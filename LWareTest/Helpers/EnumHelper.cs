using System;

namespace LWareTest.Helpers
{
    public static class EnumHelper
    {
        public static T ToEnum<T>(string @string)
        {
            if (string.IsNullOrEmpty(@string))
            {
                throw new ArgumentException();
            }
            if (@string.Length > 1)
            {
                throw new ArgumentException("Argument length greater than one");
            }
            return (T)Enum.ToObject(typeof(T), @string[0]);
        }
    }
}