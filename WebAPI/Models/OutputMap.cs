namespace WebAPI.Models
{
    public class OutputMap
    {
        public int Id { get; set; }

        public string Operation { get; set; }

        public Dictionary<Int64, Int64> Map { get; set; }
    }
}
