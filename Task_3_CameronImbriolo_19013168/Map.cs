using System;
using System.Collections.Generic;

namespace Task_1_CameronImbriolo_19013168
{
    public enum UnitType
    {
        Melee,
        Ranged
    }

    //Q.1.7
    class Map
    {
        private List<ResourceBuilding> redTeamRes = new List<ResourceBuilding>();
        private List<ResourceBuilding> blueTeamRes = new List<ResourceBuilding>();
        private List<FactoryBuilding> redTeamFac = new List<FactoryBuilding>();
        private List<FactoryBuilding> blueTeamFac = new List<FactoryBuilding>();
        private static List<Unit> allUnits = new List<Unit>();
        private static List<ResourceBuilding> allResource = new List<ResourceBuilding>();
        private static List<FactoryBuilding> allFactory = new List<FactoryBuilding>();
        private Random r = new Random();
        private int amount;

        private static int X = 20;

        public int mX
        {
            get { return X; }
        }

        private static int Y = 20;

        public int mY
        {
            get { return Y; }
        }
        private static string[,] mapArr = new string[X, Y];

        //Constructer for the map (Allows for maximum 40 total units)
        public Map(int amount)
        {
            if (amount <= 20)
                this.amount = amount;
            else
                this.amount = 20;
        }

        //Populates the map array with the correct symbols
        public void Populate()
        {
            Array.Clear(mapArr, 0, mapArr.Length);
            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    foreach(Unit u in allUnits)
                    {
                        if (u.xPos == x && u.yPos == y)
                            mapArr[x, y] = u.symbol;
                    }
                    foreach (FactoryBuilding b in allFactory)
                    {
                        if (b.XPos == x && b.YPos == y)
                            mapArr[x, y] = b.Symbol;
                    }
                    foreach (ResourceBuilding b in allResource)
                    {
                        if (b.XPos == x && b.YPos == y)
                            mapArr[x, y] = b.Symbol;
                    }
                }
            }
        }

        //Updates the position of all the symbols by populating an array
        public void UpdatePos(List<Unit> units, List<FactoryBuilding> facBuildings, List<ResourceBuilding> resBuildings)
        {
            allUnits = units;
            allFactory = facBuildings;
            allResource = resBuildings;
            Populate();
        }

        //Allows other classes to retrieve the current map array
        public string[,] getMap()
        {
            return mapArr;
        }

        //Generates the initial buildings and their placement on the map
        public List<ResourceBuilding> GenerateResourceBuildings()
        {
            for (int i = 0; i < amount/2; i++)
            {
                ResourceBuilding resourceR = new ResourceBuilding("Minerals", 20, Faction.Red);
                redTeamRes.Add(resourceR);
                ResourceBuilding resourceB = new ResourceBuilding("Minerals", 20, Faction.Blue);
                blueTeamRes.Add(resourceB);
            }
            foreach (ResourceBuilding b in redTeamRes)
            {
                b.XPos = r.Next(0, 11);
                b.YPos = r.Next(0, 21);
                allResource.Add(b);
            }
            foreach (ResourceBuilding b in blueTeamRes)
            {
                b.XPos = r.Next(10, 21);
                b.YPos = r.Next(0, 21);
                allResource.Add(b);
            }


            return allResource;
        }
        public List<FactoryBuilding> GenerateFactoryBuildings()
        {
            for (int i = 0; i < amount / 2; i++)
            {
                FactoryBuilding factoryR = new FactoryBuilding((UnitType)r.Next(0, 2), 20, Faction.Red);
                redTeamFac.Add(factoryR);
                FactoryBuilding factoryB = new FactoryBuilding((UnitType)r.Next(0, 2), 20, Faction.Blue);
                blueTeamFac.Add(factoryB);
            }
            foreach (FactoryBuilding b in redTeamFac)
            {
                b.XPos = r.Next(0, 11);
                b.YPos = r.Next(0, 21);
                allFactory.Add(b);
            }
            foreach (FactoryBuilding b in blueTeamFac)
            {
                b.XPos = r.Next(10, 21);
                b.YPos = r.Next(0, 21);
                allFactory.Add(b);
            }


            return allFactory;
        }
    }
}

//for(int i = 0; i < amount; i++)
//{
//    UnitType type = (UnitType)r.Next(0, 2);
//    switch (type)
//    {
//        case UnitType.Melee:
//            MeleeUnit meleeR = new MeleeUnit("Bezerker", 20, Faction.Red);
//            redTeam.Add(meleeR);
//            MeleeUnit meleeB = new MeleeUnit("Knight", 20, Faction.Blue);
//            blueTeam.Add(meleeB);
//            break;
//        case UnitType.Ranged:
//            RangedUnit resourceR = new RangedUnit("Archer", 20, Faction.Red, 5);
//            redTeam.Add(resourceR);
//            RangedUnit resourceB = new RangedUnit("Crossbowman", 20, Faction.Blue, 5);
//            blueTeam.Add(resourceB);
//            break;
//        default:
//            break;
//    }
//}
