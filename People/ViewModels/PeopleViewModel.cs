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
            // setup the commands
            AddUserCommand = new Command(AddPerson);
            RemoveUserCommand = new Command(RemovePerson);
            CreateSampleData();
        }

        private void CreateSampleData()
        {
            for (int i = 0; i < 5; i++)
            {
                AddPerson();
            }
        }

        private void AddPerson()
        {
            People.Add(new Person { Image = $"https://i.pravatar.cc/100?img={People.Count+1}" });
        }

        private void RemovePerson()
        {
            if (People.Any())
            {
                People.Remove(People.Last());
            }
        }
    }
}
