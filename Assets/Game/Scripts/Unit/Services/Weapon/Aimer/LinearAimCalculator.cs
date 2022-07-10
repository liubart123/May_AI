using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearAimCalculator : MonoBehaviour
{
    public struct AimCalcResult
    {
        public Vector2 aim;
        public bool isAvailableForHitting;
    }
    public static AimCalcResult CalculateAim(Vector2 sourcePos, Rigidbody2D target, float velocity)
    {
        var result = new AimCalcResult();
        result.isAvailableForHitting = true;
        /*
        x0 - start position
        vx - velocity x projection
        v - velocity absolute
        t - time until the hit
        x_, v_, x0_ ... - vars for target
        x, v, x0 ... - vars for bullet
        dx = x0-x0_
        */
        float x0, y0, x0_, y0_;
        float vx, vy, vx_, vy_;
        float dx, dy;

        x0 = sourcePos.x;
        y0 = sourcePos.y;
        x0_ = target.gameObject.transform.position.x;
        y0_ = target.gameObject.transform.position.y;
        vx_ = target.velocity.x;
        vy_ = target.velocity.y;
        dx = x0 - x0_;
        dy = y0 - y0_;

        if (dx == 0)
        {
            vx = vx_;
            vy = -Mathf.Sqrt(velocity * velocity - vx * vx) * Mathf.Sign(dy);
        } 
        else if (dy == 0)
        {
            vy = vy_;
            vx = -Mathf.Sqrt(velocity * velocity - vy * vy) * Mathf.Sign(dx);
        }
        //Square equation
        else
        {
            float C = dy / dx;
            float B = C * vx_ - vy_;

            float a = -C * C - 1;
            float b = 2 * B * C;
            float c = -B * B + velocity * velocity;

            float D = b * b - 4 * a * c;


            if (D < 0)
            {
                result.isAvailableForHitting = false;
                vx = 0;
                vy = 0;
            }
            else if (D == 0)
            {
                vx = -b / (2 * a);
                vy = Mathf.Sqrt(velocity * velocity - vx * vx);
                result.aim = new Vector2(vx, vy);
            }
            else
            {
                float sqrD = Mathf.Sqrt(D);

                vx = (-b + sqrD) / (2 * a);
                if (Mathf.Sign(dx) * Mathf.Sign(vx_ - vx) < 0)
                {
                    vx = (-b - sqrD) / (2 * a);
                }
                vy = Mathf.Sqrt(velocity * velocity - vx * vx);
                if (Mathf.Sign(dy) * Mathf.Sign(vy_ - vy) < 0)
                {
                    vy = -vy;
                }

            }
        }


        result.aim = new Vector2(vx, vy);
        return result;



    }
}
