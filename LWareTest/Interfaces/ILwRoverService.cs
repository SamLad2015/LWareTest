using LWareTest.Models;
using LWareTest.Objects;

namespace LWareTest.Interfaces
{
    public interface ILwRoverService
    {
        PositionDetails GetPosition();
        void UpdatePosition(string[] command);
    }
}