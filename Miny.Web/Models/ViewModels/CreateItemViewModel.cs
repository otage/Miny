using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MINY.Web.Models.ViewModels
{
    public class CreateItemViewModel
    {
        [Required]
        public int WallId { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public string Note { get; set; }
        public string Url { get; set; }
        public string PicturePath { get; set; }
        public string VideoPath { get; set; }
        public int NbCol { get; set; }

        public bool IsEmpty
        {
            get
            {
                return Note == null && Url == null && PicturePath == null && VideoPath == null ? true : false;
            }
        }
    }
}