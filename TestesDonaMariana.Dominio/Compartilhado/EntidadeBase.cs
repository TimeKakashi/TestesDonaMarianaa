namespace TestesDonaMariana.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        public int id;

        public abstract void AtualizarInformacoes(T registroAtualizado);

        public abstract string[] Validar();
    }
}
