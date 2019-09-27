namespace FindGcd
{
    public interface ITracer
    {
        void StartTrace();
        void StopTrace();
        long GetTraceResult();
    }
}