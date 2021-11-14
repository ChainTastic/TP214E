using System;
using System.Collections.Generic;
using System.Text;
using TP214E.Interface;

namespace TP214E.Data
{
    public class Inventaire 
    {

        #region Constructor
        public Inventaire(List<Aliment> lstAliments, List<Recette> lstRecettes, List<Commande> commandesTraite, List<Plat> lstPlats)
        {
            LstAliments = lstAliments;
            LstRecettes = lstRecettes;
            LstCommandesTraite = commandesTraite;
            LstPlats = lstPlats;
        }

        public Inventaire()
        {
            LstAliments = new List<Aliment>();
            LstRecettes = new List<Recette>();
            LstCommandesTraite = new List<Commande>();
            LstPlats = new List<Plat>();
        }
        #endregion

        #region Create
        public void AjouterCommande(Commande commande)
        {
            LstCommandesTraite.Add(commande);
        }

        public bool AjouterRecette(Recette recetteAEnregistrer)
        {
            foreach (Recette recette in LstRecettes)
            {
                if (recetteAEnregistrer.Nom == recette.Nom)
                {
                    return false;
                }
            }
            LstRecettes.Add(recetteAEnregistrer);
            return true;
        }

        public bool AjouterAliment(Aliment alimentAEnregistrer)
        {
            foreach (Aliment aliment in LstAliments)
            {
                if (aliment.Nom == alimentAEnregistrer.Nom)
                {
                    return false;
                }
            }
            LstAliments.Add(alimentAEnregistrer);
            return true;
        }

        public bool AjouterPlat(Plat PlatAEnregistrer)
        {
            foreach (Plat plat in LstPlats)
            {
                if (PlatAEnregistrer.Nom == plat.Nom)
                {
                    return false;
                }
            }
            LstPlats.Add(PlatAEnregistrer);
            return true;
        }
        #endregion

        #region Read

        public List<Aliment> LstAliments { get; set; }
        public List<Recette> LstRecettes { get; set; }
        public List<Commande> LstCommandesTraite { get; set; }
        public List<Plat> LstPlats { get; set; }

        #endregion

        #region Update
        public bool ModifierAliment(Aliment aliment)
        {
            int index = LstAliments.FindIndex(alimentMatch => alimentMatch.Id == aliment.Id);
            LstAliments[index] = aliment;
            if (index != -1)
            {
                LstAliments[index] = aliment;
                return true;
            }
            return false;
        }

        public bool ModifierRecette(Recette recette)
        {
            int index = LstRecettes.FindIndex(recetteMatch => recetteMatch.Id == recette.Id);
            LstRecettes[index] = recette;
            if (index != -1)
            {
                LstRecettes[index] = recette;
                return true;
            }
            return false;
        }

        public bool ModifierCommande(Commande commande)
        {
            int index = LstCommandesTraite.FindIndex(commandeMatch => commandeMatch.Id == commande.Id);
            if (index != -1)
            {
                LstCommandesTraite[index] = commande;
                return true;
            }
            return false;
        }

        public bool ModifierPlat(Plat plat)
        {
            int index = LstCommandesTraite.FindIndex(platMatch => platMatch.Id == plat.Id);
            if (index != -1)
            {
                LstPlats[index] = plat;
                return true;
            }
            return false;
        }
        #endregion

        #region Delete
        public bool SupprimerAliment(Aliment aliment)
        {
            return LstAliments.Remove(aliment);
        }

        public bool SupprimerRecette(Recette recette)
        {
            return LstRecettes.Remove(recette);
        }

        public bool SupprimerCommande(Commande commande)
        {
            return LstCommandesTraite.Remove(commande);
        }

        public bool SupprimerCommande(Plat plat)
        {
            return LstPlats.Remove(plat);
        }
        #endregion

        public List<Plat> ConsulterLesPLatsDisponibles()
        {
            List<Plat> lstPlatsDisponible = new List<Plat>();

            foreach (var plat in LstPlats)
            {
                if (plat.VerifierDisponibilite())
                {
                    lstPlatsDisponible.Add(plat);
                }
            }
            return lstPlatsDisponible;
        }


        public Commande CreerCommande(String nomClient,List<Plat> lstPlats)
        {
            Commande commande = new Commande();

            foreach (Plat plat in lstPlats)
            {
                foreach (Ingredient Ingredient in plat.Recette.Ingredients)
                {
                    Ingredient.Aliment.Quantite -= Ingredient.Quantite;

                    ModifierAliment(Ingredient.Aliment);
                }
            }

            LstCommandesTraite.Add(commande);

            return commande;
        }


    }
}
