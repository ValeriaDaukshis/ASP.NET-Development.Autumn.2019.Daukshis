
namespace NODClass
{
     interface IGcd
    {
        int EvklidMethod(int a, int b);
        int BinaryMethod(int a, int b);
        int EvklidMethod(int a, int b, int c);
        int BinaryMethod(int a, int b, int c);
        int EvklidMethod(params int[] numbers);
        int BinaryMethod(params int[] numbers);
    }
}
