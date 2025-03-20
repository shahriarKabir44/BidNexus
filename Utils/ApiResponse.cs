namespace BidNexus.Utils
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string  ErrorMsg { get; set; }
        public bool HasError { get; set; }
    }
}
