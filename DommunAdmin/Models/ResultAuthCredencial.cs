namespace DommunAdmin.Models
{
    public class ResultAuthCredencial
    {
        public bool IsAuthSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
        public string? TokenType { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}
