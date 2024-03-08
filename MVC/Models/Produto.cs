namespace MVC.Models
{
    public class Produto
    {
        /// <summary>
        /// ID - Identificador do Produto - UUID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Código - Código apresentável ao usuário - Texto
        /// </summary>
        public string Codigo { get; set; }


        /// <summary>
        /// Descrição - Descrição do Produto - Texto
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Departamento - Lista de departamentos - Caixa de Seleção (Será consumido via GET da api criada)
        /// </summary>
        public Departamento Departamento { get; set; }

        /// <summary>
        /// Preço - Preço do Produto - Decimal
        /// </summary>
        public decimal Preco { get; set; }

        /// <summary>
        /// Status - Ativo / Inativo - True/False - Booleano
        /// </summary>
        public bool Status { get; set; }

        //public dynamic Editar { get; set; }
        //public dynamic Excluir { get; set; }
    }
}
