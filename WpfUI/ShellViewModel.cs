using Caliburn.Micro;
using System;
using System.Windows;
using WpfUI.Models;
using WpfUI.ViewModels;

namespace WpfUI
{
    //Caliburn.Micro.PropertyChangedBase, IShell,
    public class ShellViewModel : Conductor<object>, IShell
    {
        private string _firstname;
        public string FirstName
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
                //NotifyOfPropertyChange(() => CanSayHello);
            }
        }

        private string _lastname;
        public string LastName
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName { get { return $"{ FirstName } { LastName }"; } }


        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Tony", LastName = "Stark" });
            People.Add(new PersonModel { FirstName = "Steve", LastName = "Rogers" });
            People.Add(new PersonModel { FirstName = "Bruce", LastName = "Banner" });
        }

        public BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();

        public BindableCollection<PersonModel> People { get { return _people; } set { _people = value; } }

        private PersonModel _selectedPerson;

        public PersonModel SelectedPerson { get { return _selectedPerson; } set { _selectedPerson = value; NotifyOfPropertyChange(() => SelectedPerson); } }

        public bool CanClearText(string firstname, string lastname)
        {
            //return string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName);
            if (string.IsNullOrWhiteSpace(firstname) && string.IsNullOrWhiteSpace(lastname))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ClearText(string firstname, string lastname)
        {
            FirstName = string.Empty;
            LastName = string.Empty;
        }
        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }

        //public bool CanSayHello
        //{
        //    get { return !string.IsNullOrWhiteSpace(FirstName); }
        //}

        //public void SayHello()
        //{
        //    MessageBox.Show(string.Format("Hello {0}!", FirstName)); //Don't do this in real life :)
        //}
    }
}