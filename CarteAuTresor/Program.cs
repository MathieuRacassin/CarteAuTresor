using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteAuTresor.Librairie;
using CarteAuTresor.Librairie.Outils;

namespace CarteAuTresor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lecture du fichier de configuration de la Carte au trésor
            var filePath = @"C:\Projects\CarteAuTresor\CarteAuTresorUnitTest\EntreCarteTest.txt";
            var fileManager = new FileManager(filePath);
            fileManager.FileReader();

            Console.WriteLine("Lecture du fichier de configuration");

            // Création et configuration de la Carte au trésor
            var carte = Carte.CreerCarteAuTresor(fileManager);
            carte.ConfigurerCarteAuTresor();
            carte.ConfigurerMontagne(fileManager);
            carte.ConfigurerTresor(fileManager);
            carte.ConfigurerAventurier(fileManager);

            Console.WriteLine("Carte configurée");

            var nombreAventurier = 0;
            //Lancement de la séquence de mouvement
            foreach(var element in carte.CarteAuTresor)
            {
                if (element.Aventurier !=null)
                {
                    element.Aventurier.Position.Xmax = carte.AxeHorizontale;
                    element.Aventurier.Position.Ymax = carte.AxeVerticale;
                    element.Aventurier.JouerSequence();
                    Console.WriteLine(element.Aventurier.Nom + " joue sa séquence de mouvement");
                    nombreAventurier++;
                }
                else
                {
                    //Console.WriteLine("Aucun aventurier");
                }
            }
            
            FileManager.FileTextWriter(carte.EcrireResultatChasseAuTresor(), @"C:\Projects\CarteAuTresor\CarteAuTresorUnitTest\");

            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
