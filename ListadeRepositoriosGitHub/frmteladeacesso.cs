using Octokit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListadeRepositoriosGitHub
{
    public partial class FrmTeladeAcesso : Form
    {
        public FrmTeladeAcesso()
        {
            InitializeComponent();
        }

        public void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var repositorioList = ObterGitHubRepositorioList(txtUsuario.Text, txtSenha.Text);

                if (repositorioList != null)
                {

                    foreach (var itemRepositorio in repositorioList)

                    richtxtConsulta.Text = (string.Format("{0} - {1}\n\t{2}\n\tCriado em {3}", itemRepositorio.Id, itemRepositorio.Name, itemRepositorio.Url, itemRepositorio.CreatedAt.ToString("dd/MM/yyyy - HH:mm")));
                }
            }
            catch (AggregateException ex)
            {
                Console.Clear();
                Console.WriteLine("Erro ao obter repositório: ");
                Console.WriteLine(ex.Message);
                foreach (var innerException in ex.InnerExceptions)
                    Console.WriteLine(innerException.Message);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Erro ao obter repositório: ");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.Read();
            }
        }
    


         private static IReadOnlyList<Repository> ObterGitHubRepositorioList(string usuario, string senha)
         {
         Task<IReadOnlyList<Repository>> repositorioList = null;
            GitHubClient client = new GitHubClient(new ProductHeaderValue(AppDomain.CurrentDomain.FriendlyName))
            {
                Credentials = new Credentials(usuario, senha)
            };
            Task.Run(() => repositorioList = client.Repository.GetAllForUser(usuario)).Wait();
         return repositorioList.Result;
         }

        private void FrmTeladeAcesso_Load(object sender, EventArgs e)
        {

        }
    }

}

   

