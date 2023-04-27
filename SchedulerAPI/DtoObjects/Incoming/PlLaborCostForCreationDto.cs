namespace ProjectManagerAPI.DtoObjects.Incoming
{
    public class PlLaborCostForCreationDto
    {
        public int? Scenarioid { get; set; }

        public int? Laborcostid { get; set; }

        public int? Factid { get; set; }

        public DateOnly? Plannedlaborcostfilldate { get; set; }

        public decimal? Plannedlaborcostpercent { get; set; }

        public int? Projectid { get; set; }

        public int? Userid { get; set; }
    }
}
