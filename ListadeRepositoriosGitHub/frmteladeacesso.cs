using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ListadeRepositoriosGitHub
{
    public partial class frmteladeacesso : Form
    {
        public frmteladeacesso()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void Button1_Click(object sender, EventArgs e)
        {
            void ObterGitHubRepositorioList(string [] args)
            {

                ObterGitHubRepositorioList access = new ObterGitHubRepositorioList();
                void ObterGitHub()
                {
                    access.GetHashCode();
                    try
                    {
                        string usuario = Console.ReadLine();
                        string senha = Console.ReadLine();

                        var repositorioList = access;
                        foreach (var repositorioItem in repositorioList)
                        {
                           void dataGridView1_CellContentClick(object  DataGridViewCellEventArgs)
                            {

                                Console.WriteLine(string.Format("{0} - {1}\n\t{2}\n\tCriado em {3}", repositorioItem.Id, repositorioItem.Name, repositorioItem.Url, repositorioItem.CreatedAt.ToString("dd/MM/yyyy - HH:mm")));
                            }
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
                        Console.ReadKey();
                    }
                }

            }
                             
        }

        internal class ObterGitHubRepositorioList
        {
            private static IReadOnlyList<Repository> ObterGitHub(string usuario, string senha)
            {
                Task<IReadOnlyList<Repository>> repositorioList = null;
                GitHubClient client = new GitHubClient(new ProductHeaderValue(AppDomain.CurrentDomain.FriendlyName));
                client.Credentials = new Credentials(usuario, senha);
                Task.Run(() => repositorioList = client.Repository.GetAllForUser(usuario)).Wait();
                return repositorioList.Result;
            }
        }
    }

}
    
