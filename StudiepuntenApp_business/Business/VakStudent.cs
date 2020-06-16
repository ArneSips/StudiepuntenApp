using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiepuntenApp_business.Business
{
    public class VakStudent
    {
        //velden
        private int _fkvak;
        private int _fkstudent;

        //Eigenschappen
        public int FKVak
        {
            get { return _fkvak; }
        }
        public int FKStudent
        {
            get { return _fkstudent; }
        }

        //Constructors
        public VakStudent(int fkvak, int fkstudent)
        {
            _fkvak = fkvak;
            _fkstudent = fkstudent;
        }
    }
}
