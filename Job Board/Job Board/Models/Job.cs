namespace Job_Board.Models
{
    public class Job
    {

        public int JobId { get; set; }
        public int EmployerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime PostedAt { get; set; }
        public virtual User Employer { get; set; }
    }
}
