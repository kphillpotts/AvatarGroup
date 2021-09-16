using People.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace People.Converters
{
    public class PeopleMultiBind : IMultiValueConverter
    {
        public int NumberToShow { get; set; } = 5;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var value in values)
            {
                if (value is IEnumerable<Person>)
                {
                    // get the first X number of people
                    List<object> returnList = new List<object>();
                    returnList.AddRange(((IEnumerable<Person>)value).Take(NumberToShow));

                    // if there are even more people - add a counter element
                    if (((IEnumerable<Person>)value).Count() > NumberToShow)
                    {
                        returnList.Add(((IEnumerable<Person>)value).Count() - NumberToShow);
                    }

                    return returnList;
                }
                else
                    return null;
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
