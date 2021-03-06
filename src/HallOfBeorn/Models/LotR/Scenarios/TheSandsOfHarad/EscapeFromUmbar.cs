﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HallOfBeorn.Models.LotR.Scenarios.TheSandsOfHarad
{
    public class EscapeFromUmbar : TheSandsOfHaradScenario
    {
        public EscapeFromUmbar()
        {
            Title = "Escape from Umbar";
            ProductName = "The Sands of Harad";
            GroupName = "The Sands of Harad";
            Number = 1;

            QuestCompanionUrl = "http://lotr-lcg-quest-companion.com/sands-of-harad-quest-escape-from-umbar.html";

            AddEncounterSet(EncounterSet.EscapeFromUmbar);
            AddEncounterSet(EncounterSet.HaradTerritory);
            AddEncounterSet(EncounterSet.HaradSoldiers);
            
            AddQuestCardId("Stranded-in-Umbar-TSoH");
            AddQuestCardId("Flee-the-City-TSoH");

            excludeEscapeFromUmbar();
            excludeHaradTerritory();
            excludeHaradSoldiers();
        }
    }
}