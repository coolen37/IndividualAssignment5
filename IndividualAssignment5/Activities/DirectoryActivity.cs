using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IndividualAssignment5.Classes;
using SQLite;

namespace IndividualAssignment5.Activities
{
    [Activity(Label = "DirectoryActivity")]
    public class DirectoryActivity : Activity
    {
        Button btnAdd;
        ListView lstEmployee;
        string systemFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "EmployeeList.db3");


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Directory);

            lstEmployee = FindViewById<ListView>(Resource.Id.NClstEmployeeList);
            btnAdd = FindViewById<Button>(Resource.Id.NCbtnAddEmployee);
            btnAdd.Click += btnAdd_Click;

            try
            {
                var db = new SQLiteConnection(systemFile);
                db.CreateTable<EmployeeClass>();
                db.CreateTable<ManagerClass>();
            }
            catch (IOException ex)
            {
                string reason = string.Format("Faild to create Table - Reason {0}", ex.Message);
                Toast.MakeText(this, reason, ToastLength.Long).Show();
            }

            PopulateListView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(NewEmployeeActivity));
        }

        private void PopulateListView()
        {
            var db = new SQLiteConnection(systemFile);
            var employeeList = db.Table<EmployeeClass>().ToList();

            List<string> employeeNames = new List<string>();

            if (employeeList.Count > 0)
            {
                foreach (EmployeeClass employee in employeeList)
                {
                    employeeNames.Add(employee.ToString());
                }
                lstEmployee.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, employeeNames.ToArray());
            }
        }
    }
}