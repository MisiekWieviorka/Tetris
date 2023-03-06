using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Tetris
{
    public class SiatkaGry
    {
        private readonly int[,] siatka;
        public int Rzedy { get;  }
        public int Kolumny { get; }

        public int this[int r, int k]
        {
            get => siatka[r, k];
            set => siatka[r, k] = value;
        }

        public SiatkaGry(int rzedy, int kolumny)
        {
            Rzedy = rzedy;
            Kolumny = kolumny;
            siatka = new int[rzedy, kolumny];
        }

        public bool JestWewnatrz(int r, int k)
        {
            return r >= 0 && k >= 0 && r < Rzedy && k < Kolumny;
        }

        public bool JestPusty(int r, int k)
        {
            return JestWewnatrz(r, k) && siatka[r, k] == 0;
        }

        public bool JestRzadPelny(int r)
        {
            for( int k = 0; k < Kolumny; k++)
            {
                if(siatka[r, k] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool JestRzadPusty(int r)
        {
            for(int k = 0; k < Kolumny; k++)
            {
                if (siatka[r, k] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void WyczyscRzad(int r)
        {
            for(int k = 0; k < Kolumny; k++)
            {
                siatka[r, k] = 0;
            }
        }

        private void PrzesunRzad(int r, int ileRzedow)
        {
            for(int k = 0; k < Kolumny; k++)
            {
                siatka[r + ileRzedow, k] = siatka[r, k];
                siatka[r, k] = 0;
            }
        }

        public int WyczyscPelneRzedy()
        {
            int wyczyszczono = 0;

            for(int r = Rzedy-1; r >= 0; r--)
            {
                if (JestRzadPelny(r))
                {
                    WyczyscRzad(r);
                    wyczyszczono++;
                }
                else if(wyczyszczono > 0)
                {
                    PrzesunRzad(r, wyczyszczono);
                }
            }
            return wyczyszczono;
        }
    }
}
