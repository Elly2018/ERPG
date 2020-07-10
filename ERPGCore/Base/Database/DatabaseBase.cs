using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ERPGCore
{
    /// <summary>
    /// Provide a way to store, access, save, load data
    /// </summary>
    /// <typeparam name="T">The data element that you want to store</typeparam>
    [System.Serializable]
    public abstract class DatabaseBase<T>
    {
        public DatabaseElement<T> value = new DatabaseElement<T>();

        /// <summary>
        /// Saving current data into target path <br />
        /// Use memory stream output
        /// </summary>
        /// <param name="path">Path</param>
        public virtual void Save(string path)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, value);
                File.WriteAllBytes(path, ms.ToArray());
            }
        }

        /// <summary>
        /// Loading current data from target path <br/>
        /// Use memory stream loading
        /// </summary>
        /// <param name="path">Path</param>
        public virtual void Load(string path)
        {
            byte[] data = File.ReadAllBytes(path);
            using (var ms = new MemoryStream())
            {
                var binform = new BinaryFormatter();
                ms.Write(data, 0, data.Length);
                ms.Seek(0, SeekOrigin.Begin);
                var obj = binform.Deserialize(ms);
                value = (DatabaseElement<T>)obj;
            }
        }
    }
}
