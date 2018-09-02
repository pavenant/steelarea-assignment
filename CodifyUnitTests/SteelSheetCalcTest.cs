using CodifyTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodifyUnitTests
{
    [TestClass]
    public class SteelSheetCalcTest
    {
        [TestMethod]
        public void GetScore_NotEdge()
        {
            int[] input = { 4, 2, 3, 2, 0, 1, 2, 2, 1, 3, 0, 2, 2, 0, 1, 5 };
            
            SteelSheetCalc test = new SteelSheetCalc();
            var result = test.GetScore(1,1, SteelSheetCalc.GetGrid(input));
            Assert.AreEqual(16, result);
        }

        [TestMethod]
        public void GetScore_Edge_LeftUpper()
        {
            int[] input = { 4, 2, 3, 2, 0, 1, 2, 2, 1, 3, 0, 2, 2, 0, 1, 5 };

            SteelSheetCalc test = new SteelSheetCalc();
            var result = test.GetScore(0, 0,  SteelSheetCalc.GetGrid(input));
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void GetScore_Edge_RightUpper()
        {
            int[] input = { 4, 2, 3, 2, 0, 1, 2, 2, 1, 3, 0, 2, 2, 0, 1, 5 };

            SteelSheetCalc test = new SteelSheetCalc();
            var result = test.GetScore(0, 3, SteelSheetCalc.GetGrid(input));
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void GetScore_Edge_LowerUpper()
        {
            int[] input = { 4, 2, 3, 2, 0, 1, 2, 2, 1, 3, 0, 2, 2, 0, 1, 5 };

            SteelSheetCalc test = new SteelSheetCalc();
            var result = test.GetScore(3, 3, SteelSheetCalc.GetGrid(input));
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void GetGridPositionFromIndex()
        {
            int[] input = { 4, 2, 3, 2, 0, 1, 2, 2, 1, 3, 0, 2, 2, 0, 1, 5 };

            SteelSheetCalc test = new SteelSheetCalc();
            var result = test.GetPointsFromIndex(4, SteelSheetCalc.GetGrid(input));
            Assert.AreEqual(1, result.x);
            Assert.AreEqual(0, result.y);
        }

        [TestMethod]
        public void GetGridPositionFromIndex_EdgeLeftTop()
        {
            int[] input = { 4, 2, 3, 2, 0, 1, 2, 2, 1, 3, 0, 2, 2, 0, 1, 5 };

            SteelSheetCalc test = new SteelSheetCalc();
            var result = test.GetPointsFromIndex(0, SteelSheetCalc.GetGrid(input));
            Assert.AreEqual(0, result.x);
            Assert.AreEqual(0, result.y);
        }

        [TestMethod]
        public void GetGridPositionFromIndex_EdgeBottomRight()
        {
            int[] input = { 4, 2, 3, 2, 0, 1, 2, 2, 1, 3, 0, 2, 2, 0, 1, 5 };

            SteelSheetCalc test = new SteelSheetCalc();
            var result = test.GetPointsFromIndex(15, SteelSheetCalc.GetGrid(input));
            Assert.AreEqual(3, result.x);
            Assert.AreEqual(3, result.y);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[] input = { 4, 2, 3, 2, 0, 1, 2, 2, 1, 3, 0, 2, 2, 0, 1, 5 };

            SteelSheetCalc test = new SteelSheetCalc();
            var result = test.EvaluateSteelArea(3, 3, input);
        }

        [TestMethod]
        public void GetScoresForArea()
        {
            int[] input = { 4, 2, 3, 2, 0, 1, 2, 2, 1, 3, 0, 2, 2, 0, 1, 5 };

            SteelSheetCalc test = new SteelSheetCalc();
            var result = test.EvaluateSteelArea(5, 1,input);
            Assert.AreEqual("(1,1,16)", result);
        }

        [TestMethod]
        public void GetScoresForArea2Items()
        {
            int[] input = { 4, 2, 3, 2, 0, 1, 2, 2, 1, 3, 0, 2, 2, 0, 1, 5 };

            SteelSheetCalc test = new SteelSheetCalc();
            var result = test.EvaluateSteelArea(5, 2, input);
            Assert.AreEqual("(1,2,17)(1,1,16)", result);
        }
    }
}
