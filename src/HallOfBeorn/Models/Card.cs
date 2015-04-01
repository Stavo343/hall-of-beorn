﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HallOfBeorn.Models
{
    public class Card
    {
        public Card()
        {
            Text = string.Empty;
            Traits = new List<string>();
            NormalizedTraits = new List<string>();
            Keywords = new List<string>();
            NormalizedKeywords = new List<string>();
            Categories = new List<Category>();
            EncounterCategories = new List<EncounterCategory>();
            QuestCategories = new List<QuestCategory>();
            Decks = new Dictionary<string, Deck>();
            RelatedCards = new List<Card>();
            IncludedEncounterSets = new List<EncounterSet>();

            UsePublicImageURL = true;
            Html = string.Empty;
        }

        #region Effect Functions

        private readonly List<Effect> effects = new List<Effect>();
        public void RenderEffects()
        {
            if (effects.Count == 0)
            {
                return;
            }

            var text = new StringBuilder();
            var html = new StringBuilder();

            foreach (var effect in effects)
            {
                text.Append(effect.ToText(this));
                html.Append(effect.ToHtml(this));
            }

            //this.Text = text.ToString();
            this.Html = html.ToString();
        }

        public string Html { get; set; }

        public Card Flavor(string flavor)
        {
            effects.Add(new Effect(CardEffectType.Flavor_Text, LayoutType.Block).Flavor(flavor));
            return this;
        }

        public Card Important(string important)
        {
            effects.Add(new Effect(CardEffectType.Flavor_Text, LayoutType.Important).Text(important));
            return this;
        }

        public Card Effect(Effect effect)
        {
            effects.Add(effect);
            return this;
        }

        #endregion

        private string scenarioTitle;

        public Dictionary<string, Deck> Decks { get; set; }
        public List<Card> RelatedCards { get; set; }

        public string Id { get; set; }
        
        public string ScenarioTitle 
        {
            get
            {
                return !string.IsNullOrEmpty(scenarioTitle) ? scenarioTitle : EncounterSet;
            }

            set { scenarioTitle = value; }
        }
        public int ScenarioNumber { get; set; }

        public string Title { get; set; }
        public string NormalizedTitle { get; set; }
        public string OppositeTitle { get; set; }
        public string NormalizedOppositeTitle { get; set; }

        public uint Number { get; set; }
        public uint StageNumber { get; set; }
        
        public string ImageName { get; set; }
        public ImageType ImageType { get; set; }

        public CardSet CardSet { get; set; }

        public bool IsUnique { get; set; }
        public CardType CardType { get; set; }
        public CardSubtype CardSubtype { get; set; }
        public Sphere Sphere { get; set; }
        public byte? ThreatCost { get; set; }
        public byte? ResourceCost { get; set; }
        
        public string ResourceCostLabel
        {
            get { return ResourceCost.Description(IsVariableCost); }
        }

        public string ThreatCostLabel
        {
            get { return ThreatCost.Description(false); }
        }

        public string EngagementCostLabel
        {
            get { return EngagementCost.Description(false); }
        }

        public byte? EngagementCost { get; set; }
        public byte? Threat { get; set; }
        public bool IsVariableCost { get; set; }
        public bool IsVariableThreat { get; set; }
        public bool IsVariableQuestPoints { get; set; }
        public bool IsVariableWillpower { get; set; }
        public bool IsVariableAttack { get; set; }
        public bool IsVariableDefense { get; set; }
        public bool IsVariableHitPoints { get; set; }
        public bool IsVariableVictoryPoints { get; set; }
        public byte? Willpower { get; set; }
        public byte? Attack { get; set; }
        public byte? Defense { get; set; }
        public byte? HitPoints { get; set; }
        public byte? QuestPoints { get; set; }

        public List<string> Traits { get; set; }
        public List<string> NormalizedTraits { get; set; }

        public List<string> Keywords { get; set; }
        public List<string> NormalizedKeywords { get; set; }

        public List<Category> Categories { get; private set; }
        public List<EncounterCategory> EncounterCategories { get; private set; }
        public List<QuestCategory> QuestCategories { get; private set; }

        public string Text { get; set; }
        public string OppositeText { get; set; }
        public string OppositeFlavorText { get; set; }
        public string Shadow { get; set; }
        public string EncounterSet { get; set; }
        public List<EncounterSet> IncludedEncounterSets { get; set; }
        public byte VictoryPoints { get; set; }
        public bool? PassValue { get; set; }
        public byte Quantity { get; set; }
        public byte? EasyModeQuantity { get; set; }
        public byte? NightmareModeQuantity { get; set; }
        public string Setup { get; set; }

        public string FlavorText { get; set; }
        public Artist Artist { get; set; }
        public Artist SecondArtist { get; set; }
        public Artist OppositeArtist { get; set; }
        public ushort Year { get; set; }
        public bool SlugIncludesOppositeTitle { get; set; }
        public bool SlugIncludesType { get; set; }

        private bool hasSecondImage;
        public bool HasSecondImage {
            get
            {
                if (CardType == Models.CardType.Quest)
                {
                    return true;
                }

                return hasSecondImage;
            }
            set { hasSecondImage = value; }
        }

        private string publicSlug;
        public string PublicSlug
        {
            get
            {
                if (!string.IsNullOrEmpty(publicSlug))
                    return publicSlug;

                return !string.IsNullOrEmpty(NormalizedTitle) ?
                    NormalizedTitle.ToUrlSafeString().Replace("'", string.Empty).ToLower()
                    : Title.ToUrlSafeString().Replace("'", string.Empty).ToLower();
            }
            private set { publicSlug = value; }
        }

        public bool UsePublicImageURL { get; set; }

        private string publicImageURL;
        public string PublicImageURL
        {
            get
            {
                /*
                if (!string.IsNullOrEmpty(publicImageURL))
                {
                    return publicImageURL;
                }

                return string.Format("http://www.cardgamedb.com/forums/uploads/lotr/{0}-{1}.jpg", PublicSlug, CardSet.PublicSlug);
                */

                return null;
            }
            set { publicImageURL = value; }
        }

        public string Slug
        {
            get
            {
                var title = !string.IsNullOrEmpty(NormalizedTitle) ?  NormalizedTitle.ToUrlSafeString() : Title.ToUrlSafeString();
                var subtitle = SlugIncludesOppositeTitle ? string.Format("{0}-", OppositeTitle.ToUrlSafeString()) : string.Empty;
                var type = SlugIncludesType ? string.Format("{0}-", CardType.ToString().ToUrlSafeString()) : string.Empty;
                var set = CardSet.Abbreviation.ToString().ToUrlSafeString();
                return string.Format("{0}-{1}{2}{3}", title, subtitle, type, set); 
            }
        }

        public string TraitList
        {
            get
            {
                if (Traits == null || Traits.Count == 0)
                    return string.Empty;

                return string.Join(" ", Traits);
            }
        }

        public bool HasKeyword(string keyword)
        {
            return Keywords.Any(x => x != null && string.Equals(x.Trim().Replace("~", string.Empty), keyword));
        }

        public bool HasTrait(string trait)
        {
            return Traits.Any(x => x != null && string.Equals(x.Trim(), trait))
                || NormalizedTraits.Any(x => x != null && string.Equals(x.Trim(), trait));
        }

        public bool HasFaction(Sphere sphere, string trait)
        {
            return Sphere == sphere && HasTrait(trait);
        }

        public Func<IEnumerable<ScenarioGroup>, bool> UpdateScenarioCards { get; set; }

        public bool HasErrata { get; set; }

        private string errataUrl;
        public string ErrataUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(errataUrl))
                {
                    return errataUrl;
                }
                else if (this.HasErrata)
                {
                    return "http://www.fantasyflightgames.com/ffg_content/lotr-lcg/support/LotR-FAQ.pdf";
                }

                return null;
            }
            set { errataUrl = value; } 
        }

        protected DeckType deckType = DeckType.None;
        public DeckType GetDeckType()
        {
            if (deckType != DeckType.None) {
                return deckType;
            }

            switch (CardType)
            {
                case Models.CardType.Hero:
                case Models.CardType.Ally:
                case Models.CardType.Attachment:
                case Models.CardType.Event:
                case Models.CardType.Treasure:
                    return DeckType.Player;
                case Models.CardType.Enemy:
                case Models.CardType.Location:
                case Models.CardType.Treachery:
                case Models.CardType.Objective:
                case Models.CardType.Objective_Ally:
                    return DeckType.Encounter;
                case Models.CardType.Quest:
                case Models.CardType.Campaign:
                case Models.CardType.GenCon_Setup:
                case Models.CardType.Nightmare_Setup:
                    return DeckType.Quest;
                default:
                    return DeckType.None;
            }
        }

        public bool BelongsToScenario(Scenario scenario)
        {
            if (scenario == null) {
                return false;
            }

            if (scenario.Title == ScenarioTitle) {
                return true;
            }

            if (!string.IsNullOrEmpty(EncounterSet)) {
                if (scenario.IncludesEncounterSet(EncounterSet))
                {
                    return true;
                }
            }

            return false;
        }

        public static Card Enemy(string title, bool isUnique, string id, string encounterSet, byte? engagementCost, byte? threat, byte? attack, byte? defense, byte? hitPoints)
        {
            var isVariableThreat = threat.HasValue && threat.Value == byte.MaxValue;
            var isVariableAttack = attack.HasValue && attack.Value == byte.MaxValue;
            var isVariableDefense = defense.HasValue && defense.Value == byte.MaxValue;
            var isVariableHitPoints = hitPoints.HasValue && hitPoints.Value == byte.MaxValue;

            return new Card()
            {
                CardType = Models.CardType.Enemy,
                IsUnique = isUnique,
                Title = title,
                Id = id,
                EngagementCost = engagementCost,
                Threat = threat,
                IsVariableThreat = isVariableThreat,
                Attack = attack,
                IsVariableAttack = isVariableAttack,
                Defense = defense,
                IsVariableDefense = isVariableDefense,
                HitPoints = hitPoints,
                IsVariableHitPoints = isVariableHitPoints,
                EncounterSet = encounterSet
            };
        }

        public static Card Location(string title, bool isUnique, string id, string encounterSet, byte? threat, byte questPoints)
        {
            return new Card()
            {
                CardType = Models.CardType.Location,
                IsUnique = isUnique,
                Title = title,
                Id = id,
                Threat = threat,
                QuestPoints = questPoints,
                EncounterSet = encounterSet
            };
        }

        public static Card Treachery(string title, string id, string encounterSet)
        {
            return new Card()
            {
                CardType = Models.CardType.Treachery,
                Title = title,
                Id = id,
                EncounterSet = encounterSet
            };
        }

        public Card WithTraits(params string[] traits)
        {
            foreach (var trait in traits)
                this.Traits.Add(trait);

            return this;
        }

        public Card WithVictoryPoints(byte victoryPoints)
        {
            this.VictoryPoints = victoryPoints;
            return this;
        }

        public Card WithNormalizedTitle(string normalizedTitle)
        {
            this.NormalizedTitle = normalizedTitle;
            return this;
        }

        public Card WithKeywords(params string[] keywords)
        {
            foreach (var keyword in keywords)
                this.Keywords.Add(keyword);

            return this;
        }

        public Card WithText(string text)
        {
            this.Text = text;
            return this;
        }

        public Card WithShadow(string shadow)
        {
            return this.WithEffect(CardEffectType.Shadow, shadow);
        }

        public Card WithEffect(CardEffectType type, string effect)
        {
            switch (type)
            {
                case CardEffectType.Shadow:
                    this.Shadow = effect;
                    break;
                case CardEffectType.Flavor_Text:
                    this.FlavorText = effect;
                    break;
                default:
                case CardEffectType.None:
                case CardEffectType.Passive:
                    {
                        if (string.IsNullOrEmpty(this.Text))
                        {
                            this.Text = string.Empty;
                        }
                        else
                        {
                            this.Text += "\r\n";
                        }

                        this.Text += effect;
                    }
                    break;
            }

            return this;
        }

        public Card WithInfo(byte number, byte quantity, Artist artist)
        {
            this.Number = number;
            this.Quantity = quantity;
            this.Artist = artist;

            return this;
        }
    }
}