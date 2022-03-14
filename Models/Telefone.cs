using System;
using System.Collections.Generic;

namespace servicos_api.Models
{
    public partial class Telefone
    {
        public int Id { get; set; }
        public string Numero { get; set; } = null!;
        public int IdProfissional { get; set; }
        public int IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Profissional IdProfissionalNavigation { get; set; } = null!;
    }
}
