using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher_Fight_Hallway
{
    public static class c1
    {
        public static int player1Fighter = 0;
        public static int player2Fighter = 0;
        public static int player1left;
        public static int player1top;
        public static int player2left;
        public static int player1right;
        public static int player2right;
        public static int p1Health = 1000, p2Health = 1000;
        public static int player1Y = 290;
        public static void jump()
        {
            //jump on W key
            while (player1top > (player1Y - 70))
            {
                var t = Task.Run(async delegate
                {
                    await Task.Delay(100);
                    return 42;
                });
                player1top = player1top - 10;
                t.Wait();
            }
            while (player1Y > player1top)
            {
                var t = Task.Run(async delegate
                {
                    await Task.Delay(10);
                    return 42;
                });
                player1top = player1top + 10;
                t.Wait();
            }
        }
        public static void punch()
        {
            //punch
            int p2y = fightStage.player2.Left;
            if ((player2left - player1right) <= 20)
            {
                var t = Task.Run(async delegate
                {
                    await Task.Delay(50);
                    return 42;
                });
                p2Health = p2Health - 50;
                while (player2left < (p2y + 40) & player2right <= 1032)
                {
                    player2left = player2left + 1;
                    t.Wait();
                }
            }
        }
    }
}
