using NUnit.Framework;
using SquareRepresentation;

namespace Matrixes.Tests
{
    public class Tests
    {
        [Test]
        public void TestDiagonal()
        {
            var diagonal = new int[3, 3] { { 1, 0, 0 }, { 0, 4, 0 }, { 0, 0, 6 } };
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(diagonal);
            Assert.AreEqual(3, diagonalMatrix.Size);
            Assert.AreEqual(9, diagonalMatrix.matrix.Length);
        }
        
        [Test]
        public void TestSquare()
        {
            var square = new int[3, 3] { { 1, 2, 3 }, { 5, 4, 8 }, { 9, 0, 6 } };
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(square);
            Assert.AreEqual(3, squareMatrix.Size);
            Assert.AreEqual(9, squareMatrix.matrix.Length);
        }
        
        [Test]
        public void TestSymmetric()
        {
            var symmetric = new int[3, 3] { { 1, 2, 3 }, { 2, 5, 4 }, { 3, 4, 0 } };
            SymmetricMatrix<int> symmetricMatrix = new SymmetricMatrix<int>(symmetric);
            Assert.AreEqual(3, symmetricMatrix.Size);
            Assert.AreEqual(9, symmetricMatrix.matrix.Length);
        }
        
        [Test]
        public void TestAdditionSquareAndDiagonal()
        {
            var diagonal = new int[3, 3] { { 1, 0, 0 }, { 0, 4, 0 }, { 0, 0, 6 } };
            var square = new int[3, 3] { { 1, 2, 3 }, { 5, 4, 8 }, { 9, 0, 6 } };
            var expected = new int[3, 3] { { 2, 2, 3 }, { 5, 8, 8 }, { 9, 0, 12 } };
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(square);
            squareMatrix.Accept(new AdditionVisitor<int>(), new DiagonalMatrix<int>(diagonal));
            Assert.AreEqual(squareMatrix.matrix, expected);
        }
        
        [Test]
        public void TestElementChoise()
        {
            var diagonal = new int[3, 3] { { 1, 0, 0 }, { 0, 4, 0 }, { 0, 0, 6 } };
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(diagonal);
            bool changed = false;
            diagonalMatrix.ElementChanged += (sender, args) => changed = true;
            diagonalMatrix[0, 0] = 5;
            Assert.AreEqual(true, changed);
        }
    }
}