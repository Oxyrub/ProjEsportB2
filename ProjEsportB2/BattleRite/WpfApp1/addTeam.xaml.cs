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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour addTeam.xaml
    /// </summary>
    public partial class addTeam : Window
    {
        public MonSingleton saveData = new MonSingleton();
        public Gestion gestion;

        public addTeam()
        {
            gestion = (Gestion)App.Current.Properties["gestion"];
            InitializeComponent();
        }

        private void AjoutEquipe(object sender, RoutedEventArgs e)
        {
            gestion.AddTeam(saveData.NomEquipe);

            MessageBox.Show("Equipe créé");
        }

        private void NomChange(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
                return;
            saveData.NomEquipe = textBox.Text;
        }
    }
}
