﻿using System.ComponentModel.DataAnnotations;

namespace BookShop.Data
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string? UserId { get; set; }
        public int BookId { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime DatePosted { get; set; }= DateTime.Now;
        public ApplicationUser User { get; set; }
        public Book Book { get; set; }
    }
}
