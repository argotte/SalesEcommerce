using System.Net;

namespace Sales.Web.Repositories
{
    //Generic class
    //Generic response for https responses
    //This is copied and pasted from Zulu's course
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Error = error;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }

        public bool Error { get; set; }

        public T? Response { get; set; }

        public HttpResponseMessage HttpResponseMessage { get; set; }

        public async Task<string?> GetErrorMessage()
        {
            if (!Error)
            {
                return null;
            }

            var codigoEstatus = HttpResponseMessage.StatusCode;
            if (codigoEstatus == HttpStatusCode.NotFound)
            {
                return "RESOURCE NOT FOUND";
            }
            else if (codigoEstatus == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            else if (codigoEstatus == HttpStatusCode.Unauthorized)
            {
                return "You need to login to keep going forward.";
            }
            else if (codigoEstatus == HttpStatusCode.Forbidden)
            {
                return "You are not allowed to continue with this operation";
            }

            return "An unexpected error has occurred";
        }
    }

}
