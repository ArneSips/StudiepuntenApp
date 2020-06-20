﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudiepuntenApp_business.Business;

namespace StudiepuntenApp_business.Persistence
{
    class Controller
    {
        private string _connectionString;
        public Controller()
        {
            _connectionString = "server = localhost; user id = root;password=1234; database=studiepunten";
        }
        public Controller(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Vak> GetVakFromStudentFromDB(int idstudent)
        {
            VakMapper mapper = new VakMapper(_connectionString);
            return mapper.GetVakFromStudentFromDB(idstudent);
        }

        public List<Student> getStudent()
        {
            StudentMapper mapper = new StudentMapper(_connectionString);
            return mapper.getStudentFromDB();
        }
        public void addStudent(Student student)
        {
            StudentMapper mapper = new StudentMapper(_connectionString);
            mapper.addStudentToDB(student);
        }
        public void removeStudent(int id)
        {
            StudentMapper mapper = new StudentMapper(_connectionString);
            mapper.removeStudentFromDB(id);
        }
        public void adjustStudent(Student student)
        {
            StudentMapper mapper = new StudentMapper(_connectionString);
            mapper.AdjustStudentFromDB(student);
        }

        public List<StudentStudierichting> getStudentStudierichting()
        {
            StudentStudierichtingMapper mapper = new StudentStudierichtingMapper(_connectionString);
            return mapper.getStudentStudierichtingFromDB();
        }
        public void addStudentStudierichting(StudentStudierichting studentstudierichting)
        {
            StudentStudierichtingMapper mapper = new StudentStudierichtingMapper(_connectionString);
            mapper.addStudentStudierichtingToDB(studentstudierichting);
        }
        public void adjustStudentStudierichting(StudentStudierichting studentstudierichting, int id)
        {
            StudentStudierichtingMapper mapper = new StudentStudierichtingMapper(_connectionString);
            mapper.AdjustStudentStudierichtingFromDB(studentstudierichting, id);
        }

        public List<Studiejaar> getStudiejaar()
        {
            StudiejaarMapper mapper = new StudiejaarMapper(_connectionString);
            return mapper.getStudiejaarFromDB();
        } 
        public void addStudiejaar(Studiejaar studiejaar)
        {
            StudiejaarMapper mapper = new StudiejaarMapper(_connectionString);
            mapper.addStudiejaarToDB(studiejaar);
        }
        public List<Studiejaar> getStudiejaarFromStudierichting(Studierichting studierichting)
        {
            StudiejaarMapper mapper = new StudiejaarMapper(_connectionString);
            return mapper.getStudiejaarFromStudierichtingFromDB(studierichting);
        }

        public List<Studierichting> getStudierichting()
        {
            StudierichtingMapper mapper = new StudierichtingMapper(_connectionString);
            return mapper.getStudierichtingFromDB();
        }
        public void addStudierichting(Studierichting studierichting)
        {
            StudierichtingMapper mapper = new StudierichtingMapper(_connectionString);
            mapper.addStudierichtingToDB(studierichting);
        }
        public void removeStudierichting(int id)
        {
            StudierichtingMapper mapper = new StudierichtingMapper(_connectionString);
            mapper.removeStudierichtingFromDB(id);
        }
        public void adjustStudierichting(Studierichting studierichting, int id)
        {
            StudierichtingMapper mapper = new StudierichtingMapper(_connectionString);
            mapper.AdjustStudentFromDB(studierichting, id);
        }

        public List<Vak> getVak()
        {
            VakMapper mapper = new VakMapper(_connectionString);
            return mapper.getVakFromDB();
        }
        public void addVak(Vak vak)
        {
            VakMapper mapper = new VakMapper(_connectionString);
            mapper.addVakToDB(vak);
        }
        public void removeVak(int id)
        {
            VakMapper mapper = new VakMapper(_connectionString);
            mapper.removeVakFromDB(id);
        }
        public void adjustVak(Vak vak, int id)
        {
            VakMapper mapper = new VakMapper(_connectionString);
            mapper.AdjustVakFromDB(vak, id);
        }

        public List<VakStudent> getVakStudent()
        {
            VakStudentMapper mapper = new VakStudentMapper(_connectionString);
            return mapper.getVakStudentFromDB();
        }
        public void addVakStudent(VakStudent vakStudent)
        {
            VakStudentMapper mapper = new VakStudentMapper(_connectionString);
            mapper.addVakStudentToDB(vakStudent);
        }
        public void removeVakStudent(int idVak, int idGebruiker)
        {
            VakStudentMapper mapper = new VakStudentMapper(_connectionString);
            mapper.removeVakStudentFromDB(idVak, idGebruiker);
        }

        public List<VakStudiejaar> getVakStudiejaar()
        {
            VakStudiejaarMapper mapper = new VakStudiejaarMapper(_connectionString);
            return mapper.getVakStudiejaarFromDB();
        }
        public void addVakStudiejaar(VakStudiejaar vakStudiejaar)
        {
            VakStudiejaarMapper mapper = new VakStudiejaarMapper(_connectionString);
            mapper.addVakStudiejaarToDB(vakStudiejaar);
        }
        public void removeVakStudiejaar(int idVak, int idStudiejaar)
        {
            VakStudiejaarMapper mapper = new VakStudiejaarMapper(_connectionString);
            mapper.removeVakStudiejaarFromDB(idVak, idStudiejaar);
        }

    }
}
