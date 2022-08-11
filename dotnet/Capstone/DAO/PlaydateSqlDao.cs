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



        //public List<PlayDate> GetPlayDatesByUser(int UserId)
        //{
        //    List<PlayDate> returnPlaydates = new List<PlayDate>();

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();

        //            SqlCommand cmd = new SqlCommand("SELECT playdates.playdate_id, playdates.creator_id, pets.name, playdates.play_park_address, play_park_name, playdates.play_park_location_notes, playdates.playdate_time_date FROM playdates JOIN user_pet_playdate ON playdates.playdate_id = user_pet_playdate.playdate_id JOIN pets ON user_pet_playdate.pet_id = pets.pet_id WHERE user_id = @userId;", conn);
        //            cmd.Parameters.AddWithValue("@userId", UserId);
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                PlayDate playdate = GetPlayDateFromReader(reader);
        //                returnPlaydates.Add(playdate);
        //            }
        //        }
        //    }
        //    catch (SqlException)
        //    {
        //        throw;
        //    }

        //    return returnPlaydates;
        //}

        public List<PlayDate> GetPlayDatesByUser(int UserId)
        {
            List<PlayDate> returnPlaydates = new List<PlayDate>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT playdates.playdate_id, playdates.creator_id, playdates.play_park_address, play_park_name, playdates.play_park_location_notes, playdates.playdate_time_date FROM playdates WHERE creator_id = @userId;", conn);
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

        public PlayDate GetPlayDateByPlayDateId(int PlayDateID)
        {
            PlayDate returnPlayDate = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from playdates Where playdate_id = @playdate_id", conn);
                    cmd.Parameters.AddWithValue("@playdate_id", PlayDateID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnPlayDate = GetPlayDateFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnPlayDate;
        }
        public PlayDate CreatePlayDate(PlayDate newPlayDate)
        {
            PlayDate returnPlayDate = null;
            int newPlayDateId = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO playdates(creator_id, play_park_address, play_park_name, play_park_location_notes, playdate_time_date) VALUES (@creatorId, '@play_park_address', '@play_park_name', '@play_park_location_notes', '@playdate_time_date')", conn);
                cmd.Parameters.AddWithValue("@creatorId", newPlayDate.CreatorID);
                cmd.Parameters.AddWithValue("@play_park_address", newPlayDate.PlayParkAddress);
                cmd.Parameters.AddWithValue("@play_park_location_notes", newPlayDate.PlayParkLocationNotes);
                cmd.Parameters.AddWithValue("@playdate_time_date", newPlayDate.PlayDateTimeDate);
                cmd.Parameters.AddWithValue("@play_park_name", newPlayDate.PlayParkName);
                newPlayDateId= Convert.ToInt32(cmd.ExecuteScalar());
            }
            returnPlayDate = GetPlayDateByPlayDateId(newPlayDateId);
            return returnPlayDate;
        }
        public bool CreateUserPetPlayDate(int userId, int petId, int playdateId)
        {
            bool isSucessful = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO user_pet_playdate(user_id, pet_id, playdate_id, playdate_status)VALUES(@user_id, @pet_id, @playdate_id, 'pending'))", conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@pet_id", petId);
                    cmd.Parameters.AddWithValue("@playdate_id", playdateId);

                    int numberOfRows = cmd.ExecuteNonQuery();
                    if (numberOfRows > 0)
                    {
                        isSucessful = true;
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }


            return isSucessful;
        }




        private PlayDate GetPlayDateFromReader(SqlDataReader reader)
        {
            PlayDate p = new PlayDate()
            {
                PlayDateID = Convert.ToInt32(reader["playdate_id"]),
                CreatorID = Convert.ToInt32(reader["creator_id"]),
                //PetName = Convert.ToString(reader["name"]),
                PlayParkAddress = Convert.ToString(reader["play_park_address"]),
                PlayParkName = Convert.ToString(reader["play_park_name"]),
                PlayParkLocationNotes = Convert.ToString(reader["play_park_location_notes"]),
                PlayDateTimeDate = Convert.ToDateTime(reader["playdate_time_date"]),
            };

            return p;
        }
    }
}
