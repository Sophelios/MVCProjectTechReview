using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCReviewProject.Models
{
    public class techReview
    {
        [Key]
        public int ID { get; set; }
        public string Item { get; set; }
        public string Review { get; set; }
        private DateTime? createdDate;
        public DateTime Published
        {
            get { return createdDate ?? DateTime.Now; }
            set { createdDate = value; }
        }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

    }
}