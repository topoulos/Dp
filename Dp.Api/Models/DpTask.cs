namespace DP.Api.Models
{
    public class DpTask : DpModelBase
    {
        public DpProject DpProject { get; set; }
        public int DpProjectId { get; set; }
    }
}