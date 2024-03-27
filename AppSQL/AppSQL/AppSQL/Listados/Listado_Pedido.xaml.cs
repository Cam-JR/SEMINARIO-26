using AppSQL.Data;
using AppSQL.Listados.CRUD;
using AppSQL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSQL.Listados
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Listado_Pedido : ContentPage
	{
		public Listado_Pedido ()
		{
			InitializeComponent ();

		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvPedido.ItemsSource = ClsPedido.GetPedidos();
            totales.Text = ClsPedido.GetTotal().ToString();
        }


        private void lvPedido_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                NavegarPedidos(e.SelectedItem as Pedidos);
        }


        private void btnNuevo_Clicked(object sender, EventArgs e)
        {
            NavegarPedidos(new Pedidos());
        }

        void NavegarPedidos(Pedidos pedidos)
        {
            CRUD_pedidos pagina = new CRUD_pedidos();
            pagina.Pedidos = pedidos;
            Navigation.PushAsync(pagina);
        }
    }
}