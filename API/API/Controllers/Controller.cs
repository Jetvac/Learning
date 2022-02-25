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
        [HttpPost("Authorization")]
        public string Authorization()
        {
            string login = "";
            string password = "";
            // Тело запроса
            string request = "";

            // Чтение данных из потока
            using (StreamReader reader = new StreamReader(this.Request.Body, Encoding.UTF8, true, 1024, true))
            {
                request += reader.ReadToEndAsync().Result ?? "";
            }

            // Данные запроса
            string[] requestBody = request.Split('\n');

            // Если передано два значения, то присваиваем логин и пароль
            if (requestBody.Length == 2)
            {
                login = requestBody[0];
                password = requestBody[1];
            }

            // Если пользователя с переданными параметрами не существует, то возвращаем токен — пустую строку
            this.context.Users.ToList();
            if (this.context.Users.FirstOrDefault(u => u.Login == login && u.Password == password) == null) 
            { 
                return "";
            }

            // Получение токена пользователя
            string token = Security.GetHash($"{login}{password}", 128);

            return token;
        }
        [HttpGet("GetCompletedCourses")]
        public List<CompletedCourse> GetCompletedCourses(int employeeID)
        {
            List<CompletedCourse> completedCourses = this.context.CompletedCourses.Where(c => c.EmployeeId == employeeID).ToList();

            return completedCourses;
        }
    }
}
