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
        }

        private readonly List<ArkhamProduct> products = new List<ArkhamProduct>();

        public List<ArkhamProduct> CardSets()
        {
            return products;
        }
    }
}