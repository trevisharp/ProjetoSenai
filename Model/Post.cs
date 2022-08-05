using System;
using System.Collections.Generic;

namespace ProjetoSenai.Model
{
    public partial class Post
    {
        public int Id { get; set; }
        public int? Publicante { get; set; }
        public string Conteudo { get; set; }
        public DateTime Momento { get; set; }

        public virtual Usuario PublicanteNavigation { get; set; }
    }
}
