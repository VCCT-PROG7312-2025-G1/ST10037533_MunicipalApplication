using MunicipalApplication.Models;
using MunicipalApplication.Services;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MunicipalApplication.Services
{
    public class IssueRepository : IIssueRepository
    {
        private static readonly IssueRepository _instance = new IssueRepository();
        private readonly LinkedList<Issue> _issues = new LinkedList<Issue>();

        public IssueRepository() { }

        public static IssueRepository Instance => _instance;


        public int Count => _issues.Count;


        public void AddIssue(Issue issue)
        {
            _issues.AddFirst(issue);
        }


        public LinkedList<Issue> GetAllIssues()
        {
            return _issues;
        }
    }
}