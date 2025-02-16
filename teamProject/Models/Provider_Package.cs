using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teamProject.Models
{
    [PrimaryKey(nameof (Package_Id), nameof(provider_Id))]
    public class Provider_Package
    {


        //nav
        public virtual myServiceProvider ServiceProvider { get; set; }

        [ForeignKey(nameof(ServiceProvider))]
        public int provider_Id {  get; set; }

        //nav
        public virtual package Package { get; set; }

        [ForeignKey(nameof(Package))]
        public int Package_Id { get; set; }


    }
}
