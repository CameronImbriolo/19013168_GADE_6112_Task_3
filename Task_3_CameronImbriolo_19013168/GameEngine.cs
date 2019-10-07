using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1_CameronImbriolo_19013168
{
    //Q.1.8
    class GameEngine
    {
        private List<Unit> units = new List<Unit>();
        private List<ResourceBuilding> resourceBuildings = new List<ResourceBuilding>();
        private List<FactoryBuilding> factoryBuildings = new List<FactoryBuilding>();
        private int gameRound;
        private int redResCount = 0;
        private int blueResCount = 0;
        private static int Unit_Num = 10;
        private Map map = new Map(Unit_Num);
        private int speedCounter = 0;

        public Map MyMap
        {
            get { return map; }
        }

        public int GameRound
        {
            get { return gameRound; }
            set { gameRound = value; }
        }

        //Main game logic
        public void Run()
        {
            List<Unit> tempUnits = new List<Unit>();
            tempUnits = units;

            foreach (Unit u in units.ToList())
            {
                if (u.IsDead())
                {
                    tempUnits.Remove(u);
                }
                else if (u.InRange(u.ClosestEnemy(units)) && u.health > u.maxHealth/4)
                    u.Attack(u.ClosestEnemy(units));
                else if (u.InRange(u.ClosestEnemy(resourceBuildings)) && u.health > u.maxHealth / 4)
                    u.Attack(u.ClosestEnemy(resourceBuildings));
                else
                    u.Move(units, resourceBuildings);
            }
            BuildingLogic();
            units = tempUnits;
            GameRound++;
            map.UpdatePos(units, factoryBuildings, resourceBuildings);
        }

        //Collects info to be displayed on the form
        public string GameInfo()
        {
            string result = null;
            foreach (Unit u in units)
                result += u.ToString();
            foreach (FactoryBuilding b in factoryBuildings)
                result += b.ToString();
            foreach (ResourceBuilding b in resourceBuildings)
                result += b.ToString();
            return result;
        }

        //Displays Resources Gathered of Each Faction
        public string ResourceInfo()
        {
            foreach(ResourceBuilding b in resourceBuildings)
            {
                if (b.UnitFaction == Faction.Red)
                {
                    redResCount += b.GenPerRound;
                }
                else if(b.UnitFaction == Faction.Blue)
                {
                    blueResCount += b.GenPerRound;
                }
            }
            return String.Format("Red Resources = {0} |||||| Blue Resources = {1}", redResCount, blueResCount);
        }

        //Handles the logic of buildings
        private void BuildingLogic()
        {
            List<ResourceBuilding> tempResBuildings = new List<ResourceBuilding>();
            tempResBuildings = resourceBuildings;
            List<FactoryBuilding> tempFacBuildings = new List<FactoryBuilding>();
            tempFacBuildings = factoryBuildings;
            foreach (ResourceBuilding b in resourceBuildings.ToList())
            {
                if (b.IsDead())
                {
                    tempResBuildings.Remove(b);
                }
                else
                    b.GenerateResources();
            }
            resourceBuildings = tempResBuildings;
            foreach (FactoryBuilding b in factoryBuildings.ToList())
            {
                if (b.IsDead())
                {
                    tempFacBuildings.Remove(b);
                }
                else
                {
                    b.SpeedCounter++;
                    if (b.SpeedCounter == b.ProductionSpeed)
                    {
                        b.SpeedCounter = 0;
                        if (b.UnitFaction == Faction.Red && redResCount >= 1000)
                        {
                            redResCount -= 1000;
                            units.Add(b.SpawnUnit());
                        }
                        else if (b.UnitFaction == Faction.Blue && blueResCount >= 1000)
                        {
                            blueResCount -= 1000;
                            units.Add(b.SpawnUnit());
                        }
                    }
                }
                    
            }
            factoryBuildings = tempFacBuildings;
        }

        //initialises the present units on the map
        public void Initialise()
        {
            units.Clear();
            resourceBuildings.Clear();
            factoryBuildings.Clear();
            resourceBuildings = map.GenerateResourceBuildings();
            factoryBuildings = map.GenerateFactoryBuildings();
        }

        //Q.2.11 Save method
        public void Save()
        {
            UnitFile();
            ResourceFile();
            FactoryFile();
        }

        //Q.2.12 Load method
        public void Load()
        {
            units.Clear();
            resourceBuildings.Clear();
            factoryBuildings.Clear();

            UnitRead();
            ResourceRead();
            FactoryRead();
        }

        private void UnitRead()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("unit.dat", FileMode.Open, FileAccess.Read, FileShare.None);

            try
            {
                using (fs)
                {
                    units = (List<Unit>)bf.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ResourceRead()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("resource.dat", FileMode.Open, FileAccess.Read, FileShare.None);

            try
            {
                using (fs)
                {
                    resourceBuildings = (List<ResourceBuilding>)bf.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void FactoryRead()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("factory.dat", FileMode.Open, FileAccess.Read, FileShare.None);

            try
            {
                using (fs)
                {
                    factoryBuildings = (List<FactoryBuilding>)bf.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void UnitFile()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("unit.dat", FileMode.Create, FileAccess.Write, FileShare.None);

            try
            {
                using (fs)
                {
                    bf.Serialize(fs, units);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ResourceFile()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("resource.dat", FileMode.Create, FileAccess.Write, FileShare.None);

            try
            {
                using (fs)
                {
                    bf.Serialize(fs, resourceBuildings);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void FactoryFile()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("factory.dat", FileMode.Create, FileAccess.Write, FileShare.None);

            try
            {
                using (fs)
                {
                    bf.Serialize(fs, factoryBuildings);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
