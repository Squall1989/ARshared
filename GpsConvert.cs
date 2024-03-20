using UnityEngine;

namespace ARshared
{
    public static class GpsConvert
    {
        private const float latitudeMultiple = 111320;
        private const float earthRadius = 40075;
        public static Vector3 FromLatLong(float latitude, float longitude, float height)
        {
            var longLenght = earthRadius * Mathf.Cos(latitude) / 360f;
            var lat = latitudeMultiple * latitude;
            var lon = longLenght * longitude;
            return new Vector3(lat, height, lon);
        }
    }
}