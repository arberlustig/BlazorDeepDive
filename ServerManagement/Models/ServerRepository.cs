using System.Xml.Schema;

namespace ServerManagement.Models
{
    public class ServerRepository
    {
        private static List<Server> servers = new List<Server>()
{
    new Server { ServerId = 1, Name = "Server1", City = "Toronto"},
    new Server { ServerId = 2, Name = "Server2", City = "Toronto"},
    new Server { ServerId = 3, Name = "Server3", City = "Toronto"},
    new Server { ServerId = 4, Name = "Server4", City = "Toronto"},
    new Server { ServerId = 5, Name = "Server5", City = "Toronto"},
    new Server { ServerId = 6, Name = "Server6", City = "Montreal"},
    new Server { ServerId = 7, Name = "Server7", City = "Montreal"},
    new Server { ServerId = 8, Name = "Server8", City = "Montreal"},
    new Server { ServerId = 9, Name = "Server9", City = "Montreal"},
    new Server { ServerId = 10, Name = "Server10", City = "Ottawa"},
    new Server { ServerId = 11, Name = "Server11", City = "Ottawa"},
    new Server { ServerId = 12, Name = "Server12", City = "Calgary"},
    new Server { ServerId = 13, Name = "Server13", City = "Calgary"},
    new Server { ServerId = 14, Name = "Server14", City = "Halifax"},
    new Server { ServerId = 15, Name = "Server15", City = "Halifax"}
};
        public static List<string> cities = new List<string>()
        {
            "Toronto",
            "Washington D.C",
            "Petsburg"
        };

        public static List<string> GetCities() => cities;
        public static void AddServer(Server server)
        {
            var maxId = servers.Max(s => s.ServerId);
            server.ServerId = maxId + 1;
            servers.Add(server);
        }

        public static List<Server> GetServers() => servers;

        public static List<Server> GetServersByCity(string cityName)
        {
            return servers.Where(i => i.City.Equals(cityName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static Server? GetServerById(int id)
        {
            return servers.Find(i => i.ServerId.Equals(id));
        }

        public static void Updateserver(int serverId, Server server)
        {
            if (serverId != server.ServerId)
                throw new Exception("Kein Server gefunden");

            var serverToUpdate = GetServerById(serverId);
            if (serverToUpdate != null)
            {
                serverToUpdate.IsOnline = server.IsOnline;
                serverToUpdate.Name = server.Name;
                serverToUpdate.City = server.City;
            }

        }

        public static void DeleteServer(int serverId)
        {
            var server = GetServerById(serverId);
            if (server is not null)
            {
                servers.Remove(server);
            }
        }

        public static List<Server> SearchServers(string serverFilter)
        {
            return servers.Where(s => s.Name.Contains(serverFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }

    }


}