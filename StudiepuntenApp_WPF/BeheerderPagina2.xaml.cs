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
    /// Interaction logic for BeheerderPagina2.xaml
    /// </summary>
    public partial class BeheerderPagina2 : Window
    {
        Controller _controller;
        public BeheerderPagina2()
        {
            _controller = new Controller();
            InitializeComponent();
            lbxStudierichting.ItemsSource = _controller.GetStudierichtings();
        }

        private void btnVoegStudiejaarToe_Click(object sender, RoutedEventArgs e)
        {
             Studiejaar studiejaar = new Studiejaar(txtStudiejaar.Text, ((Studierichting)(lbxStudierichting.SelectedItem)).IDStudierichting);
             _controller.addStudiejaar(studiejaar);
             lbxStudierichting.ItemsSource = _controller.GetStudierichtings();
             lbxStudierichting.Items.Refresh();
             txtStudiejaar.Clear();
        }

        private void BtnTerug_Click(object sender, RoutedEventArgs e)
        {
            BeheerderPagina beheerderspagina = new BeheerderPagina();
            this.Close();
            beheerderspagina.Show();
        }

        private void LbxStudierichting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
