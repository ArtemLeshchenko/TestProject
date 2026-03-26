using System;
using Core;
using Dialog.View;

namespace Dialog.Presenter
{
    public class ErrorDialogPresenter : IErrorDialog
    {
        public event Action CloseDialog;
        
        private readonly ErrorDialogView _view;
        
        public ErrorDialogPresenter(ErrorDialogView view)
        {
            _view = view;
            
            _view.OnOkButtonClicked += ErrorButtonClicked;
        }

        private void ErrorButtonClicked()
        {
            CloseDialog?.Invoke();
            _view.gameObject.SetActive(false);
        }
        
        public void ShowErrorDialog(string message)
        {
            _view.gameObject.SetActive(true);
            _view.ShowErrorDialog(message);
        }
    }
}