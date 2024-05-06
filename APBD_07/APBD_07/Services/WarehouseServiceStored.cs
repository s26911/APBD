using System.Data;
using System.Data.SqlClient;
using APBD_07.Models;

namespace APBD_07.Services;

public class WarehouseServiceStored : IWarehouseService
{
    private const string ConnectionString = "Data Source = db-mssql;Initial Catalog=2019SBD; Integrated Security=True";

    public decimal Edit(Warehouse warehouse)
    {
        using SqlConnection connection = new SqlConnection(ConnectionString);
        connection.Open();

        using SqlCommand command = new SqlCommand("AddProductToWarehouse", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        command.Parameters.AddWithValue("@IdProduct", warehouse.IdProduct);
        command.Parameters.AddWithValue("@IdWarehouse", warehouse.IdWarehouse);
        command.Parameters.AddWithValue("@Amount", warehouse.Amount);
        command.Parameters.AddWithValue("@CreatedAt", warehouse.CreatedAt);
        
        return (decimal)command.ExecuteScalar();
    }
}