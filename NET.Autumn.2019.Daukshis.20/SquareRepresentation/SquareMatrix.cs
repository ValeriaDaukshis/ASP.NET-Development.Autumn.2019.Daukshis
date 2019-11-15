using System;

namespace SquareRepresentation
{
    public class SquareMatrix<T> : BaseMatrix<T>
    {
        private T value;
        
        public SquareMatrix(T[,] matrix)
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
                for (int j = 0; j < Size; j++)
                {
                    if (typeof(T) != matrix[i,j].GetType())
                    {
                        throw new ArgumentException($"Incompatible types");
                    }
                }
            }
        }

        public override void Accept(IVisitor<T> visitor, BaseMatrix<T> baseMatrix)
        {
            visitor.AddBaseMatrixToSquare(baseMatrix, this);
        }

        public override T this[int i, int j]
        {
            get => matrix[i,j]; 
            set
            {
                if (typeof(T) != matrix[i,j].GetType())
                {
                    throw new ArgumentException($"Incompatible types");
                }
                
                if (i < Size)
                {
                    this.value = value;
                    OnMatrixChanged(new ElementChangedEventArgs(i, j, this.value));
                }
            }
        }
    }
}