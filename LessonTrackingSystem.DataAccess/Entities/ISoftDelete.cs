﻿namespace LessonTrackingSystem.DataAccess.Entities
{
    public interface ISoftDelete
    {
        public bool? IsDeleted { get; set; }
    }
}