namespace DommunAdmin.Models
{
    public class ResultdoApi
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object Data { get; set; }

        public ResultdoApi()
        {
            this.Success = false;
        }
    }
}