using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Utilisateur : Personne {

    public virtual ICollection<Evenement> evenements { get; set; }
    public Utilisateur(string cin, string nom, string prenom, string email, string mdp, string numTel) : base(cin, nom, prenom, email, mdp, numTel)
    {
        evenements = new List<Evenement>();
    }

   
}