using FBISWebApi.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebAPIAuthorizationSample
{
    public class ApplicationAuthenticationHandler : DelegatingHandler
    {
        // Http Response Messages
        private const string InvalidToken = "Invalid Authorization-Token";
        private const string MissingToken = "Missing Authorization-Token";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Write your Authentication code here
            IEnumerable<string> sampleApiKeyHeaderValues = request.Headers.GetValues("AuthenticateApi");
            Hashcode hashcode = new Hashcode();
            var hashCodeEncrypt = hashcode.Encrypt("Fb!$5687");
            
            // Checking the Header values
            if (sampleApiKeyHeaderValues.Any())
            {
                string[] apiKeyHeaderValue = sampleApiKeyHeaderValues.First().Split(new char[] { ':' },2);

                // Validating header value must have both APP ID & APP key
                if (apiKeyHeaderValue.Length == 2)
                {
                    // Code logic after authenciate the application.
                    var apiKey = apiKeyHeaderValue[0];
                    var hashCode = apiKeyHeaderValue[1];

                    if (apiKey.Equals("SevaXSindhu89674523") && hashCode.Equals(hashCodeEncrypt))
                    {
                        var userNameClaim = new Claim(ClaimTypes.Name, hashCode);
                        var identity = new ClaimsIdentity(new[] { userNameClaim }, "SampleAppApiKey");
                        var principal = new ClaimsPrincipal(identity);
                        Thread.CurrentPrincipal = principal;

                        if (System.Web.HttpContext.Current != null)
                        {
                            System.Web.HttpContext.Current.User = principal;
                        }
                    }
                    else
                    {
                        // Web request cancel reason APP key is NULL
                        return requestCancel(request, cancellationToken, InvalidToken);
                    }
                }
                else
                {
                    // Web request cancel reason missing APP key or APP ID
                    return requestCancel(request, cancellationToken, MissingToken);
                }
            }
            else
            {
                // Web request cancel reason APP key missing all parameters
                return requestCancel(request, cancellationToken, MissingToken);
            }

            return base.SendAsync(request, cancellationToken);
        }

        private Task<HttpResponseMessage> requestCancel(HttpRequestMessage request, CancellationToken cancelToken, string message)
        {
            CancellationTokenSource _tokenSource = new CancellationTokenSource();
            cancelToken = _tokenSource.Token;
            _tokenSource.Cancel();
            HttpResponseMessage response = new HttpResponseMessage();

            response = request.CreateResponse(HttpStatusCode.BadRequest);
            response.Content = new StringContent(message);
            return base.SendAsync(request, cancelToken).ContinueWith(task =>
            {
                return response;
            });
        }
    }
}