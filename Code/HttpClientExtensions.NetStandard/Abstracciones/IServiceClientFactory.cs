namespace Framework.ClienteHttp.NetCore.Abstracciones
{
    public interface IServiceClientFactory<TClient>
    {
        TClient CreateClient(HttpRestClient client);
    }
}
