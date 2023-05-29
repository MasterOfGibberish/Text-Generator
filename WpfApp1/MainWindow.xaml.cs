using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //static List<string> SkaiciuNaikinimas = new List<string>();
        private void Generate_Text_Click(object sender, RoutedEventArgs e)
        {
            string inputText = Konvertavimas.Text; // Get the input text from the Konvertavimas TextBox

            // Perform the necessary conversion on the input text
            string convertedText = ConvertText(inputText);

            // Display the converted text in the Rezultatas TextBox
            Rezultatas.Text = convertedText;
        }

        private string ConvertText(string inputText)
        {
            string convertedText = inputText;

            if (inputText.Contains("[Music]"))
            {
                convertedText = convertedText.Replace("[Music]", "");
            }

            StringBuilder resultText = new StringBuilder();

            foreach (char c in convertedText)
            {
                if (!char.IsDigit(c) && c != ':')
                {
                    resultText.Append(c);
                }
            }

            return resultText.ToString();
        }

        private void migtukas_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void kopijavimas_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Rezultatas.Text);
            MessageBoxResult result = MessageBox.Show("Copied successfully!", "Congratulations!");
            if (result == MessageBoxResult.OK)
            {
                Konvertavimas.Clear();
                Rezultatas.Clear();
            }
        }
    }
}
