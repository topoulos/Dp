namespace Dp.Models.Database
{
    public class TaskItem : ModelBase
    {
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}