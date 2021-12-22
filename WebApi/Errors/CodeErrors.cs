namespace WebApi.Errors
{
    public class CodeErrors
    {
        public CodeErrors(int statusCode, string message = null)
        {
            StatusCode = statusCode;   
            //evaluo si es nulo message, si es nulo se ejecuta el método GetDefaultMessage
            Message = message ?? GetDefaultMessage(statusCode);
        }

        private string GetDefaultMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "El Request enviado tiene errores",
                401 => "No tienes autorización",
                404 => "El recurso no se ha encontrado el item",
                500 => "Se producieron errores en el servidor",
                _ => ""
            };
        }
        public int StatusCode { get; set; }

        public string Message { get; set; }



    }
}
