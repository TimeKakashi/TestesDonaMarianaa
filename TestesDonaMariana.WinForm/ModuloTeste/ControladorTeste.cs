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
using TestesDonaMariana.Dominio.ModuloQuestao;
using System.ComponentModel.DataAnnotations;
using TestesDonaMariana.WinForm.ModuloQuestao;

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

                MessageBox.Show("PDF do 'Teste' gerado com sucesso! \n'AppData - Local - Temp - teste.pdf'");
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

                if(testeSelecionado.materia.id == 0)
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

                MessageBox.Show("PDF do 'Gabarito' gerado com sucesso!\n'AppData - Local - Temp - gabarito.pdf'");
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
