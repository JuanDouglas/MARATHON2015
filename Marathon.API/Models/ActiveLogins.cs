using System;
using System.Collections.Generic;
using System.Timers;
using System.Text;
using System.IO;
using System.Linq;
namespace Marathon.API.Models
{
    public class ActiveLogins
    {
        private static List<TokenSys> ActiveTokens { get; set; }
        private static Timer timer;
        private static TimeSpan CleanTime { get; set; }
        public static TimeSpan TokenInterval { get; set; }
        public ActiveLogins(TimeSpan cleanInterval, TimeSpan tokenTime)
        {
            CleanTime = cleanInterval;
            timer = new Timer(CleanTime.TotalMilliseconds);
            timer.Elapsed += new ElapsedEventHandler((object sender, ElapsedEventArgs e) =>
            {
                Clean();
            });
            ActiveTokens = new List<TokenSys>();
            TokenInterval = tokenTime;
        }
        public static void Clean()
        {
            var colorBack = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Starting Clean!");
            Console.ForegroundColor = colorBack;
            try
            {
                if (ActiveTokens.Count != 0)
                {
                    foreach (var item in ActiveTokens)
                    {
                        var now = DateTime.Now;
                        var TimeNow = new TimeSpan(now.Hour, now.Minute, now.Second);
                        Console.WriteLine(item.ToString());
                        if (TimeNow.Subtract(item.TokenGeneratedDate) >= TokenInterval)
                        {
                            ActiveTokens.RemoveAll(Token => Token.TokenGuid == item.TokenGuid);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        public static void Add(TokenSys token)
        {
            try
            {
                ActiveTokens.RemoveAll(item => item.Email == token.Email || token.TokenGuid == item.TokenGuid);
            }
            catch (NullReferenceException)
            {
                ActiveTokens = new List<TokenSys>();
            }
            ActiveTokens.Add(token);
        }
        public static TokenSys GetToken(Guid token)
        {
            return ActiveTokens.FirstOrDefault(test => test.TokenGuid == token);
        }
        public static bool ThisTokenIsValid(Guid token)
        {
            var tested = ActiveTokens.FirstOrDefault(test => test.TokenGuid == token);
            if (tested == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool ThisTokenIsValid(TokenSys token)
        {
            return ThisTokenIsValid(token.TokenGuid);
        }
        public static bool ThisTokenIsValid(TokenUser token)
        {
            return ThisTokenIsValid(token.Token);
        }
    }
}