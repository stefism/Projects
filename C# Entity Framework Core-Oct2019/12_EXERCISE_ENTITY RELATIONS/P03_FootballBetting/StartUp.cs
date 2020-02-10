using System;
using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
    using static DbContext;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new FootballBettingContext();

            

            using (db)
            {
                
            }
        }
    }
}
