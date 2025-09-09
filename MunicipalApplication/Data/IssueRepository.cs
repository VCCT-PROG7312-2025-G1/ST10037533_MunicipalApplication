using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using MunicipalApplication.Models;

namespace MunicipalApplication.Data
{
    public class IssueRepository
    {
        private LinkedList<IssueRepository> issues = new LinkedList<IssueRepository>();
        private readonly string _saveFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "issues.json");

        public void AddIssue(IssueRepository issue)
        {
            issues.AddLast(issue);
        }

        public IEnumerable<IssueRepository> GetAllIssues()
        {
            return issues;
        }

        public int GetIssueCount()
        {
            return issues.Count;
        }

        public void SaveToFile()
        {
            var toSave = new List<IssueRepository>(issues);
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(toSave, options);
            File.WriteAllText(_saveFilePath, json);
        }

        public void LoadFromFile()
        {
            if (!File.Exists(_saveFilePath)) return;
            try
            {
                var json = File.ReadAllText(_saveFilePath);
                var array = JsonSerializer.Deserialize<Issue[]>(json);
                if (array == null) return;
                issues = new LinkedList<Issue>(array);

                foreach (var issue in issues)
                {
                    if (issue.ImagePaths == null) issue.ImagePaths = new LinkedList<string>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading issues: {ex.Message}");
            }

        }
    }
}
