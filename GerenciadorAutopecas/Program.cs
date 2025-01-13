using GerenciadorAutopecas.UI;
using System;
using System.IO;
using System.Windows.Forms;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        try
        {
            // String de conexão com o SQL Server
            string connectionstr = "Server=DESKTOP-NI8QB5S\\SQLEXPRESS;Database=autopecas;Trusted_Connection=True;";

            // Configuração do NHibernate
            var config = new NHibernate.Cfg.Configuration();
            config.DataBaseIntegration(x =>
            {
                x.ConnectionString = connectionstr;
                x.Dialect<NHibernate.Dialect.MsSql2012Dialect>();
                x.Driver<NHibernate.Driver.SqlClientDriver>();
            });

            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Caminho absoluto para o arquivo de mapeamento
            string pecasMappingPath = Path.Combine(baseDirectory, "Data", "Mappings", "Pecas.hbm.xml");
            string vendaMappingPath = Path.Combine(baseDirectory, "Data", "Mappings", "Venda.hbm.xml");

            // Carrega os arquivos de mapeamento
            config.AddFile(pecasMappingPath);
            config.AddFile(vendaMappingPath);

            // Criar o Session Factory
            var sessionFactory = config.BuildSessionFactory();

            // Testa a conexão
            using (var session = sessionFactory.OpenSession())
            {
                Console.WriteLine("Conexão bem-sucedida com o banco de dados!");

                /* Lista todas as peças
                var pecas = session.QueryOver<GerenciadorAutopecas.Data.Models.Pecas>().List();
                foreach (var peca in pecas)
                {
                    Console.WriteLine($"Peça: {peca.Nome}, Preço de Venda: {peca.PrecoVenda}");
                }*/
            }

            // Roda a interface após a configuração do NHibernate
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Inicia o formulário principal do Windows Forms
            Application.Run(new MainForm()); 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao conectar ao banco: {ex.Message}");
        }
    }
}


