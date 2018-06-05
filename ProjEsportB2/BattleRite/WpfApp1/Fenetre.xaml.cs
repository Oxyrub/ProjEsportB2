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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour Fenetre.xaml
    /// </summary>
    public partial class Fenetre : Window
    {
        public static Gestion gestion;

        public Fenetre()
        {
            InitializeComponent();
            gestion = new Gestion();
            DataContext = gestion;
            /*gestion = Charger<Gestion>("BattleRiteSave.bin");
            gestion.AddTeam("Virtus Pro");//1
            gestion.AddTeam("Team Liquid");//2
            gestion.AddTeam("PSG.LGD");//3
            gestion.AddTeam("Mineski");//4
            gestion.AddTeam("Evil Geniuses");//5
            gestion.AddTeam("Vici Gaming");//6
            gestion.AddTeam("TnC");//7
            gestion.AddTeam("Newbee");//8
            gestion.AddTeam("Fnatic");//9
            gestion.AddTeam("Team Secret");//10
            gestion.AddTeam("OpTic Gaming");//11
            gestion.AddTeam("FlyToMoon");//12
            gestion.AddTeam("Na'Vi");//13
            gestion.AddTeam("PpaiN Gaming");//14
            gestion.AddTeam("Invictus Gaming");//15
            gestion.AddTeam("OG Dota2");//16
            gestion.AddTeam("VGJ.Thunder");//17
            gestion.AddTournoi("The International 2018" + j, "Rogers Arena, Vancouver, Canada", 3, "Elimination direct", true, "01/01/0001", "17H", "", "");
            gestion.AddTournoi("Worlds 2018", "Corée du Sud", 5, "Elimination direct", true, "01/01/0001", "17H", "", "");
            Tournoi t = gestion.ListTournoi[j];
            for (int i = 0; i < gestion.ListTeams.Count; i++)
            {
                t.AddTeam(gestion.ListTeams[i]);
            }
            t.Start();*/
            for (int j = 0; j < 10; j++)
            {
                for (int k = 0; k < 63; k++) {
                    gestion.AddTeam("T " + j +""+ k);
                }
                gestion.AddTournoi("The International "+(1900 + j), "Rogers Arena, Vancouver, Canada", 3, "Elimination direct", true, "01/01/0001", "17H", "", "");
                Tournoi t = gestion.ListTournoi[j];
                for (int i = 0; i < gestion.ListTeams.Count; i++)
                {
                    t.AddTeam(gestion.ListTeams[i]);
                }
                //t.Start();

                App.Current.Properties["tournoi"] = t;
                laPage.Navigate(new ArbrePage());
            }
            Enregistrer(gestion, "BattleRiteSave.bin");
            App.Current.Properties["gestion"] = gestion;
            laPage.Navigate(new MenuPrincipal());
        }
        private void CloseWindow(object sender, CancelEventArgs e)
        {
            SaveData();
        }
        public static void SaveData()
        {
            Enregistrer(gestion, "BattleRiteSave.bin");
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
