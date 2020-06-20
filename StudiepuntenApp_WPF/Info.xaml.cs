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
    /// Interaction logic for Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        Controller _controller;

        public Info(Controller businesscontroller)
        {
            InitializeComponent();
            _controller = businesscontroller;
            //lblNameStudent.Content = _controller.GetStudents(_controller.getNaamIngelogdeStudent());
            cbxStudierichting.ItemsSource = _controller.GetStudierichtings();
            cbxStudierichting.SelectedIndex = _controller.getIndexStudierichtingIngelogdeStudent();

            int idstudiejaar = _controller.IngelogdeStudent.FKStudiejaar;
            List<Studiejaar> lijstStudiejaren = _controller.GetStudiejaarFromStudierichting((Studierichting)cbxStudierichting.SelectedItem);
            int index = 0;
            foreach (Studiejaar jaar in lijstStudiejaren)
            {
                if (jaar.IDStudiejaar == idstudiejaar)
                {
                    cbxStudiejaar.SelectedIndex = index;
                    break;
                }
                index++;
            }
           
            lbxVak.ItemsSource = _controller.GetVaks();
            lbxExtraVak.ItemsSource = _controller.getVakIngelogdeStudent();
            lblPunten.Content = _controller.getTotalPunten(_controller.getVakIngelogdeStudent());
        }

        private void BtnStudierichting_Click(object sender, RoutedEventArgs e)
        {
            //_controller.addStudierichtingToStudent((Studierichting)cbxStudierichting.SelectedItem),(Studiejaar)cbxStudiejaar.SelectedItem);
            //cbxStudiejaar.Items.Refresh();
            //cbxStudierichting.Items.Refresh();
            if (cbxStudierichting.SelectedItem != null && cbxStudiejaar.SelectedItem != null)
            {
                Studierichting studierichting = (Studierichting)cbxStudierichting.SelectedItem;
                Studiejaar studiejaar = (Studiejaar)(cbxStudiejaar.SelectedItem);
                if (_controller.addStudierichtingStudiejaarToStudent(studierichting, studiejaar))
                    MessageBox.Show("Je studierichting en studiejaar zijn toegevoegd.");
                else
                    MessageBox.Show("Deze studierichting was al toegevoegd.");
            }
            else
            {
               MessageBox.Show("Selecteer een studierichting en studiejaar!");
            }
        }

        private void CbxStudierichting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbxStudiejaar.ItemsSource = _controller.GetStudiejaarFromStudierichting((Studierichting)cbxStudierichting.SelectedItem);
            cbxStudiejaar.Items.Refresh();
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            this.Close();
            mainwindow.Show();
        }

        private void BtnVakErbij_Click(object sender, RoutedEventArgs e)
        {
            if (_controller.addVakToStudent((Vak)lbxVak.SelectedItem))
            {
                lbxExtraVak.ItemsSource = _controller.getVakIngelogdeStudent();
                lbxExtraVak.Items.Refresh();
                lblPunten.Content = _controller.getTotalPunten(_controller.getVakIngelogdeStudent());
            }
            else
                MessageBox.Show("Dit vak was al toegevoegd.");
        }

        private void BtnVakEraf_Click(object sender, RoutedEventArgs e)
        {
                Vak vak = (Vak)(lbxExtraVak.SelectedItem);
                _controller.removeVakstudent(vak.IDVak);
                lbxExtraVak.ItemsSource = _controller.getVakIngelogdeStudent();
                lbxExtraVak.Items.Refresh();
                lblPunten.Content = _controller.getTotalPunten(_controller.getVakIngelogdeStudent());
        }

        private void BtnStudiejaarAanpassen_Click(object sender, RoutedEventArgs e)
        {
            //if (cbxStudiejaar.SelectedItem != null)
            //{
            //    Studiejaar studiejaar = (Studiejaar)(cbxStudiejaar.SelectedItem);
            //    if (_controller.changeStudiejaarFromStudent(studiejaar))
            //    {
            //        MessageBox.Show("Het studiejaar is aangepast.");
            //    }
            //    else
            //        MessageBox.Show("Dit studiejaar was al toegevoegd.");
            //}
        }
    }   
}
