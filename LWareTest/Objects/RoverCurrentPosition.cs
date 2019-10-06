using LWareTest.Enums;

namespace LWareTest.Objects
{
    public static class RoverCurrentPosition
    {
        public static Directions CurrentDirection { get; set; }
        public static string CurrentDirectionValue { get; set; }
        public static int XPosition { get; set; }
        public static int YPosition { get; set; }
    }
}