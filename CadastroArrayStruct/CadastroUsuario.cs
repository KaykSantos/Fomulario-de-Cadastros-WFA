using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroArrayStruct
{
    public partial class CadastroUsuario : Form
    {
        bool tipoEdicao = false;
        int atual = 0;
        private void HabilitarEdicao()
        {
            txtBoxCodigo.Enabled = false;
            txtBoxNome.Enabled = true;
            txtBoxNivel.Enabled = true;
            txtBoxLogin.Enabled = true;
            txtBoxSenha.Enabled = true;

            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            btnAnterior.Enabled = false;
            btnProximo.Enabled = false;
            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnPesquisar.Enabled = false;
            btnImprimir.Enabled = false;
            btnSair.Enabled = false;
        }
        private void DesabilitarEdicao()
        {
            txtBoxCodigo.Enabled = false;
            txtBoxNome.Enabled = false;
            txtBoxNivel.Enabled = false;
            txtBoxLogin.Enabled = false;
            txtBoxSenha.Enabled = false;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnAnterior.Enabled = true;
            btnProximo.Enabled = true;
            btnNovo.Enabled = true;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnPesquisar.Enabled = true;
            btnImprimir.Enabled = true;
            btnSair.Enabled = true;
        }
        private void MostraDados()
        {
            txtBoxCodigo.Text = FormIndex.usuario[atual].codigo.ToString();
            txtBoxNome.Text = FormIndex.usuario[atual].nome;
            txtBoxNivel.Text = FormIndex.usuario[atual].nivel;
            txtBoxLogin.Text = FormIndex.usuario[atual].login;
            txtBoxSenha.Text = FormIndex.usuario[atual].senha;
        }
        public CadastroUsuario()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (tipoEdicao)
            {
                FormIndex.usuario[FormIndex.contUsuario].codigo = int.Parse(txtBoxCodigo.Text);
                FormIndex.usuario[FormIndex.contUsuario].nome = txtBoxNome.Text;
                FormIndex.usuario[FormIndex.contUsuario].nivel = txtBoxNivel.Text;
                FormIndex.usuario[FormIndex.contUsuario].login = txtBoxLogin.Text;
                FormIndex.usuario[FormIndex.contUsuario].senha = txtBoxSenha.Text;
                atual = FormIndex.contUsuario++;
            }
            else
            {
                FormIndex.usuario[atual].nome = txtBoxNome.Text;
                FormIndex.usuario[atual].nivel = txtBoxNivel.Text;
                FormIndex.usuario[atual].login = txtBoxLogin.Text;
                FormIndex.usuario[atual].senha = txtBoxSenha.Text;
            }
            DesabilitarEdicao();
        }

        private void CadastroUsuario_Load(object sender, EventArgs e)
        {
            DesabilitarEdicao();
            MostraDados();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (FormIndex.contUsuario < 10)
            {
                txtBoxCodigo.Text = (FormIndex.contUsuario + 1).ToString();
                txtBoxNome.Text = "";
                txtBoxNivel.Text = "";
                txtBoxLogin.Text = "";
                txtBoxSenha.Text = "";
                HabilitarEdicao();
                tipoEdicao = true;
            }
            else MessageBox.Show("Arquivo cheio!");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (FormIndex.contUsuario > 0)
            {
                HabilitarEdicao();
                tipoEdicao = false;
            }
            else MessageBox.Show("Arquivo vazio!");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DesabilitarEdicao();
            MostraDados();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if ( atual < FormIndex.contUsuario - 1)
            {
                atual++;
                MostraDados();
            }
            else
            {
                MessageBox.Show("Fim de arquivo!");
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (atual > 0)
            {
                atual--;
                MostraDados();
            }
            else
            {
                MessageBox.Show("Início do arquivo");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(FormIndex.contUsuario > 0)
            {
                FormIndex.usuario[atual].nome = "";
                FormIndex.usuario[atual].nivel = "";
                FormIndex.usuario[atual].login = "";
                FormIndex.usuario[atual].login = "";
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = true;
            txtBoxPesquisarPanel.Focus();
        }

        private void btnEnviarPesquisa_Click(object sender, EventArgs e)
        {
            int x;
            for (x = 0; x < FormIndex.contUsuario; x++)
            {
                if (FormIndex.usuario[x].nome.IndexOf(txtBoxPesquisarPanel.Text) >= 0)
                {
                    atual = x;
                    MostraDados();
                    break;
                }
            }
            if (x >= FormIndex.contUsuario)
            {
                MessageBox.Show("Não encontrado");
            }
            pnlPesquisa.Visible = false;
        }

        private void btnCancelarPesquisa_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = false;

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string strDados;
            Graphics objImpressao = e.Graphics;
            strDados = "Ficha de usuário";
            strDados += "\n===================================================================";
            strDados += "\nCódigo: "+txtBoxCodigo.Text;
            strDados += "\nNome: "+txtBoxNome.Text;
            strDados += "\nNível: "+txtBoxNivel.Text;
            strDados += "\nLogin: "+txtBoxLogin.Text;

            objImpressao.DrawString(strDados, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, 50, 50); 
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
    }
}
