namespace SoftJail.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public class ImportDepartmentDto
    {
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }

        public ImportCellDto[] Cells { get; set; }
    }
}
