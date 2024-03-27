using AppSQL.Data;
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
	public partial class Listado_Productos : ContentPage
	{
		public Listado_Productos ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvProductos.ItemsSource = ClsProductos.GetProductos();
        }
        private void lvProductos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                NavegarProductos(e.SelectedItem as Producto);
        }

        //BOTON NUEVO 
        private void btnNuevo_Clicked(object sender, EventArgs e)
        {
            NavegarProductos(new Producto());
        }

        void NavegarProductos(Producto producto)
        {
            CRUD_productos pagina = new CRUD_productos();
            pagina.Producto = producto;
            Navigation.PushAsync(pagina);
        }
    }
}