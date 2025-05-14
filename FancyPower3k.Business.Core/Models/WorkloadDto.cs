namespace FancyPower3k.Business.Core.Models
{
    public class WorkloadDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double CurrentWorkloadInKW { get; set; }

        public double MaxWorkloadInKW { get; set; }
    }
}
