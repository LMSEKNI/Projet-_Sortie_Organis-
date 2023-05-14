
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Ville {

    
    public Ville(int idVille, string nomVille, string codePostal)
    {
        this.idVille = idVille;
        this.nomVille = nomVille;
        this.codePostal = codePostal;
    }

    private int idVille { get; set; }

    private String nomVille { get; set; }

    private String codePostal { get; set; }

}