using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reactive;
using System.Text;

namespace PrintToPdfRepro.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        Window window;

        public ReactiveCommand<Unit, Unit> PrintTestPageCommand { get; }

        private string selectedPrinter = null;
        public string SelectedPrinter
        {
            get => selectedPrinter;
            set => this.RaiseAndSetIfChanged(ref selectedPrinter, value);
        }

        private List<string> installedPrinters = new List<string>();
        public List<string> InstalledPrinters
        {
            get => installedPrinters;
            set => this.RaiseAndSetIfChanged(ref installedPrinters, value);
        }

        public MainWindowViewModel(Window _window)
        {
            InstalledPrinters = System.Drawing.Printing.PrinterSettings.InstalledPrinters.Cast<string>().ToList();
            SelectedPrinter = InstalledPrinters.FirstOrDefault();
            window = _window;

            PrintTestPageCommand = ReactiveCommand.Create(PrintTestPage);
        }

        private void PrintTestPage()
        {
            //window.Hide();

            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = SelectedPrinter;
            pd.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                e1.Graphics.DrawString("This is a test page.", new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(0, 0, pd.DefaultPageSettings.PrintableArea.Width, pd.DefaultPageSettings.PrintableArea.Height));

            };
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while printing: ", ex);
            }

            //window.Show();
        }
    }
}
