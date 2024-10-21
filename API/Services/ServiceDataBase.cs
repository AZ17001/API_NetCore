using API.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace API.Services.Interfaces
{
    public class ServiceDataBase : IServiceDataBase
    {
        // Declaramos la clase de conexion //
        private readonly ApplicationDBContext _dbContext;

        // Creamos el constructor //
        public ServiceDataBase(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Funcion para ejecucion de SP en la Bases de Datos | Se manejara en JSON | Proceso unico //
        public async Task<dynamic> SP_Service(dynamic model, string sp)
        {

            // Convertimos nuestro modelo dinamico en un string //
            string strModel = JsonConvert.SerializeObject(model);

            // Ejecutamos el procedimiento almacenado y obtenemos la respuesta //
            var sql = await _dbContext.Result.FromSql($"EXEC {sp} {strModel}").ToArrayAsync();

            // Obtenemos la data devuelta de la consulta //
            var result = sql.Single().data;

            return result;
        }

        // Funcion para ejecucion de SP en la Bases de Datos | Se manejara en JSON //
        public async Task<dynamic> SP_Service(dynamic model, string sp, string process){
                 
            // Convertimos nuestro modelo dinamico en un string //
            string strModel = JsonConvert.SerializeObject(model);

            // Ejecutamos el procedimiento almacenado y obtenemos la respuesta //
            var sql = await _dbContext.Result.FromSql($"EXEC {sp} {strModel} {process}").ToArrayAsync();

            // Obtenemos la data devuelta de la consulta //
            var result = sql.Single().data;

            return result;
        }

        // Funcion para ejecucion de querys construidas en string | Su result debe ser un JSON //
        public async Task<dynamic> Query_Service(string Query)
        {

            // Ejecutamos una query construida en string //
            var sql = await _dbContext.Result.FromSqlRaw(Query).ToListAsync();

            // Obtenemos la data devuelta de la consulta //
            var result = sql.Single().data;

            return result;
        }

        // Para consultas con parametros de tablas dadas //
        public async Task<dynamic> Query_Service(int someId)
        {
            var sql = await _dbContext.Result
                                      .FromSqlInterpolated($"SELECT * FROM SomeTable WHERE Id = {someId}")
                                      .ToListAsync();

            var result = sql.Single().data;
            return result;
        }

    }
}
