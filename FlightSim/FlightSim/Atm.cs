using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSim
{
    class Atm
    {
        double x, y, v0, cosaa, sinaa, S, m, k, vx, vy, a;
        const double C = 0.15;
        const double rho = 1.29;
        const double g = 9.81;

        public Atm(double y0, double v00, double angle, double size, double weight)
        {
            x = 0;
            y = y0;
            v0 = v00;
            a = angle * Math.PI / 180;
            cosaa = (double)Math.Cos(a);
            sinaa = (double)Math.Sin(a);
            S = size;
            m = weight;
            vx = v0 * cosaa;
            vy = v0 * sinaa;
            k = 0.5 * C * rho * S / m;
        }
        
        public Tuple<double,double> calculateXY(double dt)
        {
            double v = (double)Math.Sqrt((double)(vx * vx + vy * vy));
            vx = vx - k * vx * v * dt;
            vy = vy - (g + k * vy * v) * dt;
            x = x + vx * dt;
            y = y + vy * dt;
            return Tuple.Create(x, y);
        }   

        public bool isLanded()
        {
            if (y <= 0) return true;
            else return false;
        }
    }
}
