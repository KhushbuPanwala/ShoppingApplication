using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public interface IDatabaseContext
    {
        Task<int> Count<T>();

        Task<T> FindSingleAsync<T>(int id);

        Task<bool> DeleteSingleAsync<T>(int id);

        Task<bool> UpdateSingleAsync<T>(int id, T data);

        Task<T> AddSingleAsync<T>(T data);
    }
}
