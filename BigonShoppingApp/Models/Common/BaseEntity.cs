﻿namespace BigonShoppingApp.Models.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set;}
        public int DeletedBy { get; set;}
    }
}
