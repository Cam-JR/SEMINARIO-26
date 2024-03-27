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
    public partial class CRUD_vendedores : ContentPage
    {
        public Vendedor vendedor;
        public List<Distrito> oListaDistrito { get; set; }
        public CRUD_vendedores()
        {
            InitializeComponent();
        }
        //En OnAppearing se puede agregar el código que deseas ejecutar cuando la página se muestra
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = this.vendedor;
            cargarDistritos();
           
        }
        private void cargarDistritos()
        {
            oListaDistrito = ClsDistrito.GetDistritos();

            //pk.ItemsSource=oListaDistrito;
            foreach ( Distrito item in oListaDistrito)
            {
                pk.Items.Add(item.nom);
            }
            pk.SelectedIndex = vendedor.id_dis - 1;
        }

            
        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (vendedor.id != 0)
            {
                ClsVendedor.EliminarVendedor(vendedor);
                Navigation.PopAsync();
            }
        }

        private void btnGrabar_Clicked(object sender, EventArgs e)
        {
            if (vendedor.id == 0)
                ClsVendedor.AgregarVendedor(vendedor);
            else
                ClsVendedor.ModificarVendedor(vendedor);

            Navigation.PopAsync();
        }

        private void pk_SelectedIndexChanged(object sender, EventArgs e)
        {
            vendedor.id_dis = pk.SelectedIndex +1 ;
        }
    }
}