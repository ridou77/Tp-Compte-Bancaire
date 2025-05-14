using System;

namespace TpCompteBancaire.Entities;

public class CompteBancaire
{
    //atributs
    public double solde;
    
    public int NumCompte { get; }

    public CompteBancaire(int numCompte) {
        
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

}
