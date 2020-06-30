﻿using EFCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreDemo
{

    // I. Install Nudget Packages:
    // 1. Microsoft.EntityFrameworkCore.SqlServer
    // 2. Microsoft.EntityFrameworkCore.Design
    // 3. Microsoft.EntityFrameworkCore.Tools

    // II. Отиваме с виндос експлорера в папката на проекта. Там където се намира .sln файла. Натискаме shift+right click и от менюто избираме отваряне на Power Shell за да се покаже конзолата.

    // III. Задължително пишем този ред и инсталираме това нещо: 

    //dotnet tool install --global dotnet-ef 
    //(Прави се само първия път като почваме да правим бази. После би трябвало да си работи, но ако не работи го правим пак).

    //Така инсталираме глобално ef. Иначе ще дава грешка!

    // IV. В конзолата написваме следния ред:

    // dotnet ef dbcontext scaffold "Server=DESKTOP-LNP1A21\SQLEXPRESS;Database=SoftUni;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -o Models -f -d

    // Това нещо скафолдва базата. Прави ни класове от нея.
    // -o   задава папка в която да постави класовете. В случая Models
    // -f   ако вече имаме направена база във вид на класове и сме променили нещо в базата през SQL, с тази команда му казваме да дръпне пак всичко наново като презапише класовете. Иначе дава грешка.
    //-d ако изпозваме тази команда ни прави констрейните на базата като атрибути върху самите пропертите и прави по-малко код като флуент апи. Без нея не слага атрибути върху пропертитата, а прави всичко като флуент апи.

    class Program
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();

            var employees = db.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName
                })
                .Where(x => x.FirstName.Contains("ro")).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, employees
                .Select(e => e.FirstName + " " + e.LastName)));
        }
    }
}
