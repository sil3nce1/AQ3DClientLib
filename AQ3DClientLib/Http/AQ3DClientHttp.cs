using AQ3DClientLib.Encoder;
using AQ3DClientLib.Http.Models;
using AQ3DClientLib.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AQ3DClientLib.Http
{
    public static class AQ3DClientHttp
    {
        private static readonly string baseUrl = "https://game.aq3d.com/api";
        private static RestClient restClient => new RestClient(baseUrl);

        private static int clientId = 267;
        private static int buildPlatform = 3;


        public async static Task<AQ3DHttpLoginResponse> Login(string email, string password)
        {
            RestRequest request = new RestRequest("/Game/LoginAQ3D", Method.Post);
            request.AddParameter("ClientID", clientId.ToString());
            request.AddParameter("DeviceID", Guid.NewGuid());
            request.AddParameter("BuildPlatform", buildPlatform.ToString());
            request.AddParameter("Email", Base64.Encode(email));
            request.AddParameter("Password", Base64.Encode(password));

            request.AddHeader("content-type", "application/x-www-form-urlencoded");

            CancellationTokenSource cancellationToken = new CancellationTokenSource();

            string responseStr = restClient.Execute(request).Content;

            return await restClient.PostAsync<AQ3DHttpLoginResponse>(request, cancellationToken.Token);

        }

        public async static Task<ServerInfo[]> GetServers()
        {
            RestRequest request = new RestRequest("/Game/ServerList", Method.Get);
            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            return await restClient.GetAsync<ServerInfo[]>(request, cancellationToken.Token);
        }


    }
}
