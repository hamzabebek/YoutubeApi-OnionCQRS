using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Domain.Common;

namespace YoutubeApi.Domain.Entities
{
    public class Detail : EntityBase
    {
        public Detail()
        {
        }

        public Detail(string title, string description,int categotyid) {
        
            Title = title;
            Description = description;
            CategoryId = categotyid;
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
