using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFApp4
{
    /// <summary>
    /// Interaction logic for WindowAdicionar.xaml
    /// </summary>
    public partial class WindowAdicionar : Window
    {
        public Figura FiguraAdicionada { get; private set; }
        public WindowAdicionar()
        {
            InitializeComponent();

            FiguraAdicionada = new Figura();
        }
        private void btAdicionar_Click(object sender, RoutedEventArgs e)
        {
            FiguraAdicionada.Largura = tbLargura.Text;
            FiguraAdicionada.Altura = tbAltura.Text;

            if (rbQuadrado.IsChecked == true)
                FiguraAdicionada.Nome = "Quadrado";
            else if (rbRetangulo.IsChecked == true)
                FiguraAdicionada.Nome = "Retangulo";
            else
                FiguraAdicionada.Nome = "Circulo";

            this.DialogResult = true;
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            string text = "Operação cancelada.";
            MessageBox.Show(text);
            
            this.DialogResult = false;
        }
    }
}
