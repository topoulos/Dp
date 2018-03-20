using System;
using System.ComponentModel.DataAnnotations.Schema;
using Dp.Models.Security;

namespace Dp.Models.Database
{
    public interface IModelBase : IEntity
    {
        bool IsActive { get; set; }
        DateTimeOffset CreatedDateTime { get; set; }
        DateTimeOffset ModifiedDateTime { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        bool Deleted { get; set; }
        int? CreatedByUserId { get; set; }
        int? ModifiedByUserId { get; set; }
    }

    public interface IEntity
    {
        int Id { get; set; }
    }

    public class ModelBase : IModelBase
    {
        [ForeignKey("CreatedByUserId")]
        public virtual User CreatedByUser { get; set; }

        [ForeignKey("ModifiedByUserId")]
        public virtual User ModifiedByUser { get; set; }

        public ModelBase()
        {
            IsActive = true;
            Deleted = false;
        }

        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset ModifiedDateTime { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }

        public int? CreatedByUserId { get; set; }
        public int? ModifiedByUserId { get; set; }
    }
}