namespace LetsCodeWithMe.DataAccess.Community
{
    using System;

    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    using NHibernate;
    using NHibernate.Tool.hbm2ddl;

    public class SessionProvider : IDisposable
    {
        private static readonly object synclock = new object();
        private static ISessionFactory sessionFactory;

        private readonly string providerName;
        private readonly string connectionString;

        private ISession session;

        public SessionProvider(string providerName, string connectionString)
        {
            this.providerName = providerName;
            this.connectionString = connectionString;
        }

        public virtual ISession Get()
        {
            if (session == null)
            {
                EnsureSessionFactory(providerName, connectionString);

                session = sessionFactory.OpenSession();
            }

            return session;
        }

        private static void EnsureSessionFactory(string providerName, string connectionString)
        {
            if (sessionFactory != null)
            {
                return;
            }

            lock (synclock)
            {
                if (sessionFactory != null)
                {
                    return;
                }

                sessionFactory = Fluently.Configure()
                                         .Database(() =>
                                            {
                                                if (providerName.StartsWith("System.Data.SqlServerCe"))
                                                {
                                                    return MsSqlCeConfiguration.Standard
                                                                               .ConnectionString(connectionString)
                                                                               .FormatSql()
                                                                               .ShowSql();
                                                }

                                                return MsSqlConfiguration.MsSql2008
                                                                         .ConnectionString(connectionString)
                                                                         .FormatSql()
                                                                         .ShowSql();
                                            })
                                         .Mappings(map => map.FluentMappings.AddFromAssemblyOf<SessionProvider>())
                                         .ExposeConfiguration(SchemaMetadataUpdater.QuoteTableAndColumns)
                                         .BuildSessionFactory();
            }
        }

        public void Dispose()
        {
            if (session != null)
            {
                session.Dispose();
            }
        }
    }
}