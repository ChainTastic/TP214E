﻿using System;
using TP214E.Interface;

namespace TP214E.Data
{
    public class PlatCommande : IQuantite, IPlatCommande
    {
        private int _quantite;

        public PlatCommande(Plat platEnCommande, int quantite)
        {
            Plat = platEnCommande;
            Quantite = quantite;
        }

        public Plat Plat { get; set; }

        public int Quantite
        {
            get => _quantite;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("La quantite ne peut pas être négatif");
                }

                _quantite = value;
            }
        }

        public double SousTotal => Plat.Prix * Quantite;

        public string SousTotalFormatte => $"{SousTotal:C}";

        public bool IngredientsSontDisponibles()
        {
            return Plat.VerifierDisponibilite();
        }
    }
}