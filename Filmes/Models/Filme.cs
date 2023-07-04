using System.ComponentModel.DataAnnotations;

namespace Filmes.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Duração é obrigatório.")]
        [RegularExpression(@"\d{1,2}h\s\d{1,2}m", ErrorMessage = "O formato da duração deve ser horas e minutos (ex: 2h 30m).")]
        public string Duracao { get; set; }

        [Required(ErrorMessage = "O campo Diretor é obrigatório.")]
        public string Diretor { get; set; }

        [Required(ErrorMessage = "O campo Gênero é obrigatório.")]
        public string Genero { get; set; }

        public Filme()
        {
        }

        public Filme(int id, string nome, string duracao, string diretor, string genero)
        {
            Id = id;
            Nome = nome;
            Duracao = duracao;
            Diretor = diretor;
            Genero = genero;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Duração: {Duracao}, Diretor: {Diretor}, Gênero: {Genero}";
        }
    }
}
