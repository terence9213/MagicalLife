﻿using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Networking.Server;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.World.Data;
using MagicalLifeServer;
using MagicalLifeServer.ServerWorld.World_Generation.Generators;
using MagicalLifeServerShell.API.Settings;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace MagicalLifeServerShell.API.Commands
{
    /// <summary>
    /// Creates a new world and launches a new game.
    /// </summary>
    public class NewGame : ICommand
    {
        public string getHelp()
        {
            return "Creates a new world and hosts a new game";
        }

        public string getName()
        {
            return "NewGame";
        }

        public void run(List<string> input)
        {
            Server.Load(EngineMode.ServerOnly);

            WorldGenerationSettings wset = SettingsHandler.WorldGenerationSettings.Settings;
            Util.WriteLine("Generating world!");
            World.Initialize(wset.DimensionWidth, wset.DimensionHeight, new GrassAndDirt(0));
            Util.WriteLine("World generated!");

            Util.WriteLine("Initializing networking!");
            int port = SettingsHandler.NetworkSettings.Settings.Port;
            ServerSendRecieve.Initialize(new NetworkSettings(port));
            ServerSendRecieve.TCPServer.Server.ClientConnected += Server_ClientConnected;
            ServerSendRecieve.TCPServer.Server.ClientDisconnected += Server_ClientDisconnected;

            Util.WriteLine("Done!");
        }

        private static void Server_ClientDisconnected(object sender, TcpClient e)
        {
            Util.WriteLine("Client disconnected: " + e.Client.RemoteEndPoint.ToString());
        }

        private static void Server_ClientConnected(object sender, System.Net.Sockets.TcpClient e)
        {
            Util.WriteLine("Client connected: " + e.Client.RemoteEndPoint.ToString());
        }
    }
}