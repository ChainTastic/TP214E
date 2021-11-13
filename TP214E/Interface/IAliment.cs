using System;
using MongoDB.Bson;

namespace TP214E.Interface
{
    public interface IAliment
    {
        int Quantite { get; set; }
        bool Congele { get; set; }
        DateTime DateExpiration { get; set; }
        string CongeleAsString { get; }
        ObjectId Id { get; }
        string Nom { get; set; }
    }
}