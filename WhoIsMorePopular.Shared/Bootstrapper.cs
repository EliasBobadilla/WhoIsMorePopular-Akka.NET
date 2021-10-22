namespace WhoIsMorePopular.Shared
{
    public static class Bootstrapper
    {
        public static Akka.Configuration.Config ApplyOpsConfig(this Akka.Configuration.Config previousConfig)
        {
            var nextConfig = previousConfig.BootstrapFromDocker();
            return OpsConfig.GetOpsConfig().ApplyPhobosConfig().WithFallback(nextConfig);
        }
    }
}