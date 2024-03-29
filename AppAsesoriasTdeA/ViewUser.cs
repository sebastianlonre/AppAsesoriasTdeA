﻿using Android.App;
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
        //lista usuarios
        ListView listView;
        List<insTable> userList;
        ArrayAdapter<string> adapter;
        List<string> userStrings = new List<string>();
        //lista tutorias
        ListView listView2;
        List<Tutor> tutorList;
        ArrayAdapter<string> adapter2;
        List<string> tutorStrings = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ViewUser);
            toolbarmenu = FindViewById<Toolbar>(Resource.Id.toolbarMenu);
            SetActionBar(toolbarmenu);
            ActionBar.Title = "Asesorias";

            //lista usuario
            
            userList = crud.SelectAll().ToList();

            foreach (var user in userList)
            {
                string userString = string.Format("Usuario: {0}\nCorreo: {1}\nContraseña: {2}", user.USERNAME,user.EMAIL , user.PASSWORD);
                userStrings.Add(userString);
            }

            listView = FindViewById<ListView>(Resource.Id.listView);
            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemActivated1, userStrings);
            listView.Adapter = adapter;

            //lista tutor

            tutorList = crud.SelectTutor().ToList();

            foreach (var moni in tutorList)
            {
                string tutorString = string.Format("Usuario: {0}\nCorreo: {1}\nContraseña: {2}\nId tutor: {3}", moni.className, moni.classDescription, moni.classClock, moni.InsTableId);
                tutorStrings.Add(tutorString);
            }

            listView2 = FindViewById<ListView>(Resource.Id.listView2);
            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemActivated1, tutorStrings);
            listView2.Adapter = adapter;

            //click tutor

            //click tutor
            listView2.ItemClick += (sender, e) =>
            {

                var selectedTutor = tutorList[e.Position];

                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Tutor seleccionado");
                alert.SetMessage(string.Format("Nombre: {0}\nDescripción: {1}\nHorario: {2}\nId tutor: {3}", selectedTutor.className, selectedTutor.classDescription, selectedTutor.classClock, selectedTutor.InsTableId));
                alert.SetPositiveButton("OK", (dialog, which) => { });

                //Modificar
                alert.SetNeutralButton("Modificar", (dialog, which) =>
                {
                    //crear alert
                    AlertDialog.Builder alert3 = new AlertDialog.Builder(this);
                    alert3.SetTitle("Modificar");
                    //referenciar el layout
                    LayoutInflater inflater = LayoutInflater.From(this);
                    View view = inflater.Inflate(Resource.Layout.Update, null);

                    //mapeo
                    EditText editText1 = view.FindViewById<EditText>(Resource.Id.updUser);
                    EditText editText2 = view.FindViewById<EditText>(Resource.Id.updEmail);
                    EditText editText3 = view.FindViewById<EditText>(Resource.Id.updPassword);

                    editText1.Text = selectedTutor.className;
                    editText2.Text = selectedTutor.classDescription;
                    editText3.Text = selectedTutor.classClock;

                    alert3.SetPositiveButton("Modificar", (dialog, which) =>
                    {
                        if (!string.IsNullOrEmpty(editText1.Text.Trim()) && !string.IsNullOrEmpty(editText2.Text.Trim()) && !string.IsNullOrEmpty(editText3.Text.Trim()))
                        {
                            new CRUD().UpdateTutor(new Tutor() { IDTutor = selectedTutor.IDTutor, className = editText1.Text.Trim(), classDescription = editText2.Text.Trim(), classClock = editText3.Text.Trim(), InsTableId = selectedTutor.InsTableId });
                            Intent b = new Intent(this, typeof(ViewUser));
                            Toast.MakeText(this, "Registro modificado con exito ", ToastLength.Short).Show();
                            StartActivity(b);
                        }
                        else
                        {
                            Toast.MakeText(this, "Rellene todos los campos", ToastLength.Long).Show();
                        }

                    });

                    alert3.SetNegativeButton("Cancel", (dialog, which) =>
                    {
                        Intent b = new Intent(this, typeof(ViewUser));
                        StartActivity(b);
                    });

                    alert3.SetView(view);
                    alert3.Show();
                });

                //Eliminar registro
                alert.SetNegativeButton("Eliminar", (dialog, which) =>
                {

                    AlertDialog.Builder alert2 = new AlertDialog.Builder(this);
                    alert2.SetTitle("Eliminar registro");
                    alert2.SetMessage(string.Format("¿Seguro quieres eliminar el registro?"));
                    alert2.SetPositiveButton("Si", (dialog, which) =>
                    {

                        crud.DeleteTutor(selectedTutor);
                        Intent b = new Intent(this, typeof(ViewUser));
                        Toast.MakeText(this, "Registro eliminado con exito", ToastLength.Short).Show();
                        StartActivity(b);

                    });
                    alert2.SetNegativeButton("Cancel", (dialog, which) =>
                    {

                        Intent b = new Intent(this, typeof(ViewUser));
                        StartActivity(b);

                    });
                    alert2.Show();


                });
                alert.Show();
            };



            //click user
            listView.ItemClick += (sender, e) =>
            {

                var selectedUser = userList[e.Position];

                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Usuario seleccionado");
                alert.SetMessage(string.Format("Correo: {0}\nUsuario: {1}\nContraseña: {2}", selectedUser.EMAIL, selectedUser.USERNAME, selectedUser.PASSWORD));
                alert.SetPositiveButton("OK", (dialog, which) => { });

                //Modificar
                alert.SetNeutralButton("Modificar", (dialog, which) => {
                    //crear alert
                    AlertDialog.Builder alert3 = new AlertDialog.Builder(this);
                    alert3.SetTitle("Modificar");
                    //referenciar el layout
                    LayoutInflater inflater = LayoutInflater.From(this);
                    View view = inflater.Inflate(Resource.Layout.Update, null);

                    //mapeo
                    EditText editText1 = view.FindViewById<EditText>(Resource.Id.updUser); 
                    EditText editText2 = view.FindViewById<EditText>(Resource.Id.updEmail);
                    EditText editText3 = view.FindViewById<EditText>(Resource.Id.updPassword);

                    //importante no pasar la posicion sino obtener el ID
                    var selectedUser = userList[e.Position];

                    editText1.Text= selectedUser.USERNAME;
                    editText2.Text= selectedUser.EMAIL;
                    editText3.Text= selectedUser.PASSWORD;

                    alert3.SetPositiveButton("Modificar", (dialog, which) => {
                        if (!string.IsNullOrEmpty(editText1.Text.Trim()) && !string.IsNullOrEmpty(editText2.Text.Trim()) && !string.IsNullOrEmpty(editText3.Text.Trim()))
                        {
                            new CRUD().Update(new insTable() { ID = selectedUser.ID, USERNAME = editText1.Text.Trim(), EMAIL = editText2.Text.Trim(), PASSWORD = editText3.Text.Trim() });
                            Intent b = new Intent(this, typeof(ViewUser));
                            Toast.MakeText(this, "Registro modificado con exito ", ToastLength.Short).Show();
                            StartActivity(b);
                        }
                        else
                        {
                            Toast.MakeText(this, "Rellene todos los campos", ToastLength.Long).Show();
                        }
                        
                    });

                    alert3.SetNegativeButton("Cancel", (dialog, which) => {
                        Intent b = new Intent(this, typeof(ViewUser));
                        StartActivity(b);
                    });

                    alert3.SetView(view);
                    alert3.Show();
                });

                //Eliminar registro
                alert.SetNegativeButton("Eliminar", (dialog, which) => {

                    AlertDialog.Builder alert2 = new AlertDialog.Builder(this);
                    alert2.SetTitle("Eliminar registro");
                    alert2.SetMessage(string.Format("¿Seguro quieres eliminar el registro?"));
                    alert2.SetPositiveButton("Si", (dialog, which) => {

                        crud.Delete(selectedUser);
                        Intent b = new Intent(this, typeof(ViewUser));
                        Toast.MakeText(this, "Registro eliminado con exito", ToastLength.Short).Show();
                        StartActivity(b);

                    });
                    alert2.SetNegativeButton("Cancel", (dialog, which) => {

                        Intent b = new Intent(this, typeof(ViewUser));
                        StartActivity(b);

                    });
                    alert2.Show();


                });
                alert.Show();
            };
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
