using System.Data.SqlClient;
using APBD_05.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD_06.Services;

public class AnimalService : IAnimalService
{
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        var conn = new SqlConnection("Data Source = db-mssql;Initial Catalog=2019SBD; Integrated Security=True");
        conn.Open();

        var command = new SqlCommand();
        command.Connection = conn;
        command.CommandText = "SELECT * FROM Animal ORDER BY ";

        List<string> options = new List<string>() { "name", "description", "category", "area" };
        if (options.Contains(orderBy))
            command.CommandText += orderBy;
        else
            command.CommandText += "name";
        
        var reader = command.ExecuteReader();
        var animals = new List<Animal>();
        while (reader.Read())
        {
            var animal = new Animal()
            {
                Id = (int)reader["IdAnimal"],
                Name = reader["Name"].ToString(),
                Description = reader["description"].ToString(),
                Category = reader["category"].ToString(),
                Area = reader["area"].ToString()
            };
            animals.Add(animal);
        }
        
        conn.Close();

        return animals;
    }

    public int AddAnimal(Animal animal)
    {
        var conn = new SqlConnection("Data Source = db-mssql;Initial Catalog=2019SBD; Integrated Security=True");
        conn.Open();

        var command = new SqlCommand();
        command.Connection = conn;
        command.CommandText = "INSERT INTO Animal VALUES (@Name, @Description, @Category, @Area)";
        command.Parameters.AddWithValue("@Name", animal.Name);
        command.Parameters.AddWithValue("@Description", animal.Description);
        command.Parameters.AddWithValue("@Category", animal.Category);
        command.Parameters.AddWithValue("@Area", animal.Area);

        int rowsAffected = command.ExecuteNonQuery();
        conn.Close();
        return rowsAffected;
    }

    public void EditAnimal(Animal animal)
    {
        var conn = new SqlConnection("Data Source = db-mssql;Initial Catalog=2019SBD; Integrated Security=True");
        conn.Open();

        var command = new SqlCommand();
        command.Connection = conn;
        command.CommandText = "UPDATE Animal SET Name = @Name, Description = @Description, Category = @Category, Area = @Area WHERE IdAnimal = @Id";
        
        command.Parameters.AddWithValue("@Id", animal.Id);
        command.Parameters.AddWithValue("@Name", animal.Name);
        command.Parameters.AddWithValue("@Description", animal.Description);
        command.Parameters.AddWithValue("@Category", animal.Category);
        command.Parameters.AddWithValue("@Area", animal.Area);

        command.ExecuteNonQuery();
        conn.Close();
        return;
    }

    public void DeleteAnimal(int id)
    {
        var conn = new SqlConnection("Data Source = db-mssql;Initial Catalog=2019SBD; Integrated Security=True");
        conn.Open();

        var command = new SqlCommand();
        command.Connection = conn;
        command.CommandText = "DELETE FROM Animal WHERE IdAnimal = @Id";
        
        command.Parameters.AddWithValue("@Id", id);
        command.ExecuteNonQuery();
    }
}