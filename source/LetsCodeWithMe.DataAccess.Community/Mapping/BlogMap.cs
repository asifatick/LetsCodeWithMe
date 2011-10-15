namespace LetsCodeWithMe.DataAccess.Community
{
    using FluentNHibernate.Mapping;

    using DomainObjects;

    public sealed class BlogMap : ClassMap<Blog>
    {
        public BlogMap()
        {
            Id(b => b.Id).GeneratedBy.GuidComb();

            Map(b => b.Title).Not.Nullable().Length(256);
            Map(b => b.Tagline).Length(256);
            Map(b => b.MetaKeywords).Length(512);
            Map(b => b.MetaDescription).Length(512);
            Map(b => b.Author).Not.Nullable().Length(256);
            Map(b => b.Email).Not.Nullable().Length(256);
            Map(b => b.PostsPerPage);
            Map(b => b.PagesPerPage);
            Map(b => b.Theme).Not.Nullable().Length(128);

            HasMany(b => b.Posts).Access.CamelCaseField().Cascade.Delete();
            HasMany(b => b.Pages).Access.CamelCaseField().Cascade.Delete();
        }
    }
}