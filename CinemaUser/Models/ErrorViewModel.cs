namespace CinemaUser.Models
{
    public class ErrorViewModel
    {//aa
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}