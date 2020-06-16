using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiepuntenApp_business.Business
{
    public class Student
    {
        //velden
        private int _idgebruiker;
        private string _naam;
        private string _wachtwoord;
        private double _punten;
        private int _fkstudiejaar;

        //Eigenschappen
        public int IDGebruiker
        {
            get { return _idgebruiker; }
        }
        public string Naam
        {
            get { return _naam; }
        }
        public string Wachtwoord
        {
            get { return _wachtwoord; }
            set { _wachtwoord = value; }
        }
        public double Punten
        {
            get { return _punten; }
        }
        public int FKStudiejaar
        {
            get { return _fkstudiejaar; }
            set { _fkstudiejaar = value; }
        }


        //Constructors
        public Student(int idgebruiker, string naam, string wachtwoord, double punten, int fkstudiejaar)
        {
            _idgebruiker = idgebruiker;
            _naam = naam;
            _wachtwoord = wachtwoord;
            _punten = punten;
            _fkstudiejaar = fkstudiejaar;
        }
        public Student(string naam, string wachtwoord, double punten, int fkstudiejaar)
        {
            _idgebruiker = 0;
            _naam = naam;
            _wachtwoord = wachtwoord;
            _punten = punten;
            _fkstudiejaar = fkstudiejaar;
        }

        public Student(string naam, string wachtwoord, int fkstudiejaar)
        {
            _naam = naam;
            _wachtwoord = wachtwoord;
            _fkstudiejaar = fkstudiejaar;
        }

        //Methods
        public override string ToString()
        {
            return _idgebruiker + " - " + _naam + _punten;
        }
    }
}
