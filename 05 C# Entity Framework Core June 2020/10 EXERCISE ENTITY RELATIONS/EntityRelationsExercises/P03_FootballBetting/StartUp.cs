using P03_FootballBetting.Data;
using System;

namespace P03_FootballBetting
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new FootballBettingContext();
            db.Database.EnsureCreated();
        }
    }
}
