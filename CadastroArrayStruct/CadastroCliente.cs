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
    public partial class CadastroCliente : Form
    {
        bool tipoEdicao = false;
        int atual = 0;
        public CadastroCliente()
        {
            InitializeComponent();
        }
        private void DesabilitarEdicao()
        {
            txtBoxCodigo.Enabled = false;
            txtBoxNome.Enabled = false;
            txtBoxCPF.Enabled = false;
            txtBoxRG.Enabled = false;
            txtBoxEndereco.Enabled = false;
            txtBoxBairro.Enabled = false;
            txtBoxCidade.Enabled = false;
            txtBoxUF.Enabled = false;
            txtBoxCEP.Enabled = false;
            txtBoxTelefone.Enabled = false;
            txtBoxEmail.Enabled = false;

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
        private void HabilitarEdicao()
        {
            txtBoxCodigo.Enabled = false;
            txtBoxNome.Enabled = true;
            txtBoxCPF.Enabled = true;
            txtBoxRG.Enabled = true;
            txtBoxEndereco.Enabled = true;
            txtBoxBairro.Enabled = true;
            txtBoxCidade.Enabled = true;
            txtBoxUF.Enabled = true;
            txtBoxCEP.Enabled = true;
            txtBoxTelefone.Enabled = true;
            txtBoxEmail.Enabled = true;

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
        private void MostrarDados()
        {
            txtBoxCodigo.Text = FormIndex.cliente[atual].codigo.ToString();
            txtBoxNome.Text = FormIndex.cliente[atual].nome;
            txtBoxCPF.Text = FormIndex.cliente[atual].cpf;
            txtBoxRG.Text = FormIndex.cliente[atual].rg;
            txtBoxEndereco.Text = FormIndex.cliente[atual].endereco;
            txtBoxBairro.Text = FormIndex.cliente[atual].bairro;
            txtBoxCidade.Text = FormIndex.cliente[atual].cidade;
            txtBoxUF.Text = FormIndex.cliente[atual].uf;
            txtBoxCEP.Text = FormIndex.cliente[atual].cep;
            txtBoxTelefone.Text = FormIndex.cliente[atual].telefone;
            txtBoxEmail.Text = FormIndex.cliente[atual].email;
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CadastroCliente_Load(object sender, EventArgs e)
        {
            DesabilitarEdicao();
            MostrarDados();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (tipoEdicao)
            {
                FormIndex.cliente[FormIndex.contCliente].codigo = int.Parse(txtBoxCodigo.Text);
                FormIndex.cliente[FormIndex.contCliente].nome = txtBoxNome.Text;
                FormIndex.cliente[FormIndex.contCliente].cpf = txtBoxCPF.Text;
                FormIndex.cliente[FormIndex.contCliente].rg = txtBoxRG.Text;
                FormIndex.cliente[FormIndex.contCliente].endereco = txtBoxEndereco.Text;
                FormIndex.cliente[FormIndex.contCliente].bairro = txtBoxBairro.Text;
                FormIndex.cliente[FormIndex.contCliente].cidade = txtBoxCidade.Text;
                FormIndex.cliente[FormIndex.contCliente].uf = txtBoxUF.Text;
                FormIndex.cliente[FormIndex.contCliente].cep = txtBoxCEP.Text;
                FormIndex.cliente[FormIndex.contCliente].telefone = txtBoxTelefone.Text;
                FormIndex.cliente[FormIndex.contCliente].email = txtBoxEmail.Text;
                atual = FormIndex.contCliente++;
            }
            else
            {
                FormIndex.cliente[atual].nome = txtBoxNome.Text;
                FormIndex.cliente[atual].cpf = txtBoxCPF.Text;
                FormIndex.cliente[atual].rg = txtBoxRG.Text;
                FormIndex.cliente[atual].endereco = txtBoxEndereco.Text;
                FormIndex.cliente[atual].bairro = txtBoxBairro.Text;
                FormIndex.cliente[atual].cidade = txtBoxCidade.Text;
                FormIndex.cliente[atual].uf = txtBoxUF.Text;
                FormIndex.cliente[atual].cep = txtBoxCEP.Text;
                FormIndex.cliente[atual].telefone = txtBoxTelefone.Text;
                FormIndex.cliente[atual].email = txtBoxEmail.Text;
            }DesabilitarEdicao();

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (FormIndex.contCliente < 10)
            {
                txtBoxCodigo.Text = (FormIndex.contCliente + 1).ToString();
                txtBoxNome.Text = "";
                txtBoxCPF.Text = "";
                txtBoxRG.Text = "";
                txtBoxEndereco.Text = "";
                txtBoxBairro.Text = "";
                txtBoxCidade.Text = "";
                txtBoxUF.Text = "";
                txtBoxCEP.Text = "";
                txtBoxTelefone.Text = "";
                txtBoxEmail.Text = "";
                HabilitarEdicao();
                tipoEdicao = true;
            }
            else MessageBox.Show("Arquivo cheio!");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (FormIndex.contCliente > 0)
            {
                HabilitarEdicao();
                tipoEdicao = false;
            }
            else MessageBox.Show("Arquivo vazio!");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DesabilitarEdicao();
            MostrarDados();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (atual < FormIndex.contCliente - 1)
            {
                atual++;
                MostrarDados();
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
                MostrarDados();
            }
            else
            {
                MessageBox.Show("Início do arquivo");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (FormIndex.contCliente > 0)
            {
                txtBoxNome.Text = "";
                txtBoxCPF.Text = "";
                txtBoxRG.Text = "";
                txtBoxEndereco.Text = "";
                txtBoxBairro.Text = "";
                txtBoxCidade.Text = "";
                txtBoxUF.Text = "";
                txtBoxCEP.Text = "";
                txtBoxTelefone.Text = "";
                txtBoxEmail.Text = "";
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
            for (x = 0; x < FormIndex.contCliente; x++)
            {
                if (FormIndex.cliente[x].nome.IndexOf(txtBoxPesquisarPanel.Text) >= 0)
                {
                    atual = x;
                    MostrarDados();
                    break;
                }
            }
            if(x >= FormIndex.contCliente)
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
            strDados = "Ficha de cliente";
            strDados += "\n===================================================================";
            strDados += "\nCódigo: " + txtBoxCodigo.Text;
            strDados += "\nNome: " + txtBoxNome.Text;
            strDados += "\nCPF: " + txtBoxCPF.Text;
            strDados += "\nRG: " + txtBoxRG.Text;
            strDados += "\nEndereço: " + txtBoxEndereco.Text;
            strDados += "\nBairro: " + txtBoxBairro.Text;
            strDados += "\nCidade: " + txtBoxCidade.Text;
            strDados += "\nUF: " + txtBoxUF.Text;
            strDados += "\nCEP: " + txtBoxCEP.Text;
            strDados += "\nTelefone: " + txtBoxTelefone.Text;
            strDados += "\nEmail: " + txtBoxEmail.Text;
            objImpressao.DrawString(strDados, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, 50, 50);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
    }
}
