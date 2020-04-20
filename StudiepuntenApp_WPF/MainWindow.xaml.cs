﻿using System;
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
using StudiepuntenApp_business.Business;
namespace StudiepuntenApp_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        private  Controller _businesscontroller;

        public MainWindow()
        {
            InitializeComponent();
            _businesscontroller = new Controller();
            /*lbxUsers.ItemsSource = _businesscontroller.GetStudents();*/
        }

        private void BtnBevestigInLoggen_Click(object sender, RoutedEventArgs e)
        {
            Student student = _businesscontroller.getStudentLogIn(txtNaamInLoggen.Text, txtWachtwoordInLoggen.Text);
            if (student != null)
            {
                Info info = new Info();
                this.Close();
                info.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void BtnRegistreren_Click(object sender, RoutedEventArgs e)
        {
            Registreren registreren = new Registreren();
            this.Close();
            registreren.Show();
        }

        private void LbxUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnBeheerderLogIn_Click(object sender, RoutedEventArgs e)
        {
            Student student = _businesscontroller.getStudentLogIn(txtNaamInLoggen.Text, txtWachtwoordInLoggen.Text);
            if (student != null)
            {
                BeheerderLogIn beheerderlogin = new BeheerderLogIn();
                this.Close();
                beheerderlogin.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}
