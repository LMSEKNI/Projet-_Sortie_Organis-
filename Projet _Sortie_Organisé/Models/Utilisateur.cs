
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Utilisateur : Personne {

    public List<Evenement> evenements;
    public Utilisateur() : base("", "", "", "", "", "") { }

    private void sinscrire(Evenement evenement)
    {
       evenement.utilisateurs.Add(this);
    }

    private void annulerInscription(Evenement evenement)
    {
        evenement.utilisateurs.Remove(this);

    }

}