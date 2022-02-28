using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        private readonly ILogger<Controller> logger;
        private LearningContext context;

        public Controller(ILogger<Controller> logger, LearningContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <returns>Токен пользователя</returns>
        [HttpPost("Auth")]
        public string Auth()
        {
            string login = "";
            string password = "";

            // Данные запроса
            string[] requestBody = RequestReader.GetData(this.Request.Body).ToArray();

            // Если передано два значения, то присваиваем логин и пароль
            if (requestBody.Length == 2)
            {
                login = requestBody[0];
                password = requestBody[1];
            }

            // Если пользователя с переданными параметрами не существует, то возвращаем токен — пустую строку
            if (this.context.Users.FirstOrDefault(u => u.Login == login && u.Password == password) == null)
            {
                return "";
            }

            // Получение токена пользователя
            string token = Security.GetToken(login, password);

            return token;
        }

        [HttpPost("GetCompletedCourses")]
        public List<CompletedCourse> GetCompletedCourses(int employeeID)
        {
            List<CompletedCourse> completedCourses = this.context.CompletedCourses.Where(c => c.EmployeeId == employeeID).ToList();

            return completedCourses;
        }

        #region Файлы сайта
        /// <summary>
        /// Получение файла скрипта библиотеки JQuery
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetJQuery")]
        public ContentResult GetJQuery()
        {
            string JS = System.IO.File.ReadAllText(@"../../web/scripts/jquery-3.6.0.min.js");

            return new ContentResult()
            {
                ContentType = "text/js",
                Content = JS,

            };
        }
        #region Страница Авторизации
        /// <summary>
        /// Получение HTML файла страницы Авторизации
        /// </summary>
        /// <returns></returns>
        [HttpGet("Authorization")]
        public ContentResult Authorization()
        {
            string HTML = System.IO.File.ReadAllText(@"../../web/index.html");

            return new ContentResult()
            {
                ContentType = "text/html",
                Content = HTML,
            };
        }
        /// <summary>
        /// Получение файла стилей страницы Авторизации
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAuthStyle")]
        public ContentResult GetAuthStyle()
        {
            string CSS = System.IO.File.ReadAllText(@"../../web/styles/css/auth-page.css");

            return new ContentResult()
            {
                ContentType = "text/css",
                Content = CSS,

            };
        }
        /// <summary>
        /// Получение файла скриптов страницы Авторизации
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAuthScript")]
        public ContentResult GetAuthScript()
        {
            string JS = System.IO.File.ReadAllText(@"../../web/scripts/authorization.js");

            return new ContentResult()
            {
                ContentType = "text/js",
                Content = JS,

            };
        }
        #endregion
        #endregion
    }
}
