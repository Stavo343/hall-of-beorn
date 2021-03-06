namespace HallOfBeorn.Models.LotR.Scenarios.TheLostRealm
{
    public class DeadmensDike : HallOfBeorn.Models.LotR.Scenarios.AngmarAwakened.AngmarAwakenedScenario
    {
        public DeadmensDike()
        {
            Title = "Deadmen's Dike";
            ProductName = "The Lost Realm";
            GroupName = "The Lost Realm";
            Number = 3;

            QuestCompanionUrl = "http://lotr-lcg-quest-companion.com/the-lost-realm-quest-deadmens-dike.html";

            AddEncounterSet(EncounterSet.CursedDead);
            AddEncounterSet(EncounterSet.DarkSorcery);
            AddEncounterSet(EncounterSet.DeadmensDike);
            AddEncounterSet(EncounterSet.DeadmensDikeNightmare);
            AddEncounterSet(EncounterSet.Iarion);

            AddQuestCardId("The-Shades-of-Angmar-TLR");
            AddQuestCardId("A-Fell-Wraith-TLR");

            ExcludeDarkSorceryFromEasyMode();
            ExcludeCursedDeadFromEasyMode();
            
            ExcludeFromEasyMode("Broken-Battlements-TLR", 1);
            ExcludeFromEasyMode("Deadmen's-Gate-TLR", 1);
            ExcludeFromEasyMode("Haunted-Keep-TLR", 1);
            ExcludeFromEasyMode("Thaurdir's-Damned-TLR", 2);
            ExcludeFromEasyMode("Unnatural-Fog-TLR", 1);

            ExcludeFromNightmareMode("Fornost-Square-TLR", 2);
            ExcludeFromNightmareMode("Broken-Battlements-TLR", 3);
            ExcludeFromNightmareMode("Norbury-Tombs-TLR", 2);
            ExcludeFromNightmareMode("Restless-Evil-TLR", 2);
        }
    }
}
