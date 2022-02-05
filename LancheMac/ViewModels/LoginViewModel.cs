using System.ComponentModel.DataAnnotations;

namespace LancheMac.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="O campo usuário é obrigatório")]
        [Display(Name ="Usuário")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage ="Passaword é obrigatório")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public string ReturnUrl { get; set; }
    }
}
