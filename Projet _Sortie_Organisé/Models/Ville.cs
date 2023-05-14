namespace Projet__Sortie_Organisé.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Ville
{




    [Key]
    public int idVille { get; set; }

    public String nomVille { get; set; }

    public String codePostal { get; set; }

    public virtual ICollection<Activite> Activites { get; set; }

    public Ville(int idVille, string nomVille, string codePostal)
    {
        this.idVille = idVille;
        this.nomVille = nomVille;
        this.codePostal = codePostal;
    }

}