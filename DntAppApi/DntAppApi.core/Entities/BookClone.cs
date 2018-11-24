using System;
using System.Collections.Generic;

namespace DntAppApi.core.Entities
{
    public partial class BookClone
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Dept { get; set; }
        public int? SubjectId { get; set; }
        public int? LibraryId { get; set; }
    }
}
