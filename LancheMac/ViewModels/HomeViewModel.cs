using LancheMac.Models;
using System.Collections.Generic;

namespace LancheMac.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }
    }
}
