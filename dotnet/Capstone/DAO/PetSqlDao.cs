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

        public List<Pet> GetPetByUser(int UserId)
        {
            List<Pet> returnPets = new List<Pet>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT pets.pet_id, pets.name, pets.age,pets.size,pets.breed,pets.temperament,pets.energy,pets.bio FROM pets JOIN user_pet  ON pets.pet_id = user_pet.pet_id JOIN users ON user_pet.user_id = users.user_id WHERE users.user_id = @userId", conn);
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
                Bio = Convert.ToString(reader["bio"])

            };

            return p;
        }
    }
}
