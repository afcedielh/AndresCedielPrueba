using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Models
{
    public class Catalog
    {
        public int CatalogId { get; set; }
        public string CatalogName { get; set; }
        public string CatalogDescription { get; set; }
        public string CatalogImage { get; set; }
        public int CategoryId { get; set; }
    }
}

