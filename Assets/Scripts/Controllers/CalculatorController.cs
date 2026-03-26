using Calculator.Model;
using Calculator.Presenter;
using Calculator.Services;
using Calculator.View;
using Core;
using Dialog.Presenter;
using Dialog.View;
using UnityEngine;

namespace Controllers
{
    public class CalculatorController : MonoBehaviour
    {
        [SerializeField] private CalculatorView _calculatorView;
        [SerializeField] private ErrorDialogView _errorDialogView;
        
        private ICalculator _presenter;
        private CalculatorModel _model;
        private IStorageService<CalculatorState> _storage;
        private IErrorDialog _errorDialog;
        
        private void Awake()
        {
            _model = new CalculatorModel();
            _storage = new CalculatorDataSaver();
            _errorDialog = new ErrorDialogPresenter(_errorDialogView);
            
            _presenter = new CalculatorPresenter(_calculatorView,  _model,_errorDialog, _storage);
        }

#if UNITY_EDITOR
        
        [ContextMenu("Clear All Saved Data")]
        private void OnParticleTrigger()
        {
            _storage = new CalculatorDataSaver();
            _storage.ClearData();
        }
#endif
    }
}