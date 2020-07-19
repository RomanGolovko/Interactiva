namespace Model
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool MediaInteractivaEmployee { get; set; }

        public Pet Pet { get; set; }
    }
}
