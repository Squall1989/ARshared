
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ulf
{
    public static class MathUtils
    {
        private const double latitudeMultiple = 111.320d;
        private const double earthRadius = 40075d;
        public static GlobalPosition FromLatLong(float latitude, float longitude)
        {
            var longLenght = earthRadius * Math.Cos(latitude) / 360f;
            var lat = latitudeMultiple * latitude;
            var lon = longLenght * longitude;
            return new GlobalPosition(lat, lon);
        }
        public static float GetMinAngleDiff(float x, float y)
        {
            var diffs = new List<float>() {
                Math.Abs(x - y),
                Math.Abs(x - y - 360f),
                Math.Abs(x - y + 360f)
            };

            float min = diffs.Min();

            return min;


        }

        public static float NormalizeAngle(float angle)
        {
            if (angle < 0)
            {
                angle += 360f;
            }
            else if (angle >= 360f)
            {
                angle -= 360f;
            }

            return angle;
        }
    }
}