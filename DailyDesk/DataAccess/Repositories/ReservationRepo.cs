﻿using DataAccess.DB;
using Logic.Interfaces;
using Logic.Models;
using Logic.DTO;
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

        public ReservationDto GetReservationDtoById(int reservationId)
        {
            ReservationDto result = null;

            databaseConnection.StartConnection(connection =>
            {
                string sql = @"
                SELECT
                    r.id,
                    r.title,
                    r.capacity,
                    r.startDate,
                    r.endDate,
                    u.username
                FROM 
                    reservation r  
                LEFT JOIN reservationuser ru ON r.id = ru.reservation_id
                LEFT JOIN [user] u ON ru.user_id = u.id
                WHERE 
                    r.id = @Id";
                using (SqlCommand command = new SqlCommand(sql, (SqlConnection)connection))
                {
                    command.Parameters.Add(new SqlParameter("@Id", reservationId));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {                         
                                result = MapReservationFromReader(reader);

                            // Add each username to the list
                            if (!(reader["username"] is DBNull))
                            {
                                result.Usernames.Add((string)reader["username"]);
                            }
                        }
                    }
                }
            });

            return result;
        }

        public List<ReservationDto> GetAllReservations()
        {
            List<ReservationDto> reservations = new List<ReservationDto>();

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

        public void AddReservationDto(ReservationDto reservationToAdd)
        {
            databaseConnection.StartConnection(connection =>
            {
                string insertSql = "INSERT INTO reservation (title, capacity, startDate, endDate) VALUES (@Title, @Capacity, @StartDate, @EndDate);";
                using (SqlCommand insertCommand = new SqlCommand(insertSql, (SqlConnection)connection))
                {
                    insertCommand.Parameters.Add(new SqlParameter("@Title", reservationToAdd.Title));
                    insertCommand.Parameters.Add(new SqlParameter("@Capacity", reservationToAdd.Capacity));
                    insertCommand.Parameters.Add(new SqlParameter("@StartDate", reservationToAdd.StartDate));
                    insertCommand.Parameters.Add(new SqlParameter("@EndDate", reservationToAdd.EndDate));

                    insertCommand.ExecuteNonQuery();

                }
            });
        }
        public void DeleteReservation(int id)
        {
            databaseConnection.StartConnection(connection =>
            {
                string deleteSql = "DELETE FROM reservation WHERE id = @Id";
                using (SqlCommand deleteCommand = new SqlCommand(deleteSql, (SqlConnection)connection))
                {
                    deleteCommand.Parameters.Add(new SqlParameter("@Id", id));
                    deleteCommand.ExecuteNonQuery();
                }
            });
        }

        private ReservationDto MapReservationFromReader(SqlDataReader reader)
        {
            return new ReservationDto
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
