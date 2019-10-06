using System;
using LWareTest.Enums;
using LWareTest.Exceptions;
using LWareTest.Interfaces;
using Xunit;
using LWareTest.Services;

namespace LWareRover.Test
{
    public class RoverTests
    {
        [Fact]
        public void Testing_initial_position_of_the_rover()
        {
            ILwRoverService rowerService = new LwRoverService();
            rowerService.SetInitialPosition();
            var currentPosition = rowerService.GetPosition();
            Assert.Equal(currentPosition.CurrentDirection, Directions.South);
        }
        
        [Theory]
        [InlineData("50,L,23,L,4")]
        public void Given_Max_5_Commands_To_Rover(string commands)
        {
            ILwRoverService rowerService = new LwRoverService();
            rowerService.SetInitialPosition();
            rowerService.UpdatePosition(commands);
            var currentPosition = rowerService.GetPosition();
            Assert.Equal(currentPosition.CurrentDirection, Directions.North);
            Assert.Equal(currentPosition.XPosition, 24);
            Assert.Equal(currentPosition.GridNumber, 4624);
        }
        
        [Theory]
        [InlineData("L,L,L,L")]
        public void Given_Left_Left_Left_Left_To_Rover_To_Bring_to_current_Direction(string commands)
        {
            ILwRoverService rowerService = new LwRoverService();
            rowerService.SetInitialPosition();
            rowerService.UpdatePosition(commands);
            var currentPosition = rowerService.GetPosition();
            Assert.Equal(currentPosition.CurrentDirection, Directions.South);
        }
        
        [Theory]
        [InlineData("L,102")]
        public void Given_Out_Of_Bounds_Distance_Rover_To_Catch_Exception(string commands)
        {
            ILwRoverService rowerService = new LwRoverService();
            rowerService.SetInitialPosition();
            Assert.Throws<OutOfBoundsException>(() => rowerService.UpdatePosition(commands));
        }
        
        [Theory]
        [InlineData("102")]
        public void Given_Out_Of_Bounds_Distance_To_Start_Rover_To_Catch_Exception(string commands)
        {
            ILwRoverService rowerService = new LwRoverService();
            rowerService.SetInitialPosition();
            Assert.Throws<OutOfBoundsException>(() => rowerService.UpdatePosition(commands));
        }
    }
}