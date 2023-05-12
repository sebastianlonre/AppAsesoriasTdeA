using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using AndroidX.ViewPager.Widget;
using AppAsesoriasTdeA.database;
using System;
using System.Collections.Generic;
using System.Linq;
using Toolbar = Android.Widget.Toolbar;

namespace AppAsesoriasTdeA
{
    [Activity(Label = "home")]
    public class home : Activity
    {
        Button btnViewElement;
        Toolbar toolbarmenu;
        //declaraciones para la lista
        ListView listClass;
        List<Tutor> classList;
        ArrayAdapter<string> adapter;
        List<string> superlist = new List<string>();
        ViewPager viewPager;
        TextView textTittle;
        TextView textDescrip;
        TextView textClock;

        CRUD crud = new CRUD();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.home);
            //mapeos
            toolbarmenu = FindViewById<Toolbar>(Resource.Id.toolbarMenu);
            listClass = FindViewById<ListView>(Resource.Id.listClass);
            viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);

            //toolbar
            SetActionBar(toolbarmenu);
            ActionBar.Title = "Asesorias";

            //hacer lista
            classList = crud.SelectTutor().ToList();

            //crear adaptador personalizado
            CustomListAdapter adapter = new CustomListAdapter(this, classList);
            listClass.Adapter = adapter;
        }

        public class CustomListAdapter : BaseAdapter<Tutor>
        {
            private readonly Activity _context;
            private List<Tutor> _classList;

            public CustomListAdapter(Activity context, List<Tutor> classList)
            {
                _context = context;
                _classList = classList;
            }

            public override Tutor this[int position] => _classList[position];

            public override int Count => _classList.Count;

            public override long GetItemId(int position) => position;

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                View view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.element, null);
                TextView textTittle = view.FindViewById<TextView>(Resource.Id.textTittle);
                TextView textDescrip = view.FindViewById<TextView>(Resource.Id.textDescrip);
                TextView textClock = view.FindViewById<TextView>(Resource.Id.textClock);

                //actualizar los textos con los datos del elemento de la lista
                Tutor currentClass = _classList[position];
                textTittle.Text = currentClass.className;
                textDescrip.Text = currentClass.classDescription;
                textClock.Text = currentClass.classClock;

                return view;
            }
        }



        public class Clase
        {
            public string className { get; set; }
            public string classDescription { get; set; }
            public string classClock { get; set; }

            public Clase(string className, string classDescription, string classClock)
            {
                this.className = className;
                this.classDescription = classDescription;
                this.classClock = classClock;
            }
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
