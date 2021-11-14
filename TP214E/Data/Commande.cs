using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shell;
using System.Xml.Schema;
using MongoDB.Bson;
using TP214E.Interface;

namespace TP214E.Data
{
    public class Commande
    {
        private const double TauxTPS = 5;
        private const double TauxTVQ = 9.975;

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
            get
            {
                return _platsCommandes;
            }
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

        public double CalculerTVQ()
        {
            return CalculerSousTotal() * (TauxTVQ / 100);
        }

        public double CalculerTPS()
        {
            return CalculerSousTotal() * (TauxTPS / 100);
        }

        public double CalculerTotal()
        {
            return CalculerSousTotal() + CalculerTPS() + CalculerTVQ();
        }
    }
}