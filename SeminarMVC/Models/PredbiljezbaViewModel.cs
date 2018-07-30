using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeminarMVC.Models
{
    public class PredbiljezbaViewModel
    {
        public IEnumerable<Predbiljezba> predbiljezba { get; set; }
        public PagingInfo pagingInfo { get; set; }
    }
}