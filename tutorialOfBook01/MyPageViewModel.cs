using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
namespace tutorialOfBook01
{
    public class MyPageViewModel:BindableBase
    {
        private double sliderValue;
        public double SliderValue
        {
            get { return this.sliderValue; }
            //valueをthis.sliderValueに代入している
            set { this.SetProperty(ref this.sliderValue,value); OnPropertyChanged(nameof(LabelValue)); }
        }

        public string LabelValue => string.Format("This is slider ryuichi '{0:000}'", this.sliderValue);

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
                this.People.Add(new Person { Name = $"Tanaka{r.Next()}" });
                return true;
            });
            this.NowCommand = new Command(
               _ => this.Message = DateTime.Now.ToString(),
               _ => this.canexecute);
        }


    }
}
