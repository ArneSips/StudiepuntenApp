using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiepuntenApp_business.Business
{
    class VakStudentRepository
    {
        //Velden
        private List<VakStudent> _vakStudentLijst = new List<VakStudent>();
        //eigenschappen
        public List<VakStudent> VakStudentLijst
        {
            get { return _vakStudentLijst; }
            set { _vakStudentLijst = value; }
        }
        //constructor
        //methods
        public bool addVakStudentToRepository(VakStudent vakstudent)
        {
            foreach(VakStudent item in VakStudentLijst)
            {
                if (item.FKVak == vakstudent.FKVak && item.FKStudent == vakstudent.FKStudent)
                    return false;
            }
            _vakStudentLijst.Add(vakstudent);
            return true;
        }

        public List<VakStudent> getVakFromStudent(Student student)
        {
            List<VakStudent> returnlijst = new List<VakStudent>();
            foreach (VakStudent item in VakStudentLijst)
            {
                if (item.FKStudent == student.IDGebruiker)
                    returnlijst.Add(item);
            }
            return returnlijst;
        }

        public void removeVakStudentFromRepository(VakStudent vakstudent)
        {
            foreach(VakStudent item in VakStudentLijst)
            {
                if (item.FKVak == vakstudent.FKVak && item.FKStudent == vakstudent.FKStudent)
                    _vakStudentLijst.Remove(vakstudent);
            }
        }
    }
}
