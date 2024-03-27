using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppSQL
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnTipos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Listados.Listado_Tipos());
        }

        private async void btnVendedores_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Listados.Listado_Vendedores());
        }

        private async void btnProductos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Listados.Listado_Productos());
        }

        private async void btnPedidos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Listados.Listado_Pedido());
        }

    }
}
