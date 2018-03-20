using System.Collections.Generic;

namespace Dp.Models.Database
{
    public class Project : ModelBase
    {
        public ICollection<TaskItem> TaskItems { get; set; }
    }
}