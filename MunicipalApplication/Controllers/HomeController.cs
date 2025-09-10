using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MunicipalApplication.Models;
using MunicipalApplication.Services;

namespace MunicipalApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIssueRepository _repository;
        public HomeController(IIssueRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var issueCount = _repository.GetIssueCount();
            ViewBag.IssueCount = issueCount;
            return View();
        }
    }
}
