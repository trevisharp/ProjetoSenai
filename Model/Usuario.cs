using System;
using System.Collections.Generic;

namespace ProjetoSenai.Model
{
    public partial class Usuario
    {
        public Usuario()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
