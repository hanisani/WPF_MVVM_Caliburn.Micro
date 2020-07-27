using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using WpfAppCalibun.Models;
using WpfAppCalibun.Services;

namespace WpfAppCalibun.ViewModels
{
    public class ShellViewModel : Conductor<object> // Screen
    {
        private ICalculations _calculations;
        private string _firstName = "Faheem"; // camel case
        private string _lastName;
        private BindableCollection<PersonModal> _people = new BindableCollection<PersonModal>();
        private BindableCollection<StudentModel> _student = new BindableCollection<StudentModel>();
        private PersonModal _selectedPerson;
        private StudentModel _selectedStudent;
        public ShellViewModel(ICalculations calculations)
        {
            _calculations = calculations;
            People.Add(new PersonModal { FirstName = "Faheem", LastName = "Ahmad" });
            People.Add(new PersonModal { FirstName = "Salman", LastName = "Khan" });
            People.Add(new PersonModal { FirstName = "Qasim", LastName = "Ali" });

            Student.Add(new StudentModel { FullName = "Faheem Ahmad", IsAlive = true });
            Student.Add(new StudentModel { FullName = "Ali Hasan", IsAlive = false }); ;
            Student.Add(new StudentModel { FullName = "Qasim Ali", IsAlive = false });
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public BindableCollection<PersonModal> People
        {
            get
            {
                return _people;
            }
            set
            {
                _people = value;
            }
        }
        public BindableCollection<StudentModel> Student
        {
            get
            {
                return _student;
            }
            set
            {
                _student = value;
            }
        }
        public PersonModal SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }
        public StudentModel SelectedStudent
        {
            get
            {
                return _selectedStudent;
            }
            set
            {
                _selectedStudent = value;
                NotifyOfPropertyChange(() => SelectedStudent);
            }
        }
        public bool CanClearText(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //public bool CanClearText(string firstName, string lastName) => !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName);
        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
        }
        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());
        }
        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }
        public void AddStudent()
        {
            People.Add(new PersonModal { FirstName = "Qasim", LastName = "Khan" });
        }
        public void RemoveStudent()
        {
            if (People.Count == 0)
            {
                return;
            }
            People.Remove(People[0]);
        }
    }
}
