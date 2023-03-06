using System;
using System.Collections.Generic;

namespace Tetris
{
    public abstract class Blok
    {
        protected abstract Pozycja[][] Pola { get; }
        protected abstract Pozycja PoczatkowePrzesuniecie { get; }
        public abstract int Identyfikator { get; }
        private int stanRotacji;
        private Pozycja rownowaga;

        public Blok()
        {
            rownowaga = new Pozycja(PoczatkowePrzesuniecie.Rzad, PoczatkowePrzesuniecie.Kolumna);
        }
        public IEnumerable<Pozycja> PozycjePola()
        {
            foreach (Pozycja p in Pola[stanRotacji])
                yield return new Pozycja(p.Rzad + rownowaga.Rzad, p.Kolumna + rownowaga.Kolumna);
        }
        public void ObrocCW()
        {
            stanRotacji = (stanRotacji +1) % Pola.Length;
        }
        public void ObrocCCW()
        {
            if(stanRotacji == 0)
            {
                stanRotacji = Pola.Length - 1;
            }
            else
            {
                stanRotacji--;
            }
        }
        public void Przesun(int rzedy, int kolumny)
        {
            rownowaga.Rzad += rzedy;
            rownowaga.Kolumna += kolumny;
        }
        public void Resetuj()
        {
            stanRotacji = 0;
            rownowaga.Rzad = PoczatkowePrzesuniecie.Rzad;
            rownowaga.Rzad = PoczatkowePrzesuniecie.Kolumna;
        }
    }
}
