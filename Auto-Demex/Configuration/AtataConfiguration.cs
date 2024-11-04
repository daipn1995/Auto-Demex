using Atata.Configuration.Json;

namespace Auto_Demex.Configuration;

public class AtataConfiguration : JsonConfig<AtataConfiguration>
{
    public Api Api { get; set; } = new Api();
    public string PrivateKey { get; set; } = string.Empty;
    public string WalletPassword { get; set; } = string.Empty;
}

public class Api
{
    public string BaseUrl { get; set; } = string.Empty;
}