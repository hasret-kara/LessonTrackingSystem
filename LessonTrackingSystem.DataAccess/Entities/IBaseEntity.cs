using System;

namespace LessonTrackingSystem.DataAccess.Entities
{
    public interface IBaseEntity
    {
        DateTime CreatedDate { get; set; }
        Guid? CreatorUserId { get; set; }
        DateTime? LastModificationDate { get; set; }
        Guid? LastModifierUserId { get; set; }
        DateTime? DeletionDate { get; set; }
        Guid? DeletorUserId { get; set; }
    }
}
