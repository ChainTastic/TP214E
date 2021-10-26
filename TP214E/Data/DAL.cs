using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Windows;

namespace TP214E.Data
{
    public class DAL
    {
        public MongoClient mongoDBClient;

        public DAL()
        {
            mongoDBClient = OuvrirConnexion();
        }

        public List<Aliment> ALiments()
        {
            List<Aliment> aliments = new List<Aliment>();
            try
            {
                IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
                aliments = db.GetCollection<Aliment>("Aliments").Aggregate().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return aliments;
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