using Microsoft.EntityFrameworkCore;
using API.DTOs;

namespace API.Data
{
    public class ApplicationDBContext: DbContext
    {
        // Constructor de la clase //
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        // Declarmos el modelo que recibiremos en la db //
        public DbSet<ResultDto> Result { set; get; }

        // Declarar aqui los modelos que vayan a ejecutar consultas que no sean un SP //

        // Creamos los modelos //
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
}
