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
using System.Windows.Shapes;
using StudiepuntenApp_business.Business;

namespace StudiepuntenApp_WPF
{
    /// <summary>
    /// Interaction logic for BeheerderLogIn.xaml
    /// </summary>
    public partial class BeheerderLogIn : Window
    {
        private Controller _businesscontroller;
        public BeheerderLogIn()
        {
            InitializeComponent();
            _businesscontroller = new Controller();
        }

        private void BtnTerug_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            this.Close();
            mainwindow.Show();
        }

        private void BtnBevestigInLoggenBeheerder_Click(object sender, RoutedEventArgs e)
        {
            Student student = _businesscontroller.getStudentLogIn(txtNaamInLoggen.Text, txtWachtwoordInLoggen.Text);
            if (student != null)
            {
                BeheerderPagina beheerderpagina  = new BeheerderPagina();
                this.Close();
                beheerderpagina.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}
