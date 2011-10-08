namespace LetsCodeWithMe.DomainObjects
{
    using System;
    using System.Diagnostics;

    public class Page
    {
        private Guid id;

        [DebuggerStepThrough]
        public Page()
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

        public virtual DateTime PublishedAt { get; set; }

        public virtual string Slug { get; set; }

        public virtual string Type { get; set; }

        public virtual string Title { get; set; }

        public virtual string MetaKeywords { get; set; }

        public virtual string MetaDescription { get; set; }

        public virtual string Author { get; set; }

        public virtual bool AllowComments { get; set; }

        public virtual string Body { get; set; }

        public virtual Category Category { get; set; }

        public virtual Blog Blog { get; set; }
    }
}