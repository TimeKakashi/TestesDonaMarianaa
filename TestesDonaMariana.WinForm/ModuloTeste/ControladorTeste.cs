using System.Reflection.Metadata;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloGabarito;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Dominio.ModuloTeste;
using TestesDonaMariana.WinForm.Compartilhado;
using Document = iTextSharp.text.Document;

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
            TelaTeste telaTeste = new TelaTeste(repositorioDisciplina, repositorioMateria, repositorioQuestoes, repositorioTeste);

            DialogResult resultado = telaTeste.ShowDialog();

            if (resultado == DialogResult.OK)
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

            Teste teste = repositorioTeste.SelecionarPorId(id);

            List<Questao> questoes = new List<Questao>();

            if (teste.materia == null || teste.materia.id == 0)
            {
                questoes = repositorioQuestoes.SelecionarQuestoesDisciplina(teste.disciplina);
            }
            else
                questoes = repositorioTeste.SelecionarQuestoes(teste);

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
            Teste testeSelecionado = ObterTesteSelecionado();

            if (testeSelecionado != null)
            {
                // Obter o diretório temporário do sistema
                string diretorioTemporario = Path.GetTempPath();

                // Definir o caminho completo do arquivo PDF
                string caminhoArquivo = Path.Combine(diretorioTemporario, "arquivo.pdf");

                // Criar um novo documento PDF
                Document doc = new Document();

                // Definir o caminho de saída do arquivo PDF
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));

                // Abrir o documento para escrever o conteúdo
                doc.Open();

                // Adicionar conteúdo ao documento
                doc.Add(new Paragraph($"ID do Teste: {testeSelecionado.id}"));
                doc.Add(new Paragraph($"Disciplina: {testeSelecionado.disciplina}"));
                doc.Add(new Paragraph($"Matéria: {testeSelecionado.materia}"));
                doc.Add(new Paragraph("Questões:"));

                foreach (Questao questao in testeSelecionado.questoes)
                {
                    doc.Add(new Paragraph($"- {questao.titulo}"));
                }

                // Fechar o documento
                doc.Close();

                // Exibir uma mensagem de sucesso
                MessageBox.Show("PDF gerado com sucesso!");

                // Abrir o arquivo PDF após a geração
                System.Diagnostics.Process.Start(caminhoArquivo);
            }
        }


        //Process.Start(filename);

    }
}
