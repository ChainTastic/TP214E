using System.Collections.Generic;
using MongoDB.Bson;

namespace TP214E.Data
{
    public interface IDAL
    {
        List<Aliment> Aliments();
        bool AjouterAliment(Aliment aliment);
        void ModifierAliment(ObjectId AlimentId, Aliment nouvelleAliment);
        bool RetirerAliment(Aliment aliment);
        List<Plat> ObtenirPlats();
        List<Recette> ObtenirRecettes();
        List<Commande> ObtenirCommandes();
        bool AjouterPlat(Plat nouveauPlat);
        bool AjouterRecette(Recette nouvelleRecette);
        bool AjouterCommande(Commande nouvelleCommande);
    }
}