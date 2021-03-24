using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class TeamDetail:TeamListItem
    {
        [DisplayName("Membres")]
        public IEnumerable<EmployeeListItem> Members { get; set; }
        [DisplayName("Conversations")]
        public IEnumerable<ConversationListItem> Conversations { get; set; }
        [DisplayName("Documents")]
        public IEnumerable<DocumentList> Docs { get; set; }

        public TeamDetail()
        {

        }

        public TeamDetail(Team team, Employee TeamManagerId, IEnumerable<EmployeeListItem> employees, IEnumerable<ConversationListItem> conversations, IEnumerable<DocumentList> docs) : this(team, TeamManagerId,employees)
        {
            Members = employees;
            Conversations = conversations;
            Docs = docs;
        }

        public TeamDetail(Team team, Employee TeamManagerId, IEnumerable<EmployeeListItem> employees) : base(team, TeamManagerId)
        {
            Members = employees;
        }

    }

}