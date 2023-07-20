using AQ3DClientLib.Enums;
using AQ3DClientLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib
{
    public interface IAQ3DClient
    {
        Account Account { get; }
        ServerInfo SelectedServer { get; }
        Character SelectedCharacter { get; }

        void SendChatMessage(int channelId, string message);
        void Suicide();
        void SendPosition(int state, float posX, float posY, float posZ, float rotation);
        void Emote(StateEmoteEnum emote);
        void Respawn();
        Task<bool> ConnectAsync();
        bool ConnectToWorld(ServerInfo server, Character character);
        Character[] GetCharacters();
        Task<ServerInfo[]> GetServers();

    }
}
