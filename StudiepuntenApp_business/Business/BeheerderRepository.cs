using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiepuntenApp_business.Business
{
    class BeheerderRepository
    {
        //velden
        private List<Beheerder> _beheerdersLijst = new List<Beheerder>();
        //eigenschappen
        public List<Beheerder> BeheerdersLijst
        {
            get { return _beheerdersLijst; }
            set { _beheerdersLijst = value; }
        }
        //constructor
        //methods
        public void addBeheerderToRepository(Beheerder beheer)
        {
            _beheerdersLijst.Add(beheer);
        }

        public Beheerder getBeheerderLogIn(string naam, string ww)
        {
            foreach (Beheerder beh in _beheerdersLijst)
            {
                if (beh.BeheerdersNaam == naam && beh.BeheerdersWachtWoord == ww)
                {
                    return beh;
                }
            }
            return null;
        }
    }
}
