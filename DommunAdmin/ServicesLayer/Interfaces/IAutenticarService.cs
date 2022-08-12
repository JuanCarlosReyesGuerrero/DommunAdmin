namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IAutenticarService
    {
        Task<string> GetToken();
        string GetBaseUrl();
    }
}
