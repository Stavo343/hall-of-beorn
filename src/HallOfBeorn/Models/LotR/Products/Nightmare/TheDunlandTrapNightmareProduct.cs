﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HallOfBeorn.Models.LotR.Products.Nightmare
{
    public class TheDunlandTrapNightmareProduct : Product
    {
        public TheDunlandTrapNightmareProduct()
            : base("The Dunland Trap Nightmare Deck", "MEN29", ImageType.Jpg, new DateTime(2015, 10, 29))
        {
            AddCardSet(CardSet.TheDunlandTrapNightmare);
        }
    }
}