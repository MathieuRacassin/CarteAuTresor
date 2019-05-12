using CarteAuTresor;
using CarteAuTresor.Librairie;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarteAuTresorWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string cheminFichier;
        Carte carte;
        string cheminSortie;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Instancie le fichier de configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        cheminFichier = openFileDialog.FileName;
                    }
                }

                System.Windows.Forms.MessageBox.Show(cheminFichier + " enregistré");
                textBlock1.Text = "Le chemin du ficher de configuration est : " + cheminFichier;
                textBox1.Text = cheminFichier;
            }
            catch
            {
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// Lance la chasse au trésor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var filePath = cheminFichier;
            var fileManager = new FileManager(filePath);

            try
            {
                // Lecture du fichier de configuration de la Carte au trésor
                fileManager.FileReader();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Votre fichier de configuration n'a pas été lu, vérifié le !");
            }

            textBlock1.Text += "\n " + " Fichier lu ";
            Thread.Sleep(5000);

            // Création et configuration de la Carte au trésor
            carte = Carte.CreerCarteAuTresor(fileManager);
            textBlock1.Text += "\n" + "La carte au trésor a été crée ";

            carte.ConfigurerCarteAuTresor();
            carte.ConfigurerMontagne(fileManager);
            carte.ConfigurerTresor(fileManager);
            carte.ConfigurerAventurier(fileManager);

            textBlock1.Text += "\n" + "La carte au trésor a été configuré ";

            var nombreAventurier = 0;
            //Lancement de la séquence de mouvement
            foreach (var element in carte.CarteAuTresor)
            {
                if (element.Aventurier != null)
                {
                    element.Aventurier.Position.Xmax = carte.AxeHorizontale;
                    element.Aventurier.Position.Ymax = carte.AxeVerticale;
                    element.Aventurier.JouerSequence();

                    textBlock1.Text += "\n" + element.Aventurier.Nom + " joue sa séquence de mouvement";
                    nombreAventurier++;
                }
                else
                {
                }
            }
        }

        /// <summary>
        /// Instancie le répertoire de sortie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var folderBrowser = new FolderBrowserDialog())
                {
                    DialogResult result = folderBrowser.ShowDialog();

                    if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                    {
                        cheminSortie = folderBrowser.SelectedPath;
                    }
                }

                System.Windows.Forms.MessageBox.Show("Chemin de sortie enregistré");
                textBox2.Text = "Le chemin d'enregistrement : " + cheminSortie;
            }
            catch
            {

            }
        }

        /// <summary>
        /// Ecrit le fichier de sortie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            FileManager.FileTextWriter(carte.EcrireResultatChasseAuTresor(), cheminSortie);

            System.Windows.Forms.MessageBox.Show("Votre fichier a été écrit");

        }
    }
}
