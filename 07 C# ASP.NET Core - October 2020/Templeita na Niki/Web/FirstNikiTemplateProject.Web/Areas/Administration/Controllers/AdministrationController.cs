namespace FirstNikiTemplateProject.Web.Areas.Administration.Controllers
{
    using FirstNikiTemplateProject.Common;
    using FirstNikiTemplateProject.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
