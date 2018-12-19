using System;
using System.Collections.Generic;

namespace StarWars
{
    class Bataille
    {
        private List<Soldat> RebellesList;
        private List<Soldat> EmpireList;
        private List<Soldat> listeSoldats;
        private Camp enumFavori;
        Random rnd = new Random();

        public Bataille(List<Soldat> rebellesList, List<Soldat> empireList)
        {
            this.RebellesList = rebellesList;
            this.EmpireList = empireList;

            string favori = getFavori(rebellesList, empireList);

            listeSoldats = new List<Soldat>();
            listeSoldats.AddRange(rebellesList);
            listeSoldats.AddRange(empireList);

            if (Enum.TryParse(favori, out enumFavori) && enumFavori == Camp.Empire)
            {
                Console.WriteLine("L'empire commence la bataille!");
                empireList[1].Attaquer(rebellesList[1]);
            }
            else
            {
                Console.WriteLine("Les rebelles commencent la bataille!");
                rebellesList[1].Attaquer(empireList[1]);
            }

            do
            {
                Soldat soldatEmpire = empireList[rnd.Next(0, empireList.Count - 1)];
                rebellesList[rnd.Next(0, rebellesList.Count)].Attaquer(soldatEmpire);

                if (soldatEmpire.IsDead(soldatEmpire.Sante))
                {
                    empireList.Remove(soldatEmpire);
                }
                //listeSoldats[rnd.Next(0, 100)].Attaquer(listeSoldats[rnd.Next(0, 100)]);
            } while (empireList.Count > 0);

            Console.WriteLine("Les rebelles ont gagné");
        }

        public string getFavori(List<Soldat> rebellesList, List<Soldat> empireList)
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
    }
}
