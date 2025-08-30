namespace Housing_Society.DTOs
{
    public class HouseRequestDto
    {
        public string name { get; set; } = null!;
        public string city { get; set; } = null!;
        public string state { get; set; } = null!;
        public int availableUnits { get; set; } = 0!;
        public string wifi { get; set; } = null!;
        public string laundry { get; set; } = null!;
        public string description { get; set; } = null!;
        public List<IFormFile> photo { get; set; } = new List<IFormFile>();
    }

    public class HouseResponseDto
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
    }
    public class HouseDto
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string city { get; set; } = null!;
        public string state { get; set; } = null!;
        public int availableUnits { get; set; } = 0!;
        public string wifi { get; set; } = null!;
        public string laundry { get; set; } = null!;
        public string description { get; set; } = null!;
        public List<string> photo { get; set; } = new List<string>();


    }
}