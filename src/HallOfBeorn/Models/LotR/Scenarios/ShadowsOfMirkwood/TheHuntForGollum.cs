namespace HallOfBeorn.Models.LotR.Scenarios.ShadowsOfMirkwood
{
    public class TheHuntForGollum : Scenario
    {
        public TheHuntForGollum()
        {
            Title = "The Hunt for Gollum";
            ProductName = "The Hunt for Gollum";
            GroupName = "Shadows of Mirkwood";
            Number = 0;

            QuestCompanionUrl = "http://lotr-lcg-quest-companion.com/cycle-shadows-of-mirkwood.html";

            AddEncounterSet(EncounterSet.JourneyAlongTheAnduin);
            AddEncounterSet(EncounterSet.SauronsReach);
            AddEncounterSet(EncounterSet.TheHuntForGollum);
            AddEncounterSet(EncounterSet.TheHuntForGollumNightmare);

            AddQuestCardId("The-Hunt-Begins-THfG");
            AddQuestCardId("A-New-Terror-Abroad-THfG");
            AddQuestCardId("On-the-Trail-THfG");

            ExcludeFromEasyMode("Gladden-Fields-Core", 2);
            ExcludeFromEasyMode("Massing-at-Night-Core", 1);
            ExcludeFromEasyMode("Eastern-Crows-Core", 2);
            ExcludeFromEasyMode("Evil-Storm-Core", 1);
            ExcludeFromEasyMode("Goblintown-Scavengers-THfG", 1);
            ExcludeFromEasyMode("Hunters-from-Mordor-THfG", 3);
            ExcludeFromEasyMode("Old-Wives'-Tales-THfG", 2);
            ExcludeFromEasyMode("The-Old-Ford-THfG", 2);

            ExcludeFromNightmareMode("Banks-of-the-Anduin-Core", 2);
            ExcludeFromNightmareMode("Gladden-Fields-Core", 3);
            ExcludeFromNightmareMode("Misty-Mountain-Goblins-Core", 2);
            ExcludeFromNightmareMode("Eastern-Crows-Core", 3);
            ExcludeFromNightmareMode("Evil-Storm-Core", 3);
            ExcludeFromNightmareMode("Treacherous-Fog-Core", 2);
            ExcludeFromNightmareMode("False-Lead-THfG", 2);
            ExcludeFromNightmareMode("River-Ninglor-THfG", 2);
            ExcludeFromNightmareMode("The-Eaves-of-Mirkwood-THfG", 1);
        }
    }
}
