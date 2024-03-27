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
	public partial class CRUD_productos : ContentPage
	{

        // public Producto Producto;
        public Producto Producto;

        public CRUD_productos()
        {
            InitializeComponent();

            // Inicializar el objeto Producto
            Producto = new Producto();

            // Obtener tipos de café desde la base de datos
            List<Tipos> tiposCafe = ClsTipos.GetTipos();
            foreach (Tipos tipos in tiposCafe)
            {
                pk_tipocafe.Items.Add(tipos.nom);
                Producto.id_tipo = tipos.id;
            }

            // Obtener lista de productores desde la base de datos
            List<Productor> listaProductor = ClsProductor.GetProductores(); // Especifica el espacio de nombres completo aquí
            // Aquí también necesitarás especificar el espacio de nombres completo al referirte a la clase Productor
            foreach (Productor productor in listaProductor)
            {
                pk_productor.Items.Add(productor.nom_productor);
                Producto.id_productor = productor.id_productor;
            }

            // PICKER ESTADO
            pk_estado.Items.Add("Activo");
            pk_estado.Items.Add("Desactivado");
            pk_estado.SelectedItem = "Activo";
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = this.Producto;
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (Producto.id == 0)
                ClsProductos.AgregarProducto(Producto);
            else
                ClsProductos.ModificarProducto(Producto);

            Navigation.PopAsync();
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (Producto.id != 0)
            {
                ClsProductos.EliminarProducto(Producto);
                Navigation.PopAsync();
            }
        }
    }
}