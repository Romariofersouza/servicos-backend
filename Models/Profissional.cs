using System;
using System.Collections.Generic;

namespace servicos_api.Models
{
    public partial class Profissional
    {
        public Profissional()
        {
            Atendimentos = new HashSet<Atendimento>();
            Telefones = new HashSet<Telefone>();
        }

        public int Id { get; set; }
        public string Cpf { get; set; } = null!;
        public string? Cnpj { get; set; }
        public string Nome { get; set; } = null!;
        public int IdEndereco { get; set; }
        public string Senha { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual Endereco IdEnderecoNavigation { get; set; } = null!;
        public virtual ICollection<Atendimento> Atendimentos { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
