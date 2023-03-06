namespace Tetris
{
    public class StanGry
    {
        private Blok obecnyBlok;

        public Blok ObecnyBlok
        {
            get => obecnyBlok;
            private set
            {
                obecnyBlok = value;
                obecnyBlok.Resetuj();
            }
        }
        public SiatkaGry SiatkaGry { get; }
        public Kolejka Kolejka { get; }
        public bool KoniecGry { get; private set; }
        
        public StanGry()
        {
            SiatkaGry = new SiatkaGry(22, 10);
            Kolejka = new Kolejka();
            ObecnyBlok = Kolejka.Zaktualizuj();
        }

        private bool BlokPasuje()
        {
            foreach(Pozycja p in ObecnyBlok.PozycjePola())
            {
                if(!SiatkaGry.JestPusty(p.Rzad, p.Kolumna))
                {
                    return false;
                }
            }
            return true;
        }

        public void ObrocBlokCW()
        {
            ObecnyBlok.ObrocCW();
            if (!BlokPasuje())
            {
                ObecnyBlok.ObrocCCW();
            }
        }

        public void ObrocBlokCCW()
        {
            ObecnyBlok.ObrocCCW();
            if (!BlokPasuje())
            {
                ObecnyBlok.ObrocCW();
            }
        }

        public void PrzesunWLewo()
        {
            ObecnyBlok.Przesun(0, -1);
            if (!BlokPasuje())
            {
                ObecnyBlok.Przesun(0, 1);
            }
        }

        public void PrzesunWPrawo()
        {
            ObecnyBlok.Przesun(0, 1);
            if (!BlokPasuje())
            {
                ObecnyBlok.Przesun(0, -1);
            }
        }

        private bool CzyKoniecGry()
        {
            return !(SiatkaGry.JestRzadPusty(0) && SiatkaGry.JestRzadPusty(1));
        }

        private void UstawBlok()
        {
            foreach(Pozycja p in ObecnyBlok.PozycjePola())
            {
                SiatkaGry[p.Rzad, p.Kolumna] = ObecnyBlok.Identyfikator;
            }
            SiatkaGry.WyczyscPelneRzedy();

            if (CzyKoniecGry())
            {
                KoniecGry = true;
            }
            else
            {
                ObecnyBlok = Kolejka.Zaktualizuj();
            }
        }
        public void PrzesunWDol()
        {
            ObecnyBlok.Przesun(1, 0);
            if (!BlokPasuje)
            {
                ObecnyBlok.Przesun(-1, 0);
                UstawBlok();
            }
        }
    }
}
