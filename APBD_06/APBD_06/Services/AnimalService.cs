using System.Data.SqlClient;
using APBD_05.Models;

namespace APBD_06.Services;

public class AnimalService : IAnimalService
{
    public IEnumerable<Animal> GetAnimals(string sortBy)
    {
        var conn = new SqlConnection("Data Source = db-mssql;Initial Catalog=2019SBD; Integrated Security=True");
        conn.Open();

        using var command = new SqlCommand();
        command.Connection = conn;
        command.CommandText = "CREATE TABLE Animal (\n    IdAnimal int  NOT NULL IDENTITY,\n    Name nvarchar(200)  NOT NULL,\n    Description nvarchar(200)  NULL,\n    Category nvarchar(200)  NOT NULL,\n    Area nvarchar(200)  NOT NULL,\n    CONSTRAINT Animal_pk PRIMARY KEY  (IdAnimal)\n);";

        Console.WriteLine("Affected: " + command.ExecuteNonQuery());
        var reader = command.ExecuteReader();
        var animals = new List<Animal>();
        // while (reader.Read())
        // {
        //     Console.WriteLine(reader["id"]);
        // }
        
        conn.Close();

        return animals;
    }
}