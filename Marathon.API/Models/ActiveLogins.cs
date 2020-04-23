using System;
using System.Collections.Generic;
using System.Timers;

namespace Marathon.API.Models
{
    public class ActiveLogins
    {
        public static List<TokenSys> ActiveTokens { get; private set; }
        private static Timer timer;
        private static TimeSpan CleanTime { get; set; }
        private static TimeSpan TokenInterval => new TimeSpan(0, 5, 0);

        public ActiveLogins(TimeSpan cleanInterval)
        {
            CleanTime = cleanInterval;
            timer = new Timer(CleanTime.TotalMilliseconds);
            timer.Elapsed += new ElapsedEventHandler((object sender, ElapsedEventArgs e) =>
            {
                Clean();
            });
            ActiveTokens = new List<TokenSys>();
        }
        public static void Clean()
        {
            foreach (var item in ActiveTokens)
            {
                var now = DateTime.Now;
                var TimeNow = new TimeSpan(now.Hour, now.Minute, now.Second);

                if (TimeNow.Subtract(item.TokenGeneratedDate) >= TokenInterval)
                {
                    ActiveTokens.RemoveAll(Token => Token.TokenGuid == item.TokenGuid);
                }
            }
        }
        public static void Add(TokenSys token)
        {
            try
            {
                ActiveTokens.RemoveAll(item => item.Email == token.Email || token.TokenGuid == item.TokenGuid);
            }
            catch (System.NullReferenceException)
            {
                ActiveTokens = new List<TokenSys>();
            }
            ActiveTokens.Add(token);
        }
    }
}