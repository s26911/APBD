using System.Data.SqlClient;
using System.Data.SqlTypes;
using APBD_07.Models;

namespace APBD_07.Services;

public class WarehouseService : IWarehouseService
{
    private const string ConnectionString = "Data Source = db-mssql;Initial Catalog=2019SBD; Integrated Security=True";

    public decimal Edit(Warehouse warehouse)
    {
        using SqlConnection connection = new SqlConnection(ConnectionString);
        connection.Open();
        if (!IfProductExists(connection, warehouse.IdProduct))
            throw new ArgumentException("Product with given id does not exist in the database");
        if (!IfWarehouseExists(connection, warehouse.IdWarehouse))
            throw new ArgumentException("Warehouse with given id does not exist in the database");
        if (warehouse.Amount <= 0 )
            throw new ArgumentException("Amount should be greater than 0");
        if (!IfOrderExists(connection, warehouse.IdProduct, warehouse.Amount, warehouse.CreatedAt))
            throw new ArgumentException("No order in the database matching the request");

        SqlCommand command = new SqlCommand("SELECT IdOrder FROM [Order] WHERE IdProduct = @IdProduct AND Amount = @Amount",
            connection);
        command.Parameters.AddWithValue("@IdProduct", warehouse.IdProduct);
        command.Parameters.AddWithValue("@Amount", warehouse.Amount);
        int idOrder = (int)command.ExecuteScalar();
        
        if (IfRealised(connection, idOrder))
            throw new Exception("Order already realised");

        command.CommandText = "SELECT Price FROM Product WHERE IdProduct = @Id";
        command.Parameters.AddWithValue("@Id", warehouse.IdProduct);
        decimal price = (decimal)command.ExecuteScalar();
        
        UpdateFulfilledAt(connection, idOrder);
        return InsertToProdWare(connection, warehouse,idOrder, price);
        
    }

    private decimal InsertToProdWare(SqlConnection connection, Warehouse warehouse, int idOrder, decimal price)
    {
        using SqlCommand command = new SqlCommand("INSERT INTO Product_Warehouse VALUES (@IdWare, @IdProd, @IdOrde, @Amount, @Price, GETDATE())", connection);
        command.Parameters.AddWithValue("@IdWare", warehouse.IdWarehouse);
        command.Parameters.AddWithValue("@IdProd", warehouse.IdProduct);
        command.Parameters.AddWithValue("@IdOrde", idOrder);
        command.Parameters.AddWithValue("@Amount", warehouse.Amount);
        command.Parameters.AddWithValue("@Price", warehouse.Amount * price);
        command.ExecuteNonQuery();

        command.CommandText = "SELECT @@IDENTITY AS NewId;";
        return (decimal)command.ExecuteScalar();
    }

    private void UpdateFulfilledAt(SqlConnection connection, int idOrder)
    {
        using SqlCommand command = new SqlCommand("UPDATE [Order] Set FulfilledAt = GETDATE() WHERE IdOrder = @Id", connection);
        command.Parameters.AddWithValue("@Id", idOrder);
        command.ExecuteNonQuery();
    }

    private bool IfRealised(SqlConnection connection, int idOrder)
    {
        using SqlCommand command = new SqlCommand("SELECT COUNT(1) FROM Product_Warehouse WHERE IdOrder = @Id", connection);
        command.Parameters.AddWithValue("@Id", idOrder);
        return (int)command.ExecuteScalar() > 0;
    }
    
    private bool IfOrderExists(SqlConnection connection, int idProoduct, int amount, DateTime dateTime)
    {
        using SqlCommand command = new SqlCommand("SELECT CreatedAt FROM [Order] WHERE IdProduct = @Id AND Amount = @Amount", connection);
        command.Parameters.AddWithValue("@Id", idProoduct);
        command.Parameters.AddWithValue("@Amount", amount);
        Object createdAt = command.ExecuteScalar();
        if (createdAt == null)
            return false;
        return ((DateTime)createdAt).CompareTo(dateTime) > 0;
    }

    private bool IfProductExists(SqlConnection connection, int id)
    {
        using SqlCommand command = new SqlCommand("SELECT COUNT(1) FROM Product WHERE IdProduct = @Id", connection);
        command.Parameters.AddWithValue("@id", id);
        return (int)command.ExecuteScalar() > 0;
    }

    private bool IfWarehouseExists(SqlConnection connection, int id)
    {
        using SqlCommand command = new SqlCommand("SELECT COUNT(1) FROM Warehouse WHERE IdWarehouse = @Id", connection);
        command.Parameters.AddWithValue("@id", id);
        return (int)command.ExecuteScalar() > 0;
    }
}