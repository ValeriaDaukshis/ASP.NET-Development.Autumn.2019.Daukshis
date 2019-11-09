using System;

namespace Bll.Contract
{
    public interface IDocumentLogger
    {
        void Error(Exception ex, string message);
    }
}