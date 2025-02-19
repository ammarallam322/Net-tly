namespace teamProject.Models
{
    public class Branch
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Fax { get; set; }///???
        public string Mobile { get; set; }///???has more than one mobile number
        public string Phone { get; set; }///???has more than one phone number

        //f.k?? (user | employee)
        public int? Manager_Id { get; set; }

        //nav
        public virtual List<Governerate>Governerates { get; set; }


    }
}
