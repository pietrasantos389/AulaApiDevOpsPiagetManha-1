namespace AulaApiDevOpsManhaPiaget.Models
{
    public class Servicos : Base
    {
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public Categoria? Categorias { get; set; }
    }
}
