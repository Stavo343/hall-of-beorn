﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HallOfBeorn.Models.Arkham;
using HallOfBeorn.Models.Arkham.Products;

namespace HallOfBeorn.Services.Arkham
{
    public class ArkhamProductRepository
    {
        public ArkhamProductRepository()
        {
            products.Add(new CoreSet());
            products.Add(new TheDunwichLegacy());
        }

        private readonly List<ArkhamProduct> products = new List<ArkhamProduct>();

        public IEnumerable<ArkhamProduct> Products()
        {
            return products;
        }

        public IEnumerable<ArkhamCard> Cards()
        {
            foreach (var product in products)
                foreach (var card in product.Cards())
                    yield return card;
        }

        public IEnumerable<string> Traits()
        {
            foreach (var card in Cards())
                foreach (var trait in card.Traits())
                    yield return trait;
        }
        public IEnumerable<string> SkillValues(Skill skill)
        {
            foreach (var card in Cards())
            {
                Func<ArkhamCard, Skill, string> getSkill = (c, sk) =>
                    {
                        switch (sk)
                        {
                            case Skill.Willpower:
                                return c.Willpower.HasValue ? c.Willpower.ToString() : string.Empty;
                            case Skill.Intellect:
                                return c.Intellect.HasValue ? c.Intellect.ToString() : string.Empty;
                            case Skill.Combat:
                                return c.Combat.HasValue ? c.Combat.ToString() : string.Empty;
                            case Skill.Agility:
                                return c.Agility.HasValue ? c.Agility.ToString() : string.Empty;
                            default:
                                return string.Empty;;
                        }
                    };

                yield return getSkill(card, skill);
            }
        }
        public IEnumerable<string> EnemyStats(EnemyStatType type, string perInvestigatorSuffix)
        {
            foreach (var card in Cards().Where(x => x.CardType == ArkhamCardType.Enemy))
            {
                Func<ArkhamCard, EnemyStatType, string> getStat = (c, t) =>
                {
                    switch (t)
                    {
                        case EnemyStatType.FightValue:
                            return c.FightValue.HasValue ? c.FightValue.Value.ToString(perInvestigatorSuffix) : string.Empty;
                        case EnemyStatType.HealthValue:
                            return c.HealthValue.HasValue ? c.HealthValue.Value.ToString(perInvestigatorSuffix) : string.Empty;
                        case EnemyStatType.EvadeValue:
                            return c.EvadeValue.HasValue ? c.EvadeValue.Value.ToString(perInvestigatorSuffix) : string.Empty;
                        case EnemyStatType.Damage:
                            return c.Damage.HasValue ? c.Damage.Value.ToString() : string.Empty;
                        case EnemyStatType.Horror:
                            return c.Horror.HasValue ? c.Horror.Value.ToString() : string.Empty;
                        default:
                            return string.Empty; ;
                    }
                };

                yield return getStat(card, type);
            }
        }
    }
}