using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters;

public class City
{
    private string name;
    private int tier;
    private Person leader;
    private int population;
    private int poiCount;
    private bool guilds;
    private int magicLvl;
    private List<POI> pointsOfInterest = new List<POI>();
    private PersonGenerator personGen;
    private BuildingNameGen buildingGen = new BuildingNameGen();
    private Random random = new Random();

    public City(string name, int tier, PersonGenerator personGen, bool guilds, int magicLvl)
    {
        this.name = name;
        this.tier = tier;
        this.personGen = personGen;
        this.guilds = guilds;
        this.magicLvl = magicLvl;

        leader = personGen.GenRandomPerson();

        if (tier <= 1)
        {
            population = random.Next(10, 401);
            poiCount = random.Next(2) + 1;

            pointsOfInterest.Add(new ServInn($"{name} Inn", personGen.GenRandomPerson(), tier, personGen));
            buildingGen.AddCustomName($"{name} Inn");
            while (poiCount > pointsOfInterest.Count)
            {
                AddPOI();
            }
        }
        else if (tier == 2)
        {
            population = random.Next(400, 801);
            poiCount = random.Next(4 , 7);
            
            pointsOfInterest.Add(new GovLeadersHouse($"{leader.GetFirstName()} {leader.GetLastName()}'s House", leader, tier));
            buildingGen.AddCustomName($"{leader.GetFirstName()} {leader.GetLastName()}'s House");
            pointsOfInterest.Add(new ServInn($"{name} Inn", personGen.GenRandomPerson(), tier, personGen));
            buildingGen.AddCustomName($"{name} Inn");
            while (poiCount > pointsOfInterest.Count)
            {
                AddPOI();
            }
        }
        else if (tier == 3)
        {
            population = random.Next(900, 1801);
            poiCount = random.Next(6 , 13);

            pointsOfInterest.Add(new GovManor($"{leader.GetLastName()} Manor", leader, tier, personGen));
            buildingGen.AddCustomName($"{leader.GetLastName()} Manor");

            pointsOfInterest.Add(new ServInn($"{name} Inn", personGen.GenRandomPerson(), tier, personGen));
            buildingGen.AddCustomName($"{name} Inn");

            pointsOfInterest.Add(new CraftBlacksmith(buildingGen.GetNamedName("Smithing"), personGen.GenRandomPerson(), tier, personGen));
            pointsOfInterest.Add(new MercGeneralStore($"{name} General Store", personGen.GenRandomPerson(), tier, personGen));
            buildingGen.AddCustomName($"{name} General Store");

            while (poiCount > pointsOfInterest.Count)
            {
                AddPOI();
            }
        }
        else if (tier == 4)
        {
            population = random.Next(2000, 5001);
            poiCount = random.Next(10 , 21);

            pointsOfInterest.Add(new GovManor($"{leader.GetLastName()} Manor", leader, tier, personGen));
            buildingGen.AddCustomName($"{leader.GetLastName()} Manor");

            if (random.Next(2) == 0)
            {
                pointsOfInterest.Add(new ServInn($"{name} Inn", personGen.GenRandomPerson(), tier, personGen));
                buildingGen.AddCustomName($"{name} Inn");
            }
            else
            {
                pointsOfInterest.Add(new ServTavern(buildingGen.GetRandomName(), personGen.GenRandomPerson(), tier, personGen));
            }

            pointsOfInterest.Add(new CraftBlacksmith(buildingGen.GetNamedName("Smithing"), personGen.GenRandomPerson(), tier, personGen));
            pointsOfInterest.Add(new MercGeneralStore($"{name} General Store", personGen.GenRandomPerson(), tier, personGen));
            buildingGen.AddCustomName($"{name} General Store");

            while (poiCount > pointsOfInterest.Count)
            {
                AddPOI();
            }
        }
        else if (tier >= 5)
        {
            population = random.Next(10000, 16001);
            poiCount = random.Next(15 , 31);

            pointsOfInterest.Add(new GovManor($"{leader.GetLastName()} Manor", leader, tier, personGen));
            buildingGen.AddCustomName($"{leader.GetLastName()} Manor");

            if (random.Next(2) == 0)
            {
                pointsOfInterest.Add(new ServInn($"{name} Inn", personGen.GenRandomPerson(), tier, personGen));
                buildingGen.AddCustomName($"{name} Inn");
            }
            else
            {
                pointsOfInterest.Add(new ServTavern(buildingGen.GetRandomName(), personGen.GenRandomPerson(), tier, personGen));
            }

            pointsOfInterest.Add(new CraftBlacksmith(buildingGen.GetNamedName("Smithing"), personGen.GenRandomPerson(), tier, personGen));
            pointsOfInterest.Add(new MercGeneralStore($"{name} General Store", personGen.GenRandomPerson(), tier, personGen));
            buildingGen.AddCustomName($"{name} General Store");

            if (guilds)
            {
                pointsOfInterest.Add(new ProGuildhouse($"{name} Guildhouse", personGen.GenRandomPerson(), tier, personGen));
                buildingGen.AddCustomName($"{name} Guildhouse");
            }

            while (poiCount > pointsOfInterest.Count)
            {
                AddPOI();
            }
        }
        
    }

    public City(string name, int tier, PersonGenerator personGen, bool guilds, int magicLvl, Person ruler)
    {
        this.name = name;
        this.tier = tier;
        this.personGen = personGen;
        this.guilds = guilds;
        this.magicLvl = magicLvl;

        leader = ruler;

        pointsOfInterest.Add(new GovPalace($"{name} Palace", leader, tier, personGen));
        buildingGen.AddCustomName($"{name} Palace");

        population = random.Next(16000, 25001);
        poiCount = random.Next(15 , 36);
        if (random.Next(2) == 0)
        {
            pointsOfInterest.Add(new ServInn($"{name} Inn", personGen.GenRandomPerson(), tier, personGen));
            buildingGen.AddCustomName($"{name} Inn");
        }
        else
        {
            pointsOfInterest.Add(new ServTavern(buildingGen.GetRandomName(), personGen.GenRandomPerson(), tier, personGen));
        }

        pointsOfInterest.Add(new CraftBlacksmith(buildingGen.GetNamedName("Smithing"), personGen.GenRandomPerson(), tier, personGen));
        pointsOfInterest.Add(new MercGeneralStore($"{name} General Store", personGen.GenRandomPerson(), tier, personGen));
            buildingGen.AddCustomName($"{name} General Store");

        if (guilds)
        {
            pointsOfInterest.Add(new ProGuildhouse($"{name} Guildhouse", personGen.GenRandomPerson(), tier, personGen));
            buildingGen.AddCustomName($"{name} Guildhouse");
        }

        while (poiCount > pointsOfInterest.Count)
        {
            AddPOI();
        }
    }

    public int GetPopulation()
    {
        return population;
    }

    public string GetName()
    {
        return name;
    }

    public void DisplayCity()
    {
        string cityType = "City";
        if (tier == 1)
        {
            cityType = "Hamlet";
        }
        else if (tier == 2)
        {
            cityType = "Commune";
        }
        else if (tier == 3)
        {
            cityType = "Village";
        }
        else if (tier == 4)
        {
            cityType = "Town";
        }
        Console.WriteLine($"{cityType}: {name}");
        Console.WriteLine($"Population: {population}");
        Console.WriteLine($"Total Locations: {poiCount}");
        if (pointsOfInterest.Any(poi => poi is CraftsmanPOI))
        {
            Console.WriteLine($"Craftsman: {pointsOfInterest.Count(poi => poi is CraftsmanPOI)}");
        }
        if (pointsOfInterest.Any(poi => poi is EntertainmentPOI))
        {
            Console.WriteLine($"Entertainment: {pointsOfInterest.Count(poi => poi is EntertainmentPOI)}");
        }
        if (pointsOfInterest.Any(poi => poi is GovernmentalPOI))
        {
            Console.WriteLine($"Govermental: {pointsOfInterest.Count(poi => poi is GovernmentalPOI)}");
        }
        if (pointsOfInterest.Any(poi => poi is MercantilePOI))
        {
            Console.WriteLine($"Mercantile: {pointsOfInterest.Count(poi => poi is MercantilePOI)}");
        }
        if (pointsOfInterest.Any(poi => poi is ProfeshionalPOI))
        {
            Console.WriteLine($"Profeshional: {pointsOfInterest.Count(poi => poi is ProfeshionalPOI)}");
        }
        if (pointsOfInterest.Any(poi => poi is ReligiousPOI))
        {
            Console.WriteLine($"Religious: {pointsOfInterest.Count(poi => poi is ReligiousPOI)}");
        }
        if (pointsOfInterest.Any(poi => poi is ScholarlyPOI))
        {
            Console.WriteLine($"Scholarly: {pointsOfInterest.Count(poi => poi is ScholarlyPOI)}");
        }
        if (pointsOfInterest.Any(poi => poi is ServicePOI))
        {
            Console.WriteLine($"Service: {pointsOfInterest.Count(poi => poi is ServicePOI)}");
        }
        if (pointsOfInterest.Any(poi => poi is TradesmanPOI))
        {
            Console.WriteLine($"Tradesman: {pointsOfInterest.Count(poi => poi is TradesmanPOI)}");
        }
        if (pointsOfInterest.Any(poi => poi is UnderworldPOI))
        {
            Console.WriteLine($"Underworld: {pointsOfInterest.Count(poi => poi is UnderworldPOI)}");
        }
    }

    public List<string> FormatCity()
    {
        List<string> formattedString = new List<string>();
        string cityType = "City";
        if (tier == 1)
        {
            cityType = "Hamlet";
        }
        else if (tier == 2)
        {
            cityType = "Commune";
        }
        else if (tier == 3)
        {
            cityType = "Village";
        }
        else if (tier == 4)
        {
            cityType = "Town";
        }

        formattedString.Add($"{cityType}: {name}");
        formattedString.Add($"Leader: {leader.GetFirstName()} {leader.GetLastName()}");
        formattedString.Add($"          {leader.GetRace()}, {leader.GetGender()}");
        formattedString.Add($"Population: {population}");
        formattedString.Add($"Points of Interest:");
        foreach (POI poi in pointsOfInterest)
        {
            int maxStringLength = poi.DisplayPOI().Max(str => str.Length);
            string spacer = "";
            for (int i = 0; i < maxStringLength; i++)
            {
                spacer = $"{spacer}_";
            }
            formattedString.Add(spacer);
            foreach (string line in poi.DisplayPOI())
            {
                formattedString.Add($"-   {line}");
            }
            formattedString.Add(spacer);

        }

        return formattedString;

    }

    public void AddPOI()
    {   
        int diceRoll = random.Next(100);
        if (tier == 1)
        {
            if (diceRoll > 90)
            {
                Person owner = personGen.GenRandomPerson();
                string building_name = $"{owner.GetLastName()}'s Smithy";
                buildingGen.AddCustomName(building_name);
                pointsOfInterest.Add(new CraftBlacksmith(building_name, owner, tier, personGen));
            }
            else if (diceRoll > 80)
            {
                Person owner = personGen.GenRandomPerson();
                string building_name = $"{owner.GetLastName()}'s Carpentry";
                buildingGen.AddCustomName(building_name);
                pointsOfInterest.Add(new CraftCarpenter(building_name, owner, tier, personGen));
            }
            else if (diceRoll > 70)
            {
                Person owner = personGen.GenRandomPerson();
                string building_name = $"{owner.GetLastName()}'s Styles";
                buildingGen.AddCustomName(building_name);
                pointsOfInterest.Add(new CraftClothier(building_name, owner, tier, personGen));
            }
            else if (diceRoll > 60)
            {
                Person owner = personGen.GenRandomPerson();
                string building_name = $"{owner.GetLastName()}'s Leatherworking";
                buildingGen.AddCustomName(building_name);
                pointsOfInterest.Add(new CraftLeatherworker(building_name, owner, tier, personGen));
            }
            else if (diceRoll > 40)
            {
                Person owner = personGen.GenRandomPerson();
                string building_name = $"{name} Stables";
                buildingGen.AddCustomName(building_name);
                pointsOfInterest.Add(new TradeStable(building_name, owner, tier, personGen));
            }
            else if (diceRoll > 20)
            {
                Person owner = personGen.GenRandomPerson();
                string building_name = $"{name} Trading Post";
                buildingGen.AddCustomName(building_name);
                pointsOfInterest.Add(new MercTradingPost(building_name, owner, tier, personGen));
            }
            else if (diceRoll > 0)
            {;
                string building_name = $"{name} Shrine";
                buildingGen.AddCustomName(building_name);
                pointsOfInterest.Add(new RelShrine(building_name, leader, tier));
            }
            else if (diceRoll == 0 && magicLvl > 1)
            {
                Person owner = personGen.GenRandomPerson();
                pointsOfInterest.Add(new SchWizardTower(buildingGen.GetNamedName("Tower"), owner, 3));
            }
        }

        else if (tier == 2)
        {
            if (diceRoll  > 75)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 75 && !pointsOfInterest.Any(poi => poi is RelTemple))
                {
                    pointsOfInterest.Add(new RelTemple($"{name} Temple", leader, tier, personGen));
                    buildingGen.AddCustomName($"{name} Temple");
                }
                else
                {
                    pointsOfInterest.Add(new RelShrine(buildingGen.GetNamedName("Shrine"), leader, tier));
                }
            }
            else if (pointsOfInterest.Any(poi => poi is ReligiousPOI))
            {
                if (diceRoll > 90 && !pointsOfInterest.Any(poi => poi is CraftBlacksmith))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()}'s Smithy";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new CraftBlacksmith(building_name, owner, tier, personGen));
                }
                else if (diceRoll > 80 && !pointsOfInterest.Any(poi => poi is CraftCarpenter))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()}'s Carpentry";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new CraftCarpenter(building_name, owner, tier, personGen));
                }
                else if (diceRoll > 70 && !pointsOfInterest.Any(poi => poi is CraftClothier))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()}'s Clothes";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new CraftClothier(building_name, owner, tier, personGen));
                }
                else if (diceRoll > 60 && !pointsOfInterest.Any(poi => poi is CraftGlassmaker))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()}'s Glassmaking";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new CraftGlassmaker(building_name, owner, tier, personGen));
                }
                else if (diceRoll > 50 && !pointsOfInterest.Any(poi => poi is CraftJeweler))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()}'s Gems";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new CraftJeweler(building_name, owner, tier, personGen));
                }
                else if (diceRoll > 40 && !pointsOfInterest.Any(poi => poi is CraftSculptor))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()}'s Sculpting";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new CraftSculptor(building_name, owner, tier, personGen));
                }
                else if (diceRoll > 30 && !pointsOfInterest.Any(poi => poi is CraftStonemason))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()}'s Masonry";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new CraftStonemason(building_name, owner, tier, personGen));
                }
                else if (diceRoll > 20 && !pointsOfInterest.Any(poi => poi is TradeApothecary))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()}'s Apothecary";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new TradeApothecary(building_name, owner, tier, personGen));
                }
                else if (diceRoll > 10 && !pointsOfInterest.Any(poi => poi is MercTradingPost))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Trading Post";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new MercTradingPost(building_name, owner, tier, personGen));
                }
                else if (diceRoll > 5 && !pointsOfInterest.Any(poi => poi is SchScriptorium))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Scriptorium";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new SchScriptorium(building_name, owner, tier, personGen));
                }
                else if (diceRoll >= 0 && !pointsOfInterest.Any(poi => poi is RelCemetary))
                {
                    string building_name = $"{name}'s Cemetary";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new RelCemetary(building_name, leader, tier));
                }
            }
        }
    
        else if (tier == 3)
        {
            int poiTier = tier;
            if (random.Next(30) == 0)
            {
                poiTier++;
            }
            //Craft
            if (diceRoll > 80)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 80 && !(pointsOfInterest.Count(poi => poi is CraftBlacksmith) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftBlacksmith(buildingGen.GetNamedName("Smithing"), owner, poiTier, personGen));
                }
                else if (diceRoll > 60 && !(pointsOfInterest.Count(poi => poi is CraftCarpenter) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftCarpenter(buildingGen.GetNamedName("Carpentry"), owner, poiTier, personGen));
                }
                else if (diceRoll > 45 && !(pointsOfInterest.Count(poi => poi is CraftClothier) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftClothier(buildingGen.GetNamedName("Styles"), owner, poiTier, personGen));
                }
                else if (diceRoll > 35 && !(pointsOfInterest.Count(poi => poi is CraftGlassmaker) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftGlassmaker(buildingGen.GetNamedName("Glassmaking"), owner, poiTier, personGen));
                }
                else if (diceRoll > 30 && !(pointsOfInterest.Count(poi => poi is CraftJeweler) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftJeweler(buildingGen.GetNamedName("Jewelry"), owner, poiTier, personGen));
                }
                else if (diceRoll > 15 && !(pointsOfInterest.Count(poi => poi is CraftSculptor) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftSculptor(buildingGen.GetNamedName("Sculpting"), owner, poiTier, personGen));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is CraftStonemason) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftStonemason(buildingGen.GetNamedName("Masonry"), owner, poiTier, personGen));
                }
            }
            //Pro
            else if (diceRoll > 75)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 25 && !pointsOfInterest.Any(poi => poi is ProGuildhouse) && guilds)
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Guildhouse";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new ProGuildhouse(building_name, owner, poiTier, personGen));
                }
                else if (!pointsOfInterest.Any(poi => poi is ProMageGuild) && guilds && magicLvl > 2)
                {
                   Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Mage Guild";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new ProMageGuild(building_name, owner, poiTier, personGen)); 
                }
            }
            //Trade
            else if (diceRoll > 65)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 70 && !(pointsOfInterest.Count(poi => poi is TradeApothecary) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new TradeApothecary(buildingGen.GetNamedName("Apothecary"), owner, poiTier, personGen));
                }
                else if (diceRoll > 40 && !(pointsOfInterest.Count(poi => poi is TradeBrewery) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new TradeBrewery(buildingGen.GetNamedName("Brewery"), owner, poiTier, personGen));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is TradeStable) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new TradeStable(buildingGen.GetNamedName("Stables"), owner, poiTier, personGen));
                }
            }
            //Merc
            else if (diceRoll > 45)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 10 && !(pointsOfInterest.Count(poi => poi is MercGeneralStore) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()}'s";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new MercGeneralStore(building_name, owner, poiTier, personGen));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is MercMarketplace) > 0))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Marketplace";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new MercMarketplace(building_name, owner, poiTier, personGen));
                }
            }
            //Serv
            else if (diceRoll > 30)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 90 && !(pointsOfInterest.Count(poi => poi is ServBarbershop) > 0))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new ServBarbershop(buildingGen.GetNamedName("Barbershop"), owner, poiTier, personGen));
                }
                else if (diceRoll > 55 && !(pointsOfInterest.Count(poi => poi is ServInn) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new ServInn(buildingGen.GetRandomName(), owner, poiTier, personGen));
                }
                else if (diceRoll > 45 && !(pointsOfInterest.Count(poi => poi is ServKitchen) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new ServKitchen(buildingGen.GetRandomName(), owner, poiTier));
                }
                else if (diceRoll > 35 && !(pointsOfInterest.Count(poi => poi is ServResteraunt) > 0))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new ServResteraunt(buildingGen.GetRandomName(), owner, poiTier, personGen));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is ServTavern) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new ServTavern(buildingGen.GetRandomName(), owner, poiTier, personGen));
                }
            }
            //Sch
            else if (diceRoll > 20)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 90 && !(pointsOfInterest.Count(poi => poi is SchAlchemist) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new SchAlchemist(buildingGen.GetNamedName("Potions"), owner, poiTier, personGen));
                }
                else if (diceRoll > 55 && !(pointsOfInterest.Count(poi => poi is SchFortuneTeller) > 0))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetFirstName()} {owner.GetLastName()}'s Fortunes";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new SchFortuneTeller(building_name, owner, poiTier));
                }
                else if (diceRoll > 45 && !(pointsOfInterest.Count(poi => poi is SchScrollshop) > 1) && magicLvl > 1)
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new SchScrollshop(buildingGen.GetNamedName("Scrolls"), owner, poiTier));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is SchWizardTower) > 0) && magicLvl > 1)
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new SchWizardTower(buildingGen.GetNamedName("Tower"), owner, poiTier));
                }
            }
            //Rel
            else if (diceRoll > 10)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 50 && !(pointsOfInterest.Count(poi => poi is RelShrine) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new RelShrine(buildingGen.GetNamedName("Shrine"), owner, poiTier));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is RelCemetary) > 0))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Cemetary";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new RelCemetary(building_name, owner, poiTier));
                }
            }
            //Gov
            else if (diceRoll > 0)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 50 && !(pointsOfInterest.Count(poi => poi is GovBarracks) > 0))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Barracks";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new GovBarracks(building_name, owner, poiTier, personGen));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is GovJail) > 0))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Jail";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new GovJail(building_name, owner, poiTier, personGen));
                }
            }
        }

        else if (tier == 4)
        {
            int poiTier = tier;
            if (random.Next(20) == 0)
            {
                poiTier++;
            }
            //Craft
            if (diceRoll > 85)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 90 && !(pointsOfInterest.Count(poi => poi is CraftBlacksmith) > 3))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftBlacksmith(buildingGen.GetNamedName("Smithing"), owner, poiTier, personGen));
                }
                else if (diceRoll > 75 && !(pointsOfInterest.Count(poi => poi is CraftArmory) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftArmory(buildingGen.GetNamedName("Armor"), owner, poiTier, personGen));
                }
                else if (diceRoll > 60 && !(pointsOfInterest.Count(poi => poi is CraftArsenal) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftArsenal(buildingGen.GetNamedName("Weapons"), owner, poiTier, personGen));
                }
                else if (diceRoll > 50 && !(pointsOfInterest.Count(poi => poi is CraftCarpenter) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftCarpenter(buildingGen.GetNamedName("Carpentry"), owner, poiTier, personGen));
                }
                else if (diceRoll > 40 && !(pointsOfInterest.Count(poi => poi is CraftClothier) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftClothier(buildingGen.GetNamedName("Styles"), owner, poiTier, personGen));
                }
                else if (diceRoll > 30 && !(pointsOfInterest.Count(poi => poi is CraftGlassmaker) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftGlassmaker(buildingGen.GetNamedName("Glassmaking"), owner, poiTier, personGen));
                }
                else if (diceRoll > 20 && !(pointsOfInterest.Count(poi => poi is CraftJeweler) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftJeweler(buildingGen.GetNamedName("Jewelry"), owner, poiTier, personGen));
                }
                else if (diceRoll > 10 && !(pointsOfInterest.Count(poi => poi is CraftSculptor) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftSculptor(buildingGen.GetNamedName("Sculpting"), owner, poiTier, personGen));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is CraftStonemason) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftStonemason(buildingGen.GetNamedName("Masonry"), owner, poiTier, personGen));
                }
            }
            //Ent
            else if (diceRoll > 80)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 75 && !pointsOfInterest.Any(poi => poi is EntCarnival))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new EntCarnival($"{owner.GetLastName()}'s {buildingGen.GetNamedName("Carnival")}", owner, poiTier, personGen));
                }
                else if (diceRoll > 25 && !pointsOfInterest.Any(poi => poi is EntPark))
                {
                   Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()} Park";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new EntPark(building_name, owner, poiTier)); 
                }
                else if (diceRoll > 0 && !pointsOfInterest.Any(poi => poi is EntTheater))
                {
                   Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Theater";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new EntTheater(building_name, owner, poiTier, personGen)); 
                }
            }
            //Pro
            else if (diceRoll > 70)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 35 && !pointsOfInterest.Any(poi => poi is ProGuildhouse) && guilds)
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Guildhouse";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new ProGuildhouse(building_name, owner, poiTier, personGen));
                }
                else if (!pointsOfInterest.Any(poi => poi is ProMageGuild) && guilds && magicLvl > 2)
                {
                   Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Mage Guild";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new ProMageGuild(building_name, owner, poiTier, personGen)); 
                }
            }
            //Trade
            else if (diceRoll > 65)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 70 && !(pointsOfInterest.Count(poi => poi is TradeApothecary) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new TradeApothecary(buildingGen.GetNamedName("Apothecary"), owner, poiTier, personGen));
                }
                else if (diceRoll > 40 && !(pointsOfInterest.Count(poi => poi is TradeBrewery) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new TradeBrewery(buildingGen.GetNamedName("Brewery"), owner, poiTier, personGen));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is TradeStable) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new TradeStable(buildingGen.GetNamedName("Stables"), owner, poiTier, personGen));
                }
            }
            //Merc
            else if (diceRoll > 50)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 25 && !(pointsOfInterest.Count(poi => poi is MercGeneralStore) > 3))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()}'s";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new MercGeneralStore(building_name, owner, poiTier, personGen));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is MercMarketplace) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()} Marketplace";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new MercMarketplace(building_name, owner, poiTier, personGen));
                }
            }
            //Serv
            else if (diceRoll > 35)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 90 && !(pointsOfInterest.Count(poi => poi is ServBarbershop) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new ServBarbershop(buildingGen.GetNamedName("Barbershop"), owner, poiTier, personGen));
                }
                else if (diceRoll > 60 && !(pointsOfInterest.Count(poi => poi is ServInn) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new ServInn(buildingGen.GetRandomName(), owner, poiTier, personGen));
                }
                else if (diceRoll > 50 && !(pointsOfInterest.Count(poi => poi is ServKitchen) > 3))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new ServKitchen(buildingGen.GetRandomName(), owner, poiTier));
                }
                else if (diceRoll > 40 && !(pointsOfInterest.Count(poi => poi is ServBathhouse) > 0))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Bathhouse";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new ServBathhouse(building_name, owner, poiTier));
                }
                else if (diceRoll > 30 && !(pointsOfInterest.Count(poi => poi is ServResteraunt) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new ServResteraunt(buildingGen.GetRandomName(), owner, poiTier, personGen));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is ServTavern) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new ServTavern(buildingGen.GetRandomName(), owner, poiTier, personGen));
                }
            }
            //Sch
            else if (diceRoll > 20)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 70 && !(pointsOfInterest.Count(poi => poi is SchAlchemist) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new SchAlchemist(buildingGen.GetNamedName("Potions"), owner, poiTier, personGen));
                }
                else if (diceRoll > 50 && !(pointsOfInterest.Count(poi => poi is SchFortuneTeller) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetFirstName()} {owner.GetLastName()}'s Fortunes";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new SchFortuneTeller(building_name, owner, poiTier));
                }
                else if (diceRoll > 40 && !(pointsOfInterest.Count(poi => poi is SchLibrary) > 0))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Library";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new SchLibrary(building_name, owner, poiTier, personGen));
                }
                else if (diceRoll > 10 && !(pointsOfInterest.Count(poi => poi is SchScrollshop) > 2) && magicLvl > 1)
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new SchScrollshop(buildingGen.GetNamedName("Scrolls"), owner, poiTier));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is SchWizardTower) > 1) && magicLvl > 1)
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new SchWizardTower(buildingGen.GetNamedName("Tower"), owner, poiTier));
                }
            }
            //Rel
            else if (diceRoll > 10)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 50 && !(pointsOfInterest.Count(poi => poi is RelShrine) > 3))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new RelShrine(buildingGen.GetNamedName("Shrine"), owner, poiTier));
                }
                else if (diceRoll > 25 && !(pointsOfInterest.Count(poi => poi is RelCemetary) > 0))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Cemetary";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new RelCemetary(building_name, owner, poiTier));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is RelTemple) > 0))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Temple";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new RelTemple(building_name, owner, poiTier, personGen));
                }
            }
            //Gov
            else if (diceRoll > 0)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 50 && !(pointsOfInterest.Count(poi => poi is GovBarracks) > 0))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Barracks";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new GovBarracks(building_name, owner, poiTier, personGen));
                }
                else if (diceRoll > 30 && !(pointsOfInterest.Count(poi => poi is GovCourthouse) > 0))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Courthouse";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new GovCourthouse(building_name, owner, poiTier, personGen));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is GovJail) > 0))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Jail";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new GovJail(building_name, owner, poiTier, personGen));
                }
            }
        }

        else if (tier >= 5)
        {
            int poiTier = tier;
            if (random.Next(10) == 0)
            {
                poiTier++;
            }
            //Craft
            if (diceRoll > 90)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 90 && !(pointsOfInterest.Count(poi => poi is CraftBlacksmith) > 3))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftBlacksmith(buildingGen.GetNamedName("Smithing"), owner, poiTier, personGen));
                }
                else if (diceRoll > 75 && !(pointsOfInterest.Count(poi => poi is CraftArmory) > 3))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftArmory(buildingGen.GetNamedName("Armor"), owner, poiTier, personGen));
                }
                else if (diceRoll > 60 && !(pointsOfInterest.Count(poi => poi is CraftArsenal) > 3))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftArsenal(buildingGen.GetNamedName("Weapons"), owner, poiTier, personGen));
                }
                else if (diceRoll > 50 && !(pointsOfInterest.Count(poi => poi is CraftCarpenter) > 3))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftCarpenter(buildingGen.GetNamedName("Carpentry"), owner, poiTier, personGen));
                }
                else if (diceRoll > 40 && !(pointsOfInterest.Count(poi => poi is CraftClothier) > 3))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftClothier(buildingGen.GetNamedName("Styles"), owner, poiTier, personGen));
                }
                else if (diceRoll > 30 && !(pointsOfInterest.Count(poi => poi is CraftGlassmaker) > 3))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftGlassmaker(buildingGen.GetNamedName("Glassmaking"), owner, poiTier, personGen));
                }
                else if (diceRoll > 20 && !(pointsOfInterest.Count(poi => poi is CraftJeweler) > 3))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftJeweler(buildingGen.GetNamedName("Jewelry"), owner, poiTier, personGen));
                }
                else if (diceRoll > 10 && !(pointsOfInterest.Count(poi => poi is CraftSculptor) > 3))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftSculptor(buildingGen.GetNamedName("Sculpting"), owner, poiTier, personGen));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is CraftStonemason) > 3))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new CraftStonemason(buildingGen.GetNamedName("Masonry"), owner, poiTier, personGen));
                }
            }
            //Ent
            else if (diceRoll > 80)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 75 && !pointsOfInterest.Any(poi => poi is EntCarnival))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new EntCarnival($"{owner.GetLastName()}'s {buildingGen.GetNamedName("Carnival")}", owner, poiTier, personGen));
                }
                else if (diceRoll > 50 && !pointsOfInterest.Any(poi => poi is EntMuseum))
                {
                   Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()} Museum";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new EntMuseum(building_name, owner, poiTier, personGen)); 
                }
                else if (diceRoll > 25 && !(pointsOfInterest.Count(poi => poi is EntPark) > 2))
                {
                   Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()} Park";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new EntPark(building_name, owner, poiTier)); 
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is EntTheater) > 1))
                {
                   Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()} Theater";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new EntTheater(building_name, owner, poiTier, personGen)); 
                }
            }
            //Pro
            else if (diceRoll > 70)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 60 && !(pointsOfInterest.Count(poi => poi is ProGuildhouse) > 2) && guilds)
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Guildhouse, {owner.GetLastName()}'s Branch";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new ProGuildhouse(building_name, owner, poiTier, personGen));
                }
                else if (diceRoll > 30 && !pointsOfInterest.Any(poi => poi is ProHospital))
                {
                   Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} General Hospital";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new ProHospital(building_name, owner, poiTier, personGen)); 
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is ProMageGuild) > 1) && guilds && magicLvl > 2)
                {
                   Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Mage Guild, {owner.GetLastName()}'s Branch";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new ProMageGuild(building_name, owner, poiTier, personGen)); 
                }
            }
            //Trade
            else if (diceRoll > 60)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 70 && !(pointsOfInterest.Count(poi => poi is TradeApothecary) > 3))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new TradeApothecary(buildingGen.GetNamedName("Apothecary"), owner, poiTier, personGen));
                }
                else if (diceRoll > 40 && !(pointsOfInterest.Count(poi => poi is TradeBrewery) > 3))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new TradeBrewery(buildingGen.GetNamedName("Brewery"), owner, poiTier, personGen));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is TradeStable) > 3))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new TradeStable(buildingGen.GetNamedName("Stables"), owner, poiTier, personGen));
                }
            }
            //Merc
            else if (diceRoll > 50)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 50 && !(pointsOfInterest.Count(poi => poi is MercGeneralStore) > 5))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()}'s";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new MercGeneralStore(building_name, owner, poiTier, personGen));
                }
                else if (diceRoll > 25 && !(pointsOfInterest.Count(poi => poi is MercMarketplace) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()} Marketplace";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new MercMarketplace(building_name, owner, poiTier, personGen));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is MercWarehouse) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()} Warehouse";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new MercWarehouse(building_name, owner, poiTier, personGen));
                }
            }
            //Serv
            else if (diceRoll > 35)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 90 && !(pointsOfInterest.Count(poi => poi is ServBarbershop) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new ServBarbershop(buildingGen.GetNamedName("Barbershop"), owner, poiTier, personGen));
                }
                else if (diceRoll > 60 && !(pointsOfInterest.Count(poi => poi is ServInn) > 4))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new ServInn(buildingGen.GetRandomName(), owner, poiTier, personGen));
                }
                else if (diceRoll > 50 && !(pointsOfInterest.Count(poi => poi is ServKitchen) > 3))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new ServKitchen(buildingGen.GetRandomName(), owner, poiTier));
                }
                else if (diceRoll > 40 && !(pointsOfInterest.Count(poi => poi is ServBathhouse) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()} Bathhouse";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new ServBathhouse(building_name, owner, poiTier));
                }
                else if (diceRoll > 30 && !(pointsOfInterest.Count(poi => poi is ServResteraunt) > 3))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new ServResteraunt(buildingGen.GetRandomName(), owner, poiTier, personGen));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is ServTavern) > 4))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new ServTavern(buildingGen.GetRandomName(), owner, poiTier, personGen));
                }
            }
            //Sch
            else if (diceRoll > 25)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 75 && !(pointsOfInterest.Count(poi => poi is SchAlchemist) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new SchAlchemist(buildingGen.GetNamedName("Potions"), owner, poiTier, personGen));
                }
                else if (diceRoll > 60 && !(pointsOfInterest.Count(poi => poi is SchFortuneTeller) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetFirstName()} {owner.GetLastName()}'s Fortunes";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new SchFortuneTeller(building_name, owner, poiTier));
                }
                else if (diceRoll > 50 && !(pointsOfInterest.Count(poi => poi is SchLibrary) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()} Library";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new SchLibrary(building_name, owner, poiTier, personGen));
                }
                else if (diceRoll > 25 && !(pointsOfInterest.Count(poi => poi is SchScrollshop) > 2) && magicLvl > 1)
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new SchScrollshop(buildingGen.GetNamedName("Scrolls"), owner, poiTier));
                }
                else if (diceRoll > 20 && !(pointsOfInterest.Count(poi => poi is SchWizardTower) > 1) && magicLvl > 1)
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new SchWizardTower(buildingGen.GetNamedName("Tower"), owner, poiTier));
                }
                else if (diceRoll > 10 && !(pointsOfInterest.Count(poi => poi is SchAcademy) > 0))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Academy";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new SchAcademy(building_name, owner, poiTier, personGen));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is SchScriptorium) > 0))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Scriptorium";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new SchScriptorium(building_name, owner, poiTier, personGen));
                }
            }
            //Rel
            else if (diceRoll > 15)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 50 && !(pointsOfInterest.Count(poi => poi is RelShrine) > 5))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new RelShrine(buildingGen.GetNamedName("Shrine"), owner, poiTier));
                }
                else if (diceRoll > 25 && !(pointsOfInterest.Count(poi => poi is RelCemetary) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new RelCemetary(buildingGen.GetNamedName("Cemetary"), owner, poiTier));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is RelTemple) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    pointsOfInterest.Add(new RelTemple(buildingGen.GetNamedName("Temple"), owner, poiTier, personGen));
                }
            }
            //Gov
            else if (diceRoll > 5)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 50 && !(pointsOfInterest.Count(poi => poi is GovBarracks) > 2))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Barracks, {owner.GetLastName()} Division";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new GovBarracks(building_name, owner, poiTier, personGen));
                }
                else if (diceRoll > 30 && !(pointsOfInterest.Count(poi => poi is GovCourthouse) > 0))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Courthouse";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new GovCourthouse(building_name, owner, poiTier, personGen));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is GovJail) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()} Jail";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new GovJail(building_name, owner, poiTier, personGen));
                }
            }
            //Und
            else if (diceRoll > 0)
            {
                diceRoll = random.Next(100);
                if (diceRoll > 75 && !(pointsOfInterest.Count(poi => poi is UndBrothel) > 1))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()}'s Tavern";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new UndBrothel(building_name, owner, poiTier, personGen));
                }
                else if (diceRoll > 60 && !(pointsOfInterest.Count(poi => poi is UndGamblingDen) > 0))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName}'s Casino";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new UndGamblingDen(building_name, owner, poiTier, personGen));
                }
                else if (diceRoll > 50 && !(pointsOfInterest.Count(poi => poi is UndFighting) > 0))
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{owner.GetLastName()}'s Entertainment";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new UndFighting(building_name, owner, poiTier, personGen));
                }
                else if (diceRoll > 0 && !(pointsOfInterest.Count(poi => poi is UndThievesGuild) > 0) && guilds)
                {
                    Person owner = personGen.GenRandomPerson();
                    string building_name = $"{name} Thieves Guild";
                    buildingGen.AddCustomName(building_name);
                    pointsOfInterest.Add(new UndThievesGuild(building_name, owner, poiTier));
                }
            }
        }
    }

}