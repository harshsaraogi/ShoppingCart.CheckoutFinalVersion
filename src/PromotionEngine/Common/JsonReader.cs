using System.IO;
using System.Text.Json;

namespace ShoppingCart.Checkout.Common
{
    internal class JsonReader
    {
        static public T LoadJson<T>(string fileName) where T : class
        {
            using StreamReader r = new StreamReader(Directory.GetCurrentDirectory() + "\\" + fileName);
            string json = r.ReadToEnd();
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
