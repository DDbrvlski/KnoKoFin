using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Database.Models.Billings
{
    [Table("expenses_positions", Schema = "billing")]
    public class ExpensePosition
    {
        [Required]
        [MaxLength(255)]
        [Column("NAME")]
        public string Name { get; set; }

        [ForeignKey("Expense")]
        [Column("EXPENSE_ID")]
        public long ExpenseId { get; set; }

        [ForeignKey("Service")]
        [Column("SERVICE_ID")]
        public long ServiceId { get; set; }

        public virtual Expense Expense { get; set; }
        public virtual Service Service { get; set; }
    }
}
