using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Dialog.View
{
    public class ErrorDialogView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _errorMessageText;
        [SerializeField] private Button _errorOkButton;

        public event Action OnOkButtonClicked;
        
        private void Awake()
        {
            _errorOkButton.onClick.AddListener(ButtonClicked);
        }

        private void OnDestroy()
        {
            _errorOkButton.onClick.RemoveListener(ButtonClicked);
        }

        public void ShowErrorDialog(string errorMessage)
        {
            _errorMessageText.text = errorMessage;
        }
        
        private void ButtonClicked()
        {
            OnOkButtonClicked?.Invoke();
        }
    }
}