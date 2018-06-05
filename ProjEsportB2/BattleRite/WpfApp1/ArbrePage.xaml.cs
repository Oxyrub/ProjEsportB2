using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class ArbrePage : Page
    {
        public Tournoi t;
        public Gestion gestion;

        public ArbrePage()
        {
            InitializeComponent();
            gestion = Fenetre.gestion;
            t = (Tournoi)App.Current.Properties["tournoi"];
            if (t.Started)
            {
                Generate();
            }
            else
            {
                ShowEditTeams();
            }
        }

        public void ShowEditTeams()
        {
            StartButton.IsEnabled = true;
            foreach (Team team in t.ListTeam)
            {
                ListBoxTeamParticipe.Items.Add(new ListBoxItem().Content=team.Name);
            }
            foreach (Team team in gestion.ListTeams)
            {
                if (!t.ListTeam.Contains(team))
                {
                    ListBoxTeam.Items.Add(new ComboBoxItem().Content=team.Name);
                }
            }
        }
        public void Generate()
        {
            main.Children.Clear();
            main.RowDefinitions.Clear();
            main.ColumnDefinitions.Clear();
            MainScroll.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            List<List<Match>> liste = t.GetArbre();

            ColumnDefinition cd = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
            main.ColumnDefinitions.Add(cd);

            int taille = 40;
            int n = 40;

            List<List<List<int>>> listPosition = new List<List<List<int>>>();

            for (int i = 0; i < liste.Count; i++)
            {
                cd = new ColumnDefinition() { Width = new GridLength(5, GridUnitType.Star) };
                main.ColumnDefinitions.Add(cd);

                cd = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
                main.ColumnDefinitions.Add(cd);

                Grid col = new Grid() { };
                Grid.SetColumn(col, i * 2 + 1);
                main.Children.Add(col);
                
                RowDefinition rd = new RowDefinition();

                listPosition.Add(new List<List<int>>());

                int fauxMatches = 0;

                for (int j = 0; j < liste[i].Count; j++)
                {
                    if (i != 0)
                    {
                        if (liste[i][j].Vrais) taille = (listPosition[i - 1][2 + 4 * j - 2 * fauxMatches][0] + listPosition[i - 1][2 + 4 * j - 2 * fauxMatches][1]) / 2 - 40 - (j > 0 ? listPosition[i][2 * j - 1][1] : 0);
                        else
                        {
                            taille = listPosition[i - 1][1 + 4 * j][0] - (j > 0 ? listPosition[i][2 * j - 1][1] : 0);
                            fauxMatches++;
                        }
                        if (taille < 0) taille = 0;
                    }
                    rd = new RowDefinition() { Height = new GridLength(taille, GridUnitType.Pixel) };
                    col.RowDefinitions.Add(rd);
                    rd = new RowDefinition() { Height = new GridLength(80, GridUnitType.Pixel) };
                    col.RowDefinitions.Add(rd);

                    listPosition[i].Add(new List<int>()
                    {
                        (j > 0 ? listPosition[i][2*j-1][1] : 0), (j > 0 ? listPosition[i][2*j-1][1] : 0)+taille
                    });
                    listPosition[i].Add(new List<int>()
                    {
                        listPosition[i][2*j][1], listPosition[i][2*j][1]+80
                    });

                    if (i == 0) n += 120;

                    Border ha = new Border() { BorderThickness = new Thickness(1), BorderBrush = Brushes.Black };

                    Grid g = new Grid();
                    if (liste[i][j].Vrais)
                    {
                        List<Team> listTeam = new List<Team>() { liste[i][j].Equipe1, liste[i][j].Equipe2 };
                        for (int k = 0; k < 2; k++)
                        {
                            Border TeamBorder = new Border() { BorderThickness = new Thickness(1), BorderBrush = Brushes.Gray };
                            Grid TeamGrid = new Grid()
                            {
                                Tag = liste[i][j].Id
                            };
                            if (liste[i][j].GetGagnant() != null)
                            {
                                if (liste[i][j].GetGagnant() == listTeam[k])
                                {
                                    TeamGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5BC85C"));
                                }
                                else
                                {
                                    TeamGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CFCFC4"));
                                }
                            }
                            RowDefinition TeamColDef = new RowDefinition()
                            {
                                Height = new GridLength(1, GridUnitType.Star)
                            };
                            if (listTeam[0] != null && listTeam[1] != null && liste[i][j].GetGagnant() != listTeam[k] && (liste[i][j].Suivant == null || liste[i][j].Suivant.GetGagnant() == null))
                            {
                                ColumnDefinition TeamDef = new ColumnDefinition()
                                {
                                    MaxWidth = 40,
                                    Width = new GridLength(20, GridUnitType.Star)

                                };
                                TeamGrid.ColumnDefinitions.Add(TeamDef);
                                TeamDef = new ColumnDefinition()
                                {
                                    Width = new GridLength(60, GridUnitType.Star)
                                };
                                TeamGrid.ColumnDefinitions.Add(TeamDef);
                                TeamDef = new ColumnDefinition()
                                {
                                    MaxWidth = 40,
                                    Width = new GridLength(20, GridUnitType.Star)

                                };
                                TeamGrid.ColumnDefinitions.Add(TeamDef);
                                Button TeamButton = new Button()
                                {
                                    Content = (liste[i][j].GetGagnant() == null ? "✔": "⇅"),
                                    Tag = k
                                };
                                TeamButton.Click += new RoutedEventHandler(WinOnClick);
                                Grid.SetColumn(TeamButton, 2);
                                TeamGrid.Children.Add(TeamButton);
                            }
                            else
                            {
                                ColumnDefinition TeamDef = new ColumnDefinition()
                                {
                                    Width = new GridLength(60, GridUnitType.Star)
                                };
                                TeamGrid.ColumnDefinitions.Add(TeamDef);
                            }
                            TextBlock TeamTextBlock = new TextBlock()
                            {
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                Text = (listTeam[k] != null ? listTeam[k].Name : ". . .")
                            };
                            Grid.SetColumn(TeamTextBlock, 1);
                            TeamGrid.Children.Add(TeamTextBlock);
                            g.RowDefinitions.Add(TeamColDef);
                            Grid.SetRow(TeamBorder, k);
                            TeamBorder.Child = TeamGrid;
                            g.Children.Add(TeamBorder);
                        }
                    }
                    else
                    {
                        string txt;
                        if (liste[i][j].Equipe1 != null)
                        {
                            txt = liste[i][j].Equipe1.Name;
                        }
                        else if (liste[i][j].Equipe2 != null)
                        {
                            txt = liste[i][j].Equipe2.Name;
                        }
                        else
                        {
                            txt = ". . .";
                        }
                        TextBlock TeamTextBlock = new TextBlock()
                        {
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Text = txt
                        };
                        Grid.SetColumn(TeamTextBlock, 0);
                        g.Children.Add(TeamTextBlock);
                    }

                    ha.Child = g;

                    Grid.SetRow(ha, j * 2 + 1);

                    col.Children.Add(ha);
                }
                if (i == 0)
                {
                    rd = new RowDefinition() { Height = new GridLength(taille, GridUnitType.Pixel) };
                    col.RowDefinitions.Add(rd);
                }
            }
        }
        private void RetourOnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPrincipal());
        }
        private void StartOnClick(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = false;
            t.Start();
            Generate();
        }
        private void WinOnClick(object sender, RoutedEventArgs e)
        {
            Button btn = ((Button)sender);
            Match m = t.GetMatch(((int)((Grid)btn.Parent).Tag));
            if (btn.Content.Equals("⇅"))
            {
                m.Suivant.RemoveTeam(m.GetGagnant());
            }
            int a = 0, b = 0;
            if (((int)btn.Tag) == 0)
            {
                a = 1;
                m.Suivant.AddTeam(m.Equipe1);
            }
            else
            {
                b = 1;
                m.Suivant.AddTeam(m.Equipe2);
            }
            m.SetScore(a, b);
            Fenetre.SaveData();
            Generate();
        }
    }
}
