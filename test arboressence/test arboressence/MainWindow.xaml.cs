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

namespace test_arboressence
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int NbEquipe { get; set; }
        public GridLength gl;
        public MainWindow()
        {
            InitializeComponent();
            NbEquipe = 20;
            generate();
        }   

        public void generate()
        {

            List<List<String>> liste = new List<List<string>>()
            {
                new List<string>()
                {
                    "1", "2", "3", "4","5","6", "7", "8", "9","10", "11", "12"
                },
                new List<string>()
                {
                    "13", "14", "15", "16","17", "18"
                },
                new List<string>()
                {
                    "19", "20","21"
                },
                new List<string>()
                {
                    "22", "23"
                },
                new List<string>()
                {
                    "24"
                }
            };

            ColumnDefinition cd = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
            main.ColumnDefinitions.Add(cd);

            int taille = 40;
            int n = 40;

            for (int i = 0; i < liste.Count; i++)
            {
                cd = new ColumnDefinition() { Width = new GridLength(5, GridUnitType.Star) };
                main.ColumnDefinitions.Add(cd);

                cd = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
                main.ColumnDefinitions.Add(cd);

                Grid col = new Grid() {};
                Grid.SetColumn(col, i*2+1);
                main.Children.Add(col);

                gl = new GridLength(80 , GridUnitType.Pixel);
                RowDefinition rd = new RowDefinition();               
                
                for (int j = 0; j < liste[i].Count; j++)
                {                                        
                    rd = new RowDefinition() { Height = new GridLength(taille, GridUnitType.Pixel) };
                    col.RowDefinitions.Add(rd);
                    rd = new RowDefinition() { Height = gl };
                    col.RowDefinitions.Add(rd);

                    if (i == 0) n += 120;

                    Border ha = new Border() { BorderThickness = new Thickness(1), BorderBrush = Brushes.Black };
                    
                    Grid g = new Grid();
                    TextBlock txt = new TextBlock() { VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center, Text = liste[i][j] };

                    ha.Child = g;

                    Grid.SetRow(ha, j*2+1);                    

                    g.Children.Add(txt);
                    col.Children.Add(ha);
                }
                rd = new RowDefinition() { Height = new GridLength(taille, GridUnitType.Pixel) };
                col.RowDefinitions.Add(rd);
                if (i < liste.Count-1) taille = (n - (liste[i + 1].Count * 80)) / (liste[i + 1].Count+1);
            }  
        }
    }    
}
