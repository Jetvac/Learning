using Microsoft.AspNetCore.Mvc;

namespace API
{
    public class FileRequester
    {
        public static ContentResult GetFile (string path, string fileType)
        {
            return new ContentResult()
            {
                ContentType = fileType,
                Content = File.ReadAllText(path),
            };
        }
    }
}
