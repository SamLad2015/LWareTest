using System.Linq;
using LWareTest.Enums;
using LWareTest.Interfaces;
using LWareTest.Objects;

namespace LWareTest.Models
{
    public class LwRover: ILwRover
    {
        private readonly PositionDetails _positionDetails;
        private readonly LwMoonSurface _surface;
        public LwRover()
        {
            _surface = new LwMoonSurface(100, 100);
            _positionDetails = new PositionDetails(Directions.South, 1, 0);
        }

        public LwMoonSurface GetParentSurface()
        {
            return _surface;
        }
    }
}