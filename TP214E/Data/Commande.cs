using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shell;
using MongoDB.Bson;
using TP214E.Interface;

namespace TP214E.Data
{
    public class Commande
    {
        private const double TauxTPS = 5;
        private const double TauxTVQ = 9.975;

        public Commande()
        {
            Id = ObjectId.GenerateNewId();
            Date = DateTime.Now;
            PlatsCommandes = new List<PlatCommande>();
        }

        public double Total { get; set; }

        public double TVQ { get; set; }

        public double TPS { get; set; }

        public double SousTotal { get; set; }

        public DateTime Date { get; set; }

        public ObjectId Id { get; set; }

        public List<PlatCommande> PlatsCommandes { get; set; }

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

        public double CalculerTVQ()
        {
            return SousTotal * (TauxTVQ / 100);
        }

        public double CalculerTPS()
        {
            return SousTotal * (TauxTPS / 100);
        }

        public double CalculerTotal()
        {
            return SousTotal + TPS + TVQ;
        }
    }
}