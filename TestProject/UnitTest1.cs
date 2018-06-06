using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simbirsoft1;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            GameLogic logic = new GameLogic();
            Random r = new Random();
            int n = logic.arr.Length;
            int x = (new Random()).Next(0, n);
            int y = (new Random()).Next(0, n);
            var v = r.Next(2);

            // Act
            var res = logic.fixNextStep(x,y,v);

            //Assert 
            Assert.IsTrue(res);
        }

        public void TestMethod2()
        {
            // Arrange
            GameLogic logic = new GameLogic();

            // Act
            var res = logic.isCompleted();

            //Assert 
            Assert.IsNotNull(res);

        }
    }
}
