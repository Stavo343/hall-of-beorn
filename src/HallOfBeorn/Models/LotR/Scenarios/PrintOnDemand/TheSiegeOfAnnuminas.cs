﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HallOfBeorn.Models.LotR.Scenarios.PrintOnDemand
{
    public class TheSiegeOfAnnuminas : Scenario
    {
        public TheSiegeOfAnnuminas()
        {
            Title = "The Siege of Annúminas";
            ProductName = "The Siege of Annúminas";
            GroupName = "GenCon";
            Number = 7;

            QuestCompanionUrl = "http://lotr-lcg-quest-companion.com/print-on-demand-quest-the-siege-of-annuminas.html";

            AddEncounterSet(EncounterSet.TheSiegeOfAnnuminas);

            AddQuestCardId("Rebuild-the-Defenses-TSoA");
            AddQuestCardId("Defend-the-City-TSoA");
            AddQuestCardId("Lead-the-Sortie-TSoA");
            AddQuestCardId("Raise-the-Levee-TSoA");
            AddQuestCardId("Guard-the-Gate-TSoA");
            AddQuestCardId("Rescue-the-Captives-TSoA");
            AddQuestCardId("Delay-the-Enemy-TSoA");
            AddQuestCardId("Man-the-Walls-TSoA");
            AddQuestCardId("Stop-the-Attack-TSoA");
        }
    }
}