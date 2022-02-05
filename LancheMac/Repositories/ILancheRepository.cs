using LancheMac.Models;
using System.Collections.Generic;

namespace LancheMac.Repositories
{
    public  interface ILancheRepository
    {
         IEnumerable<Lanche> Lanches { get; }
         IEnumerable<Lanche> LanchesPreferidos { get; }
        Lanche GetLancheById(int lancheId);
    }
}
