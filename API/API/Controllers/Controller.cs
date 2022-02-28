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

            // Занесение токена и логина пользователя в cookie (хранятся две недели)
            this.Response.Cookies.Append("token", token, new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(14),
                Secure = true,
            });
            this.Response.Cookies.Append("login", login, new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(14),
            });


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
            return FileRequester.GetFile(@"../../web/scripts/jquery-3.6.0.min.js", "text/js");
        }
        #region Страница Авторизации
        /// <summary>
        /// Получение HTML файла страницы Авторизации
        /// </summary>
        /// <returns></returns>
        [HttpGet("Authorization")]
        public ContentResult Authorization()
        {
            //if (Security.CheckToken(this.Request.Cookies))
            //{
            //    return this.Courses();
            //}
            return FileRequester.GetFile(@"../../web/index.html", "text/html");
        }
        /// <summary>
        /// Получение файла стилей страницы Авторизации
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAuthStyle")]
        public ContentResult GetAuthStyle()
        {
            return FileRequester.GetFile(@"../../web/styles/css/auth-page.css", "text/css");
        }
        /// <summary>
        /// Получение файла скриптов страницы Авторизации
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAuthScript")]
        public ContentResult GetAuthScript()
        {
            return FileRequester.GetFile(@"../../web/scripts/authorization.js", "text/js");
        }
        #endregion
        #region Страница Просмотра пройденных курсов
        [HttpGet("Courses")]
        public ContentResult Courses()
        {
            // Если в cookie нет ключей для токена и логина или токен не соответствует пользователю, то возвращаемся на страницу авторизации
            if (!Security.CheckToken(this.Request.Cookies))
            {
                return this.Authorization();
            }

            return FileRequester.GetFile(@"../../web/main-menu.html", "text/html");
        }
        #endregion
        #endregion
    }
}
