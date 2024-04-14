using System.Reflection;
using Npgsql;

namespace PracticeTracker.Services.Tools;

public class NpgSqlRepository
{
    private String ConnectionString = "Host=localhost;Port=5432;Database=practice_tracker;Username=postgres;Password=1";

    public T Get<T>(String command) where T : new()
    {
        T objectDb = new T();

        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        {
            connection.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand(command, connection))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        objectDb = Read<T>(reader);
                    }
            }

            connection.Close();
        }

        return objectDb;
    }

    private static T Read<T>(NpgsqlDataReader reader)
    {
        var objectDb = Activator.CreateInstance<T>();

        for (int i = 0; i < reader.FieldCount; i++)
        {
            string propertyName = reader.GetName(i);
            var property = typeof(T).GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);

            if (property != null)
            {
                object value = reader.GetValue(i);

                if (value != DBNull.Value)
                {
                    property.SetValue(objectDb, value);
                }
            }
        }

        return objectDb;
    }
}
