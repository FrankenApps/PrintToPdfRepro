using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PrintToPdfRepro.ViewModels;

namespace PrintToPdfRepro.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel(this);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
