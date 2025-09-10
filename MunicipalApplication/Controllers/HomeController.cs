using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MunicipalApplication.Models;
using MunicipalApplication.Services;

namespace MunicipalApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ReportCount = IssueRepository.Instance.Count;
            ViewBag.ReportTarget = 10; 
            return View();
        }
    }
}
