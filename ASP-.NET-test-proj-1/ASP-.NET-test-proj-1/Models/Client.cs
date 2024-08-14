using SQLitePCL;
using System.ComponentModel.DataAnnotations;

namespace ASP_.NET_test_proj_1.Models
{
    public class Client
    {
        [Key]
        public int ID { get; private set; }
        public UserAccount Account { get; set; }
    }
}
