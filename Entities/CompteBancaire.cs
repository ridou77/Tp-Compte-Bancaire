using System;

namespace TpCompteBancaire.Entities;

public class CompteBancaire
{
    //atributs
    
    private int NumCompte
    {
        get;
    }

    public CompteBancaire(string titulaire, int numCompte) {
        
        this.NumCompte = numCompte;

    }

}
