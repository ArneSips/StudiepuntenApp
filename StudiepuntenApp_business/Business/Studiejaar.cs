using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiepuntenApp_business.Business
{
    public class Studiejaar
    {
        //velden
        private int _idstudiejaar;
        private string _naam;
        private int _fkStudierichting;
        private int _fkstudent;

        //Eigenschappen
        public int IDStudiejaar
        {
            get { return _idstudiejaar; }
        }
        public string Naam
        {
            get { return _naam; }
        }
        public int FKStudierichting
        {
            get { return _fkStudierichting; }
        }
        public int FKStudent
        {
            get { return _fkStudierichting; }
        }



        //Constructors
        public Studiejaar(int idstudiejaar, string naam, int fkstudierichting, int fkstudent)
        {
            _idstudiejaar = idstudiejaar;
            _naam = naam;
            _fkStudierichting = fkstudierichting;
            _fkstudent = fkstudent;
        }
        public Studiejaar(string naam, int fkstudierichting, int fkstudent)
        {
            _idstudiejaar = 0;
            _naam = naam;
            _fkStudierichting = fkstudierichting;
            _fkstudent = fkstudent;
        }

        //Methods
        public override string ToString()
        {
            return _naam;
        }
    }
}
