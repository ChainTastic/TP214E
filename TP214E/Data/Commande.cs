using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace TP214E.Data
{
    public class Commande
    {
        private const double TauxTps = 5;
        private const double TauxTvq = 9.975;

        private List<PlatCommande> _platsCommandes;

        public Commande()
        {
            Id = ObjectId.GenerateNewId();
            Date = DateTime.Now;
            _platsCommandes = new List<PlatCommande>();
        }

        public DateTime Date { get; }

        public ObjectId Id { get; set; }

        public List<PlatCommande> PlatsCommandes
        {
            get => _platsCommandes;
            set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentException("Une commande ne peut pas avoir aucun plat.");
                }

                _platsCommandes = value;
            }
        }

        public void RetirerPlat(PlatCommande platCommande)
        {
            PlatsCommandes.Remove(platCommande);
        }

        public void AjouterPlat(PlatCommande platCommande)
        {
            PlatsCommandes.Add(platCommande);
        }

        public double CalculerSousTotal()
        {
            double sousTotal = 0;
            foreach (PlatCommande platCommande in PlatsCommandes)
            {
                sousTotal += platCommande.SousTotal;
            }

            return sousTotal;
        }

        public double CalculerTvq()
        {
            return CalculerSousTotal() * (TauxTvq / 100);
        }

        public double CalculerTps()
        {
            return CalculerSousTotal() * (TauxTps / 100);
        }

        public double CalculerTotal()
        {
            return CalculerSousTotal() + CalculerTps() + CalculerTvq();
        }

        public bool ContientPlat(PlatCommande nouveauPlatCommande)
        {
            foreach (var platCommande in PlatsCommandes)
            {
                if (nouveauPlatCommande.Plat.Id == platCommande.Plat.Id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}