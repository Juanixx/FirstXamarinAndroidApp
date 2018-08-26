using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;
using Newtonsoft.Json;

namespace Xamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public List<string[]> miProducto = new List<string[]>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var btnAgregar = FindViewById<Button>(Resource.Id.btnAgregar);

            btnAgregar.Click += BtnAgregar_Click;
        }

        private void BtnAgregar_Click(object sender, System.EventArgs e)
        {
            var producto = FindViewById<EditText>(Resource.Id.editTextProducto);
            var cantidad = FindViewById<EditText>(Resource.Id.editTextCantidad);

            string[] data = new string[] { producto.Text, cantidad.Text };

            miProducto.Add(data);
            producto.Text = "";
            cantidad.Text = "";

            var intent = new Intent(this, typeof(ListaProductosActivity));
            intent.PutExtra("data", JsonConvert.SerializeObject(miProducto));

            StartActivity(intent);
        }
    }
}