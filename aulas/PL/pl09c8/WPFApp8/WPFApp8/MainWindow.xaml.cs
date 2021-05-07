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

namespace WPFApp8
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

            app.Escola.InitEnded += MainWindows_Initended;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            app.Escola.Init();
        }

        private void MainWindows_Initended()
        {
            tbEscola.Text = app.Escola.Nome;

            foreach (Departamento dep in app.Escola)
            {
                cbDepartamentos.Items.Add(dep.Nome);
            }
        }

        private void cbDepartamentos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sbiNDocentes.Content = "Departamento com " + app.Escola.GetNDocentes(cbDepartamentos.SelectedIndex) + " docentes";
        }
    }
}
