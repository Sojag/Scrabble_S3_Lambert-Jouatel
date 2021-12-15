using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scabble_JOUATEL
{
    class Joueur
    {
        private string nom; //declaration des champs (variables)
        private int score;
        private List<string> motsTrouvés;
        private List<Jetons> main;
        bool estIA;


        public bool EstIA //propriétés - définition des accès en consultation
        {
            get { return this.estIA; }
        }
        public string Nom
        {
            get { return this.nom; }
        }
        public int Score
        {
            get { return this.score; }
        }
        public List<string> MotsTrouvés
        {
            get { return this.motsTrouvés; }
        }
        public List<Jetons> Main
        {
            get { return this.main; }
            set { this.main = value; }
        }

        /// <summary>
        /// Initialise un nouveau joueur (pour une nouvelle partie)
        /// </summary>
        /// <param name="nom"></param>
        public Joueur(string nom)
        {
            this.nom = nom;
            this.score = 0;
            this.motsTrouvés = new List<string>();
            this.main = new List<Jetons>();
            this.estIA = false;
        }

        /// <summary>
        /// Initialise un nouveau joueur permettant de choisir son caractère IA ou non
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="estIA"></param>
        public Joueur(string nom, bool estIA)
        {
            this.nom = nom;
            this.score = 0;
            this.motsTrouvés = new List<string>();
            this.main = new List<Jetons>();
            this.estIA = estIA;
        }

        /// <summary>
        /// Initialise un joueur à partir d'une sauvegarde pour restaurer son nom, son score, les mots qu'il a trouvé, sa main, et si c'est une IA ou non
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="score"></param>
        /// <param name="motsTrouvés"></param>
        /// <param name="main"></param>
        /// <param name="estIA"></param>
        public Joueur(string nom, int score, List<string> motsTrouvés, List<Jetons> main, bool estIA)
        {
            this.nom = nom;
            this.score = score;
            this.motsTrouvés = motsTrouvés;
            this.main = main;
            this.estIA = estIA;
        }

        /// <summary>
        /// Ajoute un jeton dans la main du joueur
        /// </summary>
        /// <param name="monjeton"></param>
        public void Add_Main_Courante(Jetons monjeton)
        {
            this.main.Add(monjeton);
        }

        /// <summary>
        /// Ajoute une valeur au score du joueur
        /// </summary>
        /// <param name="val"></param>
        public void Add_Score(int val)
        {
            this.score += val;
        }

        /// <summary>
        /// Ajoute le mot dans l'historique des mots trouvés
        /// </summary>
        /// <param name="mot"></param>
        public void Add_Mot(string mot)
        {
            this.motsTrouvés.Add(mot);
        }

        /// <summary>
        /// Retire un jeton de la main du joueur
        /// </summary>
        /// <param name="monjeton"></param>
        public void Remove_Main_Courante(Jetons monjeton)
        {
            this.main.Remove(monjeton);
        }

        /// <summary>
        /// Retourne une chaine de caractère décrivant le joueur
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string leToString = "";
            leToString += nom + " a un score de 0";  // Nom et score
            if (this.estIA)
            {
                leToString += " (C'est une IA)"; // Si c'est une IA
            }
            leToString += '\n';
            leToString += "Contenu de sa main : ";

            for (int i = 0; i < this.main.Count; i++) // Jetons de la main
            {
                leToString += this.main[i].Lettre + ", ";
            }

            return leToString;
        }
    }
}
