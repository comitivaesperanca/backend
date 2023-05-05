namespace ComitivaEsperanca.API.Domain.DTOs
{
    public class ResponseDTO<TEntity>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public TEntity Entity { get; set; }
        public List<string> ValidationErrors { get; set; }

        public ResponseDTO()
        {
            ValidationErrors = new List<string>();
        }

        public ResponseDTO(int statusCode)
            : this()
        {
            StatusCode = statusCode;
        }

        public ResponseDTO(int statusCode, string message = default)
            : this()
        {
            StatusCode = statusCode;
            Message = message;
        }

        public ResponseDTO(int statusCode, TEntity entity = default)
            : this()
        {
            StatusCode = statusCode;
            Entity = entity;
        }

        public ResponseDTO(int statusCode, List<string> validationErrors = default)
            : this()
        {
            StatusCode = statusCode;
            ValidationErrors = validationErrors;
        }

        public ResponseDTO(int statusCode, List<string> validationErrors, string message = default)
            : this(statusCode, message)
        {
            ValidationErrors = validationErrors;
        }
    }
}
