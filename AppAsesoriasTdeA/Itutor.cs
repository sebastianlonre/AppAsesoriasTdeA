using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace AppAsesoriasTdeA
{
    [Activity(Label = "Itutor")]
    public class Itutor : Activity
    {
        Button btnGoo;
        EditText txtMyClass;
        EditText txtMyRazon;
        EditText txtClock;
        Toolbar toolbarmenu;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Itutor);
            btnGoo = FindViewById<Button>(Resource.Id.btnGoo);
            toolbarmenu = FindViewById<Toolbar>(Resource.Id.toolbarMenu);
            txtMyClass = FindViewById<EditText>(Resource.Id.txtMyClass);
            txtMyRazon = FindViewById<EditText>(Resource.Id.txtMyRazon);
            txtClock = FindViewById<EditText>(Resource.Id.txtClock);
            SetActionBar(toolbarmenu);
            ActionBar.Title = "Asesorias";
            btnGoo.Click += btnGoo_Click;

        }

        private void btnGoo_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, "Gracias por querer ser tutor, en los proximos diás nos contactaremos contigo", ToastLength.Short).Show();
            Intent i = new Intent(this, typeof(home));
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