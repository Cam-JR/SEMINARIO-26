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
    public partial class Listado_Vendedores : ContentPage
    {
        public Listado_Vendedores()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvVendedores.ItemsSource = ClsVendedor.GetVendedor();
            
        }
        private void lvVendedores_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                NavegarVendedores(e.SelectedItem as Vendedor);
        }
        void NavegarVendedores(Vendedor vendedor)
        {
            CRUD_vendedores pagina = new CRUD_vendedores();
            pagina.vendedor = vendedor;
            
            Navigation.PushAsync(pagina);
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            NavegarVendedores(new Vendedor());
        }
    }
}