using Octokit;
using System;
using System.Collections.Generic;
using System.Text;
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
        //Instalar Pacote Octokit -Version 0.26.0
        public void BtnConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                var listaRepositorio = AcessoaoGHListaRepositorio(txtUsuario.Text, txtSenha.Text);

                if (listaRepositorio != null)
                {
                    StringBuilder result = new StringBuilder();
                    foreach (var itemRepositorio in listaRepositorio)
                    result.AppendLine((string.Format("{0} - {1}\n\t{2}\n\tCriado em {3}", itemRepositorio.Id, itemRepositorio.Name, itemRepositorio.Url, itemRepositorio.CreatedAt.ToString("dd/MM/yyyy - HH:mm"))) + "\n");
                    richtxtConsulta.Text = result.ToString();
                }

            }
            catch (AggregateException)
            {
                richtxtConsulta.Text = ("Usuário ou senha inválido(s)! ");

            }
            finally
            {
                Console.Read();
            }
        }

        private void BtnNvConsulta_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Restart();
        }

        

        private static IReadOnlyList<Repository> AcessoaoGHListaRepositorio(string usuario, string senha)
         {
         Task<IReadOnlyList<Repository>> listaRepositorio = null;
            GitHubClient client = new GitHubClient(new ProductHeaderValue(AppDomain.CurrentDomain.FriendlyName))
            {
                Credentials = new Credentials(usuario, senha)
            };
            Task.Run(() => listaRepositorio = client.Repository.GetAllForUser(usuario)).Wait();
         return listaRepositorio.Result;
         }

    }

}

   

