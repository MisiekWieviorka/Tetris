using System;

namespace Tetris
{
    public class IBlok : Blok
    {
        private readonly Pozycja[][] pola = new Pozycja[][]
        {
            new Pozycja[] { new(1,0), new (1,1), new(1, 2), new(1, 3) },
            new Pozycja[] { new(0,2), new (1,2), new(2, 2), new(3, 2) },
            new Pozycja[] { new(2,0), new (2,1), new(2, 2), new(2, 3) },
            new Pozycja[] { new(0,1), new (1,1), new(2, 1), new(3, 1) }
        };
        public override int Identyfikator => 1;
        protected override Pozycja PoczatkowePrzesuniecie => new Pozycja(-1, 3);
        protected override Pozycja[][] Pola => pola;
    }
}
