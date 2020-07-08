using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace SearchWordBox
{
    public static class DialogUtil
    {
        private static  MetroWindow _customWindow { get; }

        private static Stack<CustomDialog> _customDialogs { get; set; }

        static DialogUtil()
        {
            _customWindow = Application.Current.MainWindow as MetroWindow;
        }

        public async static Task ShowMessageWindowAsync(string title,string message)
        {
            await _customWindow.ShowMessageAsync(title, message);
        }

        public async static Task ShowCustomWindowAsync(string title,object content,MetroDialogSettings settings=null)
        {
            CustomDialog customDialog = new CustomDialog(settings ?? _customWindow.MetroDialogOptions);
            customDialog.Title = title;
            customDialog.Content = content;
            _customDialogs.Push(customDialog);
            await _customWindow.ShowMetroDialogAsync(customDialog);
            await customDialog.WaitUntilUnloadedAsync();
        }

        public async static Task CloseCustomWindowAsync()
        {
            if(_customDialogs.Count>0)
            {
                var customDialog = _customDialogs.Pop();
                customDialog.Content = null;
                customDialog.DialogSettings.AnimateHide = false;
                await _customWindow.HideMetroDialogAsync(customDialog);
            }
        }
    }
}
