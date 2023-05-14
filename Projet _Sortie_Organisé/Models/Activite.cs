<<<<<<< HEAD
namespace Projet__Sortie_Organisé.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
=======

using System;
using System.Collections.Generic;
>>>>>>> 0834d53b69c9ebe5455e194da6a68b8557666add
using System.Linq;
using System.Text;

public class Activite {


<<<<<<< HEAD
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
=======
    public Activite(int idActivite, TimeOnly heureDebut, TimeOnly heureFin, DateOnly date, string descriptionAct, string nomActivite)
    {
        this.idActivite = idActivite;
        this.heureDebut = heureDebut;
        this.heureFin = heureFin;
        this.date = date;
        this.descriptionAct = descriptionAct;
        this.nomActivite = nomActivite;
    }

    private int idActivite { get; set; }

    private TimeOnly heureDebut { get; set; }

    private TimeOnly heureFin { get; set; }

    private DateOnly date { get; set; }

    private String descriptionAct { get; set; }

    private String nomActivite { get; set; }
>>>>>>> 0834d53b69c9ebe5455e194da6a68b8557666add

    
    
}