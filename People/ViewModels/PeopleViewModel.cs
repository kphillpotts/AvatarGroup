using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using People.Models;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

namespace People.ViewModels
{
    public class PeopleViewModel : BaseViewModel
    {
        public ICommand AddUserCommand { get; private set; }
        public ICommand RemoveUserCommand { get; private set; }

        public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person>();

        public PeopleViewModel()
        {
            //PeopleCount = new List<object>();
            
            // setup the commands
            AddUserCommand = new Command(AddPerson);
            RemoveUserCommand = new Command(RemovePerson);
            CreateSampleData();
        }

        private void CreateSampleData()
        {
            // create 5 peeps
            for (int i = 0; i < 5; i++)
            {
                AddPerson();
            }
        }

        private void AddPerson()
        {
            // add a person using an Image from pravatar.cc
            People.Add(new Person { Image = $"https://i.pravatar.cc/64?img={People.Count + 1}" });

            //OnPropertyChanged(nameof(PeopleCount));
        }

        private void RemovePerson()
        {
            if (People.Any())
            {
                People.Remove(People.Last());

                //OnPropertyChanged(nameof(PeopleCount));

            }
        }

        //public List<object> PeopleCount
        //{
        //    get
        //    {
        //        var numberToShow = 5;
        //        List<object> returnList = new List<object>();

        //        returnList.AddRange(People.Take(numberToShow));

        //        if (People.Count > numberToShow)
        //            returnList.Add(People.Count - numberToShow);

        //        return returnList;
        //    }
        //    set { }
        //} 
    }
}
