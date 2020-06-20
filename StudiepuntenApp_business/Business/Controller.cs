using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiepuntenApp_business.Business
{
    public class Controller
    {
        //private Vak _vak;

        private Persistence.Controller _persistController;
        private StudentRepository _studentRepository;
        private StudentStudierichtingRepository _studentStudierichtingRepository;
        private StudiejaarRepository _studiejaarRepository;
        private StudierichtingRepository _studierichtingRepository;
        private VakRepository _vakRepository;
        private VakStudentRepository _vakStudentRepository;
        private VakStudiejaarRepository _vakStudiejaarRepository;
        private Student _ingelogdeStudent;
        public Student IngelogdeStudent
        {
            get { return _ingelogdeStudent; }
        }

        public Controller()
        {
            //_vak = new Vak();

            _persistController = new Persistence.Controller();
            _studentRepository = new StudentRepository();
            _studentStudierichtingRepository = new StudentStudierichtingRepository();
            _studiejaarRepository = new StudiejaarRepository();
            _studierichtingRepository = new StudierichtingRepository();
            _vakRepository = new VakRepository();
            _vakStudentRepository = new VakStudentRepository();
            _vakStudiejaarRepository = new VakStudiejaarRepository();

            _studentRepository.StudentLijst = _persistController.getStudent();
            _studentStudierichtingRepository.StudentStudierichtingLijst = _persistController.getStudentStudierichting();
            _studiejaarRepository.StudiejaarLijst = _persistController.getStudiejaar();
            _studierichtingRepository.StudierichtingLijst = _persistController.getStudierichting();
            _vakRepository.VakLijst = _persistController.getVak();
            _vakStudentRepository.VakStudentLijst = _persistController.getVakStudent();
            _vakStudiejaarRepository.VakStudiejaarLijst = _persistController.getVakStudiejaar();
            _ingelogdeStudent = null;
        }

        public Controller(string connectionstring)
        {
            //_vak = new Vak();

            _persistController = new Persistence.Controller(connectionstring);
            _studentRepository = new StudentRepository();
            _studentStudierichtingRepository = new StudentStudierichtingRepository();
            _studiejaarRepository = new StudiejaarRepository();
            _studierichtingRepository = new StudierichtingRepository();
            _vakRepository = new VakRepository();
            _vakStudentRepository = new VakStudentRepository();
            _vakStudiejaarRepository = new VakStudiejaarRepository();
            _ingelogdeStudent = null;

            _studentRepository.StudentLijst = _persistController.getStudent();
            _studentStudierichtingRepository.StudentStudierichtingLijst = _persistController.getStudentStudierichting();
            _studiejaarRepository.StudiejaarLijst = _persistController.getStudiejaar();
            _studierichtingRepository.StudierichtingLijst = _persistController.getStudierichting();
            _vakRepository.VakLijst = _persistController.getVak();
            _vakStudentRepository.VakStudentLijst = _persistController.getVakStudent();
            _vakStudiejaarRepository.VakStudiejaarLijst = _persistController.getVakStudiejaar();
        }

        public List<Student> GetStudents()
        {
            return _studentRepository.StudentLijst;
        }
        public void addStudent(Student student)
        {
            _persistController.addStudent(student);
            _studentRepository.StudentLijst = _persistController.getStudent();
        }
        public void removeStudent(int id)
        {
            _persistController.removeStudent(id);
            _studentRepository.StudentLijst = _persistController.getStudent();
        }
        public void AdjustStudent(Student student)
        {
            _persistController.adjustStudent(student);
            _studentRepository.StudentLijst = _persistController.getStudent();
        }

        public List<StudentStudierichting> GetStudentStudierichtings()
        {
            return _studentStudierichtingRepository.StudentStudierichtingLijst;
        }
        public void addStudentStudierichting(StudentStudierichting studentstudierichting)
        {
            _persistController.addStudentStudierichting(studentstudierichting);
            _studentStudierichtingRepository.StudentStudierichtingLijst = _persistController.getStudentStudierichting();
        }
        public void AdjustStudentStudierichting(StudentStudierichting studentstudierichting, int id)
        {
            _persistController.adjustStudentStudierichting(studentstudierichting, id);
            _studentStudierichtingRepository.StudentStudierichtingLijst = _persistController.getStudentStudierichting();
        }
        public int getIndexStudierichtingIngelogdeStudent()
        {
            int idStudierichting= _studentStudierichtingRepository.getIdStudierichtingFromStudent(_ingelogdeStudent);
            return _studierichtingRepository.getIndexFromIdStudierichting(idStudierichting);
        }

        public List<Studiejaar> GetStudiejaars()
        {
            return _studiejaarRepository.StudiejaarLijst;
        }
        public void addStudiejaar(Studiejaar studiejaar)
        {
            _persistController.addStudiejaar(studiejaar);
            _studiejaarRepository.StudiejaarLijst = _persistController.getStudiejaar();
        }
        public List<Studiejaar> GetStudiejaarFromStudierichting(Studierichting studierichting)
        {
            return _persistController.getStudiejaarFromStudierichting(studierichting);
        }
        public int getIndexStudiejaarFromStudierichting(Studierichting studierichting)
        {
            int index = 0;
            List<Studiejaar> studiejaarlijst = GetStudiejaarFromStudierichting(studierichting);
            foreach (Studiejaar item in studiejaarlijst)
            {
                if (item.IDStudiejaar == _ingelogdeStudent.FKStudiejaar)
                    return index;
                index++;
            }
            return -1;
        }
        public int getIndexStudiejaarIngelogdeStudent()
        {
            return _studiejaarRepository.getIndexStudiejaarFromStudent(_ingelogdeStudent.FKStudiejaar);
        }
        public int getIndexStudiejaarIngelogdeStudent(int indexstudierichting)
        {

            return _studiejaarRepository.getIndexStudiejaarFromStudent(_ingelogdeStudent.FKStudiejaar);
        }


        public List<Studierichting> GetStudierichtings()
        {
            return _studierichtingRepository.StudierichtingLijst;
        }
        public void addStudierichting(Studierichting studierichting)
        {
            _persistController.addStudierichting(studierichting);
            _studierichtingRepository.StudierichtingLijst = _persistController.getStudierichting();
        }
        public void removeStudierichting(int id)
        {
            _persistController.removeStudierichting(id);
            _studierichtingRepository.StudierichtingLijst = _persistController.getStudierichting();
        }
        public void AdjustStudierichting(Studierichting studierichting, int id)
        {
            _persistController.adjustStudierichting(studierichting, id);
            _studierichtingRepository.StudierichtingLijst = _persistController.getStudierichting();
        }
        public bool addStudierichtingStudiejaarToStudent(Studierichting studierichting, Studiejaar studiejaar)
        {
            if (!_studentStudierichtingRepository.searchCombination(studierichting.IDStudierichting, _ingelogdeStudent.IDGebruiker))
            {
                StudentStudierichting studentstudierichting = new StudentStudierichting(_ingelogdeStudent.IDGebruiker, studierichting.IDStudierichting, DateTime.Today);
                _persistController.addStudentStudierichting(studentstudierichting);
                _studentStudierichtingRepository.StudentStudierichtingLijst = _persistController.getStudentStudierichting();
                _ingelogdeStudent.FKStudiejaar = studiejaar.IDStudiejaar;
                //pas student aan in databank en in repo                
                _persistController.adjustStudent(_ingelogdeStudent);
                _studentRepository.StudentLijst = _persistController.getStudent();
                return true;
            }
            else
                return false;
        }
        public void changeStudiejaarFromStudent(Studiejaar studiejaar)
        {
            _ingelogdeStudent.FKStudiejaar = studiejaar.IDStudiejaar;      
            _persistController.adjustStudent(_ingelogdeStudent);
            _studentRepository.StudentLijst = _persistController.getStudent();
        }
        public List<Vak> GetVaks()
        {
            return _vakRepository.VakLijst;
        }
        public void addVak(Vak vak)
        {
            _persistController.addVak(vak);
            _vakRepository.VakLijst = _persistController.getVak();
        }
        public void removeVak(int id)
        {
            _persistController.removeVak(id);
            _vakRepository.VakLijst = _persistController.getVak();
        }
        public void AdjustVak(Vak vak, int id)
        {
            _persistController.adjustVak(vak, id);
            _vakRepository.VakLijst = _persistController.getVak();
        }

        public List<VakStudent> GetVakStudents()
        {
            return _vakStudentRepository.VakStudentLijst;
        }
        public void addVakStudent(VakStudent vakstudent)
        {
            _persistController.addVakStudent(vakstudent);
            _vakStudentRepository.VakStudentLijst = _persistController.getVakStudent();
        }
        public void removeVakstudent(int idvak)
        {
            _persistController.removeVakStudent(idvak, _ingelogdeStudent.IDGebruiker);
            _vakStudentRepository.VakStudentLijst = _persistController.getVakStudent();
        }
        
        public List<Vak> getVakIngelogdeStudent()
        {
            List<VakStudent> vakstudentlijst = _vakStudentRepository.getVakFromStudent(_ingelogdeStudent);
            List<Vak> vakkenlijst = new List<Vak>();
            foreach (VakStudent item in vakstudentlijst)
            {
                Vak vak = _vakRepository.getVak(item.FKVak);
                vakkenlijst.Add(vak);
            }
            return vakkenlijst;
        }
        
        public bool addVakToStudent(Vak vak)
        {
            VakStudent vakstudent = new VakStudent (vak.IDVak, IngelogdeStudent.IDGebruiker);
            if (_vakStudentRepository.addVakStudentToRepository(vakstudent))
            {
                _persistController.addVakStudent(vakstudent);
                return true;
            }
            else
                return false;
        }

        public List<VakStudiejaar> GetVakStudiejaars()
        {
            return _vakStudiejaarRepository.VakStudiejaarLijst;
        }
        public void addVakStudiejaar(VakStudiejaar vakstudiejaar)
        {
            _persistController.addVakStudiejaar(vakstudiejaar);
            _vakStudiejaarRepository.VakStudiejaarLijst = _persistController.getVakStudiejaar();
        }
        public void removeVakStudiejaar(int idvak, int idstudiejaar)
        {
            _persistController.removeVakStudiejaar(idvak, idstudiejaar);
            _vakStudiejaarRepository.VakStudiejaarLijst = _persistController.getVakStudiejaar();
        }

        public Student getStudentLogIn(string naam, string wachtwoord)
        {
            _ingelogdeStudent = _studentRepository.getStudentLogIn(naam, wachtwoord);
            return _ingelogdeStudent;
        }

        public double getTotalPunten(List<Vak> vak)
        {
            double totalPunten = 0;

            foreach (Vak item in vak)
            {
                totalPunten += item.Punten;
            }
            return totalPunten;
        }

        public string getNaamIngelogdeStudent(List<Student> student)
        {
            return null;
        }
    }
}
