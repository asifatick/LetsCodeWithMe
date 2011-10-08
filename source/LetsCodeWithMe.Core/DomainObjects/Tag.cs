namespace LetsCodeWithMe.DomainObjects
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Tag
    {
        private Guid id;
        private ICollection<Post> posts;

        [DebuggerStepThrough]
        public Tag()
        {
            id = Guid.NewGuid();
        }

        public virtual Guid Id
        {
            [DebuggerStepThrough]
            get { return id; }

            [DebuggerStepThrough]
            set { id = value; }
        }

        public virtual string Title { get; set; }

        public virtual string Slug { get; set; }

        public virtual ICollection<Post> Posts
        {
            [DebuggerStepThrough]
            get { return posts ?? (posts = new List<Post>()); }
        }
    }
}