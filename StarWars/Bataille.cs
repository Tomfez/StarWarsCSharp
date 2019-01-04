using System;
using System.Collections.Generic;

namespace StarWars
{
    class Bataille
    {
        private readonly List<Soldat> RebellesList;
        private readonly List<Soldat> EmpireList;
        private List<Soldat> listeSoldats;
        private Camp enumFavori;
        Random rnd = new Random();
        Soldat hero;

        public Bataille(List<Soldat> rebellesList, List<Soldat> empireList)
        {
            this.RebellesList = rebellesList;
            this.EmpireList = empireList;

            LaunchBattle();
            DisplayWinner(EmpireList, RebellesList);
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

        public void LaunchBattle()
        {
            string favori = GetFavori(RebellesList, EmpireList);
            listeSoldats = new List<Soldat>();
            listeSoldats.AddRange(RebellesList);
            listeSoldats.AddRange(EmpireList);

            if (Enum.TryParse(favori, out enumFavori) && enumFavori == Camp.Empire)
            {
                hero = PickHero(EmpireList);
                Console.WriteLine($"L'empire commence la bataille et le soldat {hero.Matricule} est le héros ! \r\n");
                EmpireList[0].Attaquer(RebellesList[0]);
            }
            else
            {
                hero = PickHero(RebellesList);
                Console.WriteLine($"Les rebelles commencent la bataille et le rebelle {hero.Matricule} est le favori ! \r\n");
                RebellesList[0].Attaquer(EmpireList[0]);
            }

            do
            {
                if (EmpireList.Count <= 0 || RebellesList.Count <= 0)
                {
                    break;
                }

                Soldat soldatEmpire = EmpireList[rnd.Next(0, EmpireList.Count - 1)];
                Soldat soldatRebelle = RebellesList[rnd.Next(0, RebellesList.Count - 1)];

                listeSoldats[rnd.Next(0, 100)].Attaquer(listeSoldats[rnd.Next(0, 100)]);

                if (soldatEmpire.IsDead(soldatEmpire.Sante))
                {
                    EmpireList.Remove(soldatEmpire);
                }
                if (soldatRebelle.IsDead(soldatRebelle.Sante))
                {
                    RebellesList.Remove(soldatRebelle);
                }

            } while (true);
        }

        public void DisplayWinner(List<Soldat> empireList, List<Soldat> rebellesList)
        {
            if (empireList.Count == 0)
            {
                Console.WriteLine($"Les rebelles ont gagné. Il reste {rebellesList.Count} rebelles en vie.");
            }
            else
            {
                Console.WriteLine($"L'empire a gagné. Il reste {empireList.Count} soldats encore en vie.");
            }
        }

    }
}
