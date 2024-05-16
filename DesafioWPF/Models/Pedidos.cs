using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioWPF.Models
{
	[Table("Pedidos")]
	public class Pedidos
	{
		[Key]
		public int CodigoPedidos { get; set; }
		public string Descricao { get; set; } = string.Empty;
		public int Valor { get; set; }
	}
}
