using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppAsesoriasTdeA.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppAsesoriasTdeA
{
    [Activity(Label = "ViewUser")]
    public class ViewUser : Activity
    {
        Toolbar toolbarmenu;
        CRUD crud = new CRUD();
        ListView listView;
        List<insTable> userList;
        ArrayAdapter<string> adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ViewUser);
            toolbarmenu = FindViewById<Toolbar>(Resource.Id.toolbarMenu);
            SetActionBar(toolbarmenu);
            ActionBar.Title = "Asesorias";

            userList = crud.SelectAll().ToList();

            List<string> userStrings = new List<string>();
            foreach (var user in userList)
            {
                string userString = string.Format("Correo: {0}\nUsuario: {1}\nContraseña: {2}", user.EMAIL, user.USERNAME, user.PASSWORD);
                userStrings.Add(userString);
            }

            listView = FindViewById<ListView>(Resource.Id.listView);
            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, userStrings);
            listView.Adapter = adapter;
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
                case Resource.Id.menu_item_option1:
                    Intent a = new Intent(this, typeof(home));
                    StartActivity(a);
                    break;
                case Resource.Id.menu_item_option2:
                    Intent b = new Intent(this, typeof(ViewUser));
                    StartActivity(b);
                    break;
                case Resource.Id.menu_item_option3:
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
