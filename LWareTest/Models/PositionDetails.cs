using System;
using LWareTest.Enums;

namespace LWareTest.Models
{
    public class PositionDetails
    {
        public PositionDetails(Directions currentDirection, int xPosition, int yPosition)
        {
            CurrentDirection = currentDirection;
            XPosition = xPosition;
            YPosition = yPosition;
        }

        public Directions CurrentDirection { get; set; }
        
        public string CurrentDirectionValue { get; set; }

        public int XPosition { get; set; }

        public int YPosition { get; set; }
        
        public int GridNumber { get; set; }
        
        public string LastStatusTime { get; set; }
    }
}