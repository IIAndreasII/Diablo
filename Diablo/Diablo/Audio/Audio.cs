using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media;

namespace Diablo.Audio
{
    public static class Audio
    {
        private static 
            SoundPlayer mySoundPlayer;

        private static Thread
            myConsoleMusicThread;

        private static string
            myCiricePath = "Audio\\Ghost-Cirice.wav",
            myOPNLPath = "Audio\\Behemoth-OPNL.wav";

        private static bool
            myIsMusicPlaying;

        private static ThreadStart
            myDoomThemeThreadStart = DoomTheme;

        public static void Init()
        {
            myIsMusicPlaying = true;
            myConsoleMusicThread = new Thread(DoomTheme);
            mySoundPlayer = new SoundPlayer();
            PlayOraProNobisLucifer();
        }

        public static void StopPlaying()
        {
            mySoundPlayer.Stop();
            myConsoleMusicThread.Abort();
        }

        public static bool GetIsMusicPlaying() => myIsMusicPlaying;

        public static void PlayCirice()
        {
            mySoundPlayer.Stop();
            myConsoleMusicThread.Abort();
            mySoundPlayer.SoundLocation = myCiricePath;
            mySoundPlayer.PlayLooping();
        }

        public static void PlayOraProNobisLucifer()
        {
            mySoundPlayer.Stop();
            myConsoleMusicThread.Abort();
            mySoundPlayer.SoundLocation = myOPNLPath;
            mySoundPlayer.PlayLooping();
        }

        public static void PlayDoomTheme()
        {
            mySoundPlayer.Stop();
            myConsoleMusicThread = new Thread(DoomTheme);
            myConsoleMusicThread.Start();
        }

        public static void ToggleMusic()
        {
            if (myIsMusicPlaying)
            {
                myIsMusicPlaying = false;
                StopPlaying();
            }
            else
            {
                myIsMusicPlaying = true;
                PlayOraProNobisLucifer();
            }
            
        }

        private static void DoomTheme()
        {
            mySoundPlayer.Stop();
            bool tempIsSecondLoop = false;
            int tempNoteDelay = 100;
            while (myIsMusicPlaying)
            {
                Console.Beep(330, 50); /// E
                Thread.Sleep(tempNoteDelay);

                Console.Beep(330, 50); /// E
                Thread.Sleep(tempNoteDelay);

                Console.Beep(659, 50); /// E^
                Thread.Sleep(tempNoteDelay);

                Console.Beep(330, 50); /// E
                Thread.Sleep(tempNoteDelay);

                Console.Beep(330, 50); /// E
                Thread.Sleep(tempNoteDelay);

                Console.Beep(587, 50); /// D^
                Thread.Sleep(tempNoteDelay);

                Console.Beep(330, 50); /// E
                Thread.Sleep(tempNoteDelay);

                Console.Beep(330, 50); /// E
                Thread.Sleep(tempNoteDelay);

                Console.Beep(523, 50); /// C^
                Thread.Sleep(tempNoteDelay);

                Console.Beep(330, 50); /// E
                Thread.Sleep(tempNoteDelay);

                Console.Beep(330, 50); /// E
                Thread.Sleep(tempNoteDelay);

                if (!tempIsSecondLoop)
                {
                    Console.Beep(466, 50); /// A#
                    Thread.Sleep(tempNoteDelay);

                    Console.Beep(330, 50); /// E
                    Thread.Sleep(tempNoteDelay);

                    Console.Beep(330, 50); /// E
                    Thread.Sleep(tempNoteDelay);

                    Console.Beep(494, 50); /// B
                    Thread.Sleep(tempNoteDelay);

                    Console.Beep(523, 50); /// C^
                    Thread.Sleep(tempNoteDelay);
                    tempIsSecondLoop = true;
                }
                else
                {
                    Console.Beep(466, 750); /// A#
                    Thread.Sleep(tempNoteDelay);

                    tempIsSecondLoop = false;
                }
            }
        }
    }
}
