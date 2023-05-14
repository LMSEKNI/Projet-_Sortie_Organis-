
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Activite {


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

    
    
}