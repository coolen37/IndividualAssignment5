using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using IndividualAssignment5.Activities;

namespace IndividualAssignment5
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        //declare variables
        EditText txtUser;
        EditText txtPassword;
        Button btnLogin;

        //hardcode username/password
        string username = "employeeAdmin";
        string password = "318@ppUser";

        protected override void OnCreate(Bundle savedInstanceState) {
           
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            txtUser = FindViewById<EditText>(Resource.Id.NCtxtUsername);
            txtPassword = FindViewById<EditText>(Resource.Id.NCtxtPassword);
            btnLogin = FindViewById<Button>(Resource.Id.NCbtnLogin);

            btnLogin.Click += Login_Click;
        }

        private void Login_Click(object sender, System.EventArgs e) {
            if (!txtUser.Text.Equals(username))
            {
                Toast toast = Toast.MakeText(this, "Username incorrect!", ToastLength.Short);
                toast.Show();
            }
            else if (!txtPassword.Text.Equals(password))
            {
                Toast toast = Toast.MakeText(this, "Password incorrect!", ToastLength.Short);
                toast.Show();
            }
            else
            {
                StartActivity(typeof(DirectoryActivity));
            }
        }
    }
    
}

