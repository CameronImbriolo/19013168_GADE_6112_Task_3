using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_1_CameronImbriolo_19013168
{
    [Serializable]
    //Q.2.7 Implementing ond overriding abstract classes
    class FactoryBuilding : Building
    {
        private UnitType unitType;
        private int productionSpeed;
        private int spawnX;
        private int spawnY;
        private int speedCounter;

        //Q.2.9 Creating the appropriate properties 
        public int ProductionSpeed
        {
            get { return productionSpeed; }
        }
        public int SpeedCounter
        {
            get { return speedCounter; }
            set { speedCounter = value; }
        }
        public int XPos
        {
            get { return base.xPos; }
            set { base.xPos = value; setSpawnX(); }
        }
        public int YPos
        {
            get { return base.yPos; }
            set { base.yPos = value; setSpawnY(); }
        }
        public int Health
        {
            get { return base.health; }
            set { base.health = value; }
        }
        public int MaxHealth
        {
            get { return base.maxHealth; }
        }
        public Faction UnitFaction
        {
            get { return base.faction; }
            set { base.faction = value; }
        }
        public string Symbol
        {
            get { return base.symbol; }
        }

        //Constructor
        public FactoryBuilding(UnitType unitType, int health, Faction unitFaction)
        {
            this.unitType = unitType;
            base.maxHealth = health;
            UnitFaction = unitFaction;
            Health = MaxHealth;
            if (unitFaction == Faction.Blue)
                base.symbol = "Bf";
            else
                base.symbol = "Rf";
            productionSpeed = 5;
        }

        //Q.2.8 Method that spawns units
        public Unit SpawnUnit()
        {
            Unit result = null;
            if (unitType == UnitType.Melee)
            {
                if (base.faction == Faction.Red)
                    result = new MeleeUnit("Bezerker", 20, Faction.Red, spawnX, spawnY);
                else if(base.faction == Faction.Blue)
                    result = new MeleeUnit("Knight", 20, Faction.Blue, spawnX, spawnY);
            }
            else if (unitType == UnitType.Ranged)
            {
                if (base.faction == Faction.Red)
                    result = new RangedUnit("Archer", 20, Faction.Red, 5, spawnX, spawnY);
                else if (base.faction == Faction.Blue)
                    result = new RangedUnit("Crossbowman", 20, Faction.Blue, 5, spawnX, spawnY);
            }
            return result;
        }

        private void setSpawnX()
        {
            spawnX = XPos;
        }

        private void setSpawnY()
        {
            if(YPos >= 20)
            {
                spawnY = YPos - 1;
            }
            else
            {
                spawnY = YPos + 1;
            }
        }

        public override bool IsDead()
        {
            if (Health <= 0)
                return true;
            return false;
        }

        public override void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public override string ToString()
        {
            return String.Format("{0}: Health = {1}. {2} Team. Production Speed: {3}\n", unitType, health, UnitFaction.ToString(), productionSpeed);
        }
    }
}
