using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class PlaydateSqlDao : IPlaydateDao
    {
        private readonly string connectionString;

        public PlaydateSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }



        public List<PlayDate> GetPlayDatesByUser(int UserId)
        {
            List<PlayDate> returnPlaydates = new List<PlayDate>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT playdates.playdate_id, playdates.creator_id, pets.name, playdates.play_park_address, play_park_name, playdates.play_park_location_notes, playdates.playdate_time_date FROM playdates JOIN user_pet_playdate ON playdates.playdate_id = user_pet_playdate.playdate_id JOIN pets ON user_pet_playdate.pet_id = pets.pet_id WHERE user_id = @userId ORDER BY playdate_time_date ASC;", conn);
                    cmd.Parameters.AddWithValue("@userId", UserId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        PlayDate playdate = GetPlayDateFromReader(reader);
                        returnPlaydates.Add(playdate);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnPlaydates;
        }




        private PlayDate GetPlayDateFromReader(SqlDataReader reader)
        {
            PlayDate p = new PlayDate()
            {
                PlayDateID = Convert.ToInt32(reader["playdate_id"]),
                CreatorID = Convert.ToInt32(reader["creator_id"]),
                PetName = Convert.ToString(reader["name"]),
                PlayParkAddress = Convert.ToString(reader["play_park_address"]),
                PlayParkName = Convert.ToString(reader["play_park_name"]),
                PlayParkLocationNotes = Convert.ToString(reader["play_park_location_notes"]),
                PlayDateTimeDate = Convert.ToDateTime(reader["playdate_time_date"]),
            };

            return p;
        }
    }
}
