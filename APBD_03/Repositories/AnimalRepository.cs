using Microsoft.Data.SqlClient;
using APBD_03.Model;

namespace APBD_03.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private IConfiguration _configuration;
    
    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public IEnumerable<Animal> GetAnimals()
    {
        
        string strProject = "KUBUS"; // Wprowadź nazwę instancji serwera SQL
        string strDatabase = "Animals"; // Wprowadź nazwę bazy danych
        string strUserID = "user_two"; // Wprowadź nazwę użytkownika SQL Server
        string strPassword = "aaaa"; // Wprowadź hasło użytkownika SQL Server
        string strconn = "data source=" + strProject +
                         ";Persist Security Info=false;database=" + strDatabase +
                         ";user id=" + strUserID + ";password=" +
                         strPassword +
                         ";Connection Timeout = 0;trustServerCertificate=true;";
        using var con = new SqlConnection(strconn);
        
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY Name";
        
        var dr = cmd.ExecuteReader();
        var animals = new List<Animal>();
        while (dr.Read())
        {
            var grade = new Animal()
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString(),
            };
            animals.Add(grade);
        }
        
        return animals;
    }

    public Animal GetAnimal(int idAnimal)
    {
        string strProject = "KUBUS"; // Wprowadź nazwę instancji serwera SQL
        string strDatabase = "Animals"; // Wprowadź nazwę bazy danych
        string strUserID = "user_two"; // Wprowadź nazwę użytkownika SQL Server
        string strPassword = "aaaa"; // Wprowadź hasło użytkownika SQL Server
        string strconn = "data source=" + strProject +
                         ";Persist Security Info=false;database=" + strDatabase +
                         ";user id=" + strUserID + ";password=" +
                         strPassword +
                         ";Connection Timeout = 0;trustServerCertificate=true;";
        using var con = new SqlConnection(strconn);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);
        
        var dr = cmd.ExecuteReader();
        
        if (!dr.Read()) return null;
        
        var animal = new Animal()
        {
            IdAnimal = (int)dr["IdAnimal"],
            Name = dr["Name"].ToString(),
            Description = dr["Description"].ToString(),
            Category = dr["Category"].ToString(),
            Area = dr["Area"].ToString(),
        };
        
        return animal;
    }

    public IEnumerable<Animal> GetAnimal()
    {
        throw new NotImplementedException();
    }

    public int CreateAnimal(Animal animal)
    {
        string strProject = "KUBUS"; // Wprowadź nazwę instancji serwera SQL
        string strDatabase = "Animals"; // Wprowadź nazwę bazy danych
        string strUserID = "user_two"; // Wprowadź nazwę użytkownika SQL Server
        string strPassword = "aaaa"; // Wprowadź hasło użytkownika SQL Server
        string strconn = "data source=" + strProject +
                         ";Persist Security Info=false;database=" + strDatabase +
                         ";user id=" + strUserID + ";password=" +
                         strPassword +
                         ";Connection Timeout = 0;trustServerCertificate=true;";
        using var con = new SqlConnection(strconn);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO Animal(IdAnimal, Name, Description, Category, Area) VALUES(@Name, @Description, @Category, @Area)";
        cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    
    public int DeleteAnimal(int id)
    {
        string strProject = "KUBUS"; // Wprowadź nazwę instancji serwera SQL
        string strDatabase = "Animals"; // Wprowadź nazwę bazy danych
        string strUserID = "user_two"; // Wprowadź nazwę użytkownika SQL Server
        string strPassword = "aaaa"; // Wprowadź hasło użytkownika SQL Server
        string strconn = "data source=" + strProject +
                         ";Persist Security Info=false;database=" + strDatabase +
                         ";user id=" + strUserID + ";password=" +
                         strPassword +
                         ";Connection Timeout = 0;trustServerCertificate=true;";
        using var con = new SqlConnection(strconn);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Animal WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", id);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int UpdateAnimal(Animal animal)
    {
        string strProject = "KUBUS"; // Wprowadź nazwę instancji serwera SQL
        string strDatabase = "Animals"; // Wprowadź nazwę bazy danych
        string strUserID = "user_two"; // Wprowadź nazwę użytkownika SQL Server
        string strPassword = "aaaa"; // Wprowadź hasło użytkownika SQL Server
        string strconn = "data source=" + strProject +
                         ";Persist Security Info=false;database=" + strDatabase +
                         ";user id=" + strUserID + ";password=" +
                         strPassword +
                         ";Connection Timeout = 0;trustServerCertificate=true;";
        using var con = new SqlConnection(strconn);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE Animal SET Name=@Name, Description=@Description, Category=@Category, Area=@Area WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}