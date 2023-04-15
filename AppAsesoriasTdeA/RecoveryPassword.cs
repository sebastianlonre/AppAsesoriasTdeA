using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace AppAsesoriasTdeA
{
    [Activity(Label = "RecoveryPassword")]
    public class RecoveryPassword : Activity
    {
        Button btnBackLogin;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RecoveryPassword);
            btnBackLogin = FindViewById<Button>(Resource.Id.btnBackLogin);

            btnBackLogin.Click += btnBackLogin_Click;
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