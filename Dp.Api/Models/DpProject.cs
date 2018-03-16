using System.Collections.Generic;

namespace DP.Api.Models
{
    public class DpProject : DpModelBase
    {
        public ICollection<DpTask> DpTasks { get; set; }
    }
}