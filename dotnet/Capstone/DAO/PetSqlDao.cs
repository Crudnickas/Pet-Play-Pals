using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;



namespace Capstone.DAO
{
    public class PetSqlDao : IPetDao
    {
        private readonly string connectionString;

        public PetSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Pet GetPetByPetId (int PetId)
        {
            Pet returnPet = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM pets WHERE pet_id = @petid;", conn);
                    cmd.Parameters.AddWithValue("@petid", PetId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnPet = GetPetFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnPet;
        }

        public List<Pet> GetPetByUser(int UserId)
        {
            List<Pet> returnPets = new List<Pet>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT pets.pet_id, pets.name, pets.age,pets.size,pets.breed,pets.temperament,pets.energy,pets.image_url,pets.bio FROM pets JOIN user_pet  ON pets.pet_id = user_pet.pet_id JOIN users ON user_pet.user_id = users.user_id WHERE users.user_id = @userId", conn);
                    cmd.Parameters.AddWithValue("@userId", UserId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Pet pet = GetPetFromReader(reader);
                        returnPets.Add(pet);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnPets;
        }

        public Pet CreatePet(Pet newPet)
        {
            Pet returnPet = null;
            int newPetId = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO pets (name,age,size,breed,temperament,energy,bio,image_url) OUTPUT INSERTED.pet_id VALUES (@name, @age, @size, @breed, @temperament, @energy, @bio, @imageURL)", conn);
                cmd.Parameters.AddWithValue("@name", newPet.Name);
                cmd.Parameters.AddWithValue("@age", newPet.Age);
                cmd.Parameters.AddWithValue("@size", newPet.Size);
                cmd.Parameters.AddWithValue("@breed", newPet.Breed);
                cmd.Parameters.AddWithValue("@temperament", newPet.Temperament);
                cmd.Parameters.AddWithValue("@energy", newPet.Energy);
                cmd.Parameters.AddWithValue("@bio", newPet.Bio);
                cmd.Parameters.AddWithValue("@imageURL", newPet.ImageURL);
                newPetId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            returnPet = GetPetByPetId(newPetId);
            return returnPet;
        }
        public bool CreatePetUser(int userId, int petId)
        {
            bool isSucessful = false;
            try {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO user_pet(user_id,pet_id) VALUES ( @userId, @petId)", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@petId", petId);

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
        private Pet GetPetFromReader (SqlDataReader reader)
        {
            Pet p = new Pet()
            {
                PetId = Convert.ToInt32(reader["pet_id"]),
                Name = Convert.ToString(reader["name"]),
                Age = Convert.ToString(reader["age"]),
                Size = Convert.ToString(reader["size"]),
                Breed = Convert.ToString(reader["breed"]),
                Temperament = Convert.ToString(reader["temperament"]),
                Energy = Convert.ToString(reader["energy"]),
                ImageURL = Convert.ToString(reader["image_url"]),
                Bio = Convert.ToString(reader["bio"])

            };

            return p;
        }
    }
}
