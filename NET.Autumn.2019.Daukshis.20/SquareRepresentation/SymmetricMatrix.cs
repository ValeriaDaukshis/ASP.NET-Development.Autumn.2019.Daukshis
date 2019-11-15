using System;

namespace SquareRepresentation
{
    public class SymmetricMatrix<T> : BaseMatrix<T>
    {
        private T value;
        
        public SymmetricMatrix(T[,] matrix)
        {
            this.matrix = matrix;
            Size = this.matrix.GetLength(0);
            CheckInput(matrix);
            ValidateInput();
        }

        public sealed override void ValidateInput()
        {
            for(int i = 0; i < Size; i++)
            {
                for (int j = i; j < Size; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if ((dynamic)matrix[i,j] != matrix[j,i])
                    {
                        throw new ArgumentException($"Matrix is not symmetric");
                    }
                }
            }
        }

        public override void Accept(IVisitor<T> visitor, BaseMatrix<T> baseMatrix)
        {
            visitor.AddBaseMatrixToSymmetric(baseMatrix, this);
        }

        public override T this[int i, int j]
        {
            get => matrix[i,j]; 
            set
            {
                if ((i == j) && (i < matrix.Length))
                {
                    this.value = value;
                    OnMatrixChanged(new ElementChangedEventArgs(i, j, this.value));
                }
            }
        }
    }
}