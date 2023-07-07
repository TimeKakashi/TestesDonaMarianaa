using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.Text;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloGabarito;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Dominio.ModuloTeste;
using TestesDonaMariana.WinForm.Compartilhado;
using static System.Net.Mime.MediaTypeNames;

namespace TestesDonaMariana.WinForm.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        private ListagemTesteControl listagemTeste;
        private IRepositorioTeste repositorioTeste;
        private IRepositorioGabarito repositorioGabarito;
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioMateria repositorioMateria;
        private IRepositorioQuestoes repositorioQuestoes;

        public ControladorTeste(IRepositorioTeste repositorioTeste, IRepositorioGabarito repositorioGabarito, IRepositorioDisciplina repositorioDisciplina, IRepositorioMateria repositorioMateria, IRepositorioQuestoes repositorioQuestoes)
        {
            this.repositorioTeste = repositorioTeste;
            this.repositorioGabarito = repositorioGabarito;
            this.repositorioMateria = repositorioMateria;
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioQuestoes = repositorioQuestoes;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            CarregarTestes();
        }

        public override string ToolTipInserir => "Cadastrar Teste";

        public override string ToolTipEditar => "Este botão está desabilitado nessa Tela";

        public override string ToolTipExcluir => "Excluir Teste";
        public override string ToolTipFiltrar => "Filtrar Testes";

        public override string ToolTipPdf => "Gerar PDF";

        public override string ToolTipGabarito => "Gerar Gabarito";

        public override string ToolTipDuplicar => "Duplicar Teste";

        public override bool FiltrarHabilitado => true;

        public override bool GerarGabaritoHabilitado => true;

        public override bool GerarPdfHabilitado => true;

        public override bool EditarHabilitado => false;
        public override bool DuplicarHabilitado => true;

        

        public override void Inserir()
        {
            TelaTeste telaTeste = new TelaTeste(repositorioDisciplina, repositorioMateria, repositorioQuestoes);

            DialogResult resultado = telaTeste.ShowDialog();

            if(resultado == DialogResult.OK)
            {
                Teste teste = telaTeste.ObterTeste();

                repositorioTeste.Inserir(teste, teste.questoes);
            }
            CarregarTestes();
        }

        public override void Editar()
        {
            //Não é usado
        }
        public override void Excluir()
        {
            Teste testeSelecionado = ObterTesteSelecionado();

            if (testeSelecionado == null)
            {
                MessageBox.Show("Nenhum Teste Selecionado", "Excluir Teste", MessageBoxButtons.OK);
                return;
            }
            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja Excluir o Teste?", "Exclusão de Disciplina", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioTeste.Excluir(testeSelecionado);
                CarregarTestes();
            }
        }

        private void CarregarTestes()
        {
            List<Teste> testes = repositorioTeste.SelecionarTodos();

            if (listagemTeste == null)
                listagemTeste = new ListagemTesteControl();

            listagemTeste.AtualizarRegistros(testes);
        }

        private Teste ObterTesteSelecionado()
        {
            int id = listagemTeste.ObterIdSelecionado();

            Teste teste =  repositorioTeste.SelecionarPorId(id);

            List<Questao> questoes = repositorioTeste.SelecionarQuestoes(teste);

            teste.questoes = questoes;

            return teste;
        }



        public override UserControl ObterListagem()
        {
            if (listagemTeste == null)
                listagemTeste = new ListagemTesteControl();

            return listagemTeste;
        }
        public void DuplicarTeste()
        {
            Teste testeSelecionado = ObterTesteSelecionado();

            if (testeSelecionado != null)
            {
                Teste testeDuplicado = testeSelecionado.Clone() as Teste;

                if (testeDuplicado != null)
                {
                    List<Questao> questoesDuplicadas = new List<Questao>();

                    foreach (Questao questao in testeSelecionado.questoes)
                    {
                        Questao questaoDuplicada = questao.Clone() as Questao;
                        questoesDuplicadas.Add(questaoDuplicada);
                    }
                    testeDuplicado.questoes = questoesDuplicadas;

                    repositorioTeste.Inserir(testeDuplicado, questoesDuplicadas);

                    CarregarTestes();
                }
            }
        }

        public override string ObterTipoCadastro() => "Cadastro de Testes";

        public override void GerarPdf()
        {
            //using (SaveFileDialog sfd = new SaveFileDialog())
            //{
            //    Teste teste = ObterTesteSelecionado();

            //    if (teste == null)
            //    {
            //        MessageBox.Show("Nenhum Teste Selecionado", "Excluir Teste", MessageBoxButtons.OK);
            //        return;
            //    }

            //    PdfDocument document = new PdfDocument();

            //    document.Info.Title = "Teste";

            //    PdfPage page = document.AddPage();

            //    XGraphics gfx = XGraphics.FromPdfPage(page);

            //    XFont font = new XFont("Verdana", 20, XFontStyle.Bold);

            //    gfx.DrawString($"{teste.disciplina.nome}", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormat.Center);

            //    if (teste.materia != null)
            //        gfx.DrawString($"{teste.materia.nome}", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormat.Center);



            //    document.Save(sfd.FileName);

            //    Process.Start(sfd.FileName);

            PdfDocument document = new PdfDocument();
            //You will have to add Page in PDF Document
            PdfPage page = document.AddPage();
            //For drawing in PDF Page you will nedd XGraphics Object
            XGraphics gfx = XGraphics.FromPdfPage(page);
            //For Test you will have to define font to be used
            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
            //Finally use XGraphics & font object to draw text in PDF Page
            gfx.DrawString("My First PDF Document", font, XBrushes.Black,
            new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);
            //Specify file name of the PDF file
            string filename = "FirstPDFDocument.pdf";
            //Save PDF File
            document.Save(filename);
            //Load PDF File for viewing
            Process.Start(filename);

        }


            //Process.Start(filename);
        
    }
}
