using System;

namespace Nightfall
{
    public class Champion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Courage { get; set; }
        public int Fortitude { get; set; }
        public string Color { get; set; }
        public int XpCount { get; set; }
        public int NativeZoneId { get; set; }
        public int CoordinateId { get; set; }

        public Champion(int id, string name, int courage, int fortitude, string color, int xp, int nativeZoneId, int coordinateId)
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
