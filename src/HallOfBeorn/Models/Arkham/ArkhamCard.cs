﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HallOfBeorn.Models.Arkham
{
    public class ArkhamCard : Card
    {
        private ArkhamCard()
        {
            Subtitle = string.Empty;
            FrontText = string.Empty;
            FrontFlavor = string.Empty;
            BackText = string.Empty;
            BackFlavor = string.Empty;
        }

        
        private readonly List<SkillIcon> skillTestIcons = new List<SkillIcon>();
        private readonly List<ConnectionSymbol> connections = new List<ConnectionSymbol>();

        private ArkhamProduct product;
        public ArkhamProduct Product { 
            get { return product; }
            set {
                product = value;
                NamedProduct = value;
            }
        }
        public ArkhamDeckType DeckType { get; set; }
        public ArkhamCardType CardType { get; set; }
        public ArkhamCardType? BackCardType { get; set; }
        public ArkhamCardSubtype CardSubtype { get; set; }
        
        public string Subtitle { get; private set; }
        
        public Number? Willpower { get; private set; }
        public Number? Intellect { get; private set; }
        public Number? Combat { get; private set; }
        public Number? Agility { get; private set; }

        public Number? Cost { get; private set; }
        public byte? Level { get; private set; }
        public AssetSlot? Slot { get; private set; }
        
        public Number? Shroud { get; private set; }
        public Number? ClueValue { get; private set; }
        public ConnectionSymbol? LocationSymbol { get; private set; }
        public ConnectionSymbol? BackLocationSymbol { get; private set; }

        public byte? Sequence { get; private set; }
        public Number? DoomThreshold { get; private set; }
        public Number? ClueThreshold { get; private set; }

        public Number? EnemyFightValue { get; private set; }
        public Number? EnemyHealthValue { get; private set; }
        public Number? EnemyEvadeValue { get; private set; }
        public Number? Damage { get; private set; }
        public Number? Horror { get; private set; }

        public string FrontText { 
            get { return Text; }
            set { Text = value; }
        }
        public string FrontFlavor
        {
            get { return FlavorText; }
            protected set { FlavorText = value; }
        }

        public string BackText
        {
            get { return OppositeText; }
            protected set { OppositeText = value; }
        }

        public string BackFlavor
        {
            get { return OppositeFlavorText; }
            protected set { OppositeFlavorText = value; }
        }
        
        public ClassSymbol ClassSymbol { get; private set; }
        public Number? Health { get; private set; }
        public Number? Sanity { get; private set; }
        public ArkhamEncounterSet EncounterSet { get; private set; }

        protected void addSkillTestIcons(IEnumerable<SkillIcon> skillIcons)
        {
            this.skillTestIcons.AddRange(skillIcons);
        }

        protected override string getSlug()
        {
            var name = Title.ToUrlSafeString();
            var level = string.Empty;
            if (CardType == ArkhamCardType.Scenario_Reference || CardType == ArkhamCardType.Location) {
                level = "-" + Subtitle.Replace(" / ", "-").Replace(" ", "-");
            } else {
                level = (Level.HasValue && Level.Value > 0) ? Level.ToString() : string.Empty;
            }
            var product = Product.Abbreviation;
            return string.Format("{0}{1}-{2}", name, level, product);
        }

        public IEnumerable<SkillIcon> SkillIcons()
        {
            return skillTestIcons;
        }

        public IEnumerable<ConnectionSymbol> Connections()
        {
            return connections;
        }

        public ArkhamCard WithEncounterSet(ArkhamEncounterSet encounterSet)
        {
            this.EncounterSet = encounterSet;
            return this;
        }

        public static ArkhamCard Investigator(string title, string subtitle, ClassSymbol classSymbol, byte health, byte sanity)
        {
            return new ArkhamCard()
            {
                CardType = ArkhamCardType.Investigator,
                DeckType = ArkhamDeckType.Player,
                Title = title,
                IsUnique = true,
                Subtitle = subtitle,
                ClassSymbol = classSymbol,
                Health = Number.Of(health),
                Sanity = Number.Of(sanity)
            };
        }

        public static ArkhamCard Asset(string title, ClassSymbol classSymbol, byte cost)
        {
            return Asset(title, classSymbol, cost, AssetSlot.None);
        }

        public static ArkhamCard Asset(string title, ClassSymbol classSymbol, byte cost, AssetSlot slot)
        {
            return Asset(title, classSymbol, Number.Of(cost), slot);
        }

        public static ArkhamCard Asset(string title, ClassSymbol classSymbol, Number cost, AssetSlot slot)
        {
            return new ArkhamCard()
            {
                CardType = ArkhamCardType.Asset,
                DeckType = ArkhamDeckType.Player,
                Title = title,
                ClassSymbol = classSymbol,
                Cost = cost,
                Slot = slot
            };
        }

        public static ArkhamCard Skill(string title, ClassSymbol classSymbol, byte level)
        {
            return new ArkhamCard
            {
                CardType = ArkhamCardType.Skill,
                DeckType = ArkhamDeckType.Player,
                Title = title,
                ClassSymbol = classSymbol,
                Level = level
            };
        }

        public static ArkhamCard Event(string title, ClassSymbol classSymbol, byte cost)
        {
            return Event(title, classSymbol, cost, 0);
        }

        public static ArkhamCard Event(string title, ClassSymbol classSymbol, byte cost, byte level)
        {
            return Event(title, classSymbol, Number.Of(cost), level);
        }

        public static ArkhamCard Event(string title, ClassSymbol classSymbol, Number cost, byte level)
        {
            return new ArkhamCard()
            {
                CardType = ArkhamCardType.Event,
                DeckType = ArkhamDeckType.Player,
                Title = title,
                ClassSymbol = classSymbol,
                Cost = cost,
                Level = level
            };
        }

        public static ArkhamCard Enemy(string title, Number fightValue, Number healthValue, Number evadeValue, Number damage, Number horror)
        {
            return Enemy(title, fightValue, healthValue, evadeValue, damage, horror, null);
        }

        public static ArkhamCard Enemy(string title, Number fightValue, Number healthValue, Number evadeValue, Number damage, Number horror, ArkhamEncounterSet encounterSet)
        {
            return new ArkhamCard()
            {
                EncounterSet = encounterSet,
                CardType = ArkhamCardType.Enemy,
                DeckType = ArkhamDeckType.Encounter,
                Title = title,
                EnemyFightValue = fightValue,
                EnemyHealthValue = healthValue,
                EnemyEvadeValue = evadeValue,
                Damage = damage,
                Horror = horror
            };
        }

        public ArkhamCard WithEnemyStats(Number fightValue, Number healthValue, Number evadeValue, Number damage, Number horror)
        {
            EnemyFightValue = fightValue;
            EnemyHealthValue = healthValue;
            EnemyEvadeValue = evadeValue;
            Damage = damage;
            Horror = horror;
            return this;
        }

        public ArkhamCard WithBackCardType(ArkhamCardType backCardType)
        {
            BackCardType = backCardType;
            return this;
        }

        public static ArkhamCard Location(string title, ConnectionSymbol locationSymbol, Number shroud, Number clueValue, ArkhamEncounterSet encounterSet)
        {
            return new ArkhamCard()
            {
                EncounterSet = encounterSet,
                CardType = ArkhamCardType.Location,
                DeckType = ArkhamDeckType.Encounter,
                Title = title,
                LocationSymbol = locationSymbol,
                Shroud = shroud,
                ClueValue = clueValue
            };
        }

        public static ArkhamCard Treachery(string title, ArkhamEncounterSet encounterSet)
        {
            return Treachery(title, ArkhamCardSubtype.None, encounterSet);
        }

        public static ArkhamCard Treachery(string title, ArkhamCardSubtype subtype)
        {
            return Treachery(title, subtype, null);
        }

        public static ArkhamCard Treachery(string title, ArkhamCardSubtype subtype, ArkhamEncounterSet encounterSet)
        {
            return new ArkhamCard
            {
                EncounterSet = encounterSet,
                CardType = ArkhamCardType.Treachery,
                DeckType = ArkhamDeckType.Player,
                Title = title,
                CardSubtype = subtype
            };
        }

        public static ArkhamCard ScenarioReference(string title, string subtitle, ArkhamEncounterSet encounterSet) 
        {
            return new ArkhamCard
            {
                EncounterSet = encounterSet,
                CardType = ArkhamCardType.Scenario_Reference,
                DeckType = ArkhamDeckType.None,
                Title = title,
                Subtitle = subtitle
            };
        }

        public static ArkhamCard CampaignRules(string title)
        {
            return new ArkhamCard
            {
                CardType = ArkhamCardType.Campaign_Rules,
                DeckType = ArkhamDeckType.None,
                Title = title
            };
        }

        public static ArkhamCard Agenda(string title, string subtitle, byte sequence, Number doomThreshold, ArkhamEncounterSet encounterSet)
        {
            return new ArkhamCard()
            {
                EncounterSet = encounterSet,
                CardType = ArkhamCardType.Agenda,
                DeckType = ArkhamDeckType.Agenda,
                Title = title,
                Subtitle = subtitle,
                Sequence = sequence,
                DoomThreshold = doomThreshold
            };
        }

        public static ArkhamCard Act(string title, string subtitle, byte sequence, Number clueThreshold, ArkhamEncounterSet encounterSet)
        {
            return new ArkhamCard()
            {
                EncounterSet = encounterSet,
                CardType = ArkhamCardType.Act,
                DeckType = ArkhamDeckType.Act,
                Title = title,
                Subtitle = subtitle,
                Sequence = sequence,
                ClueThreshold = clueThreshold
            };
        }

        public ArkhamCard WithUnique()
        {
            this.IsUnique = true;
            return this;
        }

        public ArkhamCard WithHealth(byte health)
        {
            this.Health = health > 0 ? Number.Of(health) : Number.NA;
            return this;
        }

        public ArkhamCard WithSanity(byte sanity)
        {
            this.Sanity = sanity > 0 ? Number.Of(sanity) : Number.NA;
            return this;
        }

        public ArkhamCard WithSubtype(ArkhamCardSubtype subtype)
        {
            this.CardSubtype = subtype;
            return this;
        }

        public ArkhamCard WithSubtitle(string subtitle)
        {
            this.Subtitle = subtitle;
            return this;
        }

        public ArkhamCard WithTraits(params string[] traits)
        {
            addTraits(traits);
            return this;
        }

        public ArkhamCard WithKeywords(params string[] keywords)
        {
            addKeywords(keywords);
            return this;
        }

        public ArkhamCard WithCost(Number cost)
        {
            this.Cost = cost;
            return this;
        }

        public ArkhamCard WithLevel(byte level)
        {
            this.Level = level;
            return this;
        }

        public ArkhamCard WithAssetSlot(AssetSlot slot)
        {
            this.Slot = slot;
            return this;
        }

        public ArkhamCard WithVictoryPoints(byte victoryPoints)
        {
            this.VictoryPoints = victoryPoints;
            return this;
        }

        public ArkhamCard WithBackLocationSymbol(ConnectionSymbol symbol)
        {
            this.BackLocationSymbol = symbol;
            return this;
        }

        public ArkhamCard WithConnections(params ConnectionSymbol[] connections)
        {
            this.connections.AddRange(connections);
            return this;
        }

        public ArkhamCard WithSkills(byte willpower, byte intellect, byte combat, byte agility)
        {
            this.Willpower = Number.Of(willpower);
            this.Intellect = Number.Of(intellect);
            this.Combat = Number.Of(combat);
            this.Agility = Number.Of(agility);
            return this;
        }

        public ArkhamCard WithIcons(params SkillIcon[] skillIcons)
        {
            addSkillTestIcons(skillIcons);
            return this;
        }

        public ArkhamCard WithShroud(byte value, bool perInvestigator, bool isX)
        {
            this.Shroud = new Number { Value = value, IsPerInvestigator = perInvestigator, IsX = isX };
            return this;
        }

        public ArkhamCard WithClueValue(byte value, bool perInvestigator, bool isX)
        {
            this.ClueValue = new Number { Value = value, IsPerInvestigator = perInvestigator, IsX = isX };
            return this;
        }

        public ArkhamCard WithDoomThreshold(Number doomThreshold)
        {
            this.DoomThreshold = doomThreshold;
            return this;
        }

        public ArkhamCard WithClueThreshold(Number clueThreshold)
        {
            this.ClueThreshold = clueThreshold;
            return this;
        }

        /*
        public ArkhamCard WithDamage(byte? damage)
        {
            this.Damage = damage;
            return this;
        }

        public ArkhamCard WithHorror(byte? horror)
        {
            this.Horror = horror;
            return this;
        }
        */

        public ArkhamCard WithText(string text)
        {
            return WithFrontText(text);
        }

        public ArkhamCard WithFlavor(string flavor)
        {
            return WithFrontFlavor(flavor);
        }

        public ArkhamCard WithFrontText(string text)
        {
            this.FrontText = text;
            return this;
        }

        public ArkhamCard WithFrontFlavor(string flavor)
        {
            this.FrontFlavor = flavor;
            return this;
        }

        public ArkhamCard WithBackText(string text)
        {
            this.BackText = text;
            return this;
        }

        public ArkhamCard WithBackFlavor(string flavor)
        {
            this.BackFlavor = flavor;
            return this;
        }

        public ArkhamCard WithBackArtist(Artist artist)
        {
            this.BackArtist = artist;
            return this;
        }

        public ArkhamCard WithInfo(byte cardNumber, byte quantity, Artist artist)
        {
            this.CardNumber = cardNumber;
            this.Quantity = quantity;
            this.Artist = artist;
            return this;
        }
    }
}