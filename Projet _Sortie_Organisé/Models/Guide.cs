
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Guide : Personne {

    List<Evenement> evenements;

    public Guide(string cin, string nom, string prenom, string email, string mdp, string numTel) : base(cin, nom, prenom, email, mdp, numTel)
    {
        evenements = new List<Evenement>();
    }

    private void creerEvenement(Evenement evenement)
    {
        evenements.Add(evenement);
    }

    private void supprimerEvenement(Evenement evenement)
    {
        evenements.Remove(evenement);
    }

}