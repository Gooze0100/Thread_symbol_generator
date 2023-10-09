using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UVS_Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// Change connection string in App.config file.
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        Random rnd = new Random();
        string str = "";

        CancellationTokenSource cts = new CancellationTokenSource();

        public MainWindow()
        {
            DataContext = this;
            symbolsCollection = new ObservableCollection<Symbol>();
            InitializeComponent();
        }

        private ObservableCollection<Symbol> symbolsCollection;

        public ObservableCollection<Symbol> SymbolsCollection 
        { 
            get { return symbolsCollection; } 
            set { symbolsCollection = value; }
        }

        public class Symbol
        {
            public int ThreadId { get; set; }
            public string Symbols { get; set; }
        }

        public void MyConnection()
        {
            String Conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(Conn);
            con.Open();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^([1-9]|1[012345])$");
            var futureText = $"{(sender as TextBox).Text}{e.Text}";
            e.Handled = !regex.IsMatch(futureText);
        }

        private void GenerateSymbols()
        {
            int randomNumber = rnd.Next(5, 10);
            str = "";

            for (int i = 0; i <= randomNumber; i++)
            {
                str += "-";
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string content = threadAmount.Text;
                if (content != String.Empty)
                {
                    cts = new CancellationTokenSource();
                    int inputParsed = Int32.Parse(content);

                    Enumerable.Range(0, inputParsed).ToList().ForEach(x => {
                        ThreadPool.QueueUserWorkItem(o =>
                        {
                            CancellationToken token = (CancellationToken)o;
                            int threadNumber = Thread.CurrentThread.ManagedThreadId;
                            int sleepNumber = rnd.Next(500, 2001);
                            Thread.Sleep(sleepNumber);

                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                if (token.IsCancellationRequested)
                                {
                                    return;
                                }

                                GenerateSymbols();
                                SymbolsCollection.Add(new Symbol() { ThreadId = threadNumber, Symbols = str });

                                if (SymbolsCollection.Count > 20 && SymbolsCollection.Count != 0)
                                {
                                    SymbolsCollection.RemoveAt(0);
                                }

                                MyConnection();
                                cmd.Parameters.Clear();
                                cmd = new SqlCommand("INSERT INTO Symbols_Master(Time, ThreadId, Data) VALUES(@Time, @ThreadId, @Data)", con);
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@Time", DateTimeOffset.Now.ToUnixTimeSeconds());
                                cmd.Parameters.AddWithValue("@ThreadId", threadNumber);
                                cmd.Parameters.AddWithValue("@Data", str);
                                cmd.ExecuteNonQuery();
                                con.Close();
                            });
                            Debug.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} ended");
                        }, cts.Token);
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            cts.Cancel();
        }
    }
}
