using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace TP214E.Data
{
    public class DAL : IDAL
    {
        public MongoClient mongoDBClient;
        private IMongoCollection<Aliment> collectionAliments;
        private IMongoCollection<Plat> collectionPlats;
        private IMongoCollection<Recette> collectionRecettes;
        private IMongoCollection<Commande> collectionCommandes;

        public DAL()
        {
            mongoDBClient = OuvrirConnexion();
            IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
            collectionAliments = db.GetCollection<Aliment>("Aliments");
            collectionPlats = db.GetCollection<Plat>("Plats");
            collectionRecettes = db.GetCollection<Recette>("Recettes");
            collectionCommandes = db.GetCollection<Commande>("Commandes");
        }

        public List<Aliment> Aliments()
        {
            List<Aliment> aliments = new List<Aliment>();
            try
            {
                aliments = collectionAliments.Aggregate().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return aliments;
        }

        public bool AjouterAliment(Aliment aliment)
        {
            try
            {
                collectionAliments.InsertOne(aliment);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return true;
        }

        public void ModifierAliment(ObjectId AlimentId, Aliment nouvelleAliment)
        {
            try
            {
                FilterDefinition<Aliment> filtre = Builders<Aliment>.Filter.Eq("_id", AlimentId);
                UpdateDefinition<Aliment> modifications = Builders<Aliment>.Update.Set("Nom", nouvelleAliment.Nom)
                    .Set("Quantite", nouvelleAliment.Quantite)
                    .Set("Congele", nouvelleAliment.Congele)
                    .Set("DateExpiration", nouvelleAliment.DateExpiration);
                collectionAliments.UpdateOne(filtre, modifications);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool RetirerAliment(Aliment aliment)
        {
            try
            {
                IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
                IMongoCollection<Aliment> aliments = db.GetCollection<Aliment>("Aliments");
                aliments.FindOneAndDelete(Builders<Aliment>.Filter.Eq("_id", aliment.Id));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return true;
        }

        private MongoClient OuvrirConnexion()
        {
            MongoClient dbClient = null;
            try
            {
                dbClient = new MongoClient("mongodb://localhost:27017/TP2DB");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return dbClient;
        }


        public List<Plat> ObtenirPlats()
        {
            List<Plat> plats = new List<Plat>();
            try
            {
                plats = collectionPlats.Aggregate().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return plats;
        }

        public List<Recette> ObtenirRecettes()
        {
            List<Recette> recettes = new List<Recette>();
            try
            {
                recettes = collectionRecettes.Aggregate().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return recettes;
        }

        public List<Commande> ObtenirCommandes()
        {
            List<Commande> commandes = new List<Commande>();
            try
            {
                commandes = collectionCommandes.Aggregate().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return commandes;
        }

        public bool AjouterPlat(Plat nouveauPlat)
        {
            try
            {
                collectionPlats.InsertOne(nouveauPlat);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

            return true;
        }

        public bool AjouterRecette(Recette nouvelleRecette)
        {
            try
            {
                collectionRecettes.InsertOne(nouvelleRecette);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

            return true;
        }

        public bool AjouterCommande(Commande nouvelleCommande)
        {
            try
            {
                collectionCommandes.InsertOne(nouvelleCommande);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

            return true;
        }
    }
}