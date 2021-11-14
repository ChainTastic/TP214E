using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Windows;
using MongoDB.Bson;

namespace TP214E.Data
{
    public class DAL : IDAL
    {
        public MongoClient MongoDbClient;
        private readonly IMongoCollection<Aliment> _collectionAliments;
        private readonly IMongoCollection<Plat> _collectionPlats;
        private readonly IMongoCollection<Recette> _collectionRecettes;
        private readonly IMongoCollection<Commande> _collectionCommandes;

        public DAL()
        {
            MongoDbClient = OuvrirConnexion();
            IMongoDatabase db = MongoDbClient.GetDatabase("TP2DB");
            _collectionAliments = db.GetCollection<Aliment>("Aliments");
            _collectionPlats = db.GetCollection<Plat>("Plats");
            _collectionRecettes = db.GetCollection<Recette>("Recettes");
            _collectionCommandes = db.GetCollection<Commande>("Commandes");
        }

        public List<Aliment> Aliments()
        {
            List<Aliment> aliments = new List<Aliment>();
            try
            {
                aliments = _collectionAliments.Aggregate().ToList();
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
                _collectionAliments.InsertOne(aliment);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return true;
        }

        public void ModifierAliment(ObjectId alimentId, Aliment nouvelleAliment)
        {
            try
            {
                FilterDefinition<Aliment> filtre = Builders<Aliment>.Filter.Eq("_id", alimentId);
                UpdateDefinition<Aliment> modifications = Builders<Aliment>.Update.Set("Nom", nouvelleAliment.Nom)
                    .Set("Quantite", nouvelleAliment.Quantite)
                    .Set("Congele", nouvelleAliment.Congele)
                    .Set("DateExpiration", nouvelleAliment.DateExpiration);
                _collectionAliments.UpdateOne(filtre, modifications);
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
                IMongoDatabase db = MongoDbClient.GetDatabase("TP2DB");
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
                plats = _collectionPlats.Aggregate().ToList();
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
                recettes = _collectionRecettes.Aggregate().ToList();
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
                commandes = _collectionCommandes.Aggregate().ToList();
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
                _collectionPlats.InsertOne(nouveauPlat);
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
                _collectionRecettes.InsertOne(nouvelleRecette);
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
                _collectionCommandes.InsertOne(nouvelleCommande);
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