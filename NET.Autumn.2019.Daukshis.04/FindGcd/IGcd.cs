namespace FindGcd
{
    public interface IGcd
    {
        int FindGcdByEuclidean(int a, int b); 
        int FindGcdByEuclidean(int a, int b, int c); 
        int FindGcdByEuclidean(params int[] numbers);
        
        int FindGcdByStein(int a, int b);
        int FindGcdByStein(int a, int b, int c);
        int FindGcdByStein(params int[] numbers);
    }
}