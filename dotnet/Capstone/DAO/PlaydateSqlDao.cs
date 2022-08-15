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

        public List<PlayDateResponse> GetPlayDatesByUser(int UserId)
        {
            List<PlayDateResponse> returnPlaydates = new List<PlayDateResponse>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT pets.image_url, pets.name, playdates.playdate_id, playdates.creator_id, playdates.play_park_address, play_park_name, playdates.play_park_location_notes, playdates.playdate_time_date FROM playdates JOIN user_pet_playdate ON playdates.playdate_id = user_pet_playdate.playdate_id JOIN pets ON user_pet_playdate.pet_id = pets.pet_id WHERE user_id = @userId;", conn);
                    cmd.Parameters.AddWithValue("@userId", UserId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        PlayDate playdate = GetPlayDateFromReader(reader);
                        string petName = GetPetNameFromReader(reader);
                        string imageURL = GetImageURLFromReader(reader);
                        PlayDateResponse playDateResponse = new PlayDateResponse();
                        playDateResponse.ImageURL = imageURL;
                        playDateResponse.PetName = petName;
                        playDateResponse.PlayDateID = playdate.PlayDateID;
                        playDateResponse.CreatorID = playdate.CreatorID;
                        playDateResponse.PlayParkAddress = playdate.PlayParkAddress;
                        playDateResponse.PlayParkName = playdate.PlayParkName;
                        playDateResponse.PlayParkLocationNotes = playdate.PlayParkLocationNotes;
                        playDateResponse.PlayDateTimeDate = playdate.PlayDateTimeDate;
                        returnPlaydates.Add(playDateResponse);
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
                SqlCommand cmd = new SqlCommand("INSERT INTO playdates(creator_id, play_park_address, play_park_name, play_park_location_notes, playdate_time_date) OUTPUT INSERTED.playdate_id VALUES (@creatorId,@play_park_address,@play_park_name, @play_park_location_notes, @playdate_time_date);", conn);
                cmd.Parameters.AddWithValue("@creatorId", newPlayDate.CreatorID);
                cmd.Parameters.AddWithValue("@play_park_address", newPlayDate.PlayParkAddress);
                cmd.Parameters.AddWithValue("@play_park_location_notes", newPlayDate.PlayParkLocationNotes);
                cmd.Parameters.AddWithValue("@playdate_time_date", newPlayDate.PlayDateTimeDate);
                cmd.Parameters.AddWithValue("@play_park_name", newPlayDate.PlayParkName);
                newPlayDateId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            returnPlayDate = GetPlayDateByPlayDateId(newPlayDateId);
            return returnPlayDate;
        }
        public bool CreateUserPetPlayDate(int userId, int petId, int playdateId, string status)
        {
            bool isSucessful = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO user_pet_playdate(user_id, pet_id, playdate_id, playdate_status)VALUES(@user_id, @pet_id, @playdate_id, @status)", conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@pet_id", petId);
                    cmd.Parameters.AddWithValue("@playdate_id", playdateId);
                    cmd.Parameters.AddWithValue("@status", status);

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
                PlayParkAddress = Convert.ToString(reader["play_park_address"]),
                PlayParkName = Convert.ToString(reader["play_park_name"]),
                PlayParkLocationNotes = Convert.ToString(reader["play_park_location_notes"]),
                PlayDateTimeDate = Convert.ToDateTime(reader["playdate_time_date"]),
            };

            return p;
        }
        private string GetPetNameFromReader(SqlDataReader reader)
        {
            {
                string PetName = Convert.ToString(reader["name"]);
                return PetName;
            }
        }

        private string GetImageURLFromReader(SqlDataReader reader)
        {
            {
                string ImageURL = Convert.ToString(reader["image_url"]);
                return ImageURL;
            }
        }
    }
}
