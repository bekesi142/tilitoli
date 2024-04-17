using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace TiliToliTiliToli
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
        List<Button> gombok = new();
        private void keverGomb_Click(object sender, RoutedEventArgs e)
        {



            
            grdPanel.ColumnDefinitions.Clear();
            grdPanel.Children.Clear();
            gombok.Clear();
            grdPanel.RowDefinitions.Clear();
            keverGomb.Content = "Keverés";

            #region Grid létrehozása
            for (int oszlopIndex = 0; oszlopIndex < 3; oszlopIndex++)
            {
                ColumnDefinition ujOszlop = new();
                grdPanel.ColumnDefinitions.Add(ujOszlop);

            }
            for (int sorIndex = 0; sorIndex < 3; sorIndex++)
            {
                RowDefinition ujSor = new();
                grdPanel.RowDefinitions.Add(ujSor);
            }
            #endregion 

            #region Gombok létrehozása
            int szam = 9;
            for (int i = 0; i < szam; i++)
            {
                if (i == 8)
                {
                    Button hiddenButton = new();
                    hiddenButton.Visibility = Visibility.Hidden;
                    gombok.Add(hiddenButton);
                    break;
                }

                else
                {
                    Button button = new Button();
                    button.Content = i + 1;
                    button.Click += Button_Click;
                    gombok.Add(button);
                }
                 
            }

            #endregion

            #region Gombok keverése és gridbe felvevése
            Keveres(gombok);

            for (int i = 0; i < szam; i++)
            {
                grdPanel.Children.Add(gombok[i]);
                Grid.SetColumn(gombok[i], i % 3);
                Grid.SetRow(gombok[i], i / 3);
            }
            #endregion

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            foreach (var gomb in gombok)
            {
                if (gomb.Visibility==Visibility.Hidden)
                {

                    gomb.Visibility = Visibility.Visible;
                    gomb.Content = clickedButton.Content;
                    gomb.Click += Button_Click;
                }
            }
            
            clickedButton.Visibility = Visibility.Hidden;
            clickedButton.Content = string.Empty;
            

        }

        private static void Keveres<T>(List<T> lista)
        {
            Random rnd = new Random();
            int szamolas = lista.Count;
            while (szamolas > 1)
            {
                szamolas--;
                int randomplusz = rnd.Next(szamolas + 1);
                T ertek = lista[randomplusz];
                lista[randomplusz] = lista[szamolas];
                lista[szamolas] = ertek;
            }
        }
            
    }
}