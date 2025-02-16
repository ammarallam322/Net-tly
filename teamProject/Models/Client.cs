namespace teamProject.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; } //?name is existed in user table

        public string Mobile { get; set; }///???has more than one mobile number
        public string Phone { get; set; }

        //f.k??
        public int User_Id { get; set; }
    }
}
