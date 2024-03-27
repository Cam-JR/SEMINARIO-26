using AppSQL.Data;
using AppSQL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSQL.Listados.CRUD
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CRUD_pedidos : ContentPage
	{
        public Pedidos Pedidos;
        public CRUD_pedidos ()
		{
			InitializeComponent ();
            Pedidos = new Pedidos();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = this.Pedidos;
        }
    }
}