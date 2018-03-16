using System;

namespace DP.Api.Models
{
    public class DpModelBase
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}