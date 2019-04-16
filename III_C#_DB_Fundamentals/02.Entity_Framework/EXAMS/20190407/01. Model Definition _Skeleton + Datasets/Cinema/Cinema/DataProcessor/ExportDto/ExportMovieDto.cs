﻿using Newtonsoft.Json;

namespace Cinema.DataProcessor.ExportDto
{
    public class ExportMovieDto
    {
        [JsonProperty("MovieName")]
        public string Title { get; set; }

        public string Rating { get; set; }

        public string TotalIncomes { get; set; }

        public ExportCustomerDto[] Customers { get; set; }
    }
}
