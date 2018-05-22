using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MonSingleton saveData = new MonSingleton();
        public Gestion gestion;


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            gestion = (Gestion)App.Current.Properties["gestion"];
            ListBoxActu();
        }

        public void AddTeam(object sender, RoutedEventArgs e)
        {
            saveData.ListTeam.Add(gestion.GetTeam((int)((ListBoxItem)ListBoxTeam.SelectedValue).Tag));
            ListBoxActu();
        }
        public void ListBoxActu()
        {
            ListBoxTeam.Items.Clear();
            for (int i = 0; i<gestion.ListTeams.Count; i++)
            {
                if (!saveData.Participe(gestion.ListTeams[i].Id))
                {
                    ListBoxTeam.Items.Add(new ListBoxItem
                    {
                        Tag = gestion.ListTeams[i].Id,
                        Content = gestion.ListTeams[i].Name
                    });
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int idCreated = gestion.AddTournoi(saveData.Name, saveData.Lieu, saveData.NbBo, saveData.TypeMatch, saveData.Remplacement, saveData.Date, saveData.Heure, saveData.DescRegle, saveData.DescInfo);
            for (int i = 0; i < saveData.ListTeam.Count; i++)
            {
                gestion.GetTournoi(idCreated).AddTeam(saveData.ListTeam[i]);
            }
            MessageBox.Show("Tournoi créé");
        }

        private void AfficherVal(object sender, RoutedEventArgs e)
        {
            /*MessageBox.Show(Convert.ToString(saveData.NbBo));
            MessageBox.Show(saveData.TypeMatch);
            MessageBox.Show(saveData.TypeTournoi);
            //MessageBox.Show(saveData.Remplacement);
            MessageBox.Show(saveData.DescInfo);
            MessageBox.Show(saveData.Name);
            MessageBox.Show(saveData.Lieu);
            MessageBox.Show(saveData.Date);
            MessageBox.Show(saveData.Heure);
            MessageBox.Show(saveData.DescRegle);*/

            App.Current.Properties["gestion"] = gestion;

            MenuPrincipal main = new MenuPrincipal();
            App.Current.MainWindow = main;
            this.Close();
            main.Show();

        }

        private void CheckedBo(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton == null)
                return;
            saveData.NbBo = Convert.ToInt32(radioButton.Content.ToString());
        }
        private void CheckedMatch(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton == null)
                return;
            saveData.TypeMatch = radioButton.Content.ToString();
        }
        private void CheckedTournoi(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton == null)
                return;
            saveData.TypeTournoi = radioButton.Content.ToString();
        }
        private void CheckedRempla(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton == null)
                return;
            saveData.Remplacement = (radioButton.Content.ToString() == "Oui" ? true : false);
        }

        private void TexteChange(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
                return;
            saveData.DescInfo = textBox.Text;
        }

        private void TextRules(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
                return;
            saveData.DescRegle = textBox.Text;
        }

        private void LieuChange(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
                return;
            saveData.Lieu = textBox.Text;
        }

        private void HeureChange(object sender, MouseEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox == null)
                return;
            saveData.Heure = comboBox.Text;
        }

        private void DateChange(object sender, MouseEventArgs e)
        {
            var datePicker = sender as DatePicker;
            if (datePicker == null)
                return;
            saveData.Date = datePicker.Text;
        }

        private void NameChange(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
                return;
            saveData.Name = textBox.Text;
        }

        private void CreatEquipe(object sender, RoutedEventArgs e)
        {
            addTeam add = new addTeam();
            add.Show();
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
        private void CloseWindow(object sender, CancelEventArgs e)
        {
            Enregistrer(gestion, "BattleRiteSave.bin");
        }
    }
}
