namespace SquareRepresentation
{
    public interface IVisitor<T>
    {
        // class symmetric
        SquareMatrix<T> AddBaseMatrixToSquare<T>(BaseMatrix<T> baseMatrix, SquareMatrix<T> squareMatrix); 
        SymmetricMatrix<T> AddBaseMatrixToSymmetric<T>(BaseMatrix<T> baseMatrix, SymmetricMatrix<T> symmetricMatrix);
        // class diagonal
        DiagonalMatrix<T> AddBaseMatrixToDiagonal<T>(BaseMatrix<T> baseMatrix, DiagonalMatrix<T> diagonalMatrix); 
        //void AddSymmetricMatrixToDiagonal(); 
        
        // class square
       // void AddDiagonalMatrixToSquare(); 
        //void AddSymmetricMatrixToSquare();
    }
}