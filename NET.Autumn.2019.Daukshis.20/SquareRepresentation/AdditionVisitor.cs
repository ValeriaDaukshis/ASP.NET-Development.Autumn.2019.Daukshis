using System;

namespace SquareRepresentation
{
    public class AdditionVisitor<T> : IVisitor<T>
    {
        public SquareMatrix<T> AddBaseMatrixToSquare<T>(BaseMatrix<T> baseMatrix, SquareMatrix<T> squareMatrix)
        // так как результат - квадратная матрица, складываем все элементы
        {
            CheckInput(baseMatrix);
            
            if (baseMatrix.Size != squareMatrix.Size)
            {
                throw new ArgumentException($"matrixes {nameof(baseMatrix)}, {nameof(squareMatrix)} length are not equal");
            }
            
            for(int i = 0; i < squareMatrix.Size; i++)
            {
                for (int j = 0; j < squareMatrix.Size; j++)
                {
                    squareMatrix.matrix[i,j] = (dynamic)squareMatrix.matrix[i,j] + baseMatrix.matrix[i,j];
                }
            }

            return squareMatrix;
        }

        public SymmetricMatrix<T> AddBaseMatrixToSymmetric<T>(BaseMatrix<T> baseMatrix, SymmetricMatrix<T> symmetricMatrix)
            // так как результат - симметричная матрица, складываем элементы по главной диагонали
        {
            CheckInput(baseMatrix);
            
            if (baseMatrix.Size != symmetricMatrix.Size)
            {
                throw new ArgumentException($"matrixes {nameof(baseMatrix)}, {nameof(symmetricMatrix)} length are not equal");
            }
            
            for (int i = 0; i < symmetricMatrix.Size; i++)
            {
                for (int j = i; j < symmetricMatrix.Size; j++)
                {
                    if (i == j)
                    {
                        symmetricMatrix.matrix[i,j] = (dynamic)symmetricMatrix.matrix[i,j] + baseMatrix.matrix[i,j];
                    }                
                }
            }

            return symmetricMatrix;
        }

        public DiagonalMatrix<T> AddBaseMatrixToDiagonal<T>(BaseMatrix<T> baseMatrix, DiagonalMatrix<T> diagonalMatrix)
            // так как результат - диагональная матрица, складываем элементы по главной диагонали
        {
            CheckInput(baseMatrix);
            
            if (baseMatrix.Size != diagonalMatrix.Size)
            {
                throw new ArgumentException($"matrixes {nameof(baseMatrix)}, {nameof(diagonalMatrix)} length are not equal");
            }
            
            for (int i = 0; i < diagonalMatrix.Size; i++)
            {
                for (int j = i; j < diagonalMatrix.Size; j++)
                {
                    if (i == j)
                    {
                        diagonalMatrix.matrix[i,j] = (dynamic)diagonalMatrix.matrix[i,j] + baseMatrix.matrix[i,j];
                    }
                }
            }

            return diagonalMatrix;
        }

        private void CheckInput<T>(BaseMatrix<T> baseMatrix)
        {
            if (baseMatrix is null)
            {
                throw new ArgumentNullException(nameof(baseMatrix), $"{nameof(baseMatrix)} is null");
            }
            
            if (baseMatrix.Size == 0)
            {
                throw new ArgumentException(nameof(baseMatrix), $"{nameof(baseMatrix)} has zero length");
            }
        }
    }
}