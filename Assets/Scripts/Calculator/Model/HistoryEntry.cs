using System;

namespace Calculator.Model
{
    [Serializable]
    public class HistoryEntry
    {
        public string Expression;
        public string Result;
        
        public HistoryEntry(string expression, string result)
        {
            Expression = expression;
            Result = result;
        }
        
        public override string ToString()
        {
            return $"{Expression} = {Result}";
        }
    }
}