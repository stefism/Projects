using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApplication.Models
{
    /*
     * Добавяне на нови колони в таблицата за потребителите:
     * 
     * 1. Правим си нов клас ApplicationUser, който трябва да наследява ApplicationUser.
     * 
     * 2. Добавяме си новите пропертита, които искаме да имаме.
     * 
     * 3. На всякъде, където до сега сме ползвали ApplicationUser, минаваме и го сменяме с ApplicationUser.
     * 
     * 4. В класа ApplicationDbContext, където наследяваме IdentityDbContext, казваме IdentityDbContext<ApplicationUser> или ползвай контекста с този юзер.
     * 
     * 5. Добавяме нова миграция за да се отразят колоните.
     * 
     * 6. Ъпдейтваме базата данни в случай, че нямаме автоматична миграция при стартиране на приложението.
     */
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
