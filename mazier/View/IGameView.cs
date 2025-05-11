using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazier.View
{
    public interface IGameView
    {
        void UpdatePlayerPosition(Point newPosition);
        void ShowJumpScare();
        void ShowWinScreen();
        void HideGameObjects();
        PictureBox GetPlayerSprite();
    }
}
