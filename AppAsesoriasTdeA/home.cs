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
using Toolbar = Android.Widget.Toolbar;

namespace AppAsesoriasTdeA
{
    [Activity(Label = "home")]
    public class home : Activity
    {
        Button btnViewElement;
        Toolbar toolbarmenu;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.home);
            btnViewElement = FindViewById<Button>(Resource.Id.btnViewElement);
            toolbarmenu = FindViewById<Toolbar>(Resource.Id.toolbarMenu);
            SetActionBar(toolbarmenu);
            ActionBar.Title = "Asesorias";
            btnViewElement.Click += btnViewElement_Click;
        }

        private void btnViewElement_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(view));
            StartActivity(i);
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
