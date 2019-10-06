using System;
using LWareTest.Exceptions;

namespace LWareTest.Models
{
    public class LwMoonSurface
    {
        public LwMoonSurface(int width, int height)
        {
            if (width > 0 && height > 0)
            {
                this.Width = width;
                this.Height = height;
            }
            else
            {
                throw new OutOfBoundsException();
            }
        }

        public int Height { get; set; }

        public int Width { get; set; }
    }
}