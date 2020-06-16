using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudiepuntenApp_business.Business;
using MySql.Data.MySqlClient;
namespace StudiepuntenApp_business.Persistence
{
    class StudentStudierichtingMapper
    {
        private string _connectionString;
        public StudentStudierichtingMapper()
        {
            _connectionString = "server = localhost; user id = root;password=1234; database=studiepunten";
        }
        public StudentStudierichtingMapper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<StudentStudierichting> getStudentStudierichtingFromDB()
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            //MySqlCommand cmd = new MySqlCommand("SELECT student.Naam as Naam, studierichting.Naam as Studierichting FROM studiepunten.student_has_studierichting INNER JOIN studiepunten.student on student_has_studierichting.fkStudent = student.Naam INNER JOIN studiepunten.studierichting on student_has_studierichting.fkStudierichting = studierichting.Naam; ", conn);
            MySqlCommand cmd = new MySqlCommand("SELECT * from studiepunten.student_has_studierichting", conn);
            List <StudentStudierichting> studentStudierichtingLijst = new List<StudentStudierichting>();
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                DateTime tijd1, tijd2;
                if (!dataReader.IsDBNull(3))
                    {
                    tijd1 = Convert.ToDateTime(dataReader[3]);
                }
                else { tijd1 = DateTime.MinValue; }
                if (!dataReader.IsDBNull(4))
                {
                    tijd2 = Convert.ToDateTime(dataReader[4]);
                }
                else { tijd2 = DateTime.MinValue; }
                StudentStudierichting studentstudierichting = new StudentStudierichting(
                Convert.ToInt32(dataReader[0]),
                Convert.ToInt32(dataReader[1]),
                Convert.ToInt32(dataReader[2]),
                tijd1,
                tijd2
                );
                studentStudierichtingLijst.Add(studentstudierichting);
            }
            conn.Close();
            return studentStudierichtingLijst;
        }
        public void addStudentStudierichtingToDB(StudentStudierichting studentstudierichting)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            string opdracht = "INSERT INTO studiepunten.student_has_studierichting(idStudentVolgtRichting,fkStudent, fkStudierichting, startDatum, eindDatum) VALUES(@idstudentvolgtrichting, @fkstudent, @fkstudierichting, @startdatum, @einddatum)";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            //voeg de waarden toe, je haalt ze uit het object eval
            cmd.Parameters.AddWithValue("idstudentvolgtstudierichting", studentstudierichting.IDStudentStudierichting);
            cmd.Parameters.AddWithValue("fkstudent", studentstudierichting.FKStudent);
            cmd.Parameters.AddWithValue("fkstudierichting", studentstudierichting.FKStudierichting);
            cmd.Parameters.AddWithValue("startdatum", studentstudierichting.StartDatum);
            cmd.Parameters.AddWithValue("einddatum", studentstudierichting.EindDatum);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void AdjustStudentStudierichtingFromDB(StudentStudierichting studentstudierichting, int id)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            string opdracht = "UPDATE studiepunten.student_has_studierichting SET fkStudent = @fkstudent, fkStudierichting = @fkstudierichting, startDatum = @startdatum, eindDatum = @einddatum where (id = @id)";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            //voeg de waarden toe, je haalt ze uit het object eval
            cmd.Parameters.AddWithValue("@fkstudent", studentstudierichting.FKStudent);
            cmd.Parameters.AddWithValue("@fkstudierichting", studentstudierichting.FKStudierichting);
            cmd.Parameters.AddWithValue("@startdatum", studentstudierichting.StartDatum);
            cmd.Parameters.AddWithValue("@einddatum", studentstudierichting.EindDatum);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
    }
}
