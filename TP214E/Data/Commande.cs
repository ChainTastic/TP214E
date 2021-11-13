using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using TP214E.Interface;

namespace TP214E.Data
{
    public class Commande
    {
        public Commande()
        {
            Id = ObjectId.GenerateNewId();
            Date = DateTime.Now;
            PlatsCommandes = new List<PlatCommande>();
        }

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
    }
}
