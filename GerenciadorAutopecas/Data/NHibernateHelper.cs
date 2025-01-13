using NHibernate;
using NHibernate.Cfg;
using System;
using System.IO;

namespace GerenciadorAutopecas.Data
{
    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        // Propriedade para obter a fábrica de sessões
        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    string connectionstr = "Server=DESKTOP-NI8QB5S\\SQLEXPRESS;Database=autopecas;Trusted_Connection=True;";

                    var config = new NHibernate.Cfg.Configuration();
                    config.DataBaseIntegration(x =>
                    {
                        x.ConnectionString = connectionstr;
                        x.Dialect<NHibernate.Dialect.MsSql2012Dialect>();
                        x.Driver<NHibernate.Driver.SqlClientDriver>();
                    });

                    // Caminho para os arquivos de mapeamento
                    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string pecasMappingPath = Path.Combine(baseDirectory, "Data", "Mappings", "Pecas.hbm.xml");
                    string vendaMappingPath = Path.Combine(baseDirectory, "Data", "Mappings", "Venda.hbm.xml");

                    // Adicionar os arquivos de mapeamento
                    config.AddFile(pecasMappingPath);
                    config.AddFile(vendaMappingPath);

                    // Criar a fábrica de sessões
                    _sessionFactory = config.BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        // Método para abrir uma nova sessão
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
