using System;
using System.Collections.Generic;

namespace Calculator.Model
{
    [Serializable]
    public class CalculatorState
    {
        public List<HistoryEntry> History = new List<HistoryEntry>();
    }
}