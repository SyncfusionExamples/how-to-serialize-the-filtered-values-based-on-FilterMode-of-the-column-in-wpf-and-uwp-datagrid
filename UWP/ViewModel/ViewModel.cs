using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using Windows.Storage;

namespace SfDataGridDemo {
    internal class ViewModel : INotifyPropertyChanged
    {
        private ICommand serialize;
        public ICommand Serialize
        {
            get { return serialize; }
            set
            {
                serialize = value;
                RaisePropertyChanged("Serialize");
            }
        }

        private ICommand deserialize;
        public ICommand Deserialize
        {
            get { return deserialize; }
            set
            {
                deserialize = value;
                RaisePropertyChanged("Deserialize");
            }
        }

        public ObservableCollection<Model> employeelist;

        public ViewModel()
        {
            Random r = new Random();
            employeelist = new ObservableCollection<Model>();
            for (int i = 0; i < 10; i++)
            {
                var no = r.Next(1, 10);
                employeelist.Add(new Model
                {
                    EmployeeID = 101+no,
                    EmployeeName = "Jacobs"+no,
                    EmployeeAge = 25,
                    EmployeeSalary = 20000+no,
                    City="Belgium" + no
                });
                employeelist.Add(new Model
                {
                    EmployeeID = 102 + no,
                    EmployeeName = "Antony" + no,
                    EmployeeAge = 32,
                    EmployeeSalary = 21000 + no,
                    City = "Bracke" + no
                });
                employeelist.Add(new Model
                {
                    EmployeeID = 103 + no,
                    EmployeeName = "Markus" + no,
                    EmployeeAge = 45,
                    EmployeeSalary = 22000 + no,
                    City = "Arhus" + no
                });
                employeelist.Add(new Model
                {
                    EmployeeID = 104 + no,
                    EmployeeName = "Antony" + no,
                    EmployeeAge = 26,
                    EmployeeSalary = 23000 + no,
                    City = "Montreal" + no
                });
                employeelist.Add(new Model
                {
                    EmployeeID = 105 + no,
                    EmployeeName = "Bergius" + no,
                    EmployeeAge = 29+no,
                    EmployeeSalary = 24000 + no,
                    City = "Oulu" + no
                });
                employeelist.Add(new Model
                {
                    EmployeeID = 106 + no,
                    EmployeeName = "Thomas" + no,
                    EmployeeAge = 38,
                    EmployeeSalary = 25000 + no,
                    City = "Torino" + no
                });
                employeelist.Add(new Model
                {
                    EmployeeID = 107 + no,
                    EmployeeName = "Martin" + no,
                    EmployeeAge = 32,
                    EmployeeSalary = 35000 + no,
                    City = "Lille" + no
                });
                employeelist.Add(new Model
                {
                    EmployeeID = 108 + no,
                    EmployeeName = "Christopher" + no,
                    EmployeeAge = 32,
                    EmployeeSalary = 34000 + no,
                    City = "Geneve" + no
                });
                employeelist.Add(new Model
                {
                    EmployeeID = 109 + no,
                    EmployeeName = "Bradman Toy" + no,
                    EmployeeAge = 38,
                    EmployeeSalary = 35000 + no,
                    City = "Strasbourg" + no
                });
            }

            serialize = new CustomCommand(OnSerialize);
            deserialize = new CustomCommand(OnDeserialize);
        }

        private async void OnSerialize(object obj)
        {
            var dataGrid = obj as SfDataGrid;
            var folder = ApplicationData.Current.LocalFolder;
            var storageFile = await folder.CreateFileAsync("DataGrid.xml", CreationCollisionOption.ReplaceExisting);
            SerializationOptions options = new SerializationOptions();
            options.SerializeFiltering = true;
            dataGrid.Serialize(storageFile, options);
        }

        private async void OnDeserialize(object obj)
        {
            var dataGrid = obj as SfDataGrid;
            var folder = ApplicationData.Current.LocalFolder;
            var storageFile = await folder.GetFileAsync("DataGrid.xml");
            DeserializationOptions options = new DeserializationOptions();
            options.DeserializeFiltering = true;
            dataGrid.Deserialize(storageFile, options);
        }

        public ObservableCollection<Model> EmployeeDetails 
        {
            get { return employeelist; }
            set
            {
                value = employeelist;
                RaisePropertyChanged("EmployeeDetails");
            }
        }

        private void RaisePropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}