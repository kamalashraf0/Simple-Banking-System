namespace Simple_Banking_System.HandleResponses
{
    public class ApiResponse
    {

        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode, bool isSuccess = false, string message = null)
        {

            StatusCode = statusCode;
            Message = message;
            IsSuccess = isSuccess;
        }

        private string GetDefaultMessageForStatusCode(int code)
            => code switch
            {
                400 => "Bad Request",
                401 => "You are not authorized!!",
                404 => "resource not found",
                500 => "Internal Server Error",
                _ => null
            };

    }
}
