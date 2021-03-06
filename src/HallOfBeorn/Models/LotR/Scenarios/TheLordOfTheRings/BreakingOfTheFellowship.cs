namespace HallOfBeorn.Models.LotR.Scenarios.TheLordOfTheRings
{
    public class BreakingOfTheFellowship : Scenario
    {
        public BreakingOfTheFellowship()
        {
            Title = "Breaking of the Fellowship";
            ProductName = "The Road Darkens";
            GroupName = "The Lord of the Rings";
            Number = 6;

            QuestCompanionUrl = "http://lotr-lcg-quest-companion.com/lotr-the-road-darkens-quest-breaking-of-the-fellowship.html";

            AddEncounterSet(EncounterSet.BreakingOfTheFellowship);
            AddEncounterSet(EncounterSet.BreakingOfTheFellowshipNightmare);

            AddQuestCardId("The-Great-River-RD");
            AddQuestCardId("The-Company-Divided-RD");
            AddQuestCardId("Searching-the-Woods-RD");
            AddQuestCardId("Guard-the-Hobbits-RD");
            AddQuestCardId("The-Seat-of-Amon-Hen-RD");
            AddQuestCardId("Orc-Hunting-RD");
            AddQuestCardId("The-Ring-bearer-Sets-Out-RD");

            ExcludeFromEasyMode("Fallen-Into-Evil-RD", 1);
            ExcludeFromEasyMode("Uruk-hai-Archer-RD", 1);
            ExcludeFromEasyMode("Uruk-hai-Captain-RD", 1);
            ExcludeFromEasyMode("Uruk-hai-Hunter-RD", 1);
            ExcludeFromEasyMode("Uruk-hai-Tracker-RD", 1);
            ExcludeFromEasyMode("Wooded-Shoreline-RD", 2);

            ExcludeFromNightmareMode("Uruk-hai-Archer-RD", 4);
            ExcludeFromNightmareMode("River-Anduin-RD", 2);
            ExcludeFromNightmareMode("Slopes-of-Amon-Hen-RD", 1);
            ExcludeFromNightmareMode("Black-Feathered-Arrows-RD", 2);
        }
    }
}
