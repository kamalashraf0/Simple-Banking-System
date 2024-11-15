namespace Simple_Banking_System.HandleResponses
{
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, bool isSuccess = false, string message = null, string details = null)
            : base(statusCode, isSuccess, message)
        {
            Details = details;
        }

        public string Details { get; set; }
    }
}
