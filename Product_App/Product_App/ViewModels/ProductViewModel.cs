using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;
using Product_App.Setup;
using Product_App.Models;

namespace Product_App.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public ProductViewModel()
        {
            collection = new ObservableCollection<Product>();
            dbconn = new Db_Connection();
            model = new Product();

            InsertCommand = new RelayCommand(async () => await InsertDataAsync());
            UpdateCommand = new RelayCommand(async () => await UpdateDataAsync());
            DeleteCommand = new RelayCommand(async () => await DeleteDataAsync());
            SelectCommand = new RelayCommand(async () => await ReadDataAsync());
            SelectCommand.Execute(null);
        }

        public RelayCommand InsertCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand SelectCommand { get; set; }

        public ObservableCollection<Product> Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }

        public Product Model
        {
            get
            {
                return model;
            }
            set
            {
                if (value != null)
                {
                    IsChecked = (value.Status == "Active") ? true : false;
                }
                model = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }

        public bool IsChecked
        {
            get
            {
                return check;
            }
            set
            {
                check = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event Action OnCallBack;

        private readonly Db_Connection dbconn;
        private ObservableCollection<Product> collection;
        private Product model;
        private bool check;

        private async Task ReadDataAsync()
        {
            dbconn.OpenConnection();

            await Task.Delay(0);
            var query = "SELECT * FROM Product";
            var sqlcmd = new SqlCommand(query, dbconn.SqlConnect);
            var sqlresult = sqlcmd.ExecuteReader();

            if (sqlresult.HasRows)
            {
                collection.Clear();
                while (sqlresult.Read())
                {
                    collection.Add(new Product
                    {
                        Uid = sqlresult[0] as int? ?? 0,
                        Name = sqlresult[1].ToString(),
                        Status = (sqlresult[2].ToString() == "1") ?
                                    "Active" : "Non Active"

                    });
                }
            }
            dbconn.CloseConnection();
            OnCallBack?.Invoke();
        }
        
        private async Task InsertDataAsync()
        {
            if (IsValidating())
            {
                dbconn.OpenConnection();
                var state = check ? "1" : "0";
                var query = $"INSERT INTO Product VALUES (" +
                            $"'{model.Uid}', " +
                            $"'{model.Name}', " +
                            $"'{model.Status}')";
                var sqlcmd = new SqlCommand(query, dbconn.SqlConnect);
                sqlcmd.ExecuteNonQuery();
                dbconn.CloseConnection();
                await ReadDataAsync();
            } 
        }

        private async Task UpdateDataAsync()
        {
            if (IsValidating())
            {
                dbconn.OpenConnection();
                var state = check ? "1" : "0";
                var query = $"UPDATE Product SET " +
                            $"Name = '{model.Name}', " +
                            $"Status = '{model.Status}', " +
                            $"WHERE Uid = '{model.Uid}'";
                var sqlcmd = new SqlCommand(query, dbconn.SqlConnect);
                sqlcmd.ExecuteNonQuery();
                dbconn.CloseConnection();
                await ReadDataAsync();
            }
        }

        private async Task DeleteDataAsync()
        {
            if (IsValidating())
            {
                var msg = MessageBox.Show("Are you sure?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msg == MessageBoxResult.Yes)
                {
                    dbconn.OpenConnection();
                    var query = $"DELETE DROM Product WHERE Uid = '{model.Uid}'";
                    var sqlcmd = new SqlCommand(query, dbconn.SqlConnect);
                    sqlcmd.ExecuteNonQuery();
                    dbconn.CloseConnection();
                } 
                await ReadDataAsync();
            }
        }

        private bool IsValidating()
        {
            var flag = true;
            if (model.Uid == null)
            {
                MessageBox.Show("Text 1 cannot empty!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                flag = false;
            } else if (model.Name == null)
            {
                MessageBox.Show("Text 2 cannot empty!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                flag = false;
            } else if (model.Status == null)
            {
                MessageBox.Show("Text 3 cannot empty!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                flag = false;
            }
            return flag;
        }
    }
}
