using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gallows2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// ...
        /// Requirements:
        ///  * use MVP pattern for Forms
        ///  * graphical display
        ///  * Import words from file
        ///    - xml, txt and DB
        ///  * User interaction to start new game
        ///  * handle keyboard input
        ///  * display word
        ///  * display letters used
        ///  * draw gallows
        ///  * animate letters
        ///  * use delegates to activate method to draw part of gallow. F.e. the head has to be a circle in stead of a rectangle

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
