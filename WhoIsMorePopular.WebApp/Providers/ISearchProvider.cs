using System.Threading.Tasks;

namespace WhoIsMorePopular.WebApp.Providers
{
    public interface ISearchProvider
    {
        string Name { get; }
        Task<long> Search(string searchValue);
    }
}