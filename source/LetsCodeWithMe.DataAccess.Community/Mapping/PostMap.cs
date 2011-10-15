namespace LetsCodeWithMe.DataAccess.Community
{
    using FluentNHibernate.Mapping;

    using DomainObjects;

    public sealed class PostMap : ClassMap<Post>
    {
        public PostMap()
        {
            Id(p => p.Id).GeneratedBy.GuidComb();

            Map(p => p.PublishedAt).Nullable().Index("IX_Post_PublishedAt_Slug");
            Map(p => p.Slug).Not.Nullable().Length(256).Index("IX_Post_Slug_PublishedAt");
            Map(p => p.Type).Not.Nullable().Length(16);
            Map(p => p.Title).Not.Nullable().Length(256);
            Map(p => p.MetaKeywords).Length(512);
            Map(p => p.MetaDescription).Length(512);
            Map(p => p.Author).Length(256);
            Map(p => p.AllowComments);
            Map(p => p.Body).Not.Nullable().Length(10000);

            HasMany(p => p.Tags).Access.CamelCaseField().Cascade.Delete();
            References(p => p.Blog).ForeignKey("FK_Post_Blog").Index("IX_Post_Blog_Id");
        }
    }
}