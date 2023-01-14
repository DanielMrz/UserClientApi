using Microsoft.EntityFrameworkCore;
using UserClientApi.Entities;

namespace UserClientApi.Model

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        // Utworzenie właściwości o nazwie naszej nowej tabeli specjalnego typu DbSet przyjmujący generyczny parametr dla typu,
        // który będzie reprezentować konkretną tabele
        public DbSet<UserClient> UserClients => Set<UserClient>(); 
    }
}
