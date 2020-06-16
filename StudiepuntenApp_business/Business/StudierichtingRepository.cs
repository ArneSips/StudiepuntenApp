using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiepuntenApp_business.Business
{
    class StudierichtingRepository
    {

        //Velden
        private List<Studierichting> _studierichtingLijst = new List<Studierichting>();
        //eigenschappen
        public List<Studierichting> StudierichtingLijst
        {
            get { return _studierichtingLijst; }
            set { _studierichtingLijst = value; }
        }
        //constructor
        //methods
        public void addStudierichtingToRepository(Studierichting studierichting)
        {
            _studierichtingLijst.Add(studierichting);
        }
        public int getIndexFromIdStudierichting(int idStudierichting)
        {
            int index = 0;
            foreach(Studierichting item in StudierichtingLijst)
            {
                if(item.IDStudierichting == idStudierichting)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }
    }
}
