using API.Models;

namespace API
{
    public static class Security
    {
        private static readonly char[] T = new char[]
           { 'h', 'I', '7', 'U', 'l', 'i', 'p', 'J', 'D', 'f', 'w', 'G', 'H', 'F', 'a', 'R', 'Q', 'k', 'u', 'y', 'E', 'T', 'Z', '#', 'c', 'r', 'S', 'g', '6', '3', 'X', 's', 'z', 'Y', '0', 'n', 'V', 'M', 'L', 'O', 'q', '2', '-', 'm', '_', 'e', 'o', 'P', 'b', 'v', '&', '*', 'd', 'x', '1', '%', 'B', 't', '8', 'A', 'j', 'W', '5', 'N', 'C', 'K', '4', '9'
           };

        public static string GetHash(string str, byte hashLength = 32)
        {
            string hash = "";

            str += "qwerty";

            for (int i = 0; i < hashLength; i++)
            {
                int sum = 0;

                for (int j = 0; j < str.Length; j++)
                {
                    sum += str[j] | str.Length * i >> j | str.Substring(0, j).Sum(s => s) & str.Sum(s => s * i * j);
                }

                hash += T[sum % T.Length];
            }

            return hash;
        }
        public static string GetToken (string login, string password)
        {
            return GetHash($"{login}{password}", 128);
        }
        public static bool CheckToken(User user, string token)
        {
            return GetToken(user.Login, user.Password) == token;
        }
        public static bool CheckToken (IRequestCookieCollection cookie)
        {
            string token = "";
            string login = "";
            User? user = null;
            if (cookie.ContainsKey("token") && cookie.ContainsKey("login"))
            {
                token = cookie["token"] ?? "";
                login = cookie["login"] ?? "";

                user = new LearningContext().Users.Where(u => u.Login == login).FirstOrDefault();
            }
            else
            {
                return false;
            }

            return user != null && CheckToken(user, token);
        }
    }
}
