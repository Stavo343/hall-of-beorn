using System;
using System.Collections.Generic;
using HallOfBeorn;
using HallOfBeorn.Models;

namespace HallOfBeorn.Models.LotR.Sets.ShadowsOfMirkwood
{
    public class ReturntoMirkwood : CardSet
    {
        protected override void Initialize()
        {
            Name = "Return to Mirkwood";
            Abbreviation = "RtM";
            Number = 7;
            SetType = Models.SetType.Adventure_Pack;
            Cycle = "Shadows of Mirkwood";

            Cards.Add(new LotRCard() {
                
                Title = "Ambush",
                StageNumber = 4,
                Id = "51223bd0-ffd1-11df-a976-0801206c9001",
                CardType = CardType.Quest,
                QuestPoints = 2,
                FlavorText = "As you make the final push to Thranduil's Palace, your enemies make a desperate attempt to ambush your party, and seize Gollum for themselves.",
                OppositeText = "Forced: At the beginning of the combat phase, all enemies in play enage the player guarding ~Gollum.\r\nPlayer cannot defeat this stage if there are any enemies in play. If players defeat this stage, they have won the game.",
                HtmlTemplate2 = "<p><b>Forced:</b> At the beginning of the combat phase, all enemies in play engage the player guarding <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a>.<p><p><b>Players cannot defeat this stage if there are any enemies in play. If players defeat this stage, they have won the game.</b></p>",
                Quantity = 1,
                EncounterSet = "Return to Mirkwood",
                CardNumber = 129,
                Artist = Artist.John_Gravato,
                SecondArtist = Artist.Dimitri_Bielak,
                IncludedEncounterSets = new List<EncounterSet> { EncounterSet.SpidersOfMirkwood, EncounterSet.Wilderlands }
            });
            Cards.Add(new LotRCard() {
                
                Title = "Astonishing Speed",
                Id = "51223bd0-ffd1-11df-a976-0801206c9003",
                CardType = CardType.Event,
                Sphere = Sphere.Spirit,
                Quantity = 3,
                ResourceCost = 3,
                Text = "Action: Until the end of the phase, all Rohan characters get +2 Willpower.",
                FlavorText = "With astonishing speed and skill they checked their steeds, wheeled, and came charging round. -The Two Towers",
                CardNumber = 122,
                Artist = Artist.Anna_Christenson
            });
            Cards.Add(new LotRCard() {
                
                Title = "Attercop, Attercop",
                Id = "51223bd0-ffd1-11df-a976-0801206c9004",
                CardType = CardType.Enemy,
                Traits = new List<string>() { "Creature.", " Spider." },
                Quantity = 3,
                EasyModeQuantity = 0,
                EngagementCost = 44,
                Attack = 8,
                Defense = 4,
                HitPoints = 6,
                Text = "Forced: At the beginning of the encounter phase, Attercop, Attercop automatically engages the player guarding ~Gollum, regardless of his threat.",
                FlavorText = "\"Attercop! Attercop! Won't you stop...\" -Bilbo Baggins, The Hobbit",
                HtmlTemplate = "<p><b>Forced:</b> At the beginning of the encounter phase, {self} automatically engages the player guarding <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a>, regardless of his threat.</p><p class='flavor-text'>&quot;Attercop! Attercop! Won't you stop...&quot;<br>&ndash;Bilbo Baggins, The Hobbit</p>",
                Threat = 2,
                EncounterSet = "Return to Mirkwood",
                CardNumber = 139,
                Artist = Artist.Aaron_B_Miller
            });
            Cards.Add(new LotRCard() {
                
                Title = "Dain Ironfoot",
                Id = "51223bd0-ffd1-11df-a976-0801206c9005",
                CardType = CardType.Hero,
                Sphere = Sphere.Leadership,
                Traits = new List<string>() { "Dwarf." },
                Quantity = 1,
                ThreatCost = 11,
                IsUnique = true,
                Attack = 2,
                Defense = 3,
                Willpower = 1,
                HitPoints = 5,
                Text = "While Dain Ironfoot is ready, Dwarf characters get +1 Attack and +1 Willpower.",
                FlavorText = "\"You have not heard of Dain and the dwarves of the Iron Hills?\" -Bilbo Baggins, The Hobbit",
                CardNumber = 116,
                Artist = Artist.Tiziano_Baracchi
            });
            Cards.Add(new LotRCard() {
                
                Title = "Dawn Take You All",
                Id = "51223bd0-ffd1-11df-a976-0801206c9006",
                CardType = CardType.Event,
                Sphere = Sphere.Leadership,
                Quantity = 3,
                ResourceCost = 2,
                Text = "Play after shadow cards have been dealt, before any attacks have resolved.\r\nCombat Action: Each player may choose and discard 1 facedown shadow card from an enemy with which he is engaged.",
                FlavorText = "\"Dawn take you all, and be stone to you!\" -Gandalf, The Hobbit",
                CardNumber = 118,
                Artist = Artist.Ben_Zweifel
            });
            Cards.Add(new LotRCard() {
                
                Title = "Dry Watercourse",
                Id = "51223bd0-ffd1-11df-a976-0801206c9007",
                CardType = CardType.Location,
                Traits = new List<string>() { "Forest." },
                Quantity = 3,
                Text = "While Dry Watercourse is the active location, all treachery card effects that target the player guarding ~Gollum also target each other player.",
                HtmlTemplate = "<p>While {self} is the active location, all treachery card effects that target the player guarding <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a> also target each other player.</p>",
                Threat = 2,
                QuestPoints = 2,
                EncounterSet = "Return to Mirkwood",
                CardNumber = 132,
                Artist = Artist.Bill_Corbett
            });
            Cards.Add(new LotRCard() {
                Title = "Dúnedain Signal",
                Id = "51223bd0-ffd1-11df-a976-0801206c9008",
                CardType = CardType.Attachment,
                Sphere = Sphere.Leadership,
                Traits = new List<string>() { "Signal." },
                Quantity = 3,
                ResourceCost = 1,
                Text = "Attach to a hero. Attached hero gains sentinel.\r\nAction: Pay 1 resource from attached hero's pool to attach Dunedain Signal to another hero.",
                HtmlTemplate = "<p>Attach to a hero.</p><p>Attached hero gains {keyword:Sentinel.@sentinel}.<p><b>Action:</b> Pay 1 resource from attached hero's pool to attach {self} to another hero.</p>",
                CardNumber = 117,
                Artist = Artist.Ijur
            });
            Cards.Add(new LotRCard() {
                
                Title = "Eagles of the Misty Mountains",
                Id = "51223bd0-ffd1-11df-a976-0801206c9009",
                CardType = CardType.Ally,
                Sphere = Sphere.Tactics,
                Traits = new List<string>() { "Creature.", " Eagle." },
                Quantity = 3,
                ResourceCost = 4,
                Attack = 2,
                Defense = 2,
                Willpower = 2,
                HitPoints = 4,
                Text = "Eagles of the Misty Mountains cannot have restricted attachments. Eagles of the Misty Mountains gets +1 Attack and +1 Defense for each facedown attachment it has.\r\nResponse: After another Eagle character leaves play, you may attach that card facedown to Eagles of the Misty Mountains.",
                CardNumber = 119,
                Artist = Artist.Sandara_Tang
            });
            Cards.Add(new LotRCard() {
                
                Title = "Escape Attempt",
                StageNumber = 2,
                Id = "51223bd0-ffd1-11df-a976-0801206c9010",
                CardType = CardType.Quest,
                QuestPoints = 3,
                Quantity = 1,
                FlavorText = "As soon as he thinks that no one is watching, Gollum attempts to slip his bonds and escape.",
                OppositeText = "The player guarding ~Gollum cannot commit characters to this quest (unless he is the only player in the game).\r\nIf the players quest unsuccessfully, Gollum escapes and the players have lost the game.",
                HtmlTemplate2 = "<p>The player guarding <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a> cannot commit characters to this quest (unless he is the only player remaining in the game).</p><p><b>If the player quest unsuccessfully, <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a> escapes and the player have lost the game.</b></p>",
                EncounterSet = "Return to Mirkwood",
                CardNumber = 127,
                Artist = Artist.Tom_Garden,
                IncludedEncounterSets = new List<EncounterSet> { EncounterSet.SpidersOfMirkwood, EncounterSet.Wilderlands }
            });
            Cards.Add(new LotRCard() {
                
                Title = "Gollum",
                Id = "51223bd0-ffd1-11df-a976-0801206c9012",
                CardType = CardType.Objective_Ally,
                Traits = new List<string>() { "Creature." },
                Quantity = 1,
                IsUnique = true,
                Attack = byte.MaxValue,
                Defense = byte.MaxValue,
                Willpower = byte.MaxValue,
                HitPoints = 5,
                Text = 
@"Damage from undefended attacks against you must be dealt to Gollum. If Gollum is destroyed, or if the player guarding ~Gollum is eliminated, the players have lost the game.
                
Forced: At the end of each round, raise the threat of the player guarding ~Gollum by 3. Then, that player may choose a new player to guard ~Gollum.",
                EncounterSet = "Return to Mirkwood",
                CardNumber = 130,
                Artist = Artist.Tiziano_Baracchi
            });
            Cards.Add(new LotRCard() {
                
                Title = "Gollum's Anguish",
                Id = "51223bd0-ffd1-11df-a976-0801206c9013",
                CardType = CardType.Treachery,
                Traits = new List<string>() { "Tantrum." },
                Quantity = 2,
                EasyModeQuantity = 1,
                Text = "When Revealed: Raise the threat of the player guarding ~Gollum by 8. That player must choose a new player to guard Gollum, if able.",
                HtmlTemplate = "<p><b>When Revealed:</b> Raise the threat of the player guarding <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a> by 8. That player must choose a new player to guard <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a>, if able.</p>{shadow}<p class='shadow-text'><b>Shadow:</b> Raise the threat of the player guarding <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a> by 4.</p>",
                Shadow = "Shadow: Raise the threat of the player guarding ~Gollum by 4.",
                EncounterSet = "Return to Mirkwood",
                CardNumber = 135,
                Artist = Artist.Tom_Garden
            });
            Cards.Add(new LotRCard() {
                
                Title = "Gollum's Bite",
                Id = "51223bd0-ffd1-11df-a976-0801206c9014",
                CardType = CardType.Treachery,
                Traits = new List<string>() { "Tantrum." },
                Quantity = 2,
                EasyModeQuantity = 1,
                Text = "When Revealed: Deal 4 damage to a hero controlled by the player guarding ~Gollum. That player must choose a new player to guard Gollum, if able.",
                Shadow = "Shadow: Deal 2 damage to a hero controlled by the player guarding ~Gollum.",
                HtmlTemplate = "<p><b>When Revealed:</b> Deal 4 damage to a hero controlled by the player guarding <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a>. That player must choose a new player to guard <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a>, if able.</p>{shadow}<p class='shadow-text'><b>Shadow:</b> Deal 2 damage to a hero controlled by the player guarding <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a>.</p>",
                EncounterSet = "Return to Mirkwood",
                CardNumber = 136,
                Artist = Artist.Tom_Garden
            });
            Cards.Add(new LotRCard() {
                
                Title = "Mirkwood Bats",
                Id = "51223bd0-ffd1-11df-a976-0801206c9015",
                CardType = CardType.Enemy,
                Traits = new List<string>() { "Creature." },
                Quantity = 4,
                EasyModeQuantity = 2,
                EngagementCost = 22,
                Attack = 1,
                Defense = 1,
                HitPoints = 1,
                Text = "Forced: After Mirkwood Bats engages a player, deal 1 damage to each character controlled by the player guarding ~Gollum.",
                Keywords = new List<string>() { "Surge." },
                HtmlTemplate = "<p>{keyword:Surge.}</p><p><b>Forced:</b> After {self} engages a player, deal 1 damage to each character controlled by the player guarding <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a>.</p>",
                Threat = 1,
                EncounterSet = "Return to Mirkwood",
                CardNumber = 138,
                Artist = Artist.Felicia_Cano
            });
            Cards.Add(new LotRCard() {
                
                Title = "Mirkwood Runner",
                Id = "51223bd0-ffd1-11df-a976-0801206c9016",
                CardType = CardType.Ally,
                Sphere = Sphere.Lore,
                Traits = new List<string>() { "Silvan.", " Scout." },
                Quantity = 3,
                ResourceCost = 3,
                Attack = 2,
                Defense = 0,
                Willpower = 1,
                HitPoints = 2,
                Text = "While Mirkwood Runner is attacking alone, the defending enemy does not count its Defense.",
                FlavorText = "\"...let a ploughman plough, but choose an otter for swimming, and for running light over grass and leaf or over snow-an Elf.\" -Legolas, The Fellowship of the Ring",
                HtmlTemplate = "<p>While {self} is attacking alone, the defending enemy does not count its {Defense}.</p><p class='flavor-text-smaller'>&quot;...let a ploughman plough, but choose an otter for swimming, and for running light over grass and leaf or over snow-an Elf.&quot;<br>&ndash;Legolas, The Fellowship of the Ring</p>",
                CardNumber = 123,
                Artist = Artist.Magali_Villeneuve
            });
            Cards.Add(new LotRCard() {
                
                Title = "Rumour from the Earth",
                Id = "51223bd0-ffd1-11df-a976-0801206c9017",
                CardType = CardType.Event,
                Sphere = Sphere.Lore,
                Quantity = 3,
                ResourceCost = 0,
                Text = "Action: Look at the top card of the encounter deck. Then, you may pay 1 Lore resource to return Rumour from the Earth to your hand.",
                FlavorText = "'Where sight fails the earth may bring us rumour,' said Aragorn. 'The land must groan under their hated feet.' -The Two Towers",
                CardNumber = 124,
                Artist = Artist.Ilich_Henriquez
            });
            Cards.Add(new LotRCard() {
                
                Title = "Shadow of the Past",
                Id = "51223bd0-ffd1-11df-a976-0801206c9018",
                CardType = CardType.Event,
                Sphere = Sphere.Neutral,
                Quantity = 3,
                ResourceCost = 2,
                Text = "Action: Move the top card of the encounter discard pile to the top of the encounter deck.",
                FlavorText = "The wizard's face remained grave and attentive, and only a flicker in his deep eyes showed that he was startled and indeed alarmed. 'It has been called that before,' he said, 'but not by you.' -The Fellowship of the Ring",
                CardNumber = 125,
                Artist = Artist.Henning_Ludvigsen
            });
            Cards.Add(new LotRCard() {
                
                Title = "Support of the Eagles",
                Id = "51223bd0-ffd1-11df-a976-0801206c9019",
                CardType = CardType.Attachment,
                Sphere = Sphere.Tactics,
                Traits = new List<string>() { "Boon." },
                Quantity = 3,
                ResourceCost = 3,
                Text = "Attach to a Tactics hero.\r\nAction: Exhaust Support of the Eagles to choose an Eagle ally. Until the end of the phase, attached hero adds that ally's Attack or Defense (choose 1) to its own.",
                FlavorText = "\"I would bear you, whither you will, even were you made of stone.\" -Gwaihir, The Return of the King",
                CardNumber = 120,
                Artist = Artist.Ilich_Henriquez
            });
            Cards.Add(new LotRCard() {
                
                Title = "The Spiders' Ring",
                Id = "51223bd0-ffd1-11df-a976-0801206c9020",
                CardType = CardType.Location,
                Traits = new List<string>() { "Forest." },
                Quantity = 4,
                EasyModeQuantity = 2,
                Text = "While The Spider's Ring is the active location, the player guarding ~Gollum cannot change.",
                Shadow = "Shadow: If this attack is undefended, return any current active location to the staging area. The Spider's Ring becomes the active location.",
                HtmlTemplate = "<p>While {self} is the active location, the player guarding <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a> cannot change.</p>{shadow}<p class='shadow-text'><b>Shadow:</b> If this attack is undefended, return any current active location to the staging area. {self} becomes the active location.</p>",
                Threat = 3,
                QuestPoints = 2,
                EncounterSet = "Return to Mirkwood",
                CardNumber = 131,
                Artist = Artist.Andrew_Johanson
            });
            Cards.Add(new LotRCard() {
                
                Title = "Through the Forest",
                StageNumber = 1,
                Id = "51223bd0-ffd1-11df-a976-0801206c9021",
                CardType = CardType.Quest,
                QuestPoints = 12,
                Quantity = 1,
                Text = "Setup: Search the encounter deck for Gollum. Choose a player to guard Gollum at the start of the game, and place Gollum in front of that player. Then shuffle the encounter deck. Reveal 1 card per player from the encounter deck, and add it to the staging area.",
                OppositeFlavorText = "Mirkwood is always a dangerous place, but it is even worse with Gollum. Between the outbursts, tantrums, and the flying provisions, you are not afforded a moment's peace",
                HtmlTemplate = "<p class='flavor-text'>Having captured Gollum, you must now escort him through Mirkwood Forest for interrogation at Thranduil's Palace.</p><p><b>Setup:</b> Search the encounter deck for <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a>. Choose a player to guard <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a> at the start of the game, and place <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a> in front of that player. Then shuffle the encounter deck. Reveal 1 card per player from the encounter deck, and add it to the staging area.</p>",
                EncounterSet = "Return to Mirkwood",
                CardNumber = 126,
                Artist = Artist.Ignacio_Bazan_Lazcano,
                IncludedEncounterSets = new List<EncounterSet> { EncounterSet.SpidersOfMirkwood, EncounterSet.Wilderlands }
            });
            Cards.Add(new LotRCard() {
                
                Title = "To the Elvin King's Halls",
                StageNumber = 3,
                Id = "51223bd0-ffd1-11df-a976-0801206c9023",
                CardType = CardType.Quest,
                FlavorText = "Having thwarted Gollum's escape attempt, you tighten his rope and push on through Mirkwood, to Thranduil's palace.",
                OppositeText = "The player guarding ~Gollum cannot play cards from his hand.",
                HtmlTemplate2 = "<p>The player guarding <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a> cannot play cards from his hand.</p>",
                QuestPoints = 7,
                Quantity = 1,
                EncounterSet = "Return to Mirkwood",
                CardNumber = 128,
                Artist = Artist.Timo_Karhula,
                IncludedEncounterSets = new List<EncounterSet> { EncounterSet.SpidersOfMirkwood, EncounterSet.Wilderlands }
            });
            Cards.Add(new LotRCard() {
                
                Title = "Wasted Provisions",
                Id = "51223bd0-ffd1-11df-a976-0801206c9025",
                CardType = CardType.Treachery,
                Traits = new List<string>() { "Tantrum." },
                Quantity = 3,
                EasyModeQuantity = 2,
                Text = "When Revealed: Discard the top 10 cards from the deck of the player guarding ~Gollum. That player must choose a new player to guard Gollum, if able.",
                Shadow = "Shadow: Discard the top 5 cards from the deck of the player guarding ~Gollum.",
                HtmlTemplate = "<p><b>When Revealed:</b> Discard the top 10 cards from the deck of the player guarding <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a>. That player must choose a new player to guard <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a>, if able.</p>{shadow}<p class='shadow-text'><b>Shadow:</b> Discard the top 5 cards from the deck of the player guarding <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a>.</p>",
                EncounterSet = "Return to Mirkwood",
                CardNumber = 137,
                Artist = Artist.David_A_Nash
            });
            Cards.Add(new LotRCard() {
                
                Title = "West Road Traveller",
                Id = "51223bd0-ffd1-11df-a976-0801206c9026",
                CardType = CardType.Ally,
                Sphere = Sphere.Spirit,
                Traits = new List<string>() { "Rohan." },
                Quantity = 3,
                ResourceCost = 2,
                Attack = 0,
                Defense = 0,
                Willpower = 2,
                HitPoints = 1,
                Text = "Response: After you play West Road Traveller from your hand, switch the active location with any other location in the staging area.",
                HtmlTemplate = "<p><b>Response:</b> After you play {self} from your hand, switch the active location with any other location in the staging area.</p><p class='flavor-text'>The dark world was rushing by, and the wind sang loudly in his ears.<br>&ndash;The Return of the King</p>",
                FlavorText = "The dark world was rushing by, and the wind sang loudly in his ears. -The Return of the King",
                CardNumber = 121,
                Artist = Artist.Sara_Biddle
            });
            Cards.Add(new LotRCard() {
                
                Title = "Wood Elf Path",
                Id = "51223bd0-ffd1-11df-a976-0801206c9027",
                CardType = CardType.Location,
                Traits = new List<string>() { "Forest." },
                Quantity = 3,
                Text = "Response: After the players travel to Wood Elf Path, the player guarding ~Gollum may choose a new player to guard him.",
                HtmlTemplate = "<p><b>Response:</b> After the players travel to {self}, the player guarding <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a> may choose a new player to guard him.</p>",
                Threat = 1,
                QuestPoints = 3,
                EncounterSet = "Return to Mirkwood",
                CardNumber = 134,
                Artist = Artist.Stacey_Diana_Clark
            });
            Cards.Add(new LotRCard() {
                
                Title = "Woodman's Glade",
                Id = "51223bd0-ffd1-11df-a976-0801206c9028",
                CardType = CardType.Location,
                Traits = new List<string>() { "Forest." },
                Quantity = 3,
                Text = "Travel: The player guarding ~Gollum must exhaust a hero he controls to travel to Woodman's Glade.Response: After exploring Woodman's Glade, reduce the threat of each player not guarding ~Gollum by 2.",
                HtmlTemplate = "<p><b>Travel:</b> The player guarding <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a> must exhaust a hero he controls to travel to {self}.</p><p><b>Response:</b> After exploring {self}, reduce the threat of each player not guarding <a title='Gollum (Return to Mirkwood)' target='_blank' href='/Cards/Details/Gollum-RtM'>Gollum</a> by 2.</p>",
                Threat = 2,
                QuestPoints = 2,
                EncounterSet = "Return to Mirkwood",
                CardNumber = 133,
                Artist = Artist.Mark_Poole
            });
        }
    }
}
