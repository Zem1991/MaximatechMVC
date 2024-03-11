using System.ComponentModel;

namespace MVC.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        [DisplayName("Código")]
        public string Codigo { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
