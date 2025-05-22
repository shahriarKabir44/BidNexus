namespace BidNexus.Utils
{

    public class ApiResponse
    {
        public string ErrorMsg { get; set; }
        public bool HasError { get; set; }
        public dynamic Extra { get; set; }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }

    }
}
