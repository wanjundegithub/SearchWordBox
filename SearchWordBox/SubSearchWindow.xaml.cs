

using System.Windows;

namespace SearchWordBox
{
    /// <summary>
    /// SubSearchWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SubSearchWindow 
    {
        public SubSearchWindow()
        {
            InitializeComponent();
        }

       
        private void SubWindow_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
