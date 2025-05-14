namespace TpCompteBancaire.Entities;

public class AppBanque
{

    bool continuer = true;
    private List<Titulaire> listeTitulaires;
    private List<CompteBancaire> listeComptes;
    public AppBanque()
    {
        listeTitulaires = new List<Titulaire>();
        listeComptes = new List<CompteBancaire>();
    }

    public void init()
    {
        while (continuer)
        {
            Console.WriteLine("Bienvenu dans votre espace de GEstion d'étudiant.");
            Console.WriteLine(" --------------------------");
            Console.WriteLine("| Que voulez vous faire ?  |");
            Console.WriteLine("| 1. Ajouter un titulaire  |");
            Console.WriteLine("| 2. Liste des Titulaires  |");
            Console.WriteLine("| 3. Choisir le titulaire  |");
            Console.WriteLine("| 4. Choisir le compte     |");
            Console.WriteLine("| 5. Quitter l'application |");
            Console.WriteLine(" --------------------------");
            Console.Write("Veuillez entrer votre choix : ");

            //lire le choix de l'utilisateur
            string choix = Console.ReadLine();

            try
            {
                switch (choix)
                {
                    case "1":
                        AjouterTitulaire();
                        break;
                    case "2":
                        ListTitulaire();
                        break;
                    case "3":
                        ChoisirTitulaire();
                        break;
                    case "4":
                        AjouterCompte();
                        break;
                    case "5":
                        continuer = false;
                        Console.WriteLine("Merci d'avoir utilisé l'application. À bientôt !");
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"erreur lors de l'affichage du menu : {e.Message}");
            }
        }
    }

    public void AjouterTitulaire()
    {
        Console.WriteLine("\n--- Ajout d'un titulaire ---");

        string nom = Console.ReadLine();

        // Creation d'un nouveau titulaire
        Titulaire nouveauTitulaire = new Titulaire(nom);
        listeTitulaires.Add(nouveauTitulaire);

        Console.WriteLine($"Le titulaire {nom} a été ajouté avec succès.");
    }

    public void AjouterCompte()
    {
        Console.WriteLine("\n--- Ajout d'un commpte bancaire ---");
        int numCompte = int.Parse(Console.ReadLine());

        CompteBancaire nouveauCompte = new CompteBancaire(numCompte);
        listeComptes.Add(nouveauCompte);

        Console.Write("Veuillez entrer le solde initial : ");
        double solde = double.Parse(Console.ReadLine());

        Console.WriteLine($"Le compte numéro : {numCompte} à été ajouté");
    }

    public void ChoisirTitulaire()
    {
        if (listeTitulaires.Count == 0)
        {
            Console.WriteLine("Aucun titulaire enregistré.");
            return;
        }

        for (int i = 0; i < listeTitulaires.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {listeTitulaires[i].Nom}");
        }

        Console.WriteLine("Selectionnez un titulaire (numero)");

        try
        {
            int index = Convert.ToInt32(Console.ReadLine()) - 1;

            if (index >= 0 && index < listeTitulaires.Count)
            {
                Titulaire tituSelectionne = listeTitulaires[index];

                Console.WriteLine($"Vous avez selectionné le titulaire {tituSelectionne.Nom}, ");
                Console.WriteLine($" Tapez 1 pour voir vos comptes");

                // Readline -> entier
                string choix = Console.ReadLine();
                // verifie la valeur 
                if (choix != "1")
                {
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
                    return;
                }

                if (choix == "1")
                {
                    ChoisirCompte();// fonction pas encore créée
                }
            }
        }
        catch (FormatException)
        {

            throw;
        }
    }

    public void ChoisirCompte()
    {
        //verifiecation si un compte existe
        if (listeComptes.Count == 0)
        {
            Console.WriteLine("Le titulaire choisi ne possede encore aucun compte.");
            return;
        }

        // affichage des comptes du titulaire selectionné

        for (int i = 0; i < listeComptes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {listeComptes[i].NumCompte}");
        }

        Console.WriteLine("Selectionnez un titulaire (numero)");
        //choix du compte du titulaire
        try
        {
            int index = Convert.ToInt32(Console.ReadLine()) - 1;

            if (index >= 0 && index > listeComptes.Count)
            {
                CompteBancaire compteSelectionne = listeComptes[index];

                Console.WriteLine($"Vous avez selectionné le compte numéro {compteSelectionne.NumCompte}, ");


                //affichage du solde du compte
                Console.WriteLine($" Tapez 1 pour consulter votre solde ");

                //modification du solde du compte
                Console.WriteLine($" Tapez 2 pour crediter votre solde");
                Console.WriteLine($" Tapez 3 pour retirer une partie de votre solde");

                // Readline -> entier
                string choix = Console.ReadLine();
                // verifie la valeur 
                if (choix != "1" && choix != "2" && choix != "3")
                {
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
                    return;
                }

                // si 1 t
                if (choix == "1")
                {
                    //AfficherSolde(); fonction a faire pour afficher le solde du compte choisi
                }

                // si 2 
                if (choix == "2")
                {
                    Console.Write("Veuillez entrer le montant à créditer : ");
                    double montant = double.Parse(Console.ReadLine());
                    compteSelectionne.AjouterSolde(montant);
                    Console.WriteLine("Votre solde à été mis à jour");
                }

                // si 3
                if (choix == "3")
                {
                    Console.WriteLine("Veuillez indiquer la somme à décréditer :");
                    double montant = double.Parse(Console.ReadLine());
                    compteSelectionne.RetirerSolde(montant);
                    Console.WriteLine("Votre solde à été mis à jour");
                }
            }
        }
        catch (FormatException)
        {

            throw;
        }
    }

    public void ListTitulaire()
    {
        foreach (Titulaire titulaire in listeTitulaires)
        {
            titulaire.AfficherInfo();
            Console.WriteLine("-----------------------------");
        }
    }
}
