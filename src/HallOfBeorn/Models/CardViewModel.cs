﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HallOfBeorn.Models
{
    public class CardViewModel
    {
        public CardViewModel(Card card)
            : this(card, 0f, string.Empty)
        {
        }

        public CardViewModel(CardScore score)
            : this(score.Card, score.Score(), score.Description)
        {
        }

        public CardViewModel(Card card, float score, string searchDescription)
        {
            _card = card;
            _score = score;
            _searchDescription = searchDescription;

            foreach (var encounterSet in _card.IncludedEncounterSets)
            {
                _includedEncounterSets.Add(new EncounterSetViewModel(encounterSet));
            }
        }

        private Card _card;
        private float _score;
        private string _searchDescription;

        private readonly List<CardEffect> _keywordEffects = new List<CardEffect>();
        private readonly List<CardEffect> _textEffects = new List<CardEffect>();
        private readonly List<CardEffect> _oppositeTextEffects = new List<CardEffect>();
        private readonly List<CardEffect> _shadowEffects = new List<CardEffect>();
        private readonly List<EncounterSetViewModel> _includedEncounterSets = new List<EncounterSetViewModel>();

        public List<CardEffect> KeywordEffects { get { return _keywordEffects; } }
        public List<CardEffect> TextEffects { get { return _textEffects; } }
        public List<CardEffect> OppositeTextEffects { get { return _oppositeTextEffects; } }
        public List<CardEffect> ShadowEffects { get { return _shadowEffects; } }

        public bool HasIncludedEncounterSets { get { return _includedEncounterSets.Count > 0; } }
        public List<EncounterSetViewModel> IncludedEncounterSets { get { return _includedEncounterSets; } }

        public Card Card
        {
            get { return _card; }
        }

        public string SearchDescription
        {
            get { return _searchDescription; }
        }

        public float Score
        {
            get { return _score; }
        }

        public string Id
        {
            get { return _card.Id; }
        }

        public string Slug
        {
            get { return _card.Slug; }
        }

        public string Title
        {
            get { return _card.Title; }
        }

        public string Description
        {
            get { return string.Format("{0} ({1})", _card.Title, _card.CardSet.Abbreviation); }
        }

        public string Url
        {
            get { return string.Format("/Cards/Details/{0}", Slug); }
        }

        public string SetSearchUrl
        {
            get
            {
                return string.Format("/Cards/Search?CardSet={0}", _card.CardSet.Name.Replace(" ", "+"));
            }
        }

        /*
        public string HallOfBeornBlogSearchUrl
        {
            get
            {
                var search = !string.IsNullOrEmpty(_card.NormalizedTitle) ? _card.NormalizedTitle.ToSearchString() : _card.Title.ToSearchString();
                return string.Format("http://hallofbeorn.wordpress.com/?s={0}", search);
            }
        }

        public string TalesFromTheCardsBlogSearchUrl
        {
            get
            {
                var search = !string.IsNullOrEmpty(_card.NormalizedTitle) ? _card.NormalizedTitle.ToSearchString() : _card.Title.ToSearchString();
                return string.Format("http://talesfromthecards.wordpress.com/?s={0}", search);
            }
        }

        public string MasterOfLoreBlogSearchUrl
        {
            get
            {
                var search = !string.IsNullOrEmpty(_card.NormalizedTitle) ? _card.NormalizedTitle.ToSearchString() : _card.Title.ToSearchString();
                return string.Format("http://masteroflore.wordpress.com/?s={0}", search);
            }
        }
        */

        public bool HasBlogs { get { return _card.HasBlogs; } }

        public List<Link> Blogs()
        {
            return _card.Blogs();
        }

        public bool HasReferences { get { return _card.HasReferences; } }

        public List<Link> References()
        {
            return _card.References();
        }

        public string BlogTagUrl
        {
            get
            {
                var search = _card.Title.Replace(' ', '-').Replace("!", string.Empty).Replace("?", string.Empty);
                return string.Format("http://hallofbeorn.wordpress.com/tag/{0}", search);
            }
        }

        public bool HasErrata
        {
            get { return !string.IsNullOrEmpty(_card.ErrataUrl); }
        }

        public string ErrataUrl
        {
            get { return _card.ErrataUrl; }
        }

        public string FullTitle
        {
            get
            {
                return !string.IsNullOrEmpty(OppositeTitle) ?
                    string.Format("{0} ({1})", Title, OppositeTitle)
                    : Title;
            }
        }

        public string SetName
        {
            get { return _card.CardSet.Name; }
        }

        public string Number
        {
            get { return _card.Number.ToString(); }
        }

        public string Quantity
        {
            get { return _card.Quantity.ToString(); }
        }

        public string EasyModeQuantity
        {
            get { return _card.EasyModeQuantity.HasValue ? _card.EasyModeQuantity.Value.ToString() : string.Empty; }
        }

        public IEnumerable<string> Keywords
        {
            get
            {
                foreach (var keyword in _card.Keywords)
                {
                    yield return keyword.ToDisplayString(_card.Title);
                }
            }
        }

        public IEnumerable<string> Traits
        {
            get { return _card.Traits; }
        }

        public CardType CardType
        {
            get { return _card.CardType; }
        }

        public CardSubtype CardSubtype
        {
            get { return _card.CardSubtype; }
        }

        public string CardTypeName
        {
            get { return _card.CardType.ToString().Replace('_', '-'); }
        }

        public string CampaignCardType
        {
            get
            {
                return (_card.CardSubtype == Models.CardSubtype.Boon || _card.CardSubtype == Models.CardSubtype.Burden) ?
                    _card.CardSubtype.ToString()
                    : (string)null;

            }
        }

        public string Sphere
        {
            get { return _card.Sphere.ToString(); }
        }

        public string ThreatCost
        {
            get { return _card.ThreatCost.ToString(); }
        }

        public string ResourceCost
        {
            get { return _card.ResourceCost.Description(_card.IsVariableCost); }
        }

        public string Willpower
        {
            get { return _card.Willpower.Description(_card.IsVariableWillpower); }
        }

        public string Attack
        {
            get {return _card.Attack.Description(_card.IsVariableAttack); }
        }

        public string Defense
        {
            get { return _card.Defense.Description(_card.IsVariableDefense);  }
        }

        public string HitPoints
        {
            get { return _card.HitPoints.Description(_card.IsVariableHitPoints); }
        }

        public string EncounterSet
        {
            get
            {
                return _card.CardType != Models.CardType.Hero && _card.CardType != Models.CardType.Ally && _card.CardType != Models.CardType.Attachment && _card.CardType != Models.CardType.Event ?
                    _card.EncounterSet
                    : string.Empty;
            }
        }

        public string EncounterSetLink
        {
            get
            {
                return !string.IsNullOrEmpty(EncounterSet) ?
                    string.Format("/Cards/Search?EncounterSet={0}", _card.EncounterSet.ToSearchString())
                    : string.Empty;
            }
        }

        public string StageNumber
        {
            get { return _card.StageNumber > 0 ? _card.StageNumber.ToString() : string.Empty; }
        }

        public string StageLetters
        {
            get
            {
                char from = _card.StageLetter;
                char to = (Char)(Convert.ToUInt16(_card.StageLetter) + 1);

                return string.Format("{0}-{1}", from, to);
            }
        }

        public char GetSecondStageLetter()
        {
            var second = (Char)(Convert.ToUInt16(_card.StageLetter) + 1);
            return second;
        }

        public string QuestPoints
        {
            get { return _card.QuestPoints.Description(_card.IsVariableQuestPoints); }
        }

        public string Threat
        {
            get { return _card.Threat.Description(_card.IsVariableThreat); }
        }

        public string VictoryPoints
        {
            get
            {
                if (_card.IsVariableVictoryPoints)
                    return "Victory X.";

                return _card.VictoryPoints > 0 ?
                    string.Format("Victory {0}.", _card.VictoryPoints)
                    : (string)null;
            }
        }

        public string BackgroundImage()
        {
            switch (_card.Sphere) 
            {
                case Models.Sphere.Leadership:
                case Models.Sphere.Tactics:
                case Models.Sphere.Spirit:
                case Models.Sphere.Lore:
                    return string.Format("/Images/{0}.png", _card.Sphere.ToString());
                default:
                    if (_card.CardType == Models.CardType.Enemy || _card.CardType == Models.CardType.Location || _card.CardType == Models.CardType.Treachery || _card.CardType == Models.CardType.Objective || _card.CardType == Models.CardType.Objective_Ally || _card.CardType == Models.CardType.Objective_Location || _card.CardType == Models.CardType.Encounter_Side_Quest)
                    {
                        return "/Images/encounter-card-back.jpg";
                    }
                    return null;
            }
        }

        public string BackgroundImageTop()
        {
            switch (_card.Sphere)
            {
                case Models.Sphere.Leadership:
                case Models.Sphere.Tactics:
                case Models.Sphere.Spirit:
                case Models.Sphere.Lore:
                    return "-5px";
                default:
                    if (_card.CardType == Models.CardType.Enemy || _card.CardType == Models.CardType.Location || _card.CardType == Models.CardType.Treachery || _card.CardType == Models.CardType.Objective || _card.CardType == Models.CardType.Objective_Ally || _card.CardType == Models.CardType.Objective_Location || _card.CardType == Models.CardType.Encounter_Side_Quest)
                    {
                        return "0px";
                    }
                    return "-5px";
            }
        }

        public string BackgroundImageLeft()
        {
            //48px
            switch (_card.Sphere)
            {
                case Models.Sphere.Leadership:
                case Models.Sphere.Tactics:
                case Models.Sphere.Spirit:
                case Models.Sphere.Lore:
                    return "48px";
                default:
                    if (_card.CardType == Models.CardType.Enemy || _card.CardType == Models.CardType.Location || _card.CardType == Models.CardType.Treachery || _card.CardType == Models.CardType.Objective || _card.CardType == Models.CardType.Objective_Ally || _card.CardType == Models.CardType.Objective_Location || _card.CardType == Models.CardType.Encounter_Side_Quest)
                    {
                        return "0px";
                    }
                    return "48px;";
            }
        }

        public string BackgroundImageHeight()
        {
            switch (_card.Sphere)
            {
                case Models.Sphere.Leadership:
                case Models.Sphere.Tactics:
                case Models.Sphere.Spirit:
                case Models.Sphere.Lore:
                    return "200px";
                default:
                    if (_card.CardType == Models.CardType.Enemy || _card.CardType == Models.CardType.Location || _card.CardType == Models.CardType.Treachery || _card.CardType == Models.CardType.Objective || _card.CardType == Models.CardType.Objective_Ally || _card.CardType == Models.CardType.Objective_Location || _card.CardType == Models.CardType.Encounter_Side_Quest)
                    {
                        return "100%";
                    }
                    return "200px";
            }
        }

        public string BackgroundImageWidth()
        {
            switch (_card.Sphere)
            {
                case Models.Sphere.Leadership:
                case Models.Sphere.Tactics:
                case Models.Sphere.Spirit:
                case Models.Sphere.Lore:
                    return "200";
                default:
                    if (_card.CardType == Models.CardType.Enemy || _card.CardType == Models.CardType.Location || _card.CardType == Models.CardType.Treachery || _card.CardType == Models.CardType.Objective || _card.CardType == Models.CardType.Objective_Ally || _card.CardType == Models.CardType.Objective_Location || _card.CardType == Models.CardType.Encounter_Side_Quest)
                    {
                        return "100%";
                    }
                    return "200";
            }
        }

        public string BackgroundColor()
        {
            switch (_card.Sphere)
            {
                case Models.Sphere.Leadership:
                    return "rgba(128, 0, 128, .1)";
                case Models.Sphere.Tactics:
                    return "rgba(255, 0, 0, .1)";
                case Models.Sphere.Spirit:
                    return "rgba(0, 0, 255, .05)";
                case Models.Sphere.Lore:
                    return "rgba(0, 128, 0, .1)";
                case Models.Sphere.Neutral:
                    return "#e4e4e4";
                default:
                    if (_card.CardType == Models.CardType.Enemy || _card.CardType == Models.CardType.Location || _card.CardType == Models.CardType.Treachery || _card.CardType == Models.CardType.Objective || _card.CardType == Models.CardType.Objective_Ally || _card.CardType == Models.CardType.Objective_Location || _card.CardType == Models.CardType.Encounter_Side_Quest)
                    {
                        return "rgba(0, 0, 0, .1)";
                    }
                    else if (_card.CardType == Models.CardType.Quest)
                    {
                        return "#d3d3d3";
                    }
                    return "White";
            }
        }

        public string PassValue
        {
            get
            {
                return (_card.PassValue.HasValue && _card.PassValue.Value) ?
                    "PASS"
                    : string.Empty;
            }
        }

        public string EngagementCost
        {
            get { return _card.EngagementCost.HasValue ? _card.EngagementCost.ToString() : string.Empty; }
        }

        public string Text
        {
            get {
                return !string.IsNullOrEmpty(_card.Text) ?
                    _card.Text.ToDisplayString(_card.Title)
                    : string.Empty;
            }
        }

        public string Shadow
        {
            get {
                return !string.IsNullOrEmpty(_card.Shadow) ?
                    _card.Shadow.ToDisplayString(_card.Title)
                    : string.Empty;
            }
        }

        public IEnumerable<string> FlavorText
        {
            get
            {
                return
                    !string.IsNullOrEmpty(_card.FlavorText) ?
                    _card.FlavorText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList()
                    : Enumerable.Empty<string>();
            }
        }

        public bool HasFlavorText
        {
            get { return FlavorText.Count() > 0; }
        }

        public IEnumerable<string> OppositeFlavorText
        {
            get
            {
                return
                    !string.IsNullOrEmpty(_card.OppositeFlavorText) ?
                    _card.OppositeFlavorText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList()
                    : Enumerable.Empty<string>();
            }
        }

        public bool HasOppositeFlavorText
        {
            get { return OppositeFlavorText.Count() > 0; }
        }


        public string OppositeTitle
        {
            get { return _card.OppositeTitle; }
        }

        public string OppositeText
        {
            get {
                return !string.IsNullOrEmpty(_card.OppositeText) ?
                    _card.OppositeText.ToDisplayString(_card.Title)
                    : string.Empty;
            }
        }

        public string ImagePath
        {
            get
            {
                var format = ImageType.Jpg;
                if (_card.ImageType != ImageType.None)
                    format = _card.ImageType;
                else if (!string.IsNullOrEmpty(_card.ImageName)) {
                    format = ImageType.Png;
                }

                var ext = string.Format(".{0}", format.ToString().ToLower());
                var set = !string.IsNullOrEmpty(_card.CardSet.NormalizedName) ? _card.CardSet.NormalizedName.ToUrlSafeString() : _card.CardSet.Name.ToUrlSafeString();
                var title = _card.SlugIncludesOppositeTitle ? string.Format("{0}-{1}", Title.ToUrlSafeString(), OppositeTitle.ToUrlSafeString()) : Title.ToUrlSafeString();
                var type = _card.SlugIncludesType ? string.Format("-{0}", _card.CardType.ToString().ToUrlSafeString()) : string.Empty;
                var image = _card.ImageName.ToUrlSafeString();

                return string.IsNullOrEmpty(_card.ImageName) ?
                    string.Format("https://s3.amazonaws.com/hallofbeorn-resources/Images/Cards/{0}/{1}{2}{3}", set, title, type, ext)
                    : string.Format("https://s3.amazonaws.com/hallofbeorn-resources/Images/Cards/{0}{1}", image, ext);
            }
        }

        string getQuestCardImagePath(bool isFirst)
        {
            var format = ImageType.Jpg;
            if (_card.ImageType != ImageType.None)
                format = _card.ImageType;
            else if (!string.IsNullOrEmpty(_card.ImageName))
                format = ImageType.Png;

            var ext = string.Format(".{0}", format.ToString().ToLower());
            var set = !string.IsNullOrEmpty(_card.CardSet.NormalizedName) ? _card.CardSet.NormalizedName.ToUrlSafeString() : _card.CardSet.Name.ToUrlSafeString();
            var title = Title.ToUrlSafeString();
            var subtitle = _card.SlugIncludesOppositeTitle ? "-" + _card.OppositeTitle.ToUrlSafeString() : string.Empty;
            var number = _card.StageNumber.ToString();
            var image = _card.ImageName.ToUrlSafeString();

            var suffix = isFirst ? "A" : "B";
            if (_card.StageLetter != 'A')
            {
                suffix = isFirst ? _card.StageLetter.ToString() : GetSecondStageLetter().ToString();
            }

            return string.Format("https://s3.amazonaws.com/hallofbeorn-resources/Images/Cards/{0}/{1}{2}-{3}{4}{5}", set, title, subtitle, number, suffix, ext);
        }

        string getSetupCardImagePath(bool isFirst)
        {
            var format = ImageType.Jpg;
            if (_card.ImageType != ImageType.None)
                format = _card.ImageType;
            else if (!string.IsNullOrEmpty(_card.ImageName))
                format = ImageType.Png;

            var ext = string.Format(".{0}", format.ToString().ToLower());
            var set = !string.IsNullOrEmpty(_card.CardSet.NormalizedName) ? _card.CardSet.NormalizedName.ToUrlSafeString() : _card.CardSet.Name.ToUrlSafeString();
            var title = _card.Title.ToUrlSafeString();
            var suffix = isFirst ? "A" : "B";

            return string.Format("https://s3.amazonaws.com/hallofbeorn-resources/Images/Cards/{0}/{1}-Setup{2}{3}", set, title, suffix, ext);
        }

        public string ImagePath1
        {
            get {
                switch (_card.CardType)
                {
                    case Models.CardType.Quest:
                        return getQuestCardImagePath(true); 
                    case Models.CardType.Campaign:
                    case Models.CardType.Nightmare_Setup:
                    case Models.CardType.GenCon_Setup:
                        return getSetupCardImagePath(true);
                    default:
                        return null;
                }
            }
        }

        public string ImagePath2
        {
            get
            {
                switch (_card.CardType)
                {
                    case Models.CardType.Quest:
                        return getQuestCardImagePath(false);
                    case Models.CardType.Campaign:
                    case Models.CardType.Nightmare_Setup:
                    case Models.CardType.GenCon_Setup:
                        return getSetupCardImagePath(false);
                    default:
                        return null;
                }
            }
        }

        public bool HasSecondImage
        {
            get { return _card.HasSecondImage; }
        }

        public bool HasCategories
        {
            get { return _card.Categories.Count > 0; }
        }

        public bool HasEncounterCategories
        {
            get { return _card.EncounterCategories.Count > 0; }
        }

        public bool HasQuestCategories
        {
            get { return _card.QuestCategories.Count > 0; }
        }

        public Dictionary<string, string> Categories()
        {
            var categoryMap = new Dictionary<string, string>();

            foreach (var category in _card.Categories)
            {
                var key = category.ToString().Replace('_', ' ');
                var value = string.Format("/Cards/Search?Category={0}", category.ToString().Replace('_', '+'));
                if (!categoryMap.ContainsKey(key))
                {
                    categoryMap.Add(key, value);
                }
            }

            return categoryMap;
        }

        public Dictionary<string, string> EncounterCategories()
        {
            var categoryMap = new Dictionary<string, string>();

            foreach (var category in _card.EncounterCategories)
            {
                var key = category.ToString().Replace('_', ' ');
                var value = string.Format("/Cards/Search?EncounterCategory={0}", category.ToString().Replace('_', '+'));
                if (!categoryMap.ContainsKey(key))
                {
                    categoryMap.Add(key, value);
                }
            }

            return categoryMap;
        }

        public Dictionary<string, string> QuestCategories()
        {
            var categoryMap = new Dictionary<string, string>();

            foreach (var category in _card.QuestCategories)
            {
                var key = category.ToString().Replace('_', ' ');
                var value = string.Format("/Cards/Search?QuestCategory={0}", category.ToString().Replace('_', '+'));
                if (!categoryMap.ContainsKey(key))
                {
                    categoryMap.Add(key, value);
                }
            }

            return categoryMap;
        }

        public string DetailPath
        {
            get { return string.Format("/Cards/Details/{0}", Id); }
        }

        public bool HasCharacterStats
        {
            get
            {
                return _card.Willpower > 0 || _card.Attack > 0 || _card.Defense > 0 || _card.HitPoints > 0;
            }
        }

        public bool IsUnique
        {
            get { return _card.IsUnique; }
        }

        public string Artist
        {
            get { return _card.Artist != null ? _card.Artist.Name : string.Empty; }
        }

        public string ArtistURL
        {
            get { return _card.Artist != null ? _card.Artist.URL : string.Empty; }
        }

        public string SecondArtist
        {
            get { return _card.SecondArtist != null ? _card.SecondArtist.Name : string.Empty; }
        }

        public string SecondArtistURL
        {
            get { return _card.SecondArtist != null ? _card.SecondArtist.URL : string.Empty; }
        }

        public string OppositeArtist
        {
            get { return _card.OppositeArtist != null ? _card.OppositeArtist.Name : string.Empty; }
        }

        public string OppositeArtistURL
        {
            get { return _card.OppositeArtist != null ? _card.OppositeArtist.URL : string.Empty; }
        }

        public string Year
        {
            get { return _card.Year > 0 ? _card.Year.ToString() : string.Empty; }
        }

        public bool HasSphere
        {
            get { return _card.Sphere == Models.Sphere.Leadership || _card.Sphere == Models.Sphere.Tactics || _card.Sphere == Models.Sphere.Spirit || _card.Sphere == Models.Sphere.Lore || _card.Sphere == Models.Sphere.Mastery; }
        }

        public bool HasEncounterSet
        {
            get { return !string.IsNullOrEmpty(EncounterSet); }
        }

        public bool HasCardSubtype
        {
            get { return _card.CardSubtype != Models.CardSubtype.None; }
        }

        public string EncounterSetImagePath
        {
            get
            {
                return HasEncounterSet ?
                    string.Format("https://s3.amazonaws.com/hallofbeorn-resources/Images/Cards/{0}/{1}.png", _card.CardSet.NormalizedName.ToUrlSafeString(), _card.EncounterSet.ToUrlSafeString())
                    : string.Empty;
            }
        }

        public bool IsNightmare
        {
            get { return _card.CardSet.Cycle == "NIGHTMARE"; }
        }

        public IEnumerable<Deck> Decks
        {
            get { return _card.Decks.Values; }
        }

        public List<CardViewModel> RelatedCards
        {
            get {
                return _card.RelatedCards.Select(x => new CardViewModel(x)).ToList();
            }
        }

        public bool HasHtml
        {
            get { return !string.IsNullOrEmpty(_card.Html); }
        }

        public string Html
        {
            get { return _card.Html; }
        }
    }
}