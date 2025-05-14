using System;

namespace TpCompteBancaire.Entities;

public class Titulaire
{
    public string Nom { get; set; }
    private double solde;
    public Titulaire(string nom, double solde)
    {
        this.Nom = nom;
        this.solde = solde;
    }

    public void AfficherInfo()
    {
        Console.WriteLine($"Titulaire : {Nom}, Solde: {solde} €");
    }

    public void AjouterSolde(double solde)
    {
        if(solde > 0) {
            Console.WriteLine("vous ne pouvez pas ajouter de solde négatif");
            return;
        }
        this.solde += solde;
    }

    public void RetirerSolde(double solde)
    {
        this.solde -= solde;
    }
}
