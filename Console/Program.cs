// Cadena de conexión a la base de datos Oracle
using Oracle.ManagedDataAccess.Client;

string connectionString = "Data Source=localhost;User ID=sergio;Password=admin";

// Consulta SQL para insertar un registro
string insertQuery = "INSERT INTO productos (descripcion, stock) VALUES (:descripcion, :stock)";

// Datos para el nuevo registro
string descripcion = "Nuevo Registro";
int stock = 102;

try
{
using (OracleConnection connection = new OracleConnection(connectionString))
    {
        connection.Open();

        using (OracleCommand cmd = new OracleCommand(insertQuery, connection))
        {
            // Parámetros
            cmd.Parameters.Add(":descripcion", OracleDbType.Varchar2).Value = descripcion;
            cmd.Parameters.Add(":stock", OracleDbType.Varchar2).Value = stock;

            // Ejecutar la consulta
            int rowsInserted = cmd.ExecuteNonQuery();
            Console.WriteLine($"{rowsInserted} registro(s) insertado(s) correctamente.");
        }
}
}
catch (Exception ex)
{
    Console.WriteLine($"Error al insertar el registro: {ex.Message}");
}

Console.WriteLine("Presiona cualquier tecla para salir.");
Console.ReadKey();