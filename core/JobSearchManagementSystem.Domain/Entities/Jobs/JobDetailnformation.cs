using JobSearchManagementSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Domain.Entities.Jobs
{
    public class JobDetailnformation:BaseEntity
    {
        public JobDetailnformation()
        {
            JobInformations=new HashSet<JobInformation>();
        }
        public string Title { get; set; }
        public ICollection<JobInformation> JobInformations { get; set; }

    }
}
