using System.Text;

namespace API
{
    public class RequestReader
    {
        public static List<string> GetData (Stream request)
        {
            List<string> data = new List<string>();

            using (StreamReader reader = new StreamReader(request, Encoding.UTF8, true, 1024, true))
            {
                data = reader.ReadToEndAsync().Result.Split('\n').ToList() ?? new List<string>();
            }

            return data;
        }
    }
}
