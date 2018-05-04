using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
        private string selectedGrid = "";
        private Gestion gestion;

        public MenuPrincipal()
        {
            InitializeComponent();
            gestion = Charger<Gestion>("BattleRiteSave.bin");
            Enregistrer(gestion, "BattleRiteSave.bin");
            PageListTournoi();
        }

        public void PageListTournoi()
        {
            /*Gestion gestion = new Gestion();
            gestion.AddTeam("Na'Vi");
            gestion.AddPlayer("MamaLeRattata", "MamaLeRattata", Rank.platinium1);
            gestion.AddTournoi("Lyon E - sport" , "Arles sur tech", 100);
            gestion.AddTournoi("Baise party", "soeur de sylvain", 50);
            gestion.AddTournoi("epsi ligue", "?", 3);
            gestion.AddTournoi("1", "2", 3);
            gestion.AddTournoi("The International 2018", "Montreal", 64444044);*/

            for (int i = 0; i < gestion.CountTournoi; i++)
            {
                Grid addGrid = new Grid
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Top,
                    Tag = gestion.GetTournoi(i).Id
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
                    Content = gestion.GetTournoi(i).Nom
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
                    Content = gestion.GetTournoi(i).Lieu,
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
                    Content = gestion.GetTournoi(i).NbParticiepants,
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
            if (selectedGrid != "")
            {
                SolidColorBrush color;
                if (Int32.Parse(selectedGrid) % 2 == 0) color = Brushes.DarkGray;
                else color = Brushes.LightGray;
                Grid gridName = (Grid) this.FindName("gridName" + selectedGrid);
                gridName.Background = color;
            }
            Grid obj = (Grid)sender;
            obj.Background = Brushes.Blue;
            selectedGrid = obj.Name.Substring(8);
        }

        public Grid GetSelectedTournament()
        {
            Grid g = new Grid()
            {
                Tag = -1
            };
            if (selectedGrid != "")
            {
                g = (Grid)this.FindName("gridName" + selectedGrid);
            }
            return g;
        }
        public void EditTournament(object sender, RoutedEventArgs e)
        {
            Grid gridName = GetSelectedTournament();
            if ((int)gridName.Tag != -1)
            {
                App.Current.Properties["tournoi"] = gestion.GetTournoi((int)gridName.Tag);

                EditWindow main = new EditWindow();
                App.Current.MainWindow = main;
                this.Close();
                main.Show();
            }
        }
        public void CreateTournament(object sender, RoutedEventArgs e)
        {

        }
        private static void Enregistrer(object toSave, string path)
        {
             BinaryFormatter formatter = new BinaryFormatter();
             FileStream flux = null;
            try
            {
                flux = new FileStream(path, FileMode.Create, FileAccess.Write);
                formatter.Serialize(flux, toSave);
                flux.Flush();
            }
            catch { }
            finally
            {
                if (flux != null)
                    flux.Close();
            }
        }
        private static T Charger<T>(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream flux = null;
            try
            {
                 flux = new FileStream(path, FileMode.Open, FileAccess.Read);
                return (T)formatter.Deserialize(flux);
            }
            catch
            {
                return default(T);
            }
            finally
            {
                if (flux != null)
                    flux.Close();
            }
        }

    }
}
