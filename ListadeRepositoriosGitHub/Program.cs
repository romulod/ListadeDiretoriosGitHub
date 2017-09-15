using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListadeRepositoriosGitHub
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        /// Install-Package Octokit -Version 0.26.0
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new frmteladeacesso());
        }
        private static IReadOnlyList<Repository> ObterGitHubRepositorioList(string usuario, string senha)
        {
            Task<IReadOnlyList<Repository>> repositorioList = null;
            GitHubClient client = new GitHubClient(new ProductHeaderValue(AppDomain.CurrentDomain.FriendlyName));
            client.Credentials = new Credentials(usuario, senha);
            Task.Run(() => repositorioList = client.Repository.GetAllForUser(usuario)).Wait();
            return repositorioList.Result;
        }
    }
}
