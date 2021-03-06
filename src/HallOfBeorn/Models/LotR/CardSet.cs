﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HallOfBeorn.Models.LotR
{
    public abstract class CardSet : INamed
    {
        protected CardSet()
        {
            Cards = new List<LotRCard>();

            Initialize();

            foreach (var card in Cards)
            {
                card.CardSet = this;
            }
        }

        private string normalizedName;

        protected abstract void Initialize();

        protected void addCard(LotRCard card)
        {
            this.Cards.Add(card);
        }

        public string Id { get; protected set; }
        public string Name { get; protected set; }
        
        public string NormalizedName
        {
            get
            {
                return (!string.IsNullOrEmpty(normalizedName)) ?
                    normalizedName
                    : Name;
            }
            protected set
            {
                normalizedName = value;
            }
        }

        public string Abbreviation { get; protected set; }

        private string publicSlug;
        public string PublicSlug
        {
            get { return !string.IsNullOrEmpty(publicSlug) ? publicSlug : Abbreviation.ToLower(); }
            protected set { publicSlug = value; }
        }

        public string Cycle { get; protected set; }
        public int Number { get; protected set; }
        public SetType SetType { get; protected set; }
        public List<LotRCard> Cards { get; protected set; }
        public Product Product { get; set; }

        private readonly List<EncounterSet> encounterSets = new List<EncounterSet>();
        protected void addEncounterSets(params EncounterSet[] sets)
        {
            foreach (var encounterSet in sets) {

                foreach (var card in encounterSet.Cards()) {
                    if (card.CardSet == null) {
                        card.CardSet = this;
                    }
                }

                this.encounterSets.Add(encounterSet);
            }
        }
        public IEnumerable<EncounterSet> EncounterSets()
        {
            return encounterSets;
        }

        public string AlternateName { get; protected set; }

        public bool IsNightmare { get { return !string.IsNullOrEmpty(Name) && Name.EndsWith(" Nightmare"); } }

        private static List<CardSet> all = new List<CardSet>();

        private static void Add(CardSet cardSet)
        {
            all.Add(cardSet);
        }

        static CardSet()
        {
            Add(CoreSet);
            Add(TheHuntForGollum);
            Add(ConflictAtTheCarrock);
            Add(AJourneyToRhosgobel);
            Add(TheHillsOfEmynMuil);
            Add(TheDeadMarshes);
            Add(ReturnToMirkwood);
        
            Add(KhazadDum);
            Add(TheRedhornGate);
            Add(RoadToRivendell);
            Add(TheWatcherInTheWater);
            Add(TheLongDark);
            Add(FoundationsOfStone);
            Add(ShadowAndFlame);

            Add(HeirsOfNumenor);
            Add(TheStewardsFear);
            Add(TheDruadanForest);
            Add(EncounterAtAmonDin);
            Add(AssaultOnOsgiliath);
            Add(TheBloodOfGondor);
            Add(TheMorgulVale);

            Add(TheVoiceOfIsengard);
            Add(TheDunlandTrap);
            Add(TheThreeTrials);
            Add(TroubleInTharbad);
            Add(TheNinInEilph);
            Add(CelebrimborsSecret);
            Add(TheAntleredCrown);

            Add(TheLostRealm);
            Add(TheWastesOfEriador);
            Add(EscapeFromMountGram);
            Add(AcrossTheEttenmoors);
            Add(TheTreacheryOfRhudaur);
            Add(TheBattleOfCarnDum);
            Add(TheDreadRealm);

            Add(TheGreyHavens);
            Add(FlightOfTheStormcaller);
            Add(TheThingInTheDepths);
            Add(TempleOfTheDeceived);
            Add(TheDrownedRuins);
            Add(AStormOnCobasHaven);
            Add(TheCityOfCorsairs);

            Add(TheSandsOfHarad);
            Add(TheMumakil);
            Add(RaceAcrossHarad);
            Add(BeneathTheSands);
            Add(TheBlackSerpent);
            Add(TheDungeonsOfCirithGurat);
            Add(TheCrossingsOfPoros);

            Add(TheHobbitOverHillAndUnderHill);
            Add(TheHobbitOnTheDoorstep);

            Add(TheBlackRiders);
            Add(TheRoadDarkens);
            Add(TheTreasonOfSaruman);
            Add(TheLandOfShadow);
            Add(TheFlameOfTheWest);
            Add(TheMountainOfFire);

            Add(TheMassingAtOsgiliath);
            Add(TheBattleOfLakeTown);
            Add(TheStoneOfErech);
            Add(TheRuinsOfBelegost);

            Add(TheOldForest);
            Add(FogOnTheBarrowDowns);
            Add(MurderAtThePrancingPony);
            Add(TheSiegeOfAnnuminas);
            Add(AssaultOnDolGuldur);

            Add(PassageThroughMirkwoodNightmare);
            Add(JourneyAlongTheAnduinNightmare);
            Add(EscapeFromDolGuldurNightmare);
            Add(TheHuntForGollumNightmare);
            Add(ConflictAtTheCarrockNightmare);
            Add(AJourneyToRhosgobelNightmare);
            Add(TheHillsOfEmynMuilNightmare);
            Add(TheDeadMarshesNightmare);
            Add(ReturnToMirkwoodNightmare);
            Add(IntoThePitNightmare);
            Add(TheSeventhLevelNightmare);
            Add(FlightFromMoriaNightmare);
            Add(TheRedhornGateNightmare);
            Add(RoadToRivendellNightmare);
            Add(TheWatcherInTheWaterNightmare);
            Add(TheLongDarkNightmare);
            Add(FoundationsOfStoneNightmare);
            Add(ShadowAndFlameNightmare);
            Add(PerilInPelargirNightmare);
            Add(IntoIthilienNightmare);
            Add(TheSiegeOfCairAndrosNightmare);
            Add(TheStewardsFearNightmare);
            Add(TheDruadanForestNightmare);
            Add(EncounterAtAmonDinNightmare);
            Add(AssaultOnOsgiliathNightmare);
            Add(TheBloodOfGondorNightmare);
            Add(TheMorgulValeNightmare);
            Add(TheFordsOfIsenNightmare);
            Add(ToCatchAnOrcNightmare);
            Add(IntoFangornNightmare);
            Add(TheDunlandTrapNightmare);
            Add(TheThreeTrialsNightmare);
            Add(TroubleInTharbadNightmare);
            Add(TheNinInEilphNightmare);
            Add(CelebrimborsSecretNightmare);
            Add(TheAntleredCrownNightmare);

            Add(IntrudersInChetwoodNightmare);
            Add(TheWeatherHillsNightmare);
            Add(DeadmensDikeNightmare);

            Add(TheWastesOfEriadorNightmare);
            Add(EscapeFromMountGramNightmare);
            Add(AcrossTheEttenmoorsNightmare);
            Add(TheTreacheryOfRhudaurNightmare);
            Add(TheBattleOfCarnDumNightmare);
            Add(TheDreadRealmNightmare);

            Add(WeMustAwayEreBreakOfDayNightmare);
            Add(OverTheMistyMountainsGrimNightmare);
            Add(DungeonsDeepAndCavernsDimNightmare);
            
            Add(FliesAndSpidersNightmare);
            Add(TheLonelyMountainNightmare);
            Add(TheBattleOfFiveArmiesNightmare);

            Add(AShadowOfThePastNightmare);
            Add(AKnifeInTheDarkNightmare);
            Add(FlightToTheFordNightmare);

            Add(TheRingGoesSouthNightmare);
            Add(JourneyInTheDarkNightmare);
            Add(BreakingOfTheFellowshipNightmare);

            Add(TheUrukHaiNightmare);
            Add(HelmsDeepNightmare);
            Add(TheRoadToIsengardNightmare);

            Add(ThePassageOfTheMarshesNightmare);
            Add(JourneyToTheCrossRoadsNightmare);
            Add(ShelobsLairNightmare);

            Add(FirstAge);
            Add(TrialUponTheMarches);
            Add(AmongTheOutlaws);
        }

        public static List<CardSet> All()
        {
            return all;
        }

        #region Static Members
        public static CardSet CoreSet = new Sets.Core.CoreSet();
        public static CardSet TheHuntForGollum = new Sets.ShadowsOfMirkwood.TheHuntforGollum();
        public static CardSet ConflictAtTheCarrock = new Sets.ShadowsOfMirkwood.ConflictattheCarrock();
        public static CardSet AJourneyToRhosgobel = new Sets.ShadowsOfMirkwood.AJourneytoRhosgobel();
        public static CardSet TheHillsOfEmynMuil = new Sets.ShadowsOfMirkwood.TheHillsofEmynMuil();
        public static CardSet TheDeadMarshes = new Sets.ShadowsOfMirkwood.TheDeadMarshes();
        public static CardSet ReturnToMirkwood = new Sets.ShadowsOfMirkwood.ReturntoMirkwood();
        
        public static CardSet KhazadDum = new Sets.KhazadDum.KhazadDumSet();
        public static CardSet TheRedhornGate = new Sets.Dwarrowdelf.TheRedhornGate();
        public static CardSet RoadToRivendell = new Sets.Dwarrowdelf.RoadtoRivendell();
        public static CardSet TheWatcherInTheWater = new Sets.Dwarrowdelf.TheWatcherintheWater();
        public static CardSet TheLongDark = new Sets.Dwarrowdelf.TheLongDark();
        public static CardSet FoundationsOfStone = new Sets.Dwarrowdelf.FoundationsofStone();
        public static CardSet ShadowAndFlame = new Sets.Dwarrowdelf.ShadowandFlame();

        public static CardSet HeirsOfNumenor = new Sets.HeirsOfNumenor.HeirsofNumenorSet();
        public static CardSet TheStewardsFear = new Sets.AgainstTheShadow.TheStewardsFear();
        public static CardSet TheDruadanForest = new Sets.AgainstTheShadow.TheDruadanForest();
        public static CardSet EncounterAtAmonDin = new Sets.AgainstTheShadow.EncounteratAmonDin();
        public static CardSet AssaultOnOsgiliath = new Sets.AgainstTheShadow.AssaultOnOsgiliath();
        public static CardSet TheBloodOfGondor = new Sets.AgainstTheShadow.TheBloodofGondor();
        public static CardSet TheMorgulVale = new Sets.AgainstTheShadow.TheMorgulVale();

        public static CardSet TheVoiceOfIsengard = new Sets.TheVoiceOfIsengard.TheVoiceofIsengardSet();
        public static CardSet TheDunlandTrap = new Sets.TheRingMaker.TheDunlandTrap();
        public static CardSet TheThreeTrials = new Sets.TheRingMaker.TheThreeTrials();
        public static CardSet TroubleInTharbad = new Sets.TheRingMaker.TroubleInTharbad();
        public static CardSet TheNinInEilph = new Sets.TheRingMaker.TheNinInEilph();
        public static CardSet CelebrimborsSecret = new Sets.TheRingMaker.CelebrimborsSecret();
        public static CardSet TheAntleredCrown = new Sets.TheRingMaker.TheAntleredCrown();

        public static CardSet TheLostRealm = new Sets.TheLostRealm.TheLostRealmSet();
        public static CardSet TheWastesOfEriador = new Sets.AngmarAwakened.TheWastesOfEriador();
        public static CardSet EscapeFromMountGram = new Sets.AngmarAwakened.EscapeFromMountGram();
        public static CardSet AcrossTheEttenmoors = new Sets.AngmarAwakened.AcrossTheEttenmoors();
        public static CardSet TheTreacheryOfRhudaur = new Sets.AngmarAwakened.TheTreacheryOfRhudaur();
        public static CardSet TheBattleOfCarnDum = new Sets.AngmarAwakened.TheBattleOfCarnDum();
        public static CardSet TheDreadRealm = new Sets.AngmarAwakened.TheDreadRealm();

        public static CardSet TheGreyHavens = new Sets.TheGreyHavens.TheGreyHavensSet();
        public static CardSet FlightOfTheStormcaller = new Sets.DreamChaser.FlightOfTheStormcaller();
        public static CardSet TheThingInTheDepths = new Sets.DreamChaser.TheThingInTheDepths();
        public static CardSet TempleOfTheDeceived = new Sets.DreamChaser.TempleOfTheDeceived();
        public static CardSet TheDrownedRuins = new Sets.DreamChaser.TheDrownedRuins();
        public static CardSet AStormOnCobasHaven = new Sets.DreamChaser.AStormOnCobasHaven();
        public static CardSet TheCityOfCorsairs = new Sets.DreamChaser.TheCityOfCorsairs();

        public static CardSet TheSandsOfHarad = new Sets.TheSandsOfHarad.TheSandsOfHaradSet();
        public static CardSet TheMumakil = new Sets.Haradrim.TheMumakil();
        public static CardSet RaceAcrossHarad = new Sets.Haradrim.RaceAcrossHarad();
        public static CardSet BeneathTheSands = new Sets.Haradrim.BeneathTheSands();
        public static CardSet TheBlackSerpent = new Sets.Haradrim.TheBlackSerpent();
        public static CardSet TheDungeonsOfCirithGurat = new Sets.Haradrim.TheDungeonsOfCirithGurat();
        public static CardSet TheCrossingsOfPoros = new Sets.Haradrim.TheCrossingsOfPoros();

        public static CardSet TheHobbitOverHillAndUnderHill = new Sets.TheHobbit.OverHillandUnderHillSet();
        public static CardSet TheHobbitOnTheDoorstep = new Sets.TheHobbit.OntheDoorstepSet();

        public static CardSet TheBlackRiders = new Sets.TheLordOfTheRings.TheBlackRiders();
        public static CardSet TheRoadDarkens = new Sets.TheLordOfTheRings.TheRoadDarkens();
        public static CardSet TheTreasonOfSaruman = new Sets.TheLordOfTheRings.TheTreasonOfSaruman();
        public static CardSet TheLandOfShadow = new Sets.TheLordOfTheRings.TheLandOfShadow();
        public static CardSet TheFlameOfTheWest = new Sets.TheLordOfTheRings.TheFlameOfTheWest();
        public static CardSet TheMountainOfFire = new Sets.TheLordOfTheRings.TheMountainOfFire();

        public static CardSet TheMassingAtOsgiliath = new Sets.PrintOnDemand.TheMassingatOsgiliath();
        public static CardSet TheBattleOfLakeTown = new Sets.PrintOnDemand.TheBattleofLakeTown();
        public static CardSet TheStoneOfErech = new Sets.PrintOnDemand.TheStoneofErech();
        public static CardSet TheRuinsOfBelegost = new Sets.PrintOnDemand.TheRuinsOfBelegost();
        public static CardSet TheSiegeOfAnnuminas = new Sets.PrintOnDemand.TheSiegeOfAnnuminas();
        public static CardSet AssaultOnDolGuldur = new Sets.PrintOnDemand.AssaultOnDolGuldurSet();

        public static CardSet PassageThroughMirkwoodNightmare = new Sets.Core.PassageThroughMirkwoodNightmareSet();
        public static CardSet JourneyAlongTheAnduinNightmare = new Sets.Core.JourneyAlongTheAnduinNightmareSet();
        public static CardSet EscapeFromDolGuldurNightmare = new Sets.Core.EscapeFromDolGuldurNightmareSet();

        public static CardSet TheHuntForGollumNightmare = new Sets.ShadowsOfMirkwood.TheHuntForGollumNightmare();
        public static CardSet ConflictAtTheCarrockNightmare = new Sets.ShadowsOfMirkwood.ConflictAtTheCarrockNightmare();
        public static CardSet AJourneyToRhosgobelNightmare = new Sets.ShadowsOfMirkwood.AJourneyToRhosgobelNightmare();
        public static CardSet TheHillsOfEmynMuilNightmare = new Sets.ShadowsOfMirkwood.TheHillsOfEmynMuilNightmare();
        public static CardSet TheDeadMarshesNightmare = new Sets.ShadowsOfMirkwood.TheDeadMarshesNightmare();
        public static CardSet ReturnToMirkwoodNightmare = new Sets.ShadowsOfMirkwood.ReturnToMirkwoodNightmare();

        public static CardSet IntoThePitNightmare = new Sets.KhazadDum.IntoThePitNightmare();
        public static CardSet TheSeventhLevelNightmare = new Sets.KhazadDum.TheSeventhLevelNightmare();
        public static CardSet FlightFromMoriaNightmare = new Sets.KhazadDum.FlightFromMoriaNightmare();

        public static CardSet TheRedhornGateNightmare = new Sets.Dwarrowdelf.TheRedhornGateNightmare();
        public static CardSet RoadToRivendellNightmare = new Sets.Dwarrowdelf.RoadToRivendellNightmare();
        public static CardSet TheWatcherInTheWaterNightmare = new Sets.Dwarrowdelf.TheWatcherInTheWaterNightmare();
        public static CardSet TheLongDarkNightmare = new Sets.Dwarrowdelf.TheLongDarkNightmare();
        public static CardSet FoundationsOfStoneNightmare = new Sets.Dwarrowdelf.FoundationsOfStoneNightmare();
        public static CardSet ShadowAndFlameNightmare = new Sets.Dwarrowdelf.ShadowAndFlameNightmare();

        public static CardSet PerilInPelargirNightmare = new Sets.HeirsOfNumenor.PerilInPelargirNightmare();
        public static CardSet IntoIthilienNightmare = new Sets.HeirsOfNumenor.IntoIthilienNightmare();
        public static CardSet TheSiegeOfCairAndrosNightmare = new Sets.HeirsOfNumenor.TheSiegeOfCairAndrosNightmare();

        public static CardSet TheStewardsFearNightmare = new Sets.AgainstTheShadow.TheStewardsFearNightmare();
        public static CardSet TheDruadanForestNightmare = new Sets.AgainstTheShadow.TheDruadanForestNightmare();
        public static CardSet EncounterAtAmonDinNightmare = new Sets.AgainstTheShadow.EncounterAtAmonDinNightmare();
        public static CardSet AssaultOnOsgiliathNightmare = new Sets.AgainstTheShadow.AssaultOnOsgiliathNightmare();
        public static CardSet TheBloodOfGondorNightmare = new Sets.AgainstTheShadow.TheBloodOfGondorNightmare();
        public static CardSet TheMorgulValeNightmare = new Sets.AgainstTheShadow.TheMorgulValeNightmare();

        public static CardSet TheFordsOfIsenNightmare = new Sets.TheVoiceOfIsengard.TheFordsOfIsenNightmare();
        public static CardSet ToCatchAnOrcNightmare = new Sets.TheVoiceOfIsengard.ToCatchAnOrcNightmare();
        public static CardSet IntoFangornNightmare = new Sets.TheVoiceOfIsengard.IntoFangornNightmare();

        public static CardSet TheDunlandTrapNightmare = new Sets.TheRingMaker.TheDunlandTrapNightmare();
        public static CardSet TheThreeTrialsNightmare = new Sets.TheRingMaker.TheThreeTrialsNightmare();
        public static CardSet TroubleInTharbadNightmare = new Sets.TheRingMaker.TroubleInTharbadNightmare();
        public static CardSet TheNinInEilphNightmare = new Sets.TheRingMaker.TheNinInEilphNightmare();
        public static CardSet CelebrimborsSecretNightmare = new Sets.TheRingMaker.CelebrimborsSecretNightmare();
        public static CardSet TheAntleredCrownNightmare = new Sets.TheRingMaker.TheAntleredCrownNightmare();

        public static CardSet IntrudersInChetwoodNightmare = new Sets.TheLostRealm.IntrudersInChetwoodNightmare();
        public static CardSet TheWeatherHillsNightmare = new Sets.TheLostRealm.TheWeatherHillsNightmare();
        public static CardSet DeadmensDikeNightmare = new Sets.TheLostRealm.DeadmensDikeNightmare();
        
        public static CardSet TheWastesOfEriadorNightmare = new Sets.AngmarAwakened.TheWastesOfEriadorNightmare();
        public static CardSet EscapeFromMountGramNightmare = new Sets.AngmarAwakened.EscapeFromMountGramNightmare();
        public static CardSet AcrossTheEttenmoorsNightmare = new Sets.AngmarAwakened.AcrossTheEttenmoorsNightmare();
        public static CardSet TheTreacheryOfRhudaurNightmare = new Sets.AngmarAwakened.TheTreacheryOfRhudaurNightmare();
        public static CardSet TheBattleOfCarnDumNightmare = new Sets.AngmarAwakened.TheBattleOfCarnDumNightmare();
        public static CardSet TheDreadRealmNightmare = new Sets.AngmarAwakened.TheDreadRealmNightmare();

        public static CardSet WeMustAwayEreBreakOfDayNightmare = new Sets.TheHobbit.WeMustAwayEreBreakOfDayNightmare();
        public static CardSet OverTheMistyMountainsGrimNightmare = new Sets.TheHobbit.OverTheMistyMountainsGrimNightmare();
        public static CardSet DungeonsDeepAndCavernsDimNightmare = new Sets.TheHobbit.DungeonsDeepAndCavernsDimNightmare();
        public static CardSet FliesAndSpidersNightmare = new Sets.TheHobbit.FliesAndSpidersNightmare();
        public static CardSet TheLonelyMountainNightmare = new Sets.TheHobbit.TheLonelyMountainNightmare();
        public static CardSet TheBattleOfFiveArmiesNightmare = new Sets.TheHobbit.TheBattleOfFiveArmiesNightmare();

        public static CardSet AShadowOfThePastNightmare = new Sets.TheLordOfTheRings.AShadowOfThePastNightmare();
        public static CardSet AKnifeInTheDarkNightmare = new Sets.TheLordOfTheRings.AKnifeInTheDarkNightmare();
        public static CardSet FlightToTheFordNightmare = new Sets.TheLordOfTheRings.FlightToTheFordNightmare();
        public static CardSet TheRingGoesSouthNightmare = new Sets.TheLordOfTheRings.TheRingGoesSouthNightmare();
        public static CardSet JourneyInTheDarkNightmare = new Sets.TheLordOfTheRings.JourneyInTheDarkNightmare();
        public static CardSet BreakingOfTheFellowshipNightmare = new Sets.TheLordOfTheRings.BreakingOfTheFellowshipNightmare();

        public static CardSet TheUrukHaiNightmare = new Sets.TheLordOfTheRings.TheUrukHaiNightmare();
        public static CardSet HelmsDeepNightmare = new Sets.TheLordOfTheRings.HelmsDeepNightmareSet();
        public static CardSet TheRoadToIsengardNightmare = new Sets.TheLordOfTheRings.TheRoadToIsengardNightmareSet();

        public static CardSet ThePassageOfTheMarshesNightmare = new Sets.TheLordOfTheRings.ThePassageOfTheMarshesNightmareSet();
        public static CardSet JourneyToTheCrossRoadsNightmare = new Sets.TheLordOfTheRings.JourneyToTheCrossRoadsNightmareSet();
        public static CardSet ShelobsLairNightmare = new Sets.TheLordOfTheRings.ShelobsLairNightmareSet();

        public static CardSet TheOldForest = new Sets.PrintOnDemand.TheOldForest();
        public static CardSet FogOnTheBarrowDowns = new Sets.PrintOnDemand.FogOnTheBarrowDowns();
        public static CardSet MurderAtThePrancingPony = new Sets.PrintOnDemand.MurderAtThePrancingPony();

        public static CardSet FirstAge = new Sets.FirstAge.FirstAgeSet();
        public static CardSet TrialUponTheMarches = new Sets.FirstAge.TrialUponTheMarchesSet();
        public static CardSet AmongTheOutlaws = new Sets.FirstAge.AmongTheOutlawsSet();
        #endregion
    }
}