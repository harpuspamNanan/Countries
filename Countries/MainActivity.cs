using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Countries
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView capital;
        Spinner countrySpinner;
        ImageView countryImages;

        string[] capitalNamesInArray = { "New Delhi", "Brasilia", "Ottawa", "Paris", "Suva", "Rome", "Washington, D.C." };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            capital = (TextView)FindViewById(Resource.Id.showCapitalTv);
            countrySpinner = (Spinner)FindViewById(Resource.Id.countrySpinner);
            countryImages = (ImageView)FindViewById(Resource.Id.showImages);

            ArrayAdapter countryNamesAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.capitals_array, Android.Resource.Layout.SimpleSpinnerItem);
            countrySpinner.Adapter = countryNamesAdapter;

            countrySpinner.ItemSelected += delegate
            {
                long i = countrySpinner.SelectedItemId;
                capital.Text = capitalNamesInArray[i].ToString();
                Toast.MakeText(this, "The Selected Country is : " + countrySpinner.SelectedItem, ToastLength.Long).Show();
                string imgName = "country" + (i+1);
                int imgId = this.Resources.GetIdentifier(imgName, "mipmap", this.PackageName);
                countryImages.SetImageResource(imgId);

            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

