namespace LetsCodeWithMe.DomainObjects
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Category
    {
        private Guid id;
        private ICollection<Category> children;
        private ICollection<Page> pages;

        [DebuggerStepThrough]
        public Category()
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

        public virtual Category Parent { get; set; }

        public virtual ICollection<Category> Children
        {
            [DebuggerStepThrough]
            get { return children ?? (children = new List<Category>()); }
        }

        public virtual ICollection<Page> Pages
        {
            [DebuggerStepThrough]
            get { return pages ?? (pages = new List<Page>()); }
        }
    }
}