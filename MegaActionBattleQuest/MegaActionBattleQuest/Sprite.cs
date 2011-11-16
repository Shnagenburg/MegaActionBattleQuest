using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MegaActionBattleQuest
{

    enum SpriteSheetRowIDs { PlayerCharacter, Enemy1, Enemy2, Enemy3, Enemy4, Tiles1, Tiles2, Items, Objects, Misc }
    enum AnimatedSpriteMovementIDs { Down0, Down1, Down2, Left0, Left1, Left2, Up0, Up1, Up2, Right0, Right1, Right2 };

    class Sprite
    {

        bool isAnimated;
        Rectangle sourceRect;
        Rectangle[] animationArray;

        //this needs to be totally rewritten, just braindumping an example of what it could look like:
        public Sprite(bool IsAnimated, SpriteSheetRowIDs thisID)
        {
            if(IsAnimated)
            {
                isAnimated=true;
                animationArray = setAnimationArray(thisID);
                sourceRect = animationArray[1];
            }
            else
            {
                sourceRect = setSourceRect(thisID);
            }
            
        }


        public void draw(float elapsedSeconds)
        {

        }

        public Rectangle setSourceRect(SpriteSheetRowIDs thisID)
        {
            Rectangle myRect=new Rectangle();



            return myRect;
        }

        public Rectangle[] setAnimationArray(SpriteSheetRowIDs thisID)  
        {
            Rectangle[] myAnimationArray = new Rectangle[3]; 

            return myAnimationArray;
        }



    }
}
