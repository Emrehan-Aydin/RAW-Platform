using RAWAPI.Domain.Entities.Contents;

namespace RAW.Client.Helpers {
    public static class CustomCookieHelper {
        public static void InitializeMenuCookie(HttpRequest request, HttpResponse response) {
            if (request.Cookies["Video"] == null) {
                response.Cookies.Append("Video", "new", new CookieOptions { Expires = (DateTime.Now.Add(new TimeSpan(23, 59, 59) - DateTime.Now.TimeOfDay)) });
            }
            if (request.Cookies["Music"] == null) {
                response.Cookies.Append("Music", "new", new CookieOptions { Expires = (DateTime.Now.Add(new TimeSpan(23, 59, 59) - DateTime.Now.TimeOfDay)) });
            }
            if (request.Cookies["Draw"] == null) {
                response.Cookies.Append("Draw", "new", new CookieOptions { Expires = (DateTime.Now.Add(new TimeSpan(23, 59, 59) - DateTime.Now.TimeOfDay)) });
            }
            if (request.Cookies["Text"] == null) {
                response.Cookies.Append("Text", "new", new CookieOptions { Expires = (DateTime.Now.Add(new TimeSpan(23, 59, 59) - DateTime.Now.TimeOfDay)) });
            }
            if (request.Cookies["Document"] == null) {
                response.Cookies.Append("Document", "new", new CookieOptions { Expires = (DateTime.Now.Add(new TimeSpan(23, 59, 59) - DateTime.Now.TimeOfDay)) });
            }
        }

        public static void SetRate(HttpRequest request, HttpResponse response, string content, string rate) {
            if (!string.IsNullOrEmpty(content)) {
                response.Cookies.Append($"{content}Rate", rate, new CookieOptions { Expires = (DateTime.Now.Add(new TimeSpan(23, 59, 59) - DateTime.Now.TimeOfDay)) });
            }
        }
        public static short GetRate(HttpRequest request, string content) {
            if (!string.IsNullOrEmpty(content)) {
                if (request.Cookies[$"{content}Rate"] != null) {
                    short.TryParse(request.Cookies[$"{content}Rate"], out short rate);
                    return rate;
                }
            }
            return 0;
        }
    }
}
