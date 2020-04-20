using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiepuntenApp_business.Business
{
    class Beheerder
    {
        //velden
        private int _beheerdersID;
        private string _beheerdersnaam;
        private string _beheerderswachtwoord;

        //eigenschappen
        public int BeheerdersID
        {
            get { return _beheerdersID; }
        }
        public string BeheerdersNaam
        {
            get { return _beheerdersnaam; }
        }
        public string BeheerdersWachtWoord
        {
            get { return _beheerderswachtwoord; }
            set { _beheerderswachtwoord = value; }
        }
        //constructor
        public Beheerder(int ID, string Naam, string Wachtwoord)
        {
            _beheerdersID = ID;
            _beheerdersnaam = Naam;
            _beheerderswachtwoord = Wachtwoord;
        }
        public Beheerder(string Naam, string Wachtwoord)
        {
            _beheerdersnaam = Naam;
            _beheerderswachtwoord = Wachtwoord;
        }
        //mehtode
        public override string ToString()
        {
            return "Beheerder: " + _beheerdersID + ": " + _beheerdersnaam + " " + _beheerderswachtwoord;
        }
    }
}
