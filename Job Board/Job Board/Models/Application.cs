namespace Job_Board.Models
{
    public class Application
    {

        public int ApplicationId { get; set; }
        public int JobId { get; set; }
        public int CandidateId { get; set; }
        public string ResumePath { get; set; }
        public DateTime AppliedAt { get; set; }
        public virtual Job Job { get; set; }
        public virtual User Candidate { get; set; }
    }
}
