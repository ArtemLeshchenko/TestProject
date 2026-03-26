using System;
using System.Text.RegularExpressions;

namespace Calculator.Model
{
    public class CalculatorModel
    {
        private readonly Regex _validationRegex = new Regex(@"^\d+\+\d+$");

        public bool IsValidExpression(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                return false;
                
            return _validationRegex.IsMatch(expression);
        }
        
        public string GetCalculationResult(string expression)
        {
            if (!IsValidExpression(expression))
                return $"ERROR";
                
            string[] parts = expression.Split('+');
            
            if (int.TryParse(parts[0], out int first) && 
                int.TryParse(parts[1], out int second))
            {
                return (first + second).ToString();
            }
            
            throw new ArgumentException("Wrong number format");
        }
    }
}