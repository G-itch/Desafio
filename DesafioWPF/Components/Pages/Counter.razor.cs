using Bogus;
using MudBlazor;
using DesafioWPF.Models;
namespace DesafioWPF.Components.Pages
{
	public partial class Counter
	{
		private string? _value1;
		private int currentCount = 0;
		private int pedidosCount = 0;
		private void IncrementCount()
		{
			currentCount++;
			DB.Pedidos.Add(new Pedidos
			{
				CodigoPedidos = (DB.Pedidos.Max(p => (int?)p.CodigoPedidos) ?? 0) + 1,
				Descricao = "teste",
				Valor = 10122
			});
			DB.SaveChanges();
		}

		private void Faker()
		{
			currentCount++;
			DB.Pedidos.RemoveRange(DB.Pedidos);
			DB.SaveChanges();
			var PedidosFaker = new Faker<Pedidos>()
				.RuleFor(p => p.CodigoPedidos, f => f.IndexFaker + (DB.Pedidos.Max(p => (int?)p.CodigoPedidos) ?? 0) + 1)
				.RuleFor(p => p.Descricao, f => f.Commerce.Product())
				.RuleFor(p => p.Valor, f => int.Parse(f.Commerce.Price(1, 1000, 0, "")));
			var pedidoslist = PedidosFaker.Generate(100);
			DB.Pedidos.AddRange(pedidoslist);
			DB.SaveChanges();
		}
		protected override async Task OnInitializedAsync()
		{
			Faker();
		}

		private void GetPedidos()
		{
			pedidosCount = DB.Pedidos.ToList().Count();
		}
		private List<BreadcrumbItem> _items = new List<BreadcrumbItem>
	{
		new BreadcrumbItem("Pedidos", href: "/Counter", icon: Icons.Material.Filled.ShoppingBag),
		new BreadcrumbItem("Items", href: "/Counter", icon: Icons.Material.Filled.Inventory),
	};
	}
}