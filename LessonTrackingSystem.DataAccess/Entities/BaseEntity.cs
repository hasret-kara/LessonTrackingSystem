namespace LessonTrackingSystem.DataAccess.Entities
{

    public abstract class BaseEntity : IBaseEntity, ISoftDelete
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public Guid? CreatorUserId { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public Guid? LastModifierUserId { get; set; }
        public DateTime? DeletionDate { get; set; }
        public Guid? DeletorUserId { get; set; }
        public bool? IsDeleted { get; set; }
    }

}
