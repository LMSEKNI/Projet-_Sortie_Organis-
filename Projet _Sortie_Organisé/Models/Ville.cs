<<<<<<< HEAD
namespace Projet__Sortie_Organisé.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
=======

using System;
using System.Collections.Generic;
>>>>>>> 0834d53b69c9ebe5455e194da6a68b8557666add
using System.Linq;
using System.Text;

public class Ville {

    
<<<<<<< HEAD

    [Key]
    public int idVille { get; set; }

    public String nomVille { get; set; }

    public String codePostal { get; set; }

    public virtual ICollection<Activite> Activites { get; set; }
=======
    public Ville(int idVille, string nomVille, string codePostal)
    {
        this.idVille = idVille;
        this.nomVille = nomVille;
        this.codePostal = codePostal;
    }

    private int idVille { get; set; }

    private String nomVille { get; set; }

    private String codePostal { get; set; }
>>>>>>> 0834d53b69c9ebe5455e194da6a68b8557666add

}