using System;

namespace TpCompteBancaire.Entities;

public class CompteBancaire
{
    //atributs
    public double solde;

    public static int compteurCompte;
    
    public int NumCompte { get; }

    public int TituId;

    public CompteBancaire(int numCompte, int titulaireId) {
        
        TituId = titulaireId;
        compteurCompte ++;
        NumCompte = compteurCompte;
        this.NumCompte = numCompte;
    }

    public void AjouterSolde(double solde)
    {
        if(solde < 0) {
            Console.WriteLine("vous ne pouvez pas ajouter de solde négatif");
            return;
        }
        this.solde += solde;
    }

    public void RetirerSolde(double solde)
    {
        this.solde -= solde;
    }

    public void AfficherSolde(double solde)
    {
        Console.WriteLine($"Titulaire : {solde}");
    }

}
