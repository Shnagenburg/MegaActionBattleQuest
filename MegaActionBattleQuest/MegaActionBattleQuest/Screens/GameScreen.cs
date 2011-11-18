using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MegaActionBattleQuest.Screens
{
    class GameScreen : Screen
    {
        const int gameBorder = 8;

        Levels.Level currentLevel;

        IList<Mobs.BaseMob> existingMobs;

        Mobs.PlayerCharacter thePlayer;

        public GameScreen(SpriteBatch spriteBatch, ContentManager myContent)
        {
            currentLevel = new Levels.Level(spriteBatch, myContent, gameBorder);
            existingMobs = new List<Mobs.BaseMob>();
            thePlayer = new Mobs.PlayerCharacter(myContent, spriteBatch, 0,0, currentLevel);
        }


        public void Update(float elapsedTime)
        {

            currentLevel.Update(elapsedTime);
            thePlayer.update(elapsedTime);
        }

        public void Draw(float elapsedTime)
        {
            //draw the tilemap
            currentLevel.Draw(elapsedTime);

            //draw the objects
            //draw the player
            thePlayer.draw(elapsedTime);

            //draw the enemies
            foreach (Mobs.BaseMob thisMob in existingMobs)
            {
                thisMob.draw(elapsedTime);
            }
            
            //draw effects?


        }


        public void ProcessInput(KeyboardState currentKeyState, KeyboardState lastKeyState)
        {
            if (!thePlayer.isMoving)
            {
                if (currentKeyState.IsKeyDown(Keys.Left) && lastKeyState.IsKeyUp(Keys.Left))
                {
                    thePlayer.move(MovementDirections.Left);
                }
                else if (currentKeyState.IsKeyDown(Keys.Right) && lastKeyState.IsKeyUp(Keys.Right))
                {
                    thePlayer.move(MovementDirections.Right);
                }
                else if (currentKeyState.IsKeyDown(Keys.Down) && lastKeyState.IsKeyUp(Keys.Down))
                {
                    thePlayer.move(MovementDirections.Down);
                }
                else if (currentKeyState.IsKeyDown(Keys.Up) && lastKeyState.IsKeyUp(Keys.Up))
                {
                    thePlayer.move(MovementDirections.Up);
                }
            }
        }

    }
}
