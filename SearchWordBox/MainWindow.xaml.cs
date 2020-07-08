using SearchWordBox.ViewModels;
using System;

namespace SearchWordBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new MainViewModel();
            viewModel.SearchCommand.Subscribe(async d=>
            {
                if(d)
                {
                     ShowSubWindow();
                }
                else
                {
                    await DialogUtil.ShowMessageWindowAsync("错误", "查找不到相关数据");
                }
            });
            DataContext = viewModel;
        }

        private async void ShowSubWindow()
        {
            this.Hide();
            new SubSearchWindow().Show();
        }
    }
}
