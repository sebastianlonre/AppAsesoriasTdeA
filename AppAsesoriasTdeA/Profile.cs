using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AppAsesoriasTdeA.database;

namespace AppAsesoriasTdeA
{
    [Activity(Label = "profile")]
    public class Profile : Activity
    {
        Button btnEdit;
        EditText txtViewName;
        EditText txtViewPassword;
        EditText txtViewEmail;
        Toolbar toolbarmenu;
        CRUD crud = new CRUD();
        private insTable userConsult;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.profile);

            btnEdit = FindViewById<Button>(Resource.Id.btnEdit);
            toolbarmenu = FindViewById<Toolbar>(Resource.Id.toolbarMenu);
            txtViewName = FindViewById<EditText>(Resource.Id.txtViewName);
            txtViewPassword = FindViewById<EditText>(Resource.Id.txtViewPassword);
            txtViewEmail = FindViewById<EditText>(Resource.Id.txtViewEmail);
            SetActionBar(toolbarmenu);
            ActionBar.Title = "Asesorias";
            btnEdit.Click += btnEdit_Click;

            //traer datos de la bd

            userConsult = crud.SelectOneById(MainActivity.Globalid);
            txtViewName.Text = userConsult.USERNAME;
            txtViewEmail.Text = userConsult.EMAIL;
            txtViewPassword.Text= userConsult.PASSWORD;
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {

            try
            {
                crud.Update(new insTable() { ID = MainActivity.Globalid, USERNAME = txtViewName.Text.Trim(), EMAIL = txtViewEmail.Text.Trim(), PASSWORD = txtViewPassword.Text.Trim() });
                Intent b = new Intent(this, typeof(Profile));
                Toast.MakeText(this, "Registro modificado con exito ", ToastLength.Short).Show();
                StartActivity(b);
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