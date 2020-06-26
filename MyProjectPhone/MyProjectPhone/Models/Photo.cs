using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectPhone.Models
{
    class Photo
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Title { get; set; }
        public byte[] Data { get; set; }
    }
}
