namespace Core.DTOs.Response
{
    public class GenericResponse
    {
        public bool isSuccess { get; set; }

        public string message { get; set; }

        public dynamic Data { get; set; }
    }
}
