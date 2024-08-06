using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Extensions
{
    public class JobSearchException : ApplicationException
    {
        public JobSearchException(string message)
            : base($"Job Search project exception: {message} ")
        {

        }
    }
}
