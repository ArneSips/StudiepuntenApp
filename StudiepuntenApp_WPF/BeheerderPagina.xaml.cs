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
            lbxStudierichting.ItemsSource = _controller.GetStudierichtings();
            lbxVak.ItemsSource = _controller.GetVaks();
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

        private void BtnVoegStudierichtingToe_Click(object sender, RoutedEventArgs e)
        {
            Studierichting studierichting = new Studierichting(txtStudierichting.Text, Convert.ToInt32(txtJaren.Text));
            _controller.addStudierichting(studierichting);
            lbxStudierichting.ItemsSource = _controller.GetStudierichtings();
            lbxStudierichting.Items.Refresh();
            txtStudierichting.Clear();
            txtJaren.Clear();
        }

        private void BtnVoegVakToe_Click(object sender, RoutedEventArgs e)
        {
            Vak vak = new Vak(txtVak.Text, Convert.ToInt32(txtUren.Text), Convert.ToInt32(txtPunten.Text));
            _controller.addVak(vak);
            lbxVak.ItemsSource = _controller.GetVaks();
            lbxVak.Items.Refresh();
            txtVak.Clear();
            txtUren.Clear();
            txtPunten.Clear();
        }

        private void BtnPagina2_Click(object sender, RoutedEventArgs e)
        {
            BeheerderPagina2 beheerderspagina2 = new BeheerderPagina2();
            this.Close();
            beheerderspagina2.Show();
        }
    }
}
