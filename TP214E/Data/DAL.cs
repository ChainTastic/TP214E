using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Windows;
using MongoDB.Bson;

namespace TP214E.Data
{
    public class DAL
    {
        public MongoClient mongoDBClient;
        private IMongoCollection<Aliment> collectionAliments;

        public DAL()
        {
            mongoDBClient = OuvrirConnexion();
            IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
            collectionAliments = db.GetCollection<Aliment>("Aliments");
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

        public void AjouterAliment(Aliment aliment)
        {
            try
            {
                collectionAliments.InsertOne(aliment);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void ModifierAliment(ObjectId AlimentId, Aliment nouvelleAliment)
        {
            FilterDefinition<Aliment> filtre = Builders<Aliment>.Filter.Eq("_id", AlimentId);
            UpdateDefinition<Aliment> modifications = Builders<Aliment>.Update.Set("Nom", nouvelleAliment.Nom)
                .Set("Quantite", nouvelleAliment.Quantite)
                .Set("Congele", nouvelleAliment.Congele)
                .Set("ExpireLe", nouvelleAliment.ExpireLe);
            collectionAliments.UpdateOne(filtre, modifications);
        }

        public void RetirerAliment(Aliment aliment)
        {
            try
            {
                IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
                IMongoCollection<Aliment> aliments = db.GetCollection<Aliment>("Aliments");
                aliments.FindOneAndDelete(Builders<Aliment>.Filter.Eq("_id", aliment.Id));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
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

        
    }
}