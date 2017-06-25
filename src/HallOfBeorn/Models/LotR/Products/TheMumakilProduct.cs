﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HallOfBeorn.Models.LotR.Products
{
    public class TheMumakilProduct : Product
    {
        public TheMumakilProduct()
            : base("The Mûmakil", "MEC56", ImageType.Jpg)
        {
            AddCardSet(CardSet.TheMumakil);

            AddScenario(new HallOfBeorn.Models.LotR.Scenarios.Haradrim.TheMumakil());

            RulesUrl = "https://images-cdn.fantasyflightgames.com/filer_public/03/0a/030a4e90-544d-4d24-a160-c5e05f34c778/mec56_rule_set.pdf";
        }
    }
}