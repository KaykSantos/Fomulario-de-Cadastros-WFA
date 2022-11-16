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
    public partial class CadastroProduto : Form
    {
        bool tipoEdicao = false;
        int atual = 0;
        public CadastroProduto()
        {
            InitializeComponent();
        }
        private void DesabilitarEdicao()
        {
            txtBoxCodigo.Enabled = false;
            txtBoxDescricao.Enabled = false;
            txtBoxUnidade.Enabled = false;
            txtBoxQtEstoque.Enabled = false;
            txtBoxPrecoCusto.Enabled = false;
            txtBoxPrecoVenda.Enabled = false;

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
            txtBoxDescricao.Enabled = true;
            txtBoxUnidade.Enabled = true;
            txtBoxQtEstoque.Enabled = true;
            txtBoxPrecoCusto.Enabled = true;
            txtBoxPrecoVenda.Enabled = true;

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
            txtBoxCodigo.Text = FormIndex.produto[atual].codigo.ToString();
            txtBoxDescricao.Text = FormIndex.produto[atual].descricao;
            txtBoxUnidade.Text = FormIndex.produto[atual].unidade;
            txtBoxQtEstoque.Text = FormIndex.produto[atual].quantidade;
            txtBoxPrecoCusto.Text = FormIndex.produto[atual].precoCusto;
            txtBoxPrecoVenda.Text = FormIndex.produto[atual].precoVenda;
            
        }
        private void CadastroProduto_Load(object sender, EventArgs e)
        {
            DesabilitarEdicao();
            MostrarDados();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (tipoEdicao)
            {
                FormIndex.produto[FormIndex.contProduto].codigo = int.Parse(txtBoxCodigo.Text);
                FormIndex.produto[FormIndex.contProduto].descricao = txtBoxDescricao.Text;
                FormIndex.produto[FormIndex.contProduto].unidade = txtBoxUnidade.Text;
                FormIndex.produto[FormIndex.contProduto].quantidade = txtBoxQtEstoque.Text;
                FormIndex.produto[FormIndex.contProduto].precoCusto = txtBoxPrecoCusto.Text;
                FormIndex.produto[FormIndex.contProduto].precoVenda = txtBoxPrecoVenda.Text;
                atual = FormIndex.contProduto++;
            }
            else
            {
                FormIndex.produto[atual].descricao = txtBoxDescricao.Text;
                FormIndex.produto[atual].unidade = txtBoxUnidade.Text;
                FormIndex.produto[atual].quantidade = txtBoxQtEstoque.Text;
                FormIndex.produto[atual].precoCusto = txtBoxPrecoCusto.Text;
                FormIndex.produto[atual].precoVenda = txtBoxPrecoVenda.Text;
            }
            DesabilitarEdicao();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (FormIndex.contCliente < 10)
            {
                txtBoxCodigo.Text = (FormIndex.contProduto + 1).ToString();
                txtBoxDescricao.Text = "";
                txtBoxUnidade.Text = "";
                txtBoxQtEstoque.Text = "";
                txtBoxPrecoCusto.Text = "";
                txtBoxPrecoVenda.Text = "";
                HabilitarEdicao();
                tipoEdicao = true;
            }
            else MessageBox.Show("Arquivo cheio!");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (FormIndex.contProduto > 0)
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
            if (atual < FormIndex.contProduto - 1)
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
            if (FormIndex.contProduto > 0)
            {
                txtBoxDescricao.Text = "";
                txtBoxUnidade.Text = "";
                txtBoxQtEstoque.Text = "";
                txtBoxPrecoCusto.Text = "";
                txtBoxPrecoVenda.Text = "";
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
            for (x = 0; x < FormIndex.contProduto; x++)
            {
                if (FormIndex.produto[x].descricao.IndexOf(txtBoxPesquisarPanel.Text) >= 0)
                {
                    atual = x;
                    MostrarDados();
                    break;
                }
            }
            if (x >= FormIndex.contProduto)
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
            strDados += "\nDescrição: " + txtBoxDescricao.Text;
            strDados += "\nUnidade: " + txtBoxUnidade.Text;
            strDados += "\nQuantidade em estoque: " + txtBoxQtEstoque.Text;
            strDados += "\nPreço de custo: " + txtBoxPrecoCusto.Text;
            strDados += "\nPreço de venda:  " + txtBoxPrecoVenda.Text;
            objImpressao.DrawString(strDados, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, 50, 50);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
    }
}
