using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_1_CameronImbriolo_19013168
{
    [Serializable]
    //Q.2.5 Implementing ond overriding abstract classes
    class ResourceBuilding : Building
    {
        private string resourceType;
        private int resourcesGenerated = 0;
        private int genPerRound = 5;
        private int resourcesRemaining = 1200;

        //Q.2.9 Creating the appropriate properties 
        public int XPos
        {
            get { return base.xPos; }
            set { base.xPos = value; }
        }
        public int YPos
        {
            get { return base.yPos; }
            set { base.yPos = value; }
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

        public int GenPerRound
        {
            get { return genPerRound; }
        }

        //Constructor
        public ResourceBuilding(string resourceType, int health, Faction unitFaction)
        {
            this.resourceType = resourceType;
            base.maxHealth = health;
            Health = MaxHealth;
            UnitFaction = unitFaction;
            if (unitFaction == Faction.Blue)
                base.symbol = "Br";
            else
                base.symbol = "Rr";
            }


        //Q.2.6 Resource generation
        public void GenerateResources()
        {
            if (resourcesRemaining >= genPerRound)
            {
                resourcesGenerated += genPerRound;
                resourcesRemaining -= genPerRound;
            }
            else if (resourcesRemaining >= 0)
            {
                resourcesGenerated += resourcesRemaining;
                resourcesRemaining = 0;
            }
        }

        public override bool IsDead()
        {
            if (Health <= 0)
                return true;
            return false;
        }

        public override string ToString()
        {
            return String.Format("{0}: Health = {1}. {2} Team. Resources Remaining: {3}. Resources Generated: {4}\n", resourceType, health, UnitFaction.ToString(), resourcesRemaining, resourcesGenerated);
        }

        public override void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }
}
