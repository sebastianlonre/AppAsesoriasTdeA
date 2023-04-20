﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
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
                case Resource.Id.menu_item_option1:
                    Intent a = new Intent(this, typeof(home));
                    StartActivity(a);
                    break;
                case Resource.Id.menu_item_option2:
                    Intent b = new Intent(this, typeof(ViewUser));
                    StartActivity(b);
                    break;
                case Resource.Id.menu_item_option3:
                    Intent c = new Intent(this, typeof(Profile));
                    StartActivity(c);
                    break;
                case Resource.Id.menu_item_option4:
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
