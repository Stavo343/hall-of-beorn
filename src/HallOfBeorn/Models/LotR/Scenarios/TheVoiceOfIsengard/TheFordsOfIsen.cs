namespace HallOfBeorn.Models.LotR.Scenarios.TheVoiceOfIsengard
{
    public class TheFordsOfIsen : Scenario
    {
        public TheFordsOfIsen()
        {
            Title = "The Fords of Isen";
            ProductName = "The Voice of Isengard";
            GroupName = "The Voice of Isengard";
            Number = 1;

            QuestCompanionUrl = "http://lotr-lcg-quest-companion.com/voice-of-isengard-quest-the-fords-of-isen.html";

            AddEncounterSet(EncounterSet.DunlandRaiders);
            AddEncounterSet(EncounterSet.DunlandWarriors);
            AddEncounterSet(EncounterSet.TheFordsOfIsen);
            AddEncounterSet(EncounterSet.TheFordsOfIsenNightmare);

            AddQuestCardId("Fight-at-the-Fords-VoI");
            AddQuestCardId("Dunlending-Attack-VoI");
            AddQuestCardId("Hold-the-Fords-VoI");

            ExcludeFromEasyMode("Dunland-Raider-VoI", 2);
            ExcludeFromEasyMode("Old-Hatreds-VoI", 1);
            ExcludeFromEasyMode("Dunland-Chieftain-VoI", 2);
            ExcludeFromEasyMode("Wild-Men-of-Dunland-VoI", 1);
            ExcludeFromEasyMode("Down-from-the-Hills-VoI", 1);
            ExcludeFromEasyMode("Gap-of-Rohan-VoI", 2);
            ExcludeFromEasyMode("Pillaging-and-Burning-VoI", 1);

            ExcludeFromNightmareMode("Dunland-Prowler-VoI", 3);
            ExcludeFromNightmareMode("Dunlending-Bandit-VoI", 2);
            ExcludeFromNightmareMode("Dunland-Berserker-VoI", 1);
            ExcludeFromNightmareMode("Gap-of-Rohan-VoI", 2);
            ExcludeFromNightmareMode("The-King's-Road-VoI", 2);
        }
    }
}
