namespace Institute.Web.Models
{
    public class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int IdProfessor { get; set; }

        public int Credits { get; set; }

        public DateTime day { get; set; }

        public DateTime StartSchedule { get; set; }
        public DateTime EndSchedule { get; set; }
    }
}
