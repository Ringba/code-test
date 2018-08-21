using System.Threading.Tasks;
using RingbaLibs.Models;

namespace RingbaLibs
{
    public interface IKVRepository
    {
        /// <summary>
        /// Retrieves the object of type T by the key passed in.
        /// 
        /// If an error is encounted, the Result will be empty and the Error Code and message will
        /// be filled in.
        /// 
        /// </summary>
        /// <typeparam name="T">The type of object to retreive</typeparam>
        /// <param name="key">the key of the item</param>
        /// <returns>the item or null if not found</returns>
        Task<Result<T>> GetAsync<T>(string key) where T : class;

        /// <summary>
        /// creates an item in the repository
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<ActionResult> CreateAsync<T>(CreateKVRequest<T> item) where T : class;

        /// <summary>
        /// only create the item if it DOES NOT exist, if is created true is returned else false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns>returns tru if the item is created else false</returns>
        Task<Result<bool>> CreateIfNotExistAsync<T>(CreateKVRequest<T> item) where T : class;


        /// <summary>
        /// Removes the item with the given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<ActionResult> DeleteAsync(string key);


    }

    public class CreateKVRequest<T>
    {
        /// <summary>
        /// the unique id of the item to be stored
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// the item to be stored
        /// </summary>
        public T Item { get; set; }

        /// <summary>
        /// the expiration in seconds or never expire if -1
        /// </summary>
        public int ExpireInSeconds { get; set; } = -1;

    }


}