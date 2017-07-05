﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HallOfBeorn.Models.LotR.Sets.TheLordOfTheRings
{
    public class TheMountainOfFire : CardSet
    {
        protected override void Initialize()
        {
            Name = "The Mountain of Fire";
            Abbreviation = "TMoF";
            Number = 1008;
            SetType = Models.SetType.Saga_Expansion;
            Cycle = "The Lord of the Rings";

            addCard(LotRCard.Hero("Frodo Baggins", string.Empty, Sphere.Fellowship, 0, 2, 1, 2, 2)
                .WithTraits("Hobbit.", "Ring-bearer.")
                .WithText("Planning Action: Exhaust The One Ring to add 1 resource to a hero's pool.")
                .WithFlavor("\"I must carry the burden to the end.\"\r\n-The Return of the King")
                .WithInfo(1, 1, Artist.Aleksander_Karcz));
            addCard(LotRCard.Hero("Aragorn", string.Empty, Sphere.Fellowship, 0, 2, 3, 2, 5)
                .WithTraits("Dúnedain.", "Gondor.", "Noble.", "Warrior.")
                .WithKeywords("Sentinel.")
                .WithText("The first player gains control of Aragorn.\r\nAction: Spend 1 resource from Aragorn's pool to ready him. (Limit once per phase.)\r\nIf Aragorn leaves play the players lose the game.")
                .WithFlavor("\"As I have begun, so I will go on.\"\r\n-The Return of the King")
                .WithInfo(2, 1, Artist.David_A_Nash));
            addCard(LotRCard.Ally("Elladan", Sphere.Lore, 3, 2, 1, 1, 3)
                .WithUnique()
                .WithTraits("Noldor.", "Ranger.")
                .WithText("While Elrohir is in play, Elladan gets +2 Attack.\r\nResponse: After you optionally engage an Orc enemy, ready Elladan.")
                .WithFlavor("...they rode often far afield with the Rangers of the North, forgetting never their mother's torment in the dens of the Orcs. -The Return of the King")
                .WithInfo(7, 3, Artist.Jason_Jenicke));
            addCard(LotRCard.Ally("Elrohir", Sphere.Spirit, 3, 2, 1, 1, 3)
                .WithUnique()
                .WithTraits("Noldor.", "Ranger.")
                .WithText("While Elladan is in play, Elrohir gets +2 Defense.\r\nResponse: After you optionally engage an Orc enemy, ready Elrohir.")
                .WithFlavor("\"From the North we came with this purpose, and from Elrond our father we brought this very counsel.\"\r\n-The Return of the King")
                .WithInfo(8, 3, Artist.Jason_Jenicke));
        }
    }
}