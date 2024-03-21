using UnityEngine;

namespace ARshared
{
    /// <summary>
    /// All calculations are in kilometers
    /// </summary>
    public static class GpsConvert
    {
        private const float latitudeMultiple = 111.320f;
        private const float earthRadius = 40075f;
        public static Vector3 FromLatLong(float latitude, float longitude, float height)
        {
            var longLenght = earthRadius * Mathf.Cos(latitude) / 360f;
            var lat = latitudeMultiple * latitude;
            var lon = longLenght * longitude;
            return new Vector3(lat, height, lon);
        }
    }
}