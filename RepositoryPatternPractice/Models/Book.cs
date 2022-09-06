using System;
using System.Collections.Generic;

namespace RepositoryPatternPractice.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public string BookName { get; set; } = null!;
        public int Price { get; set; }

        public virtual Author Author { get; set; } = null!;
    }
}
