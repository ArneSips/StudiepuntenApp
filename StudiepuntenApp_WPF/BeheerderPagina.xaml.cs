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
    /// Interaction logic for BeheerderPagina.xaml
    /// </summary>
    public partial class BeheerderPagina : Window
    {
        Controller _controller;
        public BeheerderPagina()
        {
            InitializeComponent();
            _controller = new Controller();
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            this.Close();
            mainwindow.Show();
        }

        private void BtnVerwijderVak_Click(object sender, RoutedEventArgs e)
        {
            Vak vak = (Vak)(lbxVak.SelectedItem);
            _controller.removeVak(vak.IDVak);
            lbxVak.ItemsSource = _controller.GetVaks();
            lbxVak.Items.Refresh();
        }

        private void BtnVerwijderStudierichting_Click(object sender, RoutedEventArgs e)
        {
            Studierichting studierichting = (Studierichting)(lbxStudierichting.SelectedItem);
            _controller.removeStudierichting(studierichting.IDStudierichting);
            lbxStudierichting.ItemsSource = _controller.GetStudierichtings();
            lbxStudierichting.Items.Refresh();
        }
    }
}
