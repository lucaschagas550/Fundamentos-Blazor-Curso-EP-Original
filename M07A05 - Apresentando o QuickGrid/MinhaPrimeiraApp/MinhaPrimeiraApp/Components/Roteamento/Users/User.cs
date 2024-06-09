namespace MinhaPrimeiraApp.Components.Roteamento.Users;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class UserService : IUserService
{
    private List<User> users = new List<User>
    {
        new User { Id = 1, Name = "Eduardo Pires", Email = "eduardo@example.com" },
        new User { Id = 2, Name = "José da Silva", Email = "jose@example.com" },
        new User { Id = 3, Name = "Maria das Dores", Email = "maria@example.com" }
    };

    public Task<User> GetUserByIdAsync(int id)
    {
        // Simulando uma chamada assíncrona
        return Task.FromResult(users.FirstOrDefault(u => u.Id == id));
    }

    public Task<List<User>> GetAllUsersAsync()
    {
        // Simulando uma chamada assíncrona para buscar todos os usuários
        return Task.FromResult(users);
    }
}

public interface IUserService
{
    Task<User> GetUserByIdAsync(int id);
    Task<List<User>> GetAllUsersAsync();
}