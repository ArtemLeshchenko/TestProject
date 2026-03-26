using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.View
{
    public class CalculatorView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _calculateButton;
        [SerializeField] private Transform _historyContainer;
        [SerializeField] private HistoryView _historyItemPrefab;
        
        public event Action OnCalculateClicked;

        public string InputExpression => _inputField.text;
        
        private void Awake()
        {
            _calculateButton.onClick.AddListener(OnCalcButtonClicked);
        }

        private void OnDestroy()
        {
            _calculateButton.onClick.RemoveListener(OnCalcButtonClicked);
        }

        public void AddCalcHistory(string expression)
        {
           HistoryView historyView = Instantiate(_historyItemPrefab, _historyContainer.transform);
           historyView.transform.SetSiblingIndex(0);
           historyView.WriteHistory(expression);
        }

        public void ClearAndFocusOnText()
        {
            _inputField.text = string.Empty;
            _inputField.Select();
            _inputField.ActivateInputField();
        }
        
        private void OnCalcButtonClicked()
        {
            OnCalculateClicked?.Invoke();
        }
    }
}