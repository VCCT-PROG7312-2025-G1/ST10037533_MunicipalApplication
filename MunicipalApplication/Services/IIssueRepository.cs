using MunicipalApplication.Models;
using System.Collections.Generic;

namespace MunicipalApplication.Services
{
    public interface IIssueRepository
    {
        void AddIssue(Issue issue);
        LinkedList<Issue> GetAllIssues();
        int Count { get; }
    }
}
