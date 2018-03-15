using System.Collections.Generic;
using System.Threading.Tasks;

namespace App
{
    public interface ILocalDBService
    {
        Task Upsert<T>(T item);
        Task Delete<T>(T item);                
        Task<IList<T>> List<T>(string sql, params object[] args) where T : new();
    }
}