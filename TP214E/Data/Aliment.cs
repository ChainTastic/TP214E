using MongoDB.Bson;
using System;

namespace TP214E.Data
{
    public class Aliment
    {
        public ObjectId Id { get; set; }
        public string Nom { get; set; }
        public int Quantite { get; set; }
        public string Unite { get; set; }
        public DateTime ExpireLe { get; set; }
    }
}