namespace HallOfBeorn.Models.LotR.Scenarios.TheHobbit
{
    public class FliesAndSpiders : Scenario
    {
        public FliesAndSpiders()
        {
            Title = "Flies and Spiders";
            ProductName = "The Hobbit: On the Doorstep";
            GroupName = "The Hobbit";
            Number = 4;

            QuestCompanionUrl = "http://lotr-lcg-quest-companion.com/the-hobbit-on-the-doorstep-quest-flies-and-spiders.html";

            AddEncounterSet(EncounterSet.FliesAndSpiders);
            AddEncounterSet(EncounterSet.FliesAndSpidersNightmare);
            AddEncounterSet(EncounterSet.Wilderland);

            AddQuestCardId("Into-Mirkwood-THOtD");
            AddQuestCardId("Lost-in-the-Dark-THOtD");
            AddQuestCardId("Captured-by-Spiders-THOtD");
            AddQuestCardId("Battle-with-the-Spiders-THOtD");

            ExcludeFromEasyMode("Crazy-Cob-THOtD", 1);
            ExcludeFromEasyMode("Fat-Spider-THOtD", 1);
            ExcludeFromEasyMode("Giant-Web-THOtD", 1);
            ExcludeFromEasyMode("Lazy-Lob-THOtD", 2);
            ExcludeFromEasyMode("Old-Tomnoddy-THOtD", 2);
            ExcludeFromEasyMode("Poisoned-by-Spiders-THOtD", 2);
            ExcludeFromEasyMode("Fighting-Among-Friends-THOtD", 2);
            ExcludeFromEasyMode("Weighed-Down-THOtD", 1);

            ExcludeFromNightmareMode("Fat-Spider-THOtD", 1);
            ExcludeFromNightmareMode("Giant-Web-THOtD", 1);
            ExcludeFromNightmareMode("Wicked-Spider-THOtD", 5);
            ExcludeFromNightmareMode("Dark-Bats-THOtD", 3);
            ExcludeFromNightmareMode("Fighting-Among-Friends-THOtD", 2);
            ExcludeFromNightmareMode("Hidden-Path-THOtD", 3);
        }
    }
}
