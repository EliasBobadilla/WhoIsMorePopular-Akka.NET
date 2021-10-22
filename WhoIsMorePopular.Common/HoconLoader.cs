using Akka.Configuration;

namespace WhoIsMorePopular.Common
{
    public static class HoconLoader
    {
        public static Config FromFile(string hoconPath)
        {
            var hoconContent = System.IO.File.ReadAllText(hoconPath);
            return ConfigurationFactory.ParseString(hoconContent);
        }
    }
}