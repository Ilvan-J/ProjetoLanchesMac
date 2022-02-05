using LancheMac.Models;
using System.Collections.Generic;

namespace LancheMac.Repositories
{
   public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
