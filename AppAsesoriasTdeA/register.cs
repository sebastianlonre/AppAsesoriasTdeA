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
    [Activity(Label = "Register")]
   public class register : Activity
    {

        EditText txtUserRegister;
        EditText txtUserEmail;
        EditText txtUserPassReg;
        EditText txtUserPassReConf;
        Button btnRegisterNew;
        Button btnBackLogin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.register);

            txtUserRegister = FindViewById<EditText>(Resource.Id.txtUserRegister);
            txtUserEmail = FindViewById<EditText>(Resource.Id.txtUserEmail);
            txtUserPassReg = FindViewById<EditText>(Resource.Id.txtUserPassReg);
            txtUserPassReConf = FindViewById<EditText>(Resource.Id.txtUserPassReConf);
            btnRegisterNew = FindViewById<Button>(Resource.Id.btnRegisterNew);
            btnBackLogin = FindViewById<Button>(Resource.Id.btnBackLogin);

            btnRegisterNew.Click += btnRegisterNew_Click;
            btnBackLogin.Click += btnBackLogin_Click;
        }

        private void btnRegisterNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtUserRegister.Text.Trim()) && !string.IsNullOrEmpty(txtUserEmail.Text.Trim()) && !string.IsNullOrEmpty(txtUserPassReg.Text.Trim()) && !string.IsNullOrEmpty(txtUserPassReConf.Text.Trim()))
                {
                    if (txtUserPassReg.Text.Equals(txtUserPassReConf.Text))
                    {
                        Toast.MakeText(this, "Registro realizado con éxito", ToastLength.Short).Show();
                        Intent i = new Intent(this, typeof(MainActivity));
                        StartActivity(i);
                    }
                    else
                    {
                        Toast.MakeText(this, "Las contraseñas no coinciden", ToastLength.Long).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, "Rellene todos los campos", ToastLength.Long).Show();
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