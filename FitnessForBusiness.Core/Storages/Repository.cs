using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessForBusiness.Core.Storages
{
    class Repository<T>
    {
        readonly string _filePath;

        List<T> _collection;


        public Repository(string filePath)
        {
            _filePath = filePath;

            Read();
        }

        public void Save()
        {
            using (var sw = new StreamWriter(_filePath))
            {
                using (var jsonWriter = new JsonTextWriter(sw))
                {
                    jsonWriter.Formatting = Formatting.Indented;

                    var serializer = new JsonSerializer()
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    };

                    serializer.Serialize(jsonWriter, _collection);
                }
            }
        }

        private void Read()
        {
            using (var sr = new StreamReader(_filePath))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer()
                    { TypeNameHandling = TypeNameHandling.Auto };

                    _collection = serializer.Deserialize<List<T>>(jsonReader);
                }
            }
        }


        public List<T> GetCollection => _collection;
    }
}
