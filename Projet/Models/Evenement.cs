using Projet.Models;
using System.ComponentModel.DataAnnotations;
using Projet.Models;

public class Evenement
{

    [Key]
    public int idEvent { get; set; }
    
    public String Ville { get; set; }

    public float Note { get; set; }

    public DateTime dateDebut { get; set; }

    public DateTime dateFin { get; set; }

    public int nombreMax { get; set; }

    public String descriptionEvent { get; set; }

    public String nomEvent { get; set; }

    public float prix { get; set; }
    
    public String type { get; set; }

    public virtual ICollection<Activite> Activities { get; set; }
}