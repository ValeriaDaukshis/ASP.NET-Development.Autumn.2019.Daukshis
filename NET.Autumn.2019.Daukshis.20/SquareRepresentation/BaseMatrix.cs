using System;

namespace SquareRepresentation
{
    public abstract class BaseMatrix<T>
    {
        public T[,] matrix { get; set; }
        public int Size { get; set; }
        public void CheckInput(T[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), $"{nameof(matrix)} is null");
            }
            
            if (matrix.Length == 0)
            {
                throw new ArgumentException(nameof(matrix), $"{nameof(matrix)} has zero length");
            }
        }

        public abstract void ValidateInput();

        public abstract void Accept(IVisitor<T> visitor, BaseMatrix<T> baseMatrix);
        
        public abstract T this[int i, int j] { get; set; }

        public event EventHandler<ElementChangedEventArgs> ElementChanged = OnElementChangedWriter;
        
        protected void OnMatrixChanged(ElementChangedEventArgs info)
        {
            var temp = ElementChanged;
            temp?.Invoke(this, info);
        }

        private static void OnElementChangedWriter(Object sender, ElementChangedEventArgs info)
        {
            if (info is null)
            {
                throw new ArgumentNullException();
            }
            
            Console.WriteLine($"Element with indexes [{info.IndexI}][{info.IndexJ}] changed to {info.Value}");
        }    
        
        public class ElementChangedEventArgs : EventArgs
        {
            public int IndexJ { get; set; }
            public int IndexI { get; set; }
            public T Value { get; set; }

            public ElementChangedEventArgs(int i, int j, T value)
            {
                IndexI = i;
                IndexJ = j;
                Value = value;
            }
        }
    }
}