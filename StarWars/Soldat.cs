using System;

namespace StarWars
{
    class Soldat
    {

        public int Sante { get; set; }
        public int Degats { get; set; }
        public Camp Camp { get; set; }
        public Matricule Matricule { get; set; }

        public Soldat(int sante, int degats, Camp camp, Matricule matricule)
        {
            this.Sante = sante;
            this.Degats = degats;
            this.Camp = camp;
            this.Matricule = matricule;
        }

        public void Attaquer(Soldat ennemi)
        {
            if (Camp == Camp.Empire)
            {
                Console.WriteLine("Traitor!");
                Console.WriteLine($"Le soldat {Matricule} attaque le rebelle {ennemi.Matricule} et lui inflige {Degats} de dégats.");
            }
            else
            {
                Console.WriteLine("Pour la princesse Organa!");
                Console.WriteLine($"Le rebelle {Matricule} attaque le soldat {ennemi.Matricule} et lui inflige {Degats} de dégats.");
            }

            ennemi.Sante -= Degats;

            if(ennemi.IsDead(ennemi.Sante))
            {
                Console.WriteLine("Le soldat ennemi est mort");
            }
            else
            {
                Console.WriteLine($"Il reste {ennemi.Sante} de santé au soldat ennemi.");
            }
        }

        public bool IsDead(int sante)
        {
            if(sante <= 0)
            {
                return true;
            }

            return false;
        }
    }
}
