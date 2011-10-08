namespace LetsCodeWithMe.DomainObjects
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Post
    {
        private Guid id;
        private bool allowComments;
        private ICollection<Tag> tags;

        [DebuggerStepThrough]
        public Post()
        {
            tags = new List<Tag>();
            id = Guid.NewGuid();
            allowComments = true;
        }

        public virtual Guid Id
        {
            [DebuggerStepThrough]
            get { return id; }

            [DebuggerStepThrough]
            set { id = value; }
        }

        public virtual DateTime PublishedAt { get; set; }

        public virtual string Slug { get; set; }

        public virtual string Type { get; set; }

        public virtual string Title { get; set; }

        public virtual string MetaKeywords { get; set; }

        public virtual string MetaDescription { get; set; }

        public virtual string Author { get; set; }

        public virtual bool AllowComments
        {
            [DebuggerStepThrough]
            get { return allowComments; }

            [DebuggerStepThrough]
            set { allowComments = value; }
        }

        public virtual ICollection<Tag> Tags
        {
            [DebuggerStepThrough]
            get { return tags ?? (tags = new List<Tag>()); }
        }

        public virtual string Body { get; set; }

        public virtual Blog Blog { get; set; }
    }
}