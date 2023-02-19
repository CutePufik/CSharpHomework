using System;
using NUnit.Framework;
using Homework2;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestreturnArraySatisfyPred()
        {
            int[] arr = { 10, 15, 3, 5, 1, 6, -15, -145, 51 };
            Assert.That(Program.returnArraySatisfiedPred(arr,x=>x % 5 ==0),Is.EqualTo(new int[]{10,15,5,-15,-145}));
        }
        
        [Test]
        public void TestreturnArraySatisfyPred1()
        {
            int[] arr = { 10, 15, 3, 5, 1, 6, -15, -145, 51 };
            Assert.That(Program.returnArraySatisfiedPred(arr,x=>x < 0),Is.EqualTo(new int[]{-15,-145}));
        }
        
        [Test]
        public void TestreturnArraySatisfyPred2()
        {
            int[] arr = { 10, 15, 3, 5, 1, 6, -15, -145, 51 };
            Assert.That(Program.returnArraySatisfiedPred(arr,x=>x % 2 ==0),Is.EqualTo(new int[]{ 10,6}));
        }
        
        
        // vorie teste
        [Test]
        public void TestfindNumberOfStringAndDigitInMatrWithMaxSum()
        {
            int[,] matr = { { 1, 2, 3 }, { 41, 13, 51 }, { 102, -13, -14 } };
            Assert.That(Program.findNumberOfStringAndDigitInMatrWithMaxSum(matr),Is.EqualTo((2,105)));
        }
        
        
        
        [Test]
        public void TestfindNumberOfStringAndDigitInMatrWithMaxSum1()
        {
            int[,] matr = { {2,14},{3,16},{0,42},{9,-14} };
            Assert.That(Program.findNumberOfStringAndDigitInMatrWithMaxSum(matr),Is.EqualTo((3,42)));
        }
        
        [Test]
        public void TestfindNumberOfStringAndDigitInMatrWithMaxSum2()
        {
            int[,] matr = { {1,15} };
            Assert.That(Program.findNumberOfStringAndDigitInMatrWithMaxSum(matr),Is.EqualTo((1,16)));
        }
        
        
    }
}