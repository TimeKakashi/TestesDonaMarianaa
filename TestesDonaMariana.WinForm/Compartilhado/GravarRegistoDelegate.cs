using FluentResults;
using TestesDonaMariana.Dominio.Compartilhado;

namespace TestesDonaMariana.WinForm.Compartilhado
{
    public delegate Result GravarRegistroDelegate<T>(T questao) where T : EntidadeBase<T>;

}
