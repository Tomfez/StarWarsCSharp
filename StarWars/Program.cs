using System;
using System.Collections.Generic;

namespace StarWars
{
    class Program
    {
        static void Main(string[] args)
        {
            var rebellesList = new List<Soldat>();
            var empireList = new List<Soldat>();
            Random rnd = new Random();
            int scoreHerosRebelles = 0;
            int scoreHerosEmpire = 0;

            for (int i = 0; i < 100; i++)
            {
                int sante = rnd.Next(1000, 2000);
                //int degats = rnd.Next(100, 500);
                int degats = 1000;

                var v = Enum.GetValues(typeof(Camp));
                Camp camp = (Camp)v.GetValue(new Random().Next(v.Length));
                Matricule matricule = null;

                if (camp == Camp.Empire)
                {
                    int matr = rnd.Next(100, 1000);
                    matricule = new Matricule(matr);
                }
                else
                {
                    string nom = $"Rebelle {i}";
                    matricule = new Matricule(nom);
                }

                Soldat soldat = new Soldat(sante, degats, camp, matricule);

                System.Threading.Thread.Sleep(10);
                if (soldat.Camp == Camp.Empire)
                {

                    empireList.Add(soldat);
                }
                else
                {
                    rebellesList.Add(soldat);
                }
            }

            Bataille bataille = new Bataille(rebellesList, empireList);

            Console.ReadLine();
        }
    }
}
