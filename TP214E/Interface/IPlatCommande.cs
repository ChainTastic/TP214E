namespace TP214E.Data
{
    public interface IPlatCommande
    {
        Plat Plat { get; set; }
        int Quantite { get; set; }
        double SousTotal { get; }
        string SousTotalFormatte { get; }
        bool IngredientsSontDisponibles();
    }
}