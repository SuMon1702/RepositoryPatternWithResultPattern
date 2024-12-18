﻿namespace AdvanceDotNet.RepositoryPattern.Models
{
    public class BlogRequestModel
    {
         public string BlogTitle { get; set; } = null!;

        public string BlogAuthor { get; set; } = null!;

        public string BlogContent { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
