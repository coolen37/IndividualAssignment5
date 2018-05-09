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
    [Activity(Label = "NewEmployeeActivity")]
    public class NewEmployeeActivity : Activity
    {
        EditText txtFirst;
        EditText txtLast;
        EditText txtTitle;
        EditText txtOfficeNumber;
        EditText txtCellNumber;
        EditText txtEmail;
        EditText txtManagerName;
        EditText txtManagerEmail;
        Button btnAdd;
        string systemFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "EmployeeList.db3");
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewEmployee);

            txtFirst = FindViewById<EditText>(Resource.Id.NCtxtFirstName);
            txtLast = FindViewById<EditText>(Resource.Id.NCtxtLastName);
            txtTitle = FindViewById<EditText>(Resource.Id.NCtxtJobTitle);
            txtOfficeNumber = FindViewById<EditText>(Resource.Id.NCtxtOfficePhone);
            txtCellNumber = FindViewById<EditText>(Resource.Id.NCtxtCellPhone);
            txtEmail = FindViewById<EditText>(Resource.Id.NCtxtEmail);
            txtManagerName = FindViewById<EditText>(Resource.Id.NCtxtManagerEmail);
            txtManagerEmail = FindViewById<EditText>(Resource.Id.NCtxtManagerName);
            btnAdd = FindViewById<Button>(Resource.Id.NCbtnAddEmployee);
            btnAdd.Click += BtnAdd_Click;

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
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            EmployeeClass employee = new EmployeeClass {
                firstName = txtFirst.Text,
                lastName = txtLast.Text,
                jobTitle = txtTitle.Text,
                officePhone = txtOfficeNumber.Text,
                cellPhone = txtCellNumber.Text,
                email = txtEmail.Text,
                managerName = txtManagerName.Text,
                managerEmail = txtManagerEmail.Text
            };

            ManagerClass manager = new ManagerClass {
                managerName = txtManagerName.Text,
                managerEmail = txtManagerEmail.Text
            };

            var db = new SQLiteConnection(systemFile);
            db.Insert(employee);
            db.Insert(manager);

            StartActivity(typeof(DirectoryActivity));
        }
    }
}