using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Guide : Personne {

   
    public virtual ICollection<Evenement> evenements { get; set; }

    public Guide(string cin, string nom, string prenom, string email, string mdp, string numTel) : base(cin, nom, prenom, email, mdp, numTel)
    {
        evenements = new List<Evenement>();
    }

   

}