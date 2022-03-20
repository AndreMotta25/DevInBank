using DevInBank.Entidades.EnumCategoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.Entidades.CategoriaContext
{
    public class Categoria
    {
        public Categoria(string nome, ECategoria tipoCategoria)
        {
            //Id = Guid.NewGuid();
            Nome = nome;
            TipoCategoria = tipoCategoria;
        }

        //private Guid Id { get; set; }
        public string Nome { get; private set; }
        public ECategoria TipoCategoria { get; private set; }

    }
}
