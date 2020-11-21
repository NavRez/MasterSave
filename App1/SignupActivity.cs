using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Widget;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class SignupActivity : Activity
    {
        RelativeLayout relativeLayout;
        TextView SignupView;
        TextView nameView;
        TextView EmailView;
        TextView PasswordView;
        EditText NameText;
        EditText EmailText;
        EditText PasswordText;
        Button signup;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //create a new instance of RelativeLayout  
            relativeLayout = new RelativeLayout(this);
            //set a background color  
            relativeLayout.SetBackgroundColor(Color.CadetBlue);
            //TextView implementation  
            SignupView = new TextView(this);
            SignupView.Text = "Sign up for free";
            SignupView.Id = 1;//we will be needing this id  
            nameView = new TextView(this);
            nameView.Text = "Name";
            nameView.Id = 2;
            EmailView = new TextView(this);
            EmailView.Text = "Email Address";
            EmailView.Id = 3;
            PasswordView = new TextView(this);
            PasswordView.Text = "Password";
            PasswordView.Id = 4;

            //EditText implementation  
            NameText = new EditText(this);
            NameText.Id = 11;
            EmailText = new EditText(this);
            EmailText.Id = 12;
            PasswordText = new EditText(this);
            PasswordText.Id = 13;
            signup = new Button(this);
            signup.Text = "Sign up";

            //add layout rules for SignUp TextView  
            RelativeLayout.LayoutParams SignUpViewLayoutparams = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
            //to align the SignUpTextView to center.  
            SignUpViewLayoutparams.AddRule(LayoutRules.CenterHorizontal);

            //add layout rules Name TextView  
            RelativeLayout.LayoutParams NameViewLayoutparams = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
            //in order to specify the layout rules, AddRule is used.  
            //the below code states, set the layout for the NameView below the SignupView  
            NameViewLayoutparams.AddRule(LayoutRules.Below, SignupView.Id);
            NameViewLayoutparams.AddRule(LayoutRules.AlignLeft);
            //add layout rules for Name EditText  
            RelativeLayout.LayoutParams NameEditLayoutparams = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
            NameEditLayoutparams.AddRule(LayoutRules.Below, nameView.Id);
            NameEditLayoutparams.AddRule(LayoutRules.AlignLeft);

            //add layout rules for Email TextView   
            RelativeLayout.LayoutParams EmailViewLayoutparams = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
            EmailViewLayoutparams.AddRule(LayoutRules.Below, NameText.Id);
            EmailViewLayoutparams.AddRule(LayoutRules.AlignLeft);

            //add layout rules for Email EditText  
            RelativeLayout.LayoutParams EmailEditTextLayoutparams = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
            EmailEditTextLayoutparams.AddRule(LayoutRules.Below, EmailView.Id);
            EmailEditTextLayoutparams.AddRule(LayoutRules.AlignLeft);

            //add layout rules for Password TextView  
            RelativeLayout.LayoutParams PasswordViewLayoutparams = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
            PasswordViewLayoutparams.AddRule(LayoutRules.Below, EmailText.Id);
            PasswordViewLayoutparams.AddRule(LayoutRules.AlignLeft);

            //add layout rules for Password EditText  
            RelativeLayout.LayoutParams passwordEditTextLayoutparams = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
            passwordEditTextLayoutparams.AddRule(LayoutRules.Below, PasswordView.Id);
            passwordEditTextLayoutparams.AddRule(LayoutRules.AlignLeft);

            //add layout rules for Button Control  
            RelativeLayout.LayoutParams ButtonLayoutparams = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
            ButtonLayoutparams.AddRule(LayoutRules.Below, PasswordText.Id);
            ButtonLayoutparams.AddRule(LayoutRules.CenterHorizontal);
            ButtonLayoutparams.AddRule(LayoutRules.CenterVertical);

            //add controls to the layout  
            relativeLayout.AddView(SignupView, SignUpViewLayoutparams);
            relativeLayout.AddView(nameView, NameViewLayoutparams);
            relativeLayout.AddView(NameText, NameEditLayoutparams);
            relativeLayout.AddView(EmailView, EmailViewLayoutparams);
            relativeLayout.AddView(EmailText, EmailEditTextLayoutparams);
            relativeLayout.AddView(PasswordView, PasswordViewLayoutparams);
            relativeLayout.AddView(PasswordText, passwordEditTextLayoutparams);
            relativeLayout.AddView(signup, ButtonLayoutparams);

            //pass the relative layout object as the ContentView for our android activity  
            SetContentView(relativeLayout);
        }
    }
}