
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Admin : Personne
{
    public Admin() : base("", "", "", "", "", "") { }
    public Admin(string cin, string nom, string prenom, string email, string mdp, string numTel) : base(cin, nom, prenom, email, mdp, numTel)
    {
    }
}