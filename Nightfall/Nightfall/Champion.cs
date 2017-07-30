using System;

namespace Nightfall
{
    public class Champion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Courage { get; set; }
        public string Fortitude { get; set; }
        public string Color { get; set; }
        public int XpCount { get; set; }
        public int NativeZoneId { get; set; }
        public int CoordinateId { get; set; }

        public Champion(int id, string name, string courage, string fortitude, string color, int xp, int nativeZoneId, int coordinateId)
        {
            Id = id;
            Name = name;
            Courage = courage;
            Fortitude = fortitude;
            Color = color;
            XpCount = xp;
            NativeZoneId = nativeZoneId;
            CoordinateId = coordinateId;
        }
    }
}
