using MunicipalApplication.Models;
using System.Collections.Generic;

namespace MunicipalApplication.Services
{
    public interface IIssueRepository
    {
        void AddIssue(Issue issue);
        IEnumerable<Issue> GetAllIssues();
        int GetIssueCount();
        void SaveToFile();
        void LoadFromFile();
    }
}
