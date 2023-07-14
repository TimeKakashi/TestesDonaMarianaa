using FluentResults;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;
using TestesDonaMariana.Aplicacao.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Dominio.ModuloTeste;
using TestesDonaMariana.WinForm.Compartilhado;
using TestesDonaMariana.WinForm.ModuloQuestao;
using Document = iTextSharp.text.Document;

namespace TestesDonaMariana.WinForm.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        private ListagemTesteControl listagemTeste;
        private IRepositorioTeste repositorioTeste;
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioMateria repositorioMateria;
        private IRepositorioQuestoes repositorioQuestoes;
        private ServicoTeste servicoTeste;

        public ControladorTeste(IRepositorioTeste repositorioTeste, IRepositorioDisciplina repositorioDisciplina,
            IRepositorioMateria repositorioMateria, IRepositorioQuestoes repositorioQuestoes, ServicoTeste servicoTeste)
        {
            this.repositorioTeste = repositorioTeste;
            this.repositorioMateria = repositorioMateria;
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioQuestoes = repositorioQuestoes;
            this.servicoTeste = servicoTeste;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            CarregarTestes();
        }

        public override string ToolTipInserir => "Cadastrar Teste";

        public override string ToolTipEditar => "Este botão está desabilitado nessa Tela";

        public override string ToolTipExcluir => "Excluir Teste";
        public override string ToolTipFiltrar => "VisualizarTeste Testes";

        public override string ToolTipPdf => "Gerar PDF";

        public override string ToolTipGabarito => "Gerar Gabarito";

        public override string ToolTipDuplicar => "Duplicar Teste";

        public override bool VisualizarHabilitado => true;

        public override bool GerarGabaritoHabilitado => true;

        public override bool GerarPdfHabilitado => true;

        public override bool EditarHabilitado => false;
        public override bool DuplicarHabilitado => true;



        public override void Inserir()
        {
            TelaTeste telaTeste = new TelaTeste(repositorioDisciplina, repositorioMateria, repositorioQuestoes, repositorioTeste);

            telaTeste.onGravarRegistro += servicoTeste.Inserir;

            DialogResult resultado = telaTeste.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTestes();
            }

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
                Result result = servicoTeste.Excluir(testeSelecionado);

                if (result.IsFailed)
                {
                    MessageBox.Show(result.Errors[0].Message, "Exclusão de Materia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

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

            teste.questoes = repositorioTeste.SelecionarQuestoesTeste(teste);

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
                TelaTeste telaDuplicar = new TelaTeste(repositorioDisciplina, repositorioMateria, repositorioQuestoes, repositorioTeste);
                telaDuplicar.Text = "Duplicar Teste";

                telaDuplicar.SetarTelaDuplicacao(testeSelecionado);

                DialogResult resultado = telaDuplicar.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    Teste testeDuplicado = telaDuplicar.ObterTeste();

                    repositorioTeste.Inserir(testeDuplicado, testeDuplicado.questoes);

                    CarregarTestes();
                }
            }
        }






        public override string ObterTipoCadastro() => "Cadastro de Testes";

        public override void VisualizarTeste()
        {
            Teste testeSelecionado = ObterTesteSelecionado();

            if (testeSelecionado == null)
            {
                MessageBox.Show($"Nenhum Teste Selecionado!", "Edição de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaVisualizarTeste telaVisualizarTeste = new TelaVisualizarTeste();

            telaVisualizarTeste.SetarValores(testeSelecionado);
            telaVisualizarTeste.ShowDialog();
        }

        public override void GerarPdf()
        {
            Teste testeSelecionado = ObterTesteSelecionado();

            if (testeSelecionado != null)
            {
                string diretorioTemporario = Path.GetTempPath();

                string caminhoArquivo = Path.Combine(diretorioTemporario, "teste.pdf");

                Document doc = new Document();

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));

                doc.Open();

                doc.Add(new Paragraph($"ID do Teste: {testeSelecionado.id}"));
                doc.Add(new Paragraph($"Disciplina: {testeSelecionado.disciplina.nome}"));
                doc.Add(new Paragraph($"Matéria: {testeSelecionado.materia.nome}"));
                doc.Add(new Paragraph("Questões: \n--------------------------------------------------------------------------------------"));

                string letra = string.Empty;

                foreach (Questao questao in testeSelecionado.questoes)
                {
                    int contadorAlternativa = 0;
                    doc.Add(new Paragraph($"Titulo: {questao.titulo} \n"));

                    foreach (Alternativa alternativa in repositorioQuestoes.SelecionarAlternativas(questao))
                    {

                        if (contadorAlternativa == 0)
                            letra = "A) ";
                        else if (contadorAlternativa == 1)
                            letra = "B) ";
                        else if (contadorAlternativa == 2)
                            letra = "C) ";
                        else if (contadorAlternativa == 3)
                            letra = "D) ";

                        contadorAlternativa++;

                        doc.Add(new Paragraph($"{letra} {alternativa.alternativa}"));
                    }
                    doc.Add(new Paragraph($"--------------------------------------------------------------------------------------"));
                }


                doc.Close();

                MessageBox.Show("PDF do 'Teste' gerado com sucesso! \n'AppData/Local/Temp/teste.pdf'");
            }
        }

        public override void GerarGabarito()
        {
            Teste testeSelecionado = ObterTesteSelecionado();

            if (testeSelecionado != null)
            {
                string diretorioTemporario = Path.GetTempPath();

                string caminhoArquivo = Path.Combine(diretorioTemporario, "gabarito.pdf");

                Document doc = new Document();

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));

                doc.Open();

                doc.Add(new Paragraph($"ID do Teste: {testeSelecionado.id}"));
                doc.Add(new Paragraph($"Disciplina: {testeSelecionado.disciplina.nome}"));

                if (testeSelecionado.materia.id == 0)
                    doc.Add(new Paragraph($"Prova de Recuperação"));
                else
                    doc.Add(new Paragraph($"Matéria: {testeSelecionado.materia.nome}"));

                doc.Add(new Paragraph("Questões: \n--------------------------------------------------------------------------------------"));

                string letra = string.Empty;

                foreach (Questao questao in testeSelecionado.questoes)
                {
                    int contadorAlternativa = 0;
                    doc.Add(new Paragraph($"Titulo: {questao.titulo} \n"));

                    foreach (Alternativa alternativa in repositorioQuestoes.SelecionarAlternativas(questao))
                    {
                        VerificarLetra(ref letra, questao, contadorAlternativa);

                        contadorAlternativa++;

                        doc.Add(new Paragraph($"{letra} {alternativa.alternativa}"));
                    }
                    doc.Add(new Paragraph($"--------------------------------------------------------------------------------------"));
                }


                doc.Close();

                MessageBox.Show("PDF do 'Gabarito' gerado com sucesso!\n'AppData/Local/Temp/teste.pdf'");
            }
        }

        private static void VerificarLetra(ref string letra, Questao questao, int contadorAlternativa)
        {
            if (contadorAlternativa == 0)
            {
                letra = "A) ";
                if (questao.alternativaCorretaENUM == EnumAlternativaCorreta.AlternativaA)
                    letra = "X ";
            }
            else if (contadorAlternativa == 1)
            {
                letra = "B) ";
                if (questao.alternativaCorretaENUM == EnumAlternativaCorreta.AlternativaB)
                    letra = "X ";
            }
            else if (contadorAlternativa == 2)
            {
                letra = "C) ";
                if (questao.alternativaCorretaENUM == EnumAlternativaCorreta.AlternativaC)
                    letra = "X ";


            }
            else if (contadorAlternativa == 3)
            {
                letra = "D) ";
                if (questao.alternativaCorretaENUM == EnumAlternativaCorreta.AlternativaD)
                    letra = "X ";
            }
        }
    }
}
