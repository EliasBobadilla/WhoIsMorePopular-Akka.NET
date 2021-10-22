using System.IO;
using Akka.Configuration;

namespace WhoIsMorePopular.Shared.Config
{
    public static class HoconLoader
    {
        public static Akka.Configuration.Config ParseConfig(string hoconPath) =>
            ConfigurationFactory.ParseString(File.ReadAllText(hoconPath));
    }
}