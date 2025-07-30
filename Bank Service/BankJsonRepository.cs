using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace BankAppAssignment.Bank_Service
{
    /// <summary>
    /// A generic JSON repository for managing bank data.
    /// </summary>
    /// <typeparam name="T">The type of the entity to store in the repository.</typeparam>
    public class BankJsonRepository<T> where T : class
    {
        private readonly string _file;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankJsonRepository{T}"/> class.
        /// </summary>
        /// <param name="bankFile">The path to the JSON file where data will be stored.</param>
        public BankJsonRepository(string bankFile)
        {
            _file = bankFile;
            // If the file does not exist, create it and initialize with an empty JSON array.
            if (!File.Exists(bankFile))
            {
                File.WriteAllText(_file, "[]");
            }
        }

        /// <summary>
        /// Retrieves all entities from the JSON file.
        /// </summary>
        /// <returns>A list of all entities of type <typeparamref name="T"/>.</returns>
        public List<T> GetAll()
        {
            string content = File.ReadAllText(_file);
            return JsonConvert.DeserializeObject<List<T>>(content);
        }

        /// <summary>
        /// Saves a list of entities to the JSON file, overwriting existing content.
        /// </summary>
        /// <param name="data">The list of entities to save.</param>
        public void SaveAll(List<T> data)
        {
            string content = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(_file, JsonConvert.SerializeObject(data, Formatting.Indented));
        }
    }
}