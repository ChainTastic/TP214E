using System.Collections.Generic;
using MongoDB.Bson;

namespace TP214E.Data
{
    public interface IDAL
    {
        List<Aliment> Aliments();
        void AjouterAliment(Aliment aliment);
        void ModifierAliment(ObjectId AlimentId, Aliment nouvelleAliment);
        void RetirerAliment(Aliment aliment);
        List<Plat> ObtenirPlats();
        List<Recette> ObtenirRecettes();
        List<Commande> ObtenirCommandes();
        void AjouterPlat(Plat nouveauPlat);
        void AjouterRecette(Recette nouvelleRecette);
        void AjouterCommande(Commande nouvelleCommande);
    }
}