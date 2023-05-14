
using Projet.Models;

namespace Projet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




public class Activite {



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

    public Activite(int idActivite, TimeOnly heureDebut, TimeOnly heureFin, DateOnly date, string descriptionAct, string nomActivite)
    {
        this.idActivite = idActivite;
        this.heureDebut = heureDebut;
        this.heureFin = heureFin;
        this.date = date;
        this.descriptionAct = descriptionAct;
        this.nomActivite = nomActivite;
    }

    


    
    
}