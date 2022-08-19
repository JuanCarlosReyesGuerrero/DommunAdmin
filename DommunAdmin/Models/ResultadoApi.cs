namespace DommunAdmin.Models
{
    public class ResultadoApi
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object Data { get; set; }

        public ResultadoApi()
        {
            this.Success = false;
        }
    }
}