namespace Simple_Banking_System.HandleResponses
{
    public class ApiValidationErrorResponse : ApiException
    {
        public ApiValidationErrorResponse() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}
