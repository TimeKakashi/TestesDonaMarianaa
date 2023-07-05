﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.Compartilhado;

namespace TestesDonaMariana.Dominio.ModuloQuestao
{
    public class Alternativa : EntidadeBase<Alternativa>
    {
        public string alternativa { get; set; }

        public Alternativa(string nome)
        {
            this.alternativa = nome;
        }

        public Alternativa(string nome, int id)
        {
            this.alternativa = nome;
            this.id = id;
        }

        public override void AtualizarInformacoes(Alternativa registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override string[] Validar()
        {
            throw new NotImplementedException();
        }
    }
}
