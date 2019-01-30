using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
namespace tutorialOfBook01
{
    public class MyPageViewModel:BindableBase
    {   
        //Binding Contextのページです
        private double sliderValue;
        //下のようなものをプロパティと呼ぶ
        public double SliderValue
        {
            get { return this.sliderValue; }
            //MainPageにおいてSliderValueプロパティが設定されたvalueをthis.sliderValueに代入している。その後、LabelValueを呼び出している
            set { this.SetProperty(ref this.sliderValue, value); OnPropertyChanged(nameof(LabelValue)); }
        }
        public string LabelValue => string.Format("このValueは上のSliderとbindingしており、その数値は '{0:000}' です", this.sliderValue);

        public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>();

        private string message;
        public string Message
        {
            get { return this.message; }
            set { this.SetProperty(ref this.message, value); }
        }
        private bool canexecute;
        public bool CanExecute
        {
            get { return this.canexecute; }
            set 
            {
                this.SetProperty(ref this.canexecute, value);
                this.NowCommand.ChangeCanExecute();
            }

        }
        //別のプロパティと連携させる
        public Command NowCommand { get; }

        public MyPageViewModel()
        {
            var r = new Random();
            Device.StartTimer(
            TimeSpan.FromSeconds(5),
            () =>
            {
                this.People.Add(new Person { Name = $"Ryu1{r.Next()}" });
                return true;
            });
            this.NowCommand = new Command(
               x => this.Message = DateTime.Now.ToString((string)x),
               _ => this.canexecute);
        }


    }
}
