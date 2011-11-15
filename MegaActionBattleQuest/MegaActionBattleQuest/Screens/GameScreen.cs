using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MegaActionBattleQuest.Screens
{
    class GameScreen : Screen
    {

        Levels.Level currentLevel;

        IList<Mobs.BaseMob> existingMobs; 

        public void Update(float elapsedTime)
        {
            currentLevel.Update(elapsedTime);

        }

        public void Draw(float elapsedTime)
        {
            //draw the tilemap
            currentLevel.Draw(elapsedTime);

            //draw the objects
            //draw the player
            foreach (Mobs.BaseMob thisMob in existingMobs)
            {
                thisMob.draw(elapsedTime);
            }
            //draw the enemies
            //draw effects?


        }

    }
}
