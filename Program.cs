﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C20_Ex02
{
    class Program
    {
        public static void Main()
        {
            GameSettingsForm gameSettings = new GameSettingsForm();
            gameSettings.ShowDialog();
            GameManager gameManager = new GameManager(ref gameSettings);
        }
    }
}
