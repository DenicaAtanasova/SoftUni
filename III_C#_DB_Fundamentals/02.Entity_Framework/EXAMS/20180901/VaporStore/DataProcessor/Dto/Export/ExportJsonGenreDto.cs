namespace VaporStore.DataProcessor.Dto.Export
{
    using Newtonsoft.Json;

    public class ExportJsonGenreDto
    {
        public int Id { get; set; }

        [JsonProperty("Genre")]
        public string Name { get; set; }

        public ExportJsonGameDto[] Games { get; set; }

        public int TotalPlayers { get; set; }
    }
}