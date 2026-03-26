using System;

namespace Core
{
    public interface ICalculator
    {
        event Action<string> OnExpressionEntered;
    }
}