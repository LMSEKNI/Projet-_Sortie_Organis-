using Projet__Sortie_Organis�.Models;
using System.ComponentModel.DataAnnotations;

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

    public virtual ICollection<Activite> activities { get; set; }

    public string cin ;

    public virtual Guide Guide { get; set; }

    public virtual List<Utilisateur> utilisateurs { get; }

}