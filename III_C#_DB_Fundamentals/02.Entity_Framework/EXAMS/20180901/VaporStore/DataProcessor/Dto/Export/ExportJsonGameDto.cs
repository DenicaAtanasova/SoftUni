namespace VaporStore.DataProcessor.Dto.Export
{
    using Newtonsoft.Json;

    public class ExportJsonGameDto
    {
        public int Id { get; set; }

        [JsonProperty("Title")]
        public string Name { get; set; }

        public string Developer { get; set; }

        public string Tags { get; set; }

        public int Players { get; set; }
    }
}