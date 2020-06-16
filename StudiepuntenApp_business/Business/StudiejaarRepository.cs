using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiepuntenApp_business.Business
{
    class StudiejaarRepository
    {
        //Velden
        private List<Studiejaar> _studiejaarLijst = new List<Studiejaar>();
        //eigenschappen
        public List<Studiejaar> StudiejaarLijst
        {
            get { return _studiejaarLijst; }
            set { _studiejaarLijst = value; }
        }
        //constructor
        //methods
        public void addStudiejaarToRepository(Studiejaar studiejaar)
        {
            _studiejaarLijst.Add(studiejaar);
        }

        public int getIndexStudiejaarFromStudent(int idstudiejaar)
        {
            int index = 0;
            foreach (Studiejaar item in StudiejaarLijst)
            {
                if (item.IDStudiejaar == idstudiejaar)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }
    }
}
