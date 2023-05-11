using System;
using System.Web.Mvc;

namespace Backend.Challenge.Dtos
{
    public class CommentDto
    {
        public string Entity { get; set; }

        [AllowHtml]
        public string TextField { get; set; }

        public string Author { get; set; }

        public string UserId { get; set; }

        public DateTime PublishedDate { get; set; }
    }
}
