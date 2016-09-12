﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HallOfBeorn.Models.Scenarios
{
    public class TheSiegeOfAnnuminas : Scenario
    {
        public TheSiegeOfAnnuminas()
        {
            Title = "The Siege of Annúminas";
            ProductName = "The Siege of Annúminas";
            GroupName = "GenCon";
            Number = 7;

            AddEncounterSet(EncounterSet.TheSiegeOfAnnuminas);

            AddQuestCardId("Rebuild-the-Defenses-TSoA");
            AddQuestCardId("Defend-the-City-TSoA");
        }
    }
}