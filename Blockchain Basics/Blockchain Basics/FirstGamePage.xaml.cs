using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Blockchain_Basics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstGamePage : ContentPage
    {
        public FirstGamePage()
        {
            InitializeComponent();

            int count = 0;

            RadialGradientBrush radialGradientBrush = new RadialGradientBrush();
            radialGradientBrush.Radius = 1.5;
            radialGradientBrush.GradientStops = new GradientStopCollection()
            {
                new GradientStop(){ Color = Color.FromHex("#2F9BDF"), Offset = 0 },
                new GradientStop(){ Color = Color.FromHex("#51F1F2"), Offset = 1 }
            };

            button.Background = radialGradientBrush;

            string GetHashString(string s)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(s);

                MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();

                byte[] byteHash = CSP.ComputeHash(bytes);

                string hash = string.Empty;

                foreach (byte b in byteHash)
                {
                    hash += string.Format("{0:x2}", b);
                }

                return hash;
            }

            void OnClick(object sender, EventArgs e)
            {
                string value = Entry_t.Text;

                App.Current.Properties["name"] = value;

                if (value != null)
                {
                    count++;
                    string result = count.ToString();
                    textView1.Text = GetHashString(value);
                    textView3.Text = result;
                }
            }

            button.Clicked += OnClick;
        }
    }
}