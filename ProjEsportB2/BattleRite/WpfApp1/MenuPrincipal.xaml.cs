using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MenuPrincipal : Page
    {
        private String selectedGrid = "";
        private Gestion gestion;

        public MenuPrincipal()
        {
            InitializeComponent();
            gestion = Fenetre.gestion;
            DataContext = gestion;
            PageListTournoi();
            ThemeButtonCreate();
        }

        public void ThemeButtonCreate()
        {
            MenuItem MainMenu = ThemeButton;
            MainMenu.Tag = Themes.Colors[0][0];
            gestion.SetTheme(Themes.Colors[0]);
            foreach (List<String> l in Themes.Colors)
            {
                MenuItem NewMenu = new MenuItem() {
                    Header = l[1],
                    Tag = l[0]
                };
                NewMenu.MouseEnter += new MouseEventHandler(PreviewTheme);
                NewMenu.Click += new RoutedEventHandler(SetTheme);
                MainMenu.Items.Add(NewMenu);
            }
        }

        public void SetTheme(object sender, RoutedEventArgs e)
        {
            String s = (String)((MenuItem)sender).Tag;
            ThemeButton.Tag = s;
            ChangeTheme(s);
        }
        public void PreviewTheme(object sender, MouseEventArgs e)
        {
            MenuItem m = (MenuItem)sender;
            ChangeTheme((String)m.Tag);
        }
        public void ResetThemeEvent(object sender, MouseEventArgs e)
        {
            ChangeTheme((String)ThemeButton.Tag);
        }
        public void ChangeTheme(String s)
        {
            foreach (List<String> l in Themes.Colors)
            {
                if (l[0] == s)
                {
                    gestion.Color1 = l[2];
                    gestion.Color2 = l[3];
                    gestion.Color3 = l[4];

                    DataContext = null;
                    DataContext = gestion;
                }
            }
        }

        public void PageListTournoi()
        {

            for (int i = 0; i < gestion.CountTournoi; i++)
            {
                Grid addGrid = new Grid
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Top,
                    Tag = gestion.GetTournoi(i).Id,
                    Height = 60,
                    Margin = new Thickness(10, i * 70, 10, 10),
                    Name = "gridName" + i,
                    Style = (Style) FindResource("Cursor")
                };
                System.Windows.Media.Effects.DropShadowEffect shadowEffect = new System.Windows.Media.Effects.DropShadowEffect
                {
                    ShadowDepth = 3,
                    BlurRadius = 5,
                    Color = Colors.Black,
                    Opacity = 0.5
                };
                addGrid.Effect = shadowEffect;
                if (i % 2 == 0) { addGrid.Background = Brushes.DarkGray; }
                else { addGrid.Background = Brushes.LightGray; }
                addGrid.MouseDown += new MouseButtonEventHandler(SelectTournoi);
                RegisterName("gridName" + i, addGrid);
                RowDefinition row1 = new RowDefinition
                {
                    Height = new GridLength(50, GridUnitType.Star)
                };
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
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1)
                };
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
                    Content = gestion.GetTournoi(i).ListTeam.Count,
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
            obj.Background = (SolidColorBrush) new BrushConverter().ConvertFromString("#FFB74D"); 
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
                App.Current.Properties["gestion"] = gestion;

                //this.NavigationService.Navigate(new EditWindow());
                this.NavigationService.Navigate(new ArbrePage());
            }
        }
        public void CreateTournament(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["gestion"] = gestion;

            this.NavigationService.Navigate(new MainWindow());
        }
        public void ContextMenuOnClick(object sender, RoutedEventArgs e)
        {
            ((Button)sender).ContextMenu.DataContext = ((Button)sender).DataContext;
            ((Button)sender).ContextMenu.IsOpen = true;
        }
    }
}
