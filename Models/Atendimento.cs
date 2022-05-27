using System;
using System.Collections.Generic;

namespace servicos_api.Models
{
    public partial class Atendimento
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = null!;
        public string DataHora { get; set; } = null!;
        public int IdCliente { get; set; }
        public int IdProfissional { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Profissional IdProfissionalNavigation { get; set; } = null!;
    }
}
