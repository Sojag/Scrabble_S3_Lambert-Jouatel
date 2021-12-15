using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Scabble_JOUATEL
{
    class Dictionnaire
    {
        string[][] GODZILLA; // Le seul attribut sera un tableau de tableaux. Chaque tableau contiendra tous les mots d'une longueur donnée, rangée par taille de mots et par ordre alphabétique.
        
        /// <summary>
        /// Ce constructeur unique lira le fichier "Français.txt" trouvé dans l'ordinateur pour remplir le tableau de tableaux
        /// </summary>
        
        public Dictionnaire()
        {
            string fullpath = Path.GetFullPath("Francais.txt"); // accéder au chemin complet (non spécifique à un seul ordinateur)
            List<string> toutesLesLignes = new List<string>();
            try
            {
                //Créez une instance de StreamReader pour lire à partir d'un fichier
                using (StreamReader sr = new StreamReader(fullpath))
                {
                    string line;
                    // Lire les lignes du fichier jusqu'à la fin.
                    while ((line = sr.ReadLine()) != null)
                    {
                        toutesLesLignes.Add(line); // toutes les lignes lues sont rangées dans cette liste
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Le fichier n'a pas pu être lu.");
                Console.WriteLine(e.Message);
            }

            string[][] GODZILLA = new string[14][]; // On crée le 14 tableaux de tableaux (un par taille de mots possible)
            for(int i = 0; i < toutesLesLignes.Count; i+=2) // Pour une ligne sur deux,
                GODZILLA[i/2] = toutesLesLignes[i + 1].Split(' '); // on met tous les mots de la ligne dans le tableau correspondant
            this.GODZILLA = GODZILLA;
        }

        /// <summary>
        /// Cherche le mot entré en paramètre automatiquement dans le dictionnaire associé
        /// </summary>
        /// <param name="mot"></param>
        /// <param name="début"></param>
        /// <param name="fin"></param>
        /// <returns> vrai s'il existe, faux sinon </returns>
        public bool RechDichoRecursif(string mot, int début = 0, int fin = -1)
        {
            if (mot == null) // Si la variable ne retient rien, on revoie faux
                return false;
            else if (mot.Length < 2 || mot.Length > 15) // Si la longueur du mot dépasse 15 lettres ou est inférieure à 2 lettres, on renvoie faux
                return false;
            else if (fin == -1) // Si fin est à -1, donc non initialisée, on la met à la longueur du tableau correspondant
                fin = this.GODZILLA[mot.Length - 2].Length;
            else if (début >= fin) // Si fin est initialisée mais que le mot n'a quand même pas été trouvé, on renvoie faux
                return false;

            string motEnMajuscule = mot.ToUpper(); // Par sécurité on met le mot en majuscule
            int milieuDynamique = (début + fin) / 2; // on met la valeur du milieu dynamique entre début et fin
            if (this.GODZILLA[mot.Length - 2][milieuDynamique] == motEnMajuscule) // Si le mot est trouvé, on renvoie vrai
                return true;
            else if (String.Compare(mot, this.GODZILLA[mot.Length - 2][milieuDynamique]) < 0) // sinon, on compare les deux mots alphabétiquement
                return RechDichoRecursif(mot, début, milieuDynamique - 1); // Si le mot à tester précède le mot du milieu, le milieu remplace la fin
            else
                return RechDichoRecursif(mot, milieuDynamique + 1, fin); // Sinon, le milieu remplace le début

        }

        /// <summary>
        /// Décrit le dictionnaire en donnant le nombre de mots par nombre de lettres qu'ils contiennent
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string leRetourDeGodzilla = "";
            for (int i = 0; i < this.GODZILLA.Length; i++) 
            {
                Console.WriteLine(i);
                leRetourDeGodzilla += "Il y a " + this.GODZILLA[i][0].Length + " mots à " + (i + 2) + " lettres :" + '\n';
                leRetourDeGodzilla += '\n';
            }
            return leRetourDeGodzilla;
        }
    }
}
