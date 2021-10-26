using System.Threading.Tasks;

namespace WhoIsMorePopular.WebApp.Providers
{
    public interface ISearchProvider
    {
        string Name { get; }
        Task<string> Search(string searchValue);
        long GetTotal(string value);
    }
}