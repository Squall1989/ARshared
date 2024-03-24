
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ulf
{
    public static class MathUtils
    {
        private const float latitudeMultiple = 111.320f;
        private const float earthRadius = 40075f;
        public static Vector2 FromLatLong(float latitude, float longitude)
        {
            var longLenght = earthRadius * Mathf.Cos(latitude) / 360f;
            var lat = latitudeMultiple * latitude;
            var lon = longLenght * longitude;
            return new Vector2(lat, lon);
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