namespace API.Services.Interfaces
{
    public interface IServiceDataBase
    {
        Task<dynamic> SP_Service(dynamic model, string sp);
        Task<dynamic> SP_Service(dynamic model, string sp, string process);
        Task<dynamic> Query_Service(string query);
    }
}
