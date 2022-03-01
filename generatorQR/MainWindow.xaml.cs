using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QRCoder;
using QRCoder.Xaml;

namespace generatorQR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPotvrzeni_Click(object sender, RoutedEventArgs e)
        {
            string zadanyText = textboxInput.Text;

            //vytvoření generátoru QR kódů
            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();

            //vytvoření dat QR kódu
            QRCodeData dataQRkodu = qRCodeGenerator.CreateQrCode(zadanyText, QRCodeGenerator.ECCLevel.M);

            //vytvoření QR kódu s daty vytvořenými nahoře :)
            XamlQRCode qrKod = new XamlQRCode(dataQRkodu);

            DrawingImage vkladanyObrazek = qrKod.GetGraphic(30);
            obrazekQR.Source = vkladanyObrazek;
        }

        private void textboxInput_MouseEnter(object sender, MouseEventArgs e)
        {
            textboxInput.Text = "";
        }
    }
}
