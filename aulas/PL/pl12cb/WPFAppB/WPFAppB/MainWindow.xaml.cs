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

using Microsoft.Win32;


namespace WPFAppB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const char TVS = ':';
        private App app;

        public MainWindow()
        {
            InitializeComponent();

            app = App.Current as App;

            app.Enrolments.ReadEnded += Model_Inscricoes_LeituraTerminada;
            app.Enrolments.EnrolmentsUpdated += Model_Inscricoes_LeituraTerminada;
            app.Enrolments.WriteEnded += Model_Inscricoes_EscritaTerminada;
    }

    private void Model_Inscricoes_LeituraTerminada()
        {
            TreeViewItem inscritos = new TreeViewItem();
            inscritos.Header = "Inscritos";
            TreeViewItem naoinscritos = new TreeViewItem();
            naoinscritos.Header = "Não Inscritos";

            foreach (Student student in app.Enrolments.students.Values)
            {
                string line = student.Number + TVS + student.Name + TVS + student.Course;
                if (student.Subscribed)
                    inscritos.Items.Add(line);
                else
                    naoinscritos.Items.Add(line);
            }

            tvAlunos.Items.Clear();
            tvAlunos.Items.Add(inscritos);
            tvAlunos.Items.Add(naoinscritos);
        }

        private void Model_Inscricoes_EscritaTerminada()
        {
            MessageBox.Show("Ficheiro guardado com sucesso!");
        }

        private void MenuItem_AbrirTXT_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Ficheiros de texto|*.txt|Todos os ficheiros|*.*";
            if (dlg.ShowDialog() == true)
                app.Enrolments.ReadFromTXT(dlg.FileName);
        }

        private void MenuItem_GuardarTXT_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Ficheiros de texto|*.txt|Todos os ficheiros|*.*";
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    app.Enrolments.WriteToTXT(dlg.FileName);
                } catch (ApplicationException erro) {
                    MessageBox.Show(erro.Message);
                }
            }
        }

        private void MenuItem_AbrirXML_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Ficheiros XML|*.xml|Todos os ficheiros|*.*";
            if (dlg.ShowDialog() == true)
                app.Enrolments.ReadFromXML(dlg.FileName);
        }

        private void MenuItem_GuardarXML_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Ficheiros XML|*.xml|Todos os ficheiros|*.*";
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    app.Enrolments.WriteToXML(dlg.FileName);
                }
                catch (ApplicationException erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }

        private void TvAlunos_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (tvAlunos.SelectedValue != null)
                app.Enrolments.ChangeSubscrition(tvAlunos.SelectedValue.ToString().Split(TVS)[0]);
        }
    }
}
