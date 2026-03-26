using System;
using Calculator.Model;
using Calculator.View;
using Core;

namespace Calculator.Presenter
{
    public class CalculatorPresenter : ICalculator
    {
        private const string ERROR_MESSAGE = "Pleas check the expression \n you just entered";
        
        private readonly CalculatorView _view;
        private readonly CalculatorModel _model;
        private readonly IErrorDialog _errorDialog;
        private readonly IStorageService<CalculatorState> _storage;
        
        public event Action<string> OnExpressionEntered;
        
        private CalculatorState _state;
        private string _lastErrorExpression;
        
        public CalculatorPresenter(CalculatorView view, CalculatorModel model, IErrorDialog errorDialog, IStorageService<CalculatorState> storage)
        {
            _view = view;
            _model = model;
            _errorDialog = errorDialog;
            _storage = storage;

            Subscribe();
            LoadState();
        }

        ~CalculatorPresenter()
        {
            Unsubscribe();
        }
        
        private void Subscribe()
        {
            _view.OnCalculateClicked += HandleCalculate;
            _errorDialog.CloseDialog += ClosedErrorDialog;
        }

        private void ClosedErrorDialog()
        {
            _view.gameObject.SetActive(true);
            _view.ClearAndFocusOnText();
        }

        private void Unsubscribe()
        {
            _view.OnCalculateClicked -= HandleCalculate;
            _errorDialog.CloseDialog -= ClosedErrorDialog;
        }
        
        private void LoadState()
        {
            _state = _storage.LoadState();

            foreach (HistoryEntry saveData in _state.History)
                _view.AddCalcHistory(saveData.ToString());
        }
        
        private void SaveState()
        {
            _storage.SaveState(_state);
        }
        
        private void HandleCalculate()
        {
            string expression = _view.InputExpression;
            
            if (string.IsNullOrWhiteSpace(expression))
              return;
            
            if (!_model.IsValidExpression(expression))
                ShowErrorPopup();
            
            string result = _model.GetCalculationResult(expression);
            
            AddToHistory(expression, result);

            OnExpressionEntered?.Invoke(expression);
            
            _view.ClearAndFocusOnText();
        }
        
        private void AddToHistory(string expression, string result)
        {
            var entry = new HistoryEntry(expression, result);
            
            _state.History.Add(entry);
            
            SaveState();
            
            _view.AddCalcHistory(entry.ToString());
        }
        
        private void ShowErrorPopup()
        {
            _view.gameObject.SetActive(false);
            _errorDialog.ShowErrorDialog(ERROR_MESSAGE);
        }
    }
}