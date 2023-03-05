using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;

namespace AppAsesoriasTdeA
{
    [Activity(Label = "Forgetpassword")]
    public class Forgetpassword : Activity
    {
        EditText txtRecoveryEmail;
        Button btnSendRecoveryEmail;
        Button btnBackLogin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ForgetPassword);

            txtRecoveryEmail = FindViewById<EditText>(Resource.Id.txtRecoveryEmail);
            btnSendRecoveryEmail = FindViewById<Button>(Resource.Id.btnSendRecoveryEmail);
            btnBackLogin = FindViewById<Button>(Resource.Id.btnBackLogin);

            btnSendRecoveryEmail.Click += btnSendRecoveryEmail_Click;
            btnBackLogin.Click += btnBackLogin_Click;

        }

        private void btnSendRecoveryEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRecoveryEmail.Text.Trim()))
                {
                    Intent i = new Intent(this, typeof(RecoveryPassword));
                    StartActivity(i);
                }
                else
                {
                    Toast.MakeText(this, "Por favor ingrese su correo electrónico", ToastLength.Long).Show();
                }
            }
            catch
            {
            }
        }

        private void btnBackLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            }
            catch
            {
            }
        }
    }
}
