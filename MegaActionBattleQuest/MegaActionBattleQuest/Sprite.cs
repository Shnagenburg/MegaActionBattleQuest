using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MegaActionBattleQuest
{
    enum AnimatedSpriteMovementIDs { Down0, Down1, Down2, Left0, Left1, Left2, Up0, Up1, Up2, Right0, Right1, Right2 };
    enum MovementDirections { Down=2, Left=5, Up=8, Right=11 }

    class Sprite
    {
        ContentManager myContent;
        SpriteBatch spriteBatch;

        bool isAnimated;
        bool isAnimating;
        Rectangle sourceRect;
        Rectangle[] animationArray;
        Texture2D mytexture;
        int currentFrame;

        MovementDirections myDirection;

        Vector2 location;

        const int tileSize = 32;
        const int spriteSheetPadding = 1;

        const float timePerFrame = (1/2f);
        float animatingTime = 0;

        //this needs to be totally rewritten, just braindumping an example of what it could look like:
        public Sprite(string spritename, bool IsAnimated, Vector2 Location, ContentManager myContent, SpriteBatch spriteBatch)
        {
            mytexture = myContent.Load<Texture2D>(spritename);
            this.myContent = myContent;
            this.spriteBatch = spriteBatch;
            this.isAnimated = IsAnimated;
            location = Location;

            myDirection = MovementDirections.Down;

            sourceRect = new Rectangle((tileSize + spriteSheetPadding) * (int)myDirection, 0, tileSize, tileSize);

            if (isAnimated)
            {
                animationArray = getAnimationArray(myDirection);
            }     
        }

        public void draw(float elapsedSeconds)
        {            
            spriteBatch.Draw(mytexture, new Rectangle((int)location.X, (int)location.Y, tileSize, tileSize), sourceRect, Color.White);
        }

        public void update(float elapsedSeconds, Vector2 currentLocation)
        {
            
            if (isAnimating)
            {
                animatingTime += elapsedSeconds;
                if (animatingTime > timePerFrame)
                {
                    nextAnimationFrame();
                    sourceRect = animationArray[currentFrame];
                    animatingTime = 0;
                }
            }        
            location = currentLocation;
        }

        Rectangle[] getAnimationArray(MovementDirections myDirection)
        {
            Rectangle[] myRects = new Rectangle[2];

            int y = 0;
            int ctr = 0;
            for (int i = (int)myDirection-2; i < (int)myDirection; i++)
            {
                myRects[ctr] = new Rectangle( (tileSize + spriteSheetPadding) * i, y, tileSize, tileSize);
                ctr++;
            }

            return myRects;
        }


        public void setAnimation(bool isTrueOrFalse, MovementDirections myDirection = MovementDirections.Down)
        {
            
            isAnimating = isTrueOrFalse;
            currentFrame = 0;

            if (isTrueOrFalse)
            {
                animationArray = getAnimationArray(myDirection);
                sourceRect = animationArray[currentFrame];
                this.myDirection = myDirection;
            }
            else
            {
                sourceRect = new Rectangle((tileSize + spriteSheetPadding) * (int)myDirection, 0, tileSize, tileSize);
            }

        }

        void nextAnimationFrame()
        {
            if (currentFrame == 0) currentFrame = 1;
            else currentFrame = 0;
        }


    }
}
