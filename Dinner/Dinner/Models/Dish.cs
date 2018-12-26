using SQLite;

namespace Dinner.Models
{
    public class Dish
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsMeat { get; set; }
        public string Notes { get; set; }


    }
}
