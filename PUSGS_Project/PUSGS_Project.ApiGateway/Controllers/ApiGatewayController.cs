using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace PUSGS_Project.ApiGateway.Controllers
{
    [Route("pusgs_project/")]
    [ApiController]
    public class ApiGatewayController : ControllerBase
    {
        private readonly Settings settings;

        public ApiGatewayController(IOptions<Settings> settings)
        {
            this.settings = settings.Value;
        }

        [HttpGet]
        [HttpDelete]
        [Route("{**restOfUrl}")]
        public async Task<object> GetDelete(string restOfUrl)
        {
            var (client, requestUri) = SetupHttpClient(restOfUrl);
            if (client is null || requestUri is null)
            {
                return NotFound();
            }
            switch (Request.Method)
            {
                case "GET":
                    var getRequest = await client.GetAsync(requestUri);
                    if (getRequest.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return Unauthorized();
                    }
                    return await getRequest.Content.ReadAsStringAsync();
                case "DELETE":
                    var deleteRequest = await client.DeleteAsync(requestUri);
                    if (deleteRequest.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return Unauthorized();
                    }
                    return await deleteRequest.Content.ReadAsStringAsync();
                default:
                    return NotFound();
            }
        }

        [HttpPut]
        [HttpPost]
        [Route("{**restOfUrl}")]
        public async Task<object> PutPost(string restOfUrl, [FromBody] object receivedObject)
        {
            var (client, requestUri) = SetupHttpClient(restOfUrl);
            if (client is null || requestUri is null)
            {
                return NotFound();
            }
            switch (Request.Method)
            {
                case "POST":
                    var postRequest = await client.PostAsync(requestUri, new StringContent(receivedObject.ToString(), Encoding.UTF8, Request.ContentType));
                    if (postRequest.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return Unauthorized();
                    }
                    return await postRequest.Content.ReadAsStringAsync();
                case "PUT":
                    var putRequest = await client.PutAsync(requestUri, new StringContent(receivedObject.ToString(), Encoding.UTF8, Request.ContentType));
                    if (putRequest.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return Unauthorized();
                    }
                    return await putRequest.Content.ReadAsStringAsync();
                default:
                    return NotFound();
            }
        }

        private (HttpClient client, string requestUri) SetupHttpClient(string restOfUrl)
        {
            var client = new HttpClient();
            var requestUri = FindRequestUrlFromRestOfUrl(restOfUrl);
            if (requestUri is null)
            {
                return (null, null);
            }
            foreach (var item in Request.Headers)
            {
                var key = item.Key;
                if (key[0] == ':')
                {
                    key = key.AsSpan().Slice(1).ToString();
                }
                try
                {
                    client.DefaultRequestHeaders.Add(key, item.Value.ToArray());
                }
                catch (Exception ex)
                {
                    var aaaaa = ex;
                }
            }
            requestUri += Request.QueryString;
            return (client, requestUri);
        }

        private string FindRequestUrlFromRestOfUrl(string restOfUrl)
        {
            var url = restOfUrl.AsSpan();
            if (url.Slice(0, 4).CompareTo("api/".AsSpan(), StringComparison.OrdinalIgnoreCase) != 0)
            {
                return null;
            }

            var controllerUrl = url.Slice(4);

            if (controllerUrl.StartsWith("aviation", StringComparison.OrdinalIgnoreCase)
                || controllerUrl.StartsWith("flight", StringComparison.OrdinalIgnoreCase))
            {
                return $"{settings.AviationAipUrl}/{restOfUrl}";
            }

            if (controllerUrl.StartsWith("branch", StringComparison.OrdinalIgnoreCase)
                || controllerUrl.StartsWith("car", StringComparison.OrdinalIgnoreCase)
                || controllerUrl.StartsWith("rating", StringComparison.OrdinalIgnoreCase)
                || controllerUrl.StartsWith("rentacar", StringComparison.OrdinalIgnoreCase))
            {
                return $"{settings.RentACarApiUrl}/{restOfUrl}";
            }

            if (controllerUrl.StartsWith("user", StringComparison.OrdinalIgnoreCase))
            {
                return $"{settings.UserApiUrl}/{restOfUrl}";
            }

            return null;
        }
    }
}
