using System;
using Xamarin.Forms;

namespace tutorialOfBook01
{
    public class Person2:BindableObject
    {
        public static readonly BindableProperty NameProperty = BindableProperty.Create(//フィールド定義
            "Name",//プロパティ名
            typeof(string),//プロパティの型
            typeof(Person2),//プロパティの所持するクラスの型
            "tanaka");

        public string Name
        {
            get { return (string)this.GetValue(NameProperty); }
            set { this.SetValue(NameProperty, value); }
        }


    }
}
