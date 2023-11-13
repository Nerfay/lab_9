using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Laba_7_V_1
{
    public class FileManager
    {
        private static BinaryFormatter _binaryFormatter = new BinaryFormatter();

        /// <summary>
        /// Сериализация обьекта(objToSerialize)  в файл json ,если objToSerialize равен нулю или строка fileName не заканчивается на ".json" ,то возвращает ArgumentException 
        /// </summary>
        /// <param name="objToSerialize">обьект , который сериализуется</param>
        /// <param name="fileName">имя файла , в который запишется лист </param>
        public static void SerializationToJSON(Object objToSerialize, string fileName)
        {
            if (objToSerialize is not null && fileName.EndsWith(".json"))
            {
                string output = JsonSerializer.Serialize(objToSerialize);
                using var outFile = new FileStream(fileName, FileMode.Create);
                using StreamWriter writer = new StreamWriter(outFile);
                writer.Write(output);
            }
            else
            {
                throw new ArgumentException();
            }
        }
        /// <summary>
        /// Десериализация обьекта из файла json , если строка fileName не заканчивается на ".json", то возвращает ArgumentException 
        /// </summary>
        /// <param name="fileName">имя файла , из которого десериализуем лист продуктов</param>
        /// <param name="objToDeserialize">обьект, необходим чтобы получить тип для десеариализации </param>
        public static Object DeserializationFromJSON(string fileName, Object objToDeserialize)
        {
            if (fileName.EndsWith(".json"))
            {
                using var file = new FileStream(fileName, FileMode.Open);
                using StreamReader reader = new StreamReader(file);
                string json = reader.ReadToEnd();
                return JsonSerializer.Deserialize(json, objToDeserialize.GetType());
            }
            else
            {
                throw new ArgumentException();
            }
        }
        /// <summary>
        /// Сериализация обьекта в бинарнный файл  ,если objToSerialize равен нулю или строка fileName не заканчивается на ".bin", то возвращает ArgumentException 
        /// </summary>
        /// <param name="objToSerialize">обьект , который сериализуется</param>
        /// <param name="fileName">имя файла , в который запишется лист </param>
        public static void SerializationToBinary(Object objToSerialize, string fileName)
        {
            if (objToSerialize is not null && fileName.EndsWith(".bin"))
            {
                using var file = new FileStream(fileName, FileMode.Create);
                _binaryFormatter.Serialize(file, objToSerialize);
            }
            else
            {
                throw new ArgumentException();
            }
        }
        /// <summary>
        /// Десериализация из бинарного файла , возвращает Object, если строка fileName не заканчивается на ".bin", то возвращает ArgumentException 
        /// </summary>
        /// <param name="fileName">имя файла , из которого десериализуется обьект</param>
        public static Object DeserializationFromBinary(string fileName)
        {
            if (fileName.EndsWith(".bin"))
            {
                using var file = new FileStream(fileName, FileMode.Open);
                return _binaryFormatter.Deserialize(file);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}

