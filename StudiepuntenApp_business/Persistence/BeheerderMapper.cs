using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using StudiepuntenApp_business.Business;

namespace StudiepuntenApp_business.Persistence
{
    class BeheerderMapper
    {
        private string _connectionString;
        public BeheerderMapper()
        {
            _connectionString = "server = localhost; user id = root;password=1234; database=studiepunten";
        }
        public BeheerderMapper(string connectionstring)
        {
            _connectionString = connectionstring;
        }
        public List<Beheerder> getBeheerdersFromDB()
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            MySqlCommand cmd = new MySqlCommand("select * from studiepunten.beheerder", conn);
            List<Beheerder> beheerdersLijst = new List<Beheerder>();
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Beheerder beheerder = new Beheerder(
                Convert.ToInt16(dataReader[0]),
                dataReader[1].ToString(),
                dataReader[2].ToString()
                );
                beheerdersLijst.Add(beheerder);
            }
            conn.Close();
            return beheerdersLijst;
        }
        public void addBeheerderToDB(Beheerder beh)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            string opdracht = "INSERT INTO studiepunten.beheerder(Naam, Paswoord) VALUES('" + beh.BeheerdersNaam + "', '" + beh.BeheerdersWachtWoord + "');";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
