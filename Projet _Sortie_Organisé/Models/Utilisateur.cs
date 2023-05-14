
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Utilisateur : Personne {

    List<Evenement> evenements;
    public Utilisateur(string cin, string nom, string prenom, string email, string mdp, string numTel) : base(cin, nom, prenom, email, mdp, numTel)
    {
        evenements = new List<Evenement>();
    }

    private void sinscrire(Evenement evenement)
    {
       evenement.utilisateurs.Add(this);
    }

    private void annulerInscription(Evenement evenement)
    {
        evenement.utilisateurs.Remove(this);

    }

}