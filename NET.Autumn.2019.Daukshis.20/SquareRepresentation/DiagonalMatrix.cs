using System;

namespace SquareRepresentation
{
    public class DiagonalMatrix<T> : BaseMatrix<T>
    {
        private T value;
        
        public DiagonalMatrix(T[,] matrix)
        {
            this.matrix = matrix;
            Size = matrix.GetLength(0);
            CheckInput(matrix);
            ValidateInput();
        }

        public sealed override void ValidateInput()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = i; j < Size; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (((dynamic)matrix[i,j] != matrix[j,i]) || (matrix[i,j].GetType() != default(T).GetType()))
                    {
                        throw new ArgumentException($"Matrix is not diagonal");
                    }
                }
            }
        }

        public override void Accept(IVisitor<T> visitor, BaseMatrix<T> baseMatrix)
        {
            visitor.AddBaseMatrixToDiagonal(baseMatrix, this);
        }

        public override T this[int i, int j]
        {
            get => matrix[i,j]; 
            set
            {
                if ((i == j) && (i < Size))
                {
                    this.value = value;
                    OnMatrixChanged(new ElementChangedEventArgs(i, j, this.value));
                }
            }
        }
    }
}