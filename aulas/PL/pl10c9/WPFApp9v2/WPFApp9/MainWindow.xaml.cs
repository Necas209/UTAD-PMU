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

namespace WPFApp9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private App app;
        public MainWindow()
        {
            InitializeComponent();

            app = App.Current as App;
            app.Bateria.ChargeChanged += Bateria_ChargeChanged;
            Bateria_ChargeChanged(app.Bateria.ChargeValue);
            //pbBateria.Value = app.Bateria.ChargeValue;
            //this.Title = "Gestão de Bateria - " + app.Bateria.ChargeValue + "%"; 
        }

        private void Bateria_ChargeChanged(int cargaAtual)
        {
            pbBateria.Value = cargaAtual;
            this.Title = "Gestão de Bateria - " + cargaAtual + "%";
        }

        private void btCarregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                app.Bateria.Charge(10);
            } catch (OutOfLimitsException erro) {
                //MessageBox.Show(erro.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show(erro.Message, "Erro! Carga atual = " + erro.Charge + "%", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btDescarregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                app.Bateria.Descharge(10);
            } catch (OutOfLimitsException erro) {
                //MessageBox.Show(erro.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show(erro.Message, "Erro! Carga atual = " + erro.Charge + "%", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
