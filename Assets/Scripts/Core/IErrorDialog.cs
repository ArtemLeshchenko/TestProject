using System;

namespace Core
{
    public interface IErrorDialog
    {
        event Action CloseDialog;
        
        void ShowErrorDialog(string message);
    }
}