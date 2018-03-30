using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        private string selectedGrid = "-1";

        public MenuPrincipal()
        {
            InitializeComponent();
            pageListTournoi();
        }

        public void pageListTournoi()
        {
            List<string> list = new List<string> {"Lyon E-sport" , "Arles sur tech", "100",
                "Baise party", "soeur de sylvain", "50",
                "epsi ligue", "?", "3",
                "1", "2", "3" };

            for (int i = 0; i < list.Count / 3; i++)
            {

                Grid addGrid = new Grid
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Top
                };
                if (i % 2 == 0) { addGrid.Background = Brushes.DarkGray; }
                else { addGrid.Background = Brushes.LightGray; }
                addGrid.Height = 60;
                addGrid.Margin = new Thickness(0, i * 60, 0, 0);
                addGrid.MouseDown += new MouseButtonEventHandler(SelectTournoi);
                addGrid.Name = "gridName" + i;
                RegisterName("gridName" + i, addGrid);
                RowDefinition row1 = new RowDefinition();
                row1.Height = new GridLength(50, GridUnitType.Star);
                addGrid.RowDefinitions.Add(row1);
                Grid line1 = new Grid();
                Grid.SetRow(line1, 0);
                ColumnDefinition row1col1 = new ColumnDefinition
                {
                    Width = new GridLength(33, GridUnitType.Star)
                };
                line1.ColumnDefinitions.Add(row1col1);
                Border borderNomTournoi = new Border
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    BorderBrush = Brushes.Gainsboro,
                    BorderThickness = new Thickness(1)
                };
                borderNomTournoi.HorizontalAlignment = HorizontalAlignment.Stretch;
                Grid.SetColumn(borderNomTournoi, 0);
                Label labelNomTournoi = new Label
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Content = list[i * 3]
                };
                borderNomTournoi.Child = labelNomTournoi;
                line1.Children.Add(borderNomTournoi);

                ColumnDefinition row1col2 = new ColumnDefinition
                {
                    Width = new GridLength(33, GridUnitType.Star)
                };
                line1.ColumnDefinitions.Add(row1col2);
                Label labelLieu = new Label
                {
                    Content = list[i * 3 + 1],
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                Grid.SetColumn(labelLieu, 1);
                line1.Children.Add(labelLieu);

                ColumnDefinition row1col3 = new ColumnDefinition
                {
                    Width = new GridLength(33, GridUnitType.Star)
                };
                line1.ColumnDefinitions.Add(row1col3);
                Label labelNbEquipe = new Label
                {
                    Content = list[i * 3 + 2],
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                Grid.SetColumn(labelNbEquipe, 2);
                line1.Children.Add(labelNbEquipe);
                addGrid.Children.Add(line1);
                RowDefinition row2 = new RowDefinition
                {
                    Height = new GridLength(50, GridUnitType.Star)
                };
                addGrid.RowDefinitions.Add(row2);

                listTournament.Children.Add(addGrid);
            }

        }

        public void SelectTournoi(object sender, RoutedEventArgs e)
        {
            if (selectedGrid != "-1")
            {
                SolidColorBrush color;
                if (Int32.Parse(selectedGrid) % 2 == 0) color = Brushes.DarkGray;
                else color = Brushes.LightGray;
                object gridName = this.FindName("gridName" + selectedGrid);
                ((Grid)gridName).Background = Brushes.Gray;
            }
            Grid obj = (Grid)sender;
            obj.Background = Brushes.Blue;
            selectedGrid = obj.Name.Substring(8);
        }

        public void CreateTournament(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            App.Current.MainWindow = main;
            this.Close();
            main.Show();
        }

    }
}
