using System;
using System.Windows.Documents;

namespace Tetris
{
    public class Kolejka
    {
        private readonly Blok[] bloki = new Blok[]
        {
            new IBlok(),
            new OBlok(),
            new JBlok(),
            new LBlok(),
            new SBlok(),
            new WBlok(),
            new ZBlok()
        };

        private readonly Random losowanie = new Random();

        public Blok NastepnyBlok {  get; private set; }

        public Kolejka()
        {
            NastepnyBlok = LosowyBlok();
        }

        private Blok LosowyBlok()
        {
            return bloki[losowanie.Next(bloki.Length)];
        }

        public Blok Zaktualizuj()
        {
            Blok blok = NastepnyBlok;
            do
            {
                NastepnyBlok = LosowyBlok();
            }
            while (blok.Identyfikator == NastepnyBlok.Identyfikator);
            return blok;
        }
    }
}
