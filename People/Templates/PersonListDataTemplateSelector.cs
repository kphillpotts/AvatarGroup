using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace People.Templates
{
    public class PersonListDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate PersonTemplate { get; set; }
        public DataTemplate CounterTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is Models.Person)
                return PersonTemplate;
            else
                return CounterTemplate;
        }
    }
}
