using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Entities.DTOs
{
    public class PaginationDTO
    {
        public string? Filter {  get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "PageIndex must not be equal to 0.")]
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public PaginationDTO()
        {
            PageIndex = 1;
            PageSize = 10;
        }
    }
    public class PaginationDTO<T> where T : class
    {
        public T Result { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }

    }
}
