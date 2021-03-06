﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HallOfBeorn.Models.LotR
{
    public class LotRCard : Card
    {
        public LotRCard()
        {
            IncludedEncounterSets = new List<EncounterSet>();

            StageLetter = 'A';

            Html = string.Empty;
            Html2 = string.Empty;

            AlternateEncounterSet = string.Empty;
        }

        protected override string getSlug()
        {
            var title = !string.IsNullOrEmpty(NormalizedTitle) ? NormalizedTitle.ToUrlSafeString() : Title.ToUrlSafeString();
            var suffix = !string.IsNullOrEmpty(SlugSuffix) ? string.Format("{0}-", SlugSuffix.ToUrlSafeString()) : string.Empty;
            var set = CardSet.Abbreviation.ToString().ToUrlSafeString();
            return string.Format("{0}-{1}{2}", title, suffix, set);
        }

        private string html;
        public string Html
        {
            get
            {
                if (!string.IsNullOrEmpty(HtmlTemplate) && string.IsNullOrEmpty(html)) 
                {
                    html = new TextTemplate(this).RenderFrontHtml();
                }

                return html;
            }
            set { html = value; }
        }

        public string HtmlTemplate;

        private string html2;
        public string Html2
        {
            get
            {
                if (!string.IsNullOrEmpty(HtmlTemplate2) && string.IsNullOrEmpty(html2))
                {
                    html2 = new TextTemplate(this).RenderBackHtml();
                }

                return html2;
            }
            set { html2 = value; }
        }

        public string HtmlTemplate2;

        public uint StageNumber { get; set; }
        public char StageLetter { get; private set; }

        private CardSet cardSet;
        public CardSet CardSet {
            get { return cardSet; } 
            set {
                cardSet = value;
                NamedProduct = value;
            }
        }

        public CardType CardType { get; set; }
        public CardSubtype CardSubtype { get; set; }
        public Sphere Sphere { get; set; }

        public byte? MaxPerDeck { get; set; }
        public byte? ThreatCost { get; set; }
        public byte? ResourceCost { get; set; }
        public byte? EngagementCost { get; set; }

        public byte? Threat { get; set; }
        public byte? Willpower { get; set; }
        public byte? Attack { get; set; }
        public byte? Defense { get; set; }
        public byte? HitPoints { get; set; }
        public byte? QuestPoints { get; set; }

        public string Shadow { get; set; }
        public string EncounterSet { get; set; }
        public string AlternateEncounterSet { get; set; }
        public List<EncounterSet> IncludedEncounterSets { get; set; }
        public bool? PassValue { get; set; }
        public byte? EyeIcon { get; set; }
        public byte? EasyModeQuantity { get; set; }
        public byte? NightmareModeQuantity { get; set; }

        public bool HasErrata { get; set; }

        private DeckType deckType = DeckType.None;
        public DeckType DeckType
        {
            get {
                if (deckType != DeckType.None) {
                    return deckType;
                }

                switch (CardType)
                {
                    case LotR.CardType.Hero:
                    case LotR.CardType.Ally:
                    case LotR.CardType.Attachment:
                    case LotR.CardType.Event:
                    case LotR.CardType.Treasure:
                    case LotR.CardType.Player_Side_Quest:
                        return DeckType.Player;
                    case LotR.CardType.Enemy:
                    case LotR.CardType.Location:
                    case LotR.CardType.Treachery:
                    case LotR.CardType.Objective:
                    case LotR.CardType.Objective_Ally:
                    case LotR.CardType.Objective_Hero:
                    case LotR.CardType.Objective_Location:
                    case LotR.CardType.Encounter_Side_Quest:
                    case LotR.CardType.Ship_Objective:
                    case LotR.CardType.Ship_Enemy:
                        return DeckType.Encounter;
                    case LotR.CardType.Quest:
                    case LotR.CardType.Campaign:
                    case LotR.CardType.GenCon_Setup:
                    case LotR.CardType.Nightmare_Setup:
                        return DeckType.Quest;
                    default:
                        return DeckType.None;
                }
            }
        }

        #region Static Fluent Helpers

        public static LotRCard Hero(string title, string id, Sphere sphere, byte threatCost, byte willpower, byte attack, byte defense, byte hitPoints)
        {
            return new LotRCard()
            {
                CardType = Models.LotR.CardType.Hero,
                Title = title,
                Id = id,
                IsUnique = true,
                Sphere = sphere,
                ThreatCost = threatCost,
                Willpower = willpower,
                Attack = attack,
                Defense = defense,
                HitPoints = hitPoints
            };
        }

        public static LotRCard Ally(string title, Sphere sphere, byte resourceCost, byte willpower, byte attack, byte defense, byte hitPoints)
        {
            return new LotRCard()
            {
                CardType = Models.LotR.CardType.Ally,
                Title = title,
                Sphere = sphere,
                ResourceCost = resourceCost,
                Willpower = willpower,
                Attack = attack,
                Defense = defense,
                HitPoints = hitPoints
            };
        }

        public static LotRCard Attachment(string title, string id, Sphere sphere, byte resourceCost)
        {
            return new LotRCard()
            {
                CardType = Models.LotR.CardType.Attachment,
                Title = title,
                Id = id,
                Sphere = sphere,
                ResourceCost = resourceCost
            };
        }

        public static LotRCard Event(string title, string id, Sphere sphere, byte resourceCost)
        {
            return new LotRCard()
            {
                CardType = Models.LotR.CardType.Event,
                Title = title,
                Id = id,
                Sphere = sphere,
                ResourceCost = resourceCost
            };
        }

        public static LotRCard ObjectiveHero(string title, string encounterSet, byte willpower, byte attack, byte defense, byte hitPoints)
        {
            return new LotRCard()
            {
                CardType = Models.LotR.CardType.Objective_Hero,
                Title = title,
                Id = string.Empty,
                EncounterSet = encounterSet,
                IsUnique = true,
                Willpower = willpower,
                Attack = attack,
                Defense = defense,
                HitPoints = hitPoints
            };
        }

        public static LotRCard Enemy(string title, string id, string encounterSet, byte? engagementCost, byte? threat, byte? attack, byte? defense, byte? hitPoints)
        {
            return new LotRCard()
            {
                CardType = Models.LotR.CardType.Enemy,
                Title = title,
                Id = string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id,
                EngagementCost = engagementCost,
                Threat = threat,
                Attack = attack,
                Defense = defense,
                HitPoints = hitPoints,
                EncounterSet = encounterSet
            };
        }

        public static LotRCard Location(string title, string id, string encounterSet, byte? threat, byte? questPoints)
        {
            return new LotRCard()
            {
                CardType = Models.LotR.CardType.Location,
                Title = title,
                Id = id,
                Threat = threat,
                QuestPoints = questPoints,
                EncounterSet = encounterSet
            };
        }

        public static LotRCard Treachery(string title, string id, string encounterSet)
        {
            return new LotRCard()
            {
                CardType = Models.LotR.CardType.Treachery,
                Title = title,
                Id = id,
                EncounterSet = encounterSet
            };
        }

        public static LotRCard EncounterSideQuest(string title, string id, string encounterSet, byte? questPoints)
        {
            return new LotRCard()
            {
                CardType = CardType.Encounter_Side_Quest,
                Title = title,
                Id = id,
                EncounterSet = encounterSet,
                QuestPoints = questPoints
            };
        }

        public static LotRCard PlayerSideQuest(string title, string id, Sphere sphere, byte resourceCost, byte questPoints)
        {
            return new LotRCard()
            {
                CardType = CardType.Player_Side_Quest,
                Title = title,
                Id = id,
                Sphere = sphere,
                ResourceCost = resourceCost,
                QuestPoints = questPoints
            };
        }

        public static LotRCard Quest(string title, uint stageNumber, string encounterSet, byte? questPoints)
        {
            return Quest(title, stageNumber, encounterSet, questPoints, 'A');
        }

        public static LotRCard Quest(string title, uint stageNumber, string encounterSet, byte? questPoints, char stageLetter)
        {
            return new LotRCard()
            {
                CardType = CardType.Quest,
                Title = title,
                EncounterSet = encounterSet,
                QuestPoints = questPoints,
                StageNumber = stageNumber,
                StageLetter = stageLetter,
                SlugSuffix = stageLetter == 'A' ? string.Empty : stageLetter.ToString()
            };
        }

        public static LotRCard Campaign(string title, string encounterSet, string oppositeTitle)
        {
            return new LotRCard()
            {
                CardType = CardType.Campaign,
                Title = title,
                EncounterSet = encounterSet,
                SlugSuffix = "Campaign",
                OppositeTitle = oppositeTitle
            };
        }

        public static LotRCard NightmareSetup(string title, string encounterSet)
        {
            return new LotRCard()
            {
                CardType = CardType.Nightmare_Setup,
                Title = title,
                Id = string.Empty,
                EncounterSet = encounterSet
            };
        }

        public static LotRCard GenConSetup(string title, string encounterSet)
        {
            return new LotRCard()
            {
                CardType = CardType.GenCon_Setup,
                Title = title,
                EncounterSet = encounterSet
            };
        }

        public static LotRCard Scenario(string title, int scenarioNumber, string encounterSet, string oppositeTitle)
        {
            return new LotRCard()
            {
                CardType = CardType.Scenario,
                Title = title,
                EncounterSet = encounterSet,
                OppositeTitle = oppositeTitle
            };
        }

        public static LotRCard Objective(string title, string id, string encounterSet)
        {
            return new LotRCard()
            {
                CardType = CardType.Objective,
                Title = title,
                Id = id,
                EncounterSet = encounterSet
            };
        }

        public static LotRCard ObjectiveAlly(string title, string id, string encounterSet, byte willpower, byte attack, byte defense, byte hitPoints)
        {
            return new LotRCard()
            {
                CardType = CardType.Objective_Ally,
                Title = title,
                Id = id,
                EncounterSet = encounterSet,
                Willpower = willpower,
                Attack = attack,
                Defense = defense,
                HitPoints = hitPoints
            };
        }

        public static LotRCard ObjectiveLocation(string title, string encounterSet, byte questPoints)
        {
            return new LotRCard()
            {
                CardType = CardType.Objective_Location,
                Title = title,
                Id = string.Empty,
                EncounterSet = encounterSet,
                QuestPoints = questPoints
            };
        }

        public static LotRCard ShipObjective(string title, string encounterSet, byte willpower, byte attack, byte defense, byte hitPoints)
        {
            return new LotRCard()
            {
                CardType = CardType.Ship_Objective,
                Title = title,
                Id = string.Empty,
                EncounterSet = encounterSet,
                Willpower = willpower,
                Attack = attack,
                Defense = defense,
                HitPoints = hitPoints
            };
        }

        public static LotRCard ShipEnemy(string title, string encounterSet, byte engagementCost, byte threat, byte attack, byte defense, byte hitPoints)
        {
            return new LotRCard()
            {
                CardType = Models.LotR.CardType.Ship_Enemy,
                Title = title,
                Id = string.Empty,
                EncounterSet = encounterSet,
                EngagementCost = engagementCost,
                Threat = threat,
                Attack = attack,
                Defense = defense,
                HitPoints = hitPoints
            };
        }

        public LotRCard WithUnique()
        {
            this.IsUnique = true;
            return this;
        }

        public LotRCard WithEasyModeQuantity(byte quantity)
        {
            this.EasyModeQuantity = quantity;
            return this;
        }

        public LotRCard WithTraits(params string[] traits)
        {
            addTraits(traits);
            return this;
        }

        public LotRCard WithVictoryPoints(byte victoryPoints)
        {
            this.VictoryPoints = victoryPoints;
            return this;
        }

        public LotRCard WithKeywords(params string[] keywords)
        {
            addKeywords(keywords);
            return this;
        }

        public LotRCard WithText(string text)
        {
            this.Text = text;
            return this;
        }

        public LotRCard WithOppositeTitle(string title)
        {
            return WithOppositeTitle(title, false);
        }

        public LotRCard WithOppositeTitle(string title, bool includedInSlug)
        {
            this.OppositeTitle = title;
            this.SlugSuffix = title;
            return this;
        }

        public LotRCard WithOppositeText(string text)
        {
            this.OppositeText = text;
            return this;
        }

        public LotRCard WithBackArtist(Artist artist)
        {
            this.BackArtist = artist;
            return this;
        }

        public LotRCard WithIncludedEncounterSets(params EncounterSet[] sets)
        {
            foreach (var set in sets)
                this.IncludedEncounterSets.Add(set);

            return this;
        }

        public LotRCard WithShadow(string shadow)
        {
            this.Shadow = shadow;
            return this;
        }

        public LotRCard WithYear(ushort year)
        {
            this.Year = year;
            return this;
        }

        public LotRCard WithInfo(byte number, byte quantity, Artist artist)
        {
            this.CardNumber = number;
            this.Quantity = quantity;
            this.Artist = artist;

            return this;
        }

        public LotRCard WithBoon()
        {
            this.CardSubtype = CardSubtype.Boon;
            return this;
        }

        public LotRCard WithBurden()
        {
            this.CardSubtype = CardSubtype.Burden;
            return this;
        }

        public LotRCard WithEyeIcon()
        {
            this.EyeIcon += 1;
            return this;
        }

        public LotRCard WithErrata()
        {
            this.HasErrata = true;
            return this;
        }

        public LotRCard WithTemplate(string htmlTemplate)
        {
            this.HtmlTemplate = htmlTemplate;
            return this;
        }

        public LotRCard WithTemplate2(string htmlTemplate)
        {
            this.HtmlTemplate2 = htmlTemplate;
            return this;
        }

        public LotRCard WithFlavor(string flavor)
        {
            this.FlavorText = flavor;
            return this;
        }

        public LotRCard WithOppositeFlavor(string flavor)
        {
            this.OppositeFlavorText = flavor;
            return this;
        }

        public LotRCard WithSuffix(string suffix)
        {
            this.SlugSuffix = suffix;
            return this;
        }

        public LotRCard WithStageLetter(char letter)
        {
            if (letter != 'A') {
                SlugSuffix = letter.ToString();
            }
            StageLetter = letter;
            return this;
        }

        #endregion
    }
}