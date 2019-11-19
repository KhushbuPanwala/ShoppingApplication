using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp;
using ShoppingApp.Controllers;
using Xunit;

namespace TestProject
{
    public class MathOperationTestController
    {
        //api controller reference
        MathOperationController _mathController;
        public MathOperationTestController()
        {
            _mathController = new MathOperationController();
        }
        [Fact]
        public void Task_Add_TwoNumber()
        {
            // Arrange  
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = 6;

            // Act  
            var sum = _mathController.Add(num1, num2);

            //Assert  
            Assert.Equal(expectedValue, sum, 1);
        }

        [Fact]
        public void Task_Subtract_TwoNumber()
        {
            // Arrange  
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = -0.2;

            // Act  
            var sub = _mathController.Subtract(num1, num2);

            //Assert  
            Assert.Equal(expectedValue, sub, 1);
        }

        [Fact]
        public void Task_Multiply_TwoNumber()
        {
            // Arrange  
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = 8.99;

            // Act  
            var mult = _mathController.Multiply(num1, num2);

            //Assert  
            Assert.Equal(expectedValue, mult, 2);
        }

        [Fact]
        public void Task_Divide_TwoNumber()
        {
            // Arrange  
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = 0.94; //Rounded value  

            // Act  
            var div = _mathController.Divide(num1, num2);

            //Assert  
            Assert.Equal(expectedValue, div, 2);
        }
    }
}
