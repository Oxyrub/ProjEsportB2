using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Page
    {
        public Tournoi t;
        public EditWindow()
        {
            InitializeComponent();
            t = (Tournoi)App.Current.Properties["tournoi"];
            Title.Content = t.Nom;
            SubTitle.Content = "à " + t.Lieu + " avec " + t.ListTeam.Count + " participants";
            if (t.ListMatch.Count > 0)
            {
                StartButton.IsEnabled = false;
                ActualiserListBox();
            }
            //t.GetArbre();
        }
        public void StratTournoi(object sender, RoutedEventArgs e)
        {
            t.Start();
            ActualiserListBox();
            StartButton.IsEnabled = false;
        }
        private void OnSelected(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)sender;
            Match m = t.GetMatch((int)item.Tag);
            Equipe1.Content = m.Equipe1.Name;
            Equipe2.Content = m.Equipe2.Name;
            Score1.Text = m.ScoreTeam1.ToString();
            Score2.Text = m.ScoreTeam2.ToString();
            Editor1.Visibility = Visibility.Visible;
            Editor2.Visibility = Visibility.Visible;
            ValideButton.IsEnabled = true;
            ListBoxMatchs.Tag = m.Id;
        }
        private void ActualiserListBox()
        {
            ListBoxMatchs.Items.Clear();
            List<Match> listeMatch = t.GetMatchNotEnded();
            for (int i = 0; i < listeMatch.Count; i++)
            {
                Match m = listeMatch[i];
                ListBoxItem item = new ListBoxItem
                {
                    Tag = m.Id,
                    Content = m.Equipe1.Name + " / " + m.Equipe2.Name
                };
                item.Selected += OnSelected;
                ListBoxMatchs.Items.Add(item);
            }
        }
        private void Moins1(object sender, RoutedEventArgs e)
        {
            if (t.GetMatch((int)ListBoxMatchs.Tag).ScoreTeam1 - 1 > -1)
            {
                t.GetMatch((int)ListBoxMatchs.Tag).ScoreTeam1--;
                Score1.Text = t.GetMatch((int)ListBoxMatchs.Tag).ScoreTeam1.ToString();
            }
        }
        private void Plus1(object sender, RoutedEventArgs e)
        {
            if (t.GetMatch((int)ListBoxMatchs.Tag).ScoreTeam1 + t.GetMatch((int)ListBoxMatchs.Tag).ScoreTeam2 < t.Bo)
            {
                t.GetMatch((int)ListBoxMatchs.Tag).ScoreTeam1++;
                Score1.Text = t.GetMatch((int)ListBoxMatchs.Tag).ScoreTeam1.ToString();
            }
        }
        private void Moins2(object sender, RoutedEventArgs e)
        {
            if (t.GetMatch((int)ListBoxMatchs.Tag).ScoreTeam2 - 1 > -1)
            {
                t.GetMatch((int)ListBoxMatchs.Tag).ScoreTeam2--;
                Score2.Text = t.GetMatch((int)ListBoxMatchs.Tag).ScoreTeam2.ToString();
            }
        }
        private void Plus2(object sender, RoutedEventArgs e)
        {
            if (t.GetMatch((int)ListBoxMatchs.Tag).ScoreTeam1 + t.GetMatch((int)ListBoxMatchs.Tag).ScoreTeam2 < t.Bo)
            {
                t.GetMatch((int)ListBoxMatchs.Tag).ScoreTeam2++;
                Score2.Text = t.GetMatch((int)ListBoxMatchs.Tag).ScoreTeam2.ToString();
            }
        }
        private void SaveScore(object sender, RoutedEventArgs e)
        {
            Match m = t.GetMatch((int)ListBoxMatchs.Tag);
            if (m.ScoreTeam1 + m.ScoreTeam2 == t.Bo || m.ScoreTeam1 > t.Bo/2 || m.ScoreTeam2 > t.Bo/2)
            {
                t.GetMatch((int)ListBoxMatchs.Tag).SetScore(int.Parse(Score1.Text), int.Parse(Score2.Text));
                if (m.Suivant != null) m.Suivant.AddTeam(t.GetMatch((int)ListBoxMatchs.Tag).GetGagnant());
                Editor1.Visibility = Visibility.Hidden;
                Editor2.Visibility = Visibility.Hidden;
                ValideButton.IsEnabled = false;
                ActualiserListBox();
            }
        }
        private void RetourOnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPrincipal());
        }
    }
}
