using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeminarMVC.Models
{
    public class SeminarViewModel
    {
        public IEnumerable<Seminar> seminar { get; set; }
        public PagingInfo pagingInfo { get; set; }
    }
}