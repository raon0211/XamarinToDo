using Android.App;
using Android.Widget;
using Android.OS;
using MvvmCross.Droid.Views;
using Android.Views;
using Now.Core.ViewModels;
using System;

namespace Now.Droid
{
    [Activity(Label = "Now", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/AppTheme")]
    public class ListActivity : MvxActivity
    {
        private ListViewModel viewModel;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            viewModel = (ListViewModel)ViewModel;

            SetContentView(Resource.Layout.activity_list);

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar_list);
            SetActionBar(toolbar);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.list, menu);

            var item = menu.FindItem(Resource.Id.list_add);
            item.ActionView.Click += (v, args) =>
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetTitle("Add a to-do");

                EditText input = new EditText(this);
                input.SetSingleLine(true);
                builder.SetView(input);

                builder.SetPositiveButton("OK", (dialog, which) =>
                {
                    viewModel.AddItem(input.Text);
                });
                
                builder.SetNegativeButton("Cancel", (dialog, which) => { });

                builder.Show();
            };
            return true;
        }
    }
}

