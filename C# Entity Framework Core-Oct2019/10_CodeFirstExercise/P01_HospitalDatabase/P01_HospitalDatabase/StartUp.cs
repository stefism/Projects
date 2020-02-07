using P01_HospitalDatabase.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace P01_HospitalDatabase
{
    public class StartUp
    {
        //Install-Package Microsoft.EntityFrameworkCore -v 2.2.0
        //Install-Package Microsoft.EntityFrameworkCore.SqlServer -v 2.2.0
        //Install-Package Microsoft.EntityFrameworkCore.Tools -v 2.2.0
        public static void Main(string[] args)
        {
            var db = new HospitalContext();

            using (db)
            {
                db.Database.Migrate();
            }
            //Uninstall-Package Microsoft.EntityFrameworkCore.Tools -r
        }
    }
}
