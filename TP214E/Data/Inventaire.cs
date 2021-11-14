using System.Collections.Generic;

namespace TP214E.Data
{
    public class Inventaire
    {
        #region Constructor

        public Inventaire(List<Aliment> lstAliments, List<Recette> lstRecettes, List<Commande> commandesTraite,
            List<Plat> lstPlats)
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

        #endregion

        #region Delete

        public bool SupprimerAliment(Aliment aliment)
        {
            return LstAliments.Remove(aliment);
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
    }
}