using System;

namespace TpCompteBancaire.Entities;

public class Titulaire
{
    public string Nom { get; set; }
    public Titulaire(string nom)
    {
        this.Nom = nom;
    }

    public void AfficherInfo()
    {
        Console.WriteLine($"Titulaire : {Nom}");
    }

    
}
