using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppAsesoriasTdeA
{
    [Activity(Label = "view")]
    public class view : Activity
    {
        Button btnGo;
        Button btnBack;
        Toolbar toolbarmenu;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.view);
            btnGo = FindViewById<Button>(Resource.Id.btnGo);
            btnBack = FindViewById<Button>(Resource.Id.btnBack);
            toolbarmenu = FindViewById<Toolbar>(Resource.Id.toolbarMenu);
            SetActionBar(toolbarmenu);
            ActionBar.Title = "Asesorias";

            btnGo.Click += btnGo_click;
            btnBack.Click += btnBack_Click;

        }

        private void btnGo_click(object sender, System.EventArgs e)
        {
            try
            {
                Toast.MakeText(this, "En proximas actualizaciones", ToastLength.Long).Show();
                Intent i = new Intent(this, typeof(home));
                StartActivity(i);
            }
            catch
            {

            }

        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            try
            {
                Intent i = new Intent(this, typeof(home));
                StartActivity(i);
            }
            catch
            {

            }

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.icAdd:
                    Intent i = new Intent(this, typeof(MainActivity));
                    StartActivity(i);
                    break;
                default:
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}