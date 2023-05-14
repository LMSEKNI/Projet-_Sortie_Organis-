
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

public abstract class Personne {

    public Personne(string cin, string nom, string prenom, string email, string mdp, string numTel)
    {
        this.cin = cin;
        this.nom = nom;
        this.prenom = prenom;
        this.email = email;
        this.mdp = mdp;
        this.numTel = numTel;

    }

    [Key]
    public string cin { get; set; }

    protected string nom { get; set; }

    protected string prenom { get; set; }

    protected string email { get; set; }

    protected string mdp { get; set; }

    protected string numTel { get; set; }

}