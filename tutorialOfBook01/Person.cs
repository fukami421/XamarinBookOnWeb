using System;
using Xamarin.Forms;

namespace tutorialOfBook01
{
    public class Person:BindableObject
    {

        public static readonly BindableProperty NameProperty = BindableProperty.Create(
            "Namechan",
            typeof(string),
            typeof(Person),
            "Ryu1君",
            coerceValue: OnNameCoerceValue);

        private static void OnNameChanged(BindableObject bindable,object oldValue,object newValue)
        {

        }

        private static object OnNameCoerceValue(BindableObject bindable,object value)
        {
            string name = (string)value;
            if(name.Length > 10)
            {
                name = name.Substring(0, 10);
            }
            return name;
        }


        public string Namechan
        {
            get { return (string)this.GetValue(NameProperty); }
            set { this.SetValue(NameProperty, value); }
        }

        public string Name { get; internal set; }
    }
}
