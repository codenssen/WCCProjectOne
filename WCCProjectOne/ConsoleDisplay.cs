using System;

namespace WCCProjectOne
{
    public static class ConsoleDisplay
    {
        // Définition de l'énumération des couleurs
        public enum Color
        {
            Red,
            Green,
            Blue,
        }

        // Méthode pour afficher le texte en fonction de la couleur spécifiée
        public static void DisplayColor(Color color, string input)
        {
            // Définir la couleur de la console en fonction de l'énumération
            switch (color)
            {
                case Color.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Color.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Color.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }

            // Afficher le texte
            Console.WriteLine(input);

            // Réinitialiser la couleur de la console après affichage
            Console.ResetColor();
        }
    }
}
