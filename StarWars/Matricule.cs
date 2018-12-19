namespace StarWars
{
    class Matricule
    {
        public string Nom { get; set; }
        public int NumMatricule { get; set; }

        public Matricule(string nom)
        {
            this.Nom = nom;
        }

        public Matricule(int matNumber)
        {
            this.NumMatricule = matNumber;
        }

        public override string ToString()
        {
            if (NumMatricule > 0)
                return NumMatricule.ToString();

            return Nom;
        }
    }
}
