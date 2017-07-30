namespace Nightfall.Datastore.Dto
{
    class ChampionRow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CourageExpression { get; set; }
        public string FortitudeExpression { get; set; }
        public string Color { get; set; }
        public int XpCount { get; set; }
        public int NativeZoneId { get; set; }
        public int CoordinateId { get; set; }

        public Champion ToDomain()
        {
            return new Champion(Id, Name, CourageExpression, FortitudeExpression, Color, XpCount, NativeZoneId, CoordinateId);
        }
    }
}
