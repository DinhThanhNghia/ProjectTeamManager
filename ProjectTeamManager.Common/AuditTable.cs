using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTeamManager.Common
{
    public class AuditTable
    {
        public static void InsertAuditFields(object obj)
        {
            dynamic project = obj;
            project.IsDeleted = false;
            project.InsAt = DateTime.Now;
            project.InsBy = "Admin";
            project.UpdAt = DateTime.Now;
            project.UpdBy = "Admin";
        }
        public static void UpdateAuditFields(object obj)
        {
            dynamic project = obj;
            project.UpdAt = DateTime.Now;
            project.UpdBy = "Admin";
        }
    }
}
