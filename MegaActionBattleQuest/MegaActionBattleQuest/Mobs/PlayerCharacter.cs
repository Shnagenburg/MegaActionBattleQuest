using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MegaActionBattleQuest.Mobs
{
    class PlayerCharacter : BaseMob
    {
        int experience;

        int xpos, ypos;          //the location in tiles (xpos = column, ypos= row)
        public Vector2 location; //the location in pixels

        Levels.Level environment;

        float timeSinceLastMove = 0;
        float movingTime = (1/24f);
        //float movingTime = (0);
        public PlayerCharacter(ContentManager myContent, SpriteBatch spriteBatch, int x, int y, Levels.Level currentLevel)
        {
            isMoving = false;
            environment = currentLevel;
            xpos = x;
            ypos = y;
            location = setlocation();
            sprite = new Sprite("playercharacter", true, location, myContent, spriteBatch);

            moveSpeed = ((float)environment.tileSize) / 24f; 
        }

        public void update(float elapsedSeconds)
        {
            if (!isMoving)
            {
                location = setlocation();
            }
            else
            {
                timeSinceLastMove += elapsedSeconds;
                if (timeSinceLastMove >= movingTime)
                {
                    switch (moveDirection)
                    {
                        case MovementDirections.Down:
                            location.Y += moveSpeed;
                            if (location.Y >= environment.gameBorder + ypos * environment.tileSize)
                            {
                                isMoving = false;
                                sprite.setAnimation(false,MovementDirections.Down);
                            }
                            break;
                        case MovementDirections.Left:
                            location.X -= moveSpeed;
                            if (location.X <= environment.gameBorder + xpos * environment.tileSize)
                            {
                                isMoving = false;
                                sprite.setAnimation(false, MovementDirections.Left);
                            }
                            break;
                        case MovementDirections.Right:
                            location.X += moveSpeed;
                            if (location.X >= environment.gameBorder + xpos * environment.tileSize)
                            {
                                isMoving = false;
                                sprite.setAnimation(false, MovementDirections.Right);
                            }
                            break;
                        case MovementDirections.Up:
                            location.Y -= moveSpeed;
                            if (location.Y <= environment.gameBorder + ypos * environment.tileSize)
                            {
                                isMoving = false;
                                sprite.setAnimation(false,MovementDirections.Up);
                            }
                            break;
                    }
                   timeSinceLastMove = 0;                   
                }
            }
            sprite.update(elapsedSeconds, location);
        }

        public void move(MovementDirections myDirection)
        {
            if (canMove(myDirection))
            {
                isMoving = true;
                moveDirection = myDirection;
                sprite.setAnimation(true);

                switch (myDirection)
                {
                    case MovementDirections.Down:
                        ypos++;
                        break;
                    case MovementDirections.Left:
                        xpos--;
                        break;
                    case MovementDirections.Right:
                        xpos++;
                        break;
                    case MovementDirections.Up:
                        ypos--;
                        break;
                }
            }
        }

        bool canMove(MovementDirections myDirection)
        {
            return true;
        }

        Vector2 setlocation()
        {
            return new Vector2(environment.gameBorder + xpos * environment.tileSize, environment.gameBorder + ypos * environment.tileSize);
        }
    }
}
