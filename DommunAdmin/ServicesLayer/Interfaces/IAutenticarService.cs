namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IAutenticarService
    {
        Task<string> GetToken();
        Task<string> GetBaseUrl();
    }
}
