using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MunicipalApplication.Models;
using MunicipalApplication.Services;
using System;
using System.IO;

namespace MunicipalApplication.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ReportController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Submit()
        {
            ViewBag.ReportCount = IssueRepository.Instance.Count;
            ViewBag.ReportTarget = 10;
            ViewBag.Categories = new SelectList(new[] { "Sanitation", "Roads", "Streetlights", "Water", "Other" });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(Issue model, IFormFile attachment)
        {
            ViewBag.Categories = new SelectList(new[] { "Sanitation", "Roads", "Utilities", "Streetlights", "Water", "Other" });

            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Please fill in required fields.";
                return View(model);
            }
            if (attachment != null && attachment.Length > 0)
            {
                var uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");
                if (!Directory.Exists(uploadsDir))
                    Directory.CreateDirectory(uploadsDir);

                var uniqueName = $"{Guid.NewGuid()}_{Path.GetFileName(attachment.FileName)}";
                var path = Path.Combine(uploadsDir, uniqueName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    attachment.CopyTo(stream);
                }

                model.AttachmentPath = "/Uploads/" + uniqueName;
            }

            model.SubmittedAt = DateTime.UtcNow;
            IssueRepository.Instance.AddIssue(model);

            // Redirect to success page
            return RedirectToAction("Success");
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}
