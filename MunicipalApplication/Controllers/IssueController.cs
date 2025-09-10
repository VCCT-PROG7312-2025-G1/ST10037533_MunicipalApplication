using System;
using MunicipalApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using MunicipalApplication.Services;

namespace MunicipalApplication.Controllers
{
    public class IssueController : Controller
    {
        private readonly IIssueRepository _repository;
        private readonly IWebHostEnvironment _env;
        private const int EngagementTarget = 10;

        public IssueController(IIssueRepository repository, IWebHostEnvironment env)
        {
            _repository = repository;
            _env = env;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Categories = Enum.GetValues(typeof(IssueCategory));
            ViewBag.IssueCount = _repository.GetIssueCount();
            ViewBag.EngagementTarget = EngagementTarget;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Submit(string location, IssueCategory category, string description, List<IFormFile> images)
        {
            if (string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(description) || images == null || images.Count == 0)
            {
                TempData["Error"] = "All fields are required, including at least one image.";
                return RedirectToAction("Index");
            }
            var issue = new Issue
            {
                Location = location.Trim(),
                Category = category,
                Description = description.Trim()
            };

            if (Attachment != null && Attachment.Length > 0)
            {
                var uploads = Path.Combine(_env.WebRootPath, "uploads");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                var safeFileName = $"{Guid.NewGuid()}_{Path.GetFileName(Attachment.FileName)}";
                var filePath = Path.Combine(uploads, safeFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Attachment.CopyToAsync(stream);
                }
                issue.AttachmentPath = $"/uploads/{safeFileName}";
            }
            _repository.AddIssue(issue);
            TempData["Success"] = "Thank you for your report - your issue has been submitted";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult List()
        {
            var issues = _repository.GetAllIssues();
            return View(issues);
        }
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var issue = _repository.GetIssueById(id);
            if (issue == null)
            {
                return NotFound();
            }
            return View(issue);
        }
    }
}
