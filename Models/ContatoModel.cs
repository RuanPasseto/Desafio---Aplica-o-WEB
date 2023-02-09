using System.ComponentModel.DataAnnotations;

namespace Desafio___Aplicação_WEB.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o E-mail do contato")]
        [EmailAddress(ErrorMessage = "O E-mail informado é invalido")]
        public string Email { get; set;}
        [Required(ErrorMessage = "Digite a data de nascimento do contato")]
        public string DataNascimento { get; set;}
        [Required(ErrorMessage = "Digite o RG do contato")]
        public string Rg { get; set;}
        [Required(ErrorMessage = "Digite o Endereço do contato")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Digite o Cep do contato")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Digite o Bairro do contato")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Digite a Cidade do contato")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Digite o CPF do contato")]
        public string Cpf { get; set;}
        [Required(ErrorMessage = "Digite o  telefone residencial do contato")]
        [Phone(ErrorMessage = "O numero de telefone não é valido")]
        public string TelefoneResidencial { get; set;}
        public string TelefoneComercial { get; set;}
        [Required(ErrorMessage = "Digite o celular do contato")]
        [Phone(ErrorMessage = "O numero de celular não é valido")]
        public string Celular { get; set;}
        public string Faceboo { get; set;}
        public string Instagram { get; set;}
        public string Twitter { get; set;}
        [Required(ErrorMessage = "Digite o LinkedIn do contato")]
        public string LinkedIn { get; set;}


    }
}
