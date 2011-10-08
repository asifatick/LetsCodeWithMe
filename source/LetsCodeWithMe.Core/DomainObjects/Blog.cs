namespace LetsCodeWithMe.DomainObjects
{
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;

    public class Blog
    {
        private static int defaultPostPerPage = 5;
        private static int defaultPagesPerPage = 5;
        private static string defaultTheme = "default";

        private Guid id;
        private int postsPerPage;
        private int pagesPerPage;
        private string theme;
        private ICollection<Post> posts;
        private ICollection<Page> pages;

        [DebuggerStepThrough]
        public Blog()
        {
            id = Guid.NewGuid();
            postsPerPage = DefaultPostPerPage;
            pagesPerPage = DefaultPagesPerPage;
            theme = DefaultTheme;
        }

        public static int DefaultPostPerPage
        {
            [DebuggerStepThrough]
            get { return defaultPostPerPage; }

            [DebuggerStepThrough]
            set { defaultPostPerPage = value; }
        }

        public static int DefaultPagesPerPage
        {
            [DebuggerStepThrough]
            get { return defaultPagesPerPage; }

            [DebuggerStepThrough]
            set { defaultPagesPerPage = value; }
        }

        public static string DefaultTheme
        {
            [DebuggerStepThrough]
            get { return defaultTheme; }

            [DebuggerStepThrough]
            set { defaultTheme = value; }
        }

        public virtual Guid Id
        {
            [DebuggerStepThrough]
            get { return id; }

            [DebuggerStepThrough]
            set { id = value; }
        }

        public virtual string Title { get; set; }

        public virtual string Tagline { get; set; }

        public virtual string MetaKeywords { get; set; }

        public virtual string MetaDescription { get; set; }

        public virtual string Author { get; set; }

        public virtual string Email { get; set; }

        public virtual int PostsPerPage
        {
            [DebuggerStepThrough]
            get { return postsPerPage; }

            [DebuggerStepThrough]
            set { postsPerPage = value; }
        }

        public virtual int PagesPerPage
        {
            [DebuggerStepThrough]
            get { return pagesPerPage; }

            [DebuggerStepThrough]
            set { pagesPerPage = value; }
        }

        public virtual string Theme
        {
            [DebuggerStepThrough]
            get { return theme; }

            [DebuggerStepThrough]
            set { theme = value; }
        }

        public virtual ICollection<Post> Posts
        {
            [DebuggerStepThrough]
            get { return posts ?? (posts = new List<Post>()); }
        }

        public virtual ICollection<Page> Pages
        {
            [DebuggerStepThrough]
            get { return pages ?? (pages = new List<Page>()); }
        }
    }
}