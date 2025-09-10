using MunicipalApplication.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MunicipalApplication.Services
{
    public class IssueRepository : IIssueRepository
    {
        private readonly LinkedList<Issue> issues = new LinkedList<Issue>();
        public void AddIssue(Issue issue)
        {
            if (issue == null) throw new ArgumentNullException(nameof(issue));
            issues.AddLast(issue);
        }
        public IEnumerable<Issue> GetAllIssues()
        {
            foreach (var i in issues)
                yield return i;
        }
        public int GetIssueCount()
        {
            return issues.Count;
        }
        public Issue GetIssueById(Guid id)
        {
            var node = issues.First;
            while (node != null)
            {
                if (node.Value.Id == id)
                    return node.Value;
                node = node.Next;
            }
            return null;
        }
        public int Count => issues.Count;
    }
}
