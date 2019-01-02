using System;
using System.Collections.Generic;

namespace StarWars
{
    class Bataille
    {
        private readonly List<Soldat> RebellesList;
        private readonly List<Soldat> EmpireList;
        private List<Soldat> listeSoldats;
        private readonly Camp enumFavori;
        Random rnd = new Random();
        Soldat hero;

        public Bataille(List<Soldat> rebellesList, List<Soldat> empireList)
        {
            this.RebellesList = rebellesList;
            this.EmpireList = empireList;

            string favori = GetFavori(rebellesList, empireList);

            listeSoldats = new List<Soldat>();
            listeSoldats.AddRange(rebellesList);
            listeSoldats.AddRange(empireList);

            if (Enum.TryParse(favori, out enumFavori) && enumFavori == Camp.Empire)
            {
                hero = PickHero(empireList);
                Console.WriteLine($"L'empire commence la bataille et le soldat {hero.Matricule} est le héros ! \r\n");
                empireList[0].Attaquer(rebellesList[0]);
            }
            else
            {
                hero = PickHero(rebellesList);
                Console.WriteLine($"Les rebelles commencent la bataille et le rebelle {hero.Matricule} est le favori ! \r\n");
                rebellesList[0].Attaquer(empireList[0]);
            }

            do
            {
                Soldat soldatEmpire = empireList[rnd.Next(0, empireList.Count - 1)];
                rebellesList[rnd.Next(0, rebellesList.Count)].Attaquer(soldatEmpire);

                if (soldatEmpire.IsDead(soldatEmpire.Sante))
                {
                    empireList.Remove(soldatEmpire);
                }
                listeSoldats[rnd.Next(0, 100)].Attaquer(listeSoldats[rnd.Next(0, 100)]);
            } while (empireList.Count > 0);

            Console.WriteLine("Les rebelles ont gagné");
        }

        public string GetFavori(List<Soldat> rebellesList, List<Soldat> empireList)
        {
            int scoreRebelles = 0;
            int scoreEmpire = 0;

            foreach (var rebelle in rebellesList)
            {
                scoreRebelles += (rebelle.Sante + rebelle.Degats) * 10;
            }

            foreach (var stormtrooper in empireList)
            {
                scoreEmpire += (stormtrooper.Sante + stormtrooper.Degats) * 10;
            }

            if (scoreRebelles > scoreEmpire)
            {
                return "Rebelles";
            }

            return "Empire";
        }

        public Soldat PickHero(List<Soldat> soldats)
        {
            if (soldats.Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }

            foreach (Soldat soldat in soldats)
            {
                if (soldat.Degats + soldat.Sante > 0)
                {
                    hero = soldat;
                }
            }

            return hero;
        }
    }
}
