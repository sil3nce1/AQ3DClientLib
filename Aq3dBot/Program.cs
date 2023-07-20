using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AQ3DClientLib;
using AQ3DClientLib.Enums;
using AQ3DClientLib.Models;

namespace Aq3dBot
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IAQ3DClient aq3dClient = new AQ3DClient("username@username.com", "password");

            if (await aq3dClient.ConnectAsync())
            {
                ServerInfo[] servers = await aq3dClient.GetServers();

                ServerInfo server = servers.Where(s => s.Name.Contains("Blue")).FirstOrDefault();

                Character c = aq3dClient.GetCharacters()[0];

                aq3dClient.ConnectToWorld(server, c);


                foreach (StateEmoteEnum i in typeof(StateEmoteEnum).GetEnumValues())
                {
                    aq3dClient.Emote(i);
                    Thread.Sleep(1000);
                }


            }
            Console.ReadLine();
        }

    }
}
