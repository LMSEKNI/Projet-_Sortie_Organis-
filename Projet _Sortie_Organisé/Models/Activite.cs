namespace Projet__Sortie_Organisé.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Activite
{


    [Key]
    public int idActivite { get; set; }

    [NotMapped]
    public TimeOnly heureDebut { get; set; }

    [NotMapped]
    public TimeOnly heureFin { get; set; }

    [NotMapped]
    public DateOnly date { get; set; }

    public String descriptionAct { get; set; }

    public String nomActivite { get; set; }

    public int idEvent;
    public int idVille;

    public virtual Evenement Event { get; set; }
    public virtual Ville Ville { get; set; }

    

}