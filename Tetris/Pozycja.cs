namespace Tetris
{
    public class Pozycja
    {
        public int Rzad { get; set; }
        public int Kolumna { get; set; }

        public Pozycja(int rzad, int kolumna)
        {
            Rzad = rzad;
            Kolumna = kolumna;
        }
    }
}
