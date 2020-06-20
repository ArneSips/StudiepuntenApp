using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiepuntenApp_business.Business
{
    class StudentStudierichtingRepository
    {
        //Velden
        private List<StudentStudierichting> _studentStudierichtingLijst = new List<StudentStudierichting>();
        //eigenschappen
        public List<StudentStudierichting> StudentStudierichtingLijst
        {
            get { return _studentStudierichtingLijst; }
            set { _studentStudierichtingLijst = value; }
        }
        //constructor
        //methods
        public void addStudentStudierichtingToRepository(StudentStudierichting studentStudierichting)
        {
            _studentStudierichtingLijst.Add(studentStudierichting);
        }

        public int getIdStudierichtingFromStudent(Student student)
        {
            foreach(StudentStudierichting item in StudentStudierichtingLijst)
            {
                if (item.FKStudent == student.IDGebruiker && item.EindDatum == DateTime.MinValue)
                    return item.FKStudierichting;
            }
            return -1;
        }
        public bool searchCombination(int idStudierichting, int idStudent)
        {
            foreach (StudentStudierichting item in StudentStudierichtingLijst)
            {
                if (item.FKStudent == idStudent && item.FKStudierichting == idStudierichting)
                    return true;
            }
            return false;
        }
    }
}
