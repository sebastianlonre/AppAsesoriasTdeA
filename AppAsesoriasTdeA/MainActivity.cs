using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace AppAsesoriasTdeA
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText txtUserLogin;
        EditText txtUserPassword;
        Button btnLogin;
        Button btnRegister;
        Button btnForgetpassword;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            txtUserLogin = FindViewById<EditText>(Resource.Id.txtUserLogin);
            txtUserPassword = FindViewById<EditText>(Resource.Id.txtUserPassword);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnForgetpassword = FindViewById<Button>(Resource.Id.btnForgetpassword);

            btnLogin.Click += btnLogin_Click;
            btnRegister.Click += btnRegister_Click;
            btnForgetpassword.Click += btnForgetpassword_Click;
        }
        private void btnRegister_Click(object sender, System.EventArgs e)
        {
            try
            {
                Intent i = new Intent(this, typeof(register));
                StartActivity(i);
            }
            catch
            {

            }

        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtUserLogin.Text.Trim()) && !string.IsNullOrEmpty(txtUserPassword.Text.Trim()))
                {
                    Toast.MakeText(this, "Login realizado con exito", ToastLength.Short).Show();
                    Intent i = new Intent(this, typeof(home));
                    StartActivity(i);
                    Finish();
                }
                else
                {
                    Toast.MakeText(this, "Por favor ingrese un nombre de usuario y una clave", ToastLength.Long).Show();
                }
                
            }
            catch
            {

            }
        }

        private void btnForgetpassword_Click (object sender, System.EventArgs e)
        {
            try
            {
                Intent i = new Intent(this, typeof(Forgetpassword));
                StartActivity(i);
            }
            catch
            {

            }
        }
    }
}