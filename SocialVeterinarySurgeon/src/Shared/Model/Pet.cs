namespace Model
{
    public class Pet : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public int OwnerId { get; set; }
        public Employee Owner { get; set; }
    }
}
