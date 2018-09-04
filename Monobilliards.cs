using System;
using System.Collections.Generic;

namespace Monobilliards
{
    public class Monobilliards : IMonobilliards
    {
        public bool IsCheater(IList<int> inspectedBalls)
        {
            var pocket = new Stack<int>();
            var max = 0;
            foreach (var ball in inspectedBalls)
            {
                var topBall = pocket.Count > 0 ? pocket.Peek() : 0; // подсмотрели шар
                if (topBall < ball) // видим шар меньший - считаем, что были забиты шары
                    for (var i = max + 1; i < ball; ++i)
                        pocket.Push(i);
                else if (topBall == ball) // Просто правильный шар из лузы.
                    pocket.Pop();
                else // а вот тут что-то не срослось. плутовство налицо!
                    return true;
                if (max < ball)
                    max = ball;
            }
            return false;
        }
    }
}
