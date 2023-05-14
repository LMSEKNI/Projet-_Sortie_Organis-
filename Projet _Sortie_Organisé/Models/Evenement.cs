
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Evenement {
    
    private int idEvent { get; set; }
    private  String Ville { get; set; }
    public float Note { get; set; }
    private DateTime dateDebut { get; set; }
    private DateTime dateFin { get; set; }
    private  int    nombreMax { get; set; }
    private String descriptionEvent { get; set; }
    private String nomEvent { get; set; }
    private float prix { get; set; }

    public Evenement(int id,String Ville, float Note, DateTime dateDebut, DateTime dateFin, int nombreMax,
        String descriptionEvent, String nomEvent, float prix) 
    {   this.idEvent=id; this.Ville=Ville;this.Note = Note;this.dateDebut=dateDebut;this.dateFin=dateFin;
        this.nombreMax = nombreMax; this.descriptionEvent = descriptionEvent; this.nomEvent=nomEvent;
        this.prix=prix;
    }

    

}