namespace Tetris
{
    public class OBlok : Blok
    {
        private readonly Pozycja[][] pola = new Pozycja[][]
        {
            new Pozycja[] { new(0,0), new (0,1), new(1, 0), new(1, 1) }
        };
        public override int Identyfikator => 4;
        protected override Pozycja PoczatkowePrzesuniecie => new Pozycja(0, 4);
        protected override Pozycja[][] Pola => pola;
    }
}
