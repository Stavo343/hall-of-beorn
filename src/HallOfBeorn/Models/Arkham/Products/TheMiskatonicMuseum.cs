﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HallOfBeorn.Models.Arkham.Products
{
    public class TheMiskatonicMuseum : ArkhamProduct
    {
        public TheMiskatonicMuseum()
            : base("The Miskatonic Museum", "TMT", "AHC02", 2, new DateTime(2016, 12, 31))
        {
        }

        protected override void init()
        {
            addCard(ArkhamCard.Investigator("Zoey Samaras", "The Chef", ClassSymbol.Guardian, 9, 6)
                .WithSkills(4, 2, 4, 2)
                .WithTraits("Believer.", "Hunter.")
                .WithFrontText("{Reaction} After you become engaged with an enemy: Gain 1 resource.\r\n{Elder Sign} effect: +1. If this skill test is successful during an attack, that attack deals +1 damage.")
                .WithFrontFlavor("\"God has spoken. I will do His work without hesitation.\"")
                .WithInfo(1, 1, Artist.Magali_Villeneuve));
        }
    }
}