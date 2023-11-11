using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetLibrary
{
    public class CategoryModel
    {
        public string IdCategory { get; set; }
        public string strCategory { get; set; }
        public string strCategoryThumb { get; set; }
        public string strCategoryDescription { get; set; }
    }

    public class CategoryModelList
    {
        public List<CategoryModel> Categories { get; set; }

    }
}
