using System;

namespace TpCompteBancaire.Entities;

public class Titulaire
{

    
    private static int compteur;
    public int Id { get; set; }
    public string Nom { get; set; }

    public Titulaire(string nom)
    {
        compteur++;
        Id = compteur;
        this.Nom = nom;

    }

    public void AfficherInfo()
    {
        Console.WriteLine($"Titulaire : {Nom}");
    }

    
}
