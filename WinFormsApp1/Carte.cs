namespace WinFormsApp1;

public enum EtatCarte
{
    Cachee,
    Revelee,
    Trouvee
}

public class Carte
{
    public int Id { get; set; }
    public EtatCarte Etat { get; set; }

    public Carte(int id)
    {
        Id = id;
        Etat = EtatCarte.Cachee;
    }
}