using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AppAsesoriasTdeA.database;
using System;

namespace AppAsesoriasTdeA
{
    [Activity(Label = "newRoom")]
    public class newRoom : Activity
    {
        Button btnBestRoom;
        EditText txtnewRoom;
        EditText txtDescriptionRoom;
        EditText txtRoomClock;
        Toolbar toolbarmenu;
        CRUD crud = new CRUD();
        private Tutor newClase;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.newRoom);

            btnBestRoom = FindViewById<Button>(Resource.Id.btnBestRoom);
            toolbarmenu = FindViewById<Toolbar>(Resource.Id.toolbarMenu);
            txtnewRoom = FindViewById<EditText>(Resource.Id.txtnewRoom);
            txtDescriptionRoom = FindViewById<EditText>(Resource.Id.txtDescriptionRoom);
            txtRoomClock = FindViewById<EditText>(Resource.Id.txtRoomClock);
            SetActionBar(toolbarmenu);
            ActionBar.Title = "Asesorias";

            btnBestRoom.Click += btnBestRoom_Click;
        }

        private void btnBestRoom_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtnewRoom.Text.Trim()) && !string.IsNullOrEmpty(txtDescriptionRoom.Text.Trim()) && !string.IsNullOrEmpty(txtRoomClock.Text.Trim()))
                {

                    new CRUD().saveTutor(new Tutor() { IDTutor = 0, className = txtnewRoom.Text.Trim(), classDescription = txtDescriptionRoom.Text.Trim(), classClock = txtRoomClock.Text.Trim() , InsTableId = MainActivity.Globalid });

                    Toast.MakeText(this, "Clase creada con exito, cuando sea verificada nos comunicaremos", ToastLength.Short).Show();

                    Intent i = new Intent(this, typeof(Profile));
                    StartActivity(i);
                }
                else
                {
                    Toast.MakeText(this, "Rellene todos los campos", ToastLength.Long).Show();
                }


            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
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
                    Intent d = new Intent(this, typeof(newRoom));
                    StartActivity(d);
                    break;
                case Resource.Id.menu_item_option5:
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