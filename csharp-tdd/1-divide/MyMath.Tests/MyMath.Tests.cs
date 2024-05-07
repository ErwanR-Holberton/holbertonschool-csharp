using NUnit.Framework;

namespace MyMath.Tests
{
    public class Tests
    {
        [Test]
        public void divide_matrix_normal()
        {
            int[,] matrix = new int[3, 3] {{ 1, 2, 3 },{ 4, 5, 6 },{ 7, 8, 9 }};
            int[,] matrix2 = new int[3, 3] {{ 2, 4, 6 },{ 8, 10, 12 },{ 14, 16, 18 }};
            int[,] result = Matrix.Divide(matrix2, 2);
            Assert.AreEqual(matrix, result);
        }
        [Test]
        public void divide_matrix_0()
        {
            int[,] matrix2 = new int[3, 3] {{ 2, 4, 6 },{ 8, 10, 12 },{ 14, 16, 18 }};
            int[,] result = Matrix.Divide(matrix2, 0);
            Assert.AreEqual(null, result);
        }
        [Test]
        public void divide_matrix_null()
        {
            int[,] result = Matrix.Divide(null, 2);
            Assert.AreEqual(null, result);
        }
    }
}
