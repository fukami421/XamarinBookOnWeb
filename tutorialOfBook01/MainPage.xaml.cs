using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace tutorialOfBook01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    this.Padding = new Thickness(0, 20, 0, 0);
                    break;
                case Device.Android:
                    this.Padding = new Thickness(0, 10, 0, 0);
                    break;
                default:
                    this.Padding = new Thickness(0, 100, 0, 0);
                    break;
            }

            //label00.BindingContext = slider;
            //label00.SetBinding(RotationProperty, "Value");//SetBinding メソッドはバインディング ターゲットに対して呼び出されますが、ターゲット プロパティとソース プロパティの両方を指定しています。ソース プロパティは文字列として指定され、Slider の Value プロパティを示しています。
        }

        //ここのメソッドで,MainPageクラスのlayoutがいじれることが分かった
        public void Click01(object sender,EventArgs args){
            label01.Text = "クリックされたよ";
        }
            
        public void Click02(object sender,EventArgs args)
        {
            this.button02.CornerRadius = 70;
            this.button02.Text = DateTime.Now.ToString();
        }
    }
}
