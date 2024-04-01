namespace ManagementStudentWithNHibernate.Models
{
    public class Enrollment
    {
        public virtual int Id { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual double ProzessGrade { get; set; }
        public virtual double ComponentGrade { get; set; }

        public virtual double finalGrade => (double)((ProzessGrade + ComponentGrade) / 2.0);
        public virtual bool isPassed => finalGrade >= 4.0;
    }
}
