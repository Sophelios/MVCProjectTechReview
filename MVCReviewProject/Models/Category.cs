using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCReviewProject.Models
{
    public class Category
    {
        public int ID { get; set; }
        public virtual ICollection<techReview> Reviews { get; set; }
        public string Name { get; set; }
    }
}