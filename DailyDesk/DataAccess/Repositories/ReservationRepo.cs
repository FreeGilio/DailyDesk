using DataAccess.DB;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ReservationRepo : IReservationRepo
    {
        private readonly DatabaseConnection databaseConnection;
        public ReservationRepo(DatabaseConnection databaseConnection)
        {
            this.databaseConnection = databaseConnection;
        }

        public List<Reservation> GetAllReservations()
        {
            List<Reservation> reservations = new List<Reservation>();

            databaseConnection.StartConnection(connection =>
            {
                string sql = "SELECT id, title, capacity, startDate, endDate FROM reservation";
                using (SqlCommand command = new SqlCommand(sql, (SqlConnection)connection))

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reservations.Add(MapReservationFromReader(reader));
                    }
                }
            });

            return reservations;
        }

        private Reservation MapReservationFromReader(SqlDataReader reader)
        {
            return new Reservation
            {
                Id = (int)reader["id"],
                Title = (string)reader["title"],
                Capacity = (int)reader["capacity"],
                StartDate = (DateTime)reader["startDate"],
                EndDate = (DateTime)reader["endDate"]         
            };
        }
    }
}
