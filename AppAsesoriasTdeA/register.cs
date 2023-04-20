using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AppAsesoriasTdeA.database;
using System;
using System.Threading.Tasks;

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

        private async void btnRegisterNew_Click(object sender, EventArgs e)
        {

            try
            {
                if (!string.IsNullOrEmpty(txtUserRegister.Text.Trim()) && !string.IsNullOrEmpty(txtUserEmail.Text.Trim()) && !string.IsNullOrEmpty(txtUserPassReg.Text.Trim()) && !string.IsNullOrEmpty(txtUserPassReConf.Text.Trim()))
                {


                    if (txtUserPassReg.Text.Equals(txtUserPassReConf.Text))
                    {
                        new CRUD().save(new insTable() { ID = 0, USERNAME = txtUserRegister.Text.Trim(), EMAIL = txtUserEmail.Text.Trim(), PASSWORD = txtUserPassReConf.Text.Trim() });

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
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
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