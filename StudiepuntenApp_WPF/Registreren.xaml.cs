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
using System.Windows.Shapes;
using StudiepuntenApp_business.Business;
namespace StudiepuntenApp_WPF
{
    /// <summary>
    /// Interaction logic for Registreren.xaml
    /// </summary>
    public partial class Registreren : Window
    {
       
            private Controller _controller;
            public Registreren()
            {
                InitializeComponent();
                _controller = new Controller();
            }

            private void BtnRegisterAccount_Click(object sender, RoutedEventArgs e)
            {
                string naam = "";
                string wachtwoord = "";

                try
                {
                    naam = txtRegisterNaam.Text;
                    wachtwoord = txtRegisterWachtwoord.Password;
                }
                finally
                {
                    Student student = new Student(naam, wachtwoord);
                    _controller.addStudent(student);
                }
                MainWindow mainwindow = new MainWindow();
                this.Close();
                mainwindow.Show();


            }
        
    }
}
