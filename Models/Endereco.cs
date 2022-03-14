using System;
using System.Collections.Generic;

namespace servicos_api.Models
{
    public partial class Endereco
    {
        public Endereco()
        {
            Clientes = new HashSet<Cliente>();
            Profissionals = new HashSet<Profissional>();
        }

        public int Id { get; set; }
        public string Rua { get; set; } = null!;
        public string Bairro { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Cep { get; set; } = null!;
        public string Complemento { get; set; } = null!;

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Profissional> Profissionals { get; set; }
    }
}
