using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Lab2.Models
{
    public class Book
    {
        private int id;
        private string Tilte;
        private string author;
        private string images_cover;

        public Book()
        {

        }

        public Book(int id, string tilte, string author, string imagesCover)
        {
            this.id = id;
            this.Tilte = tilte;
            this.author = author;
            this.images_cover = imagesCover;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [StringLength(250, ErrorMessage = "Tiêu đề không vượt quá 250 kí tự")]
        [Display(Name = "Tiêu đề")]

        public string Title
        {
            get { return Tilte; }
            set { Tilte = value;}
        }

        [Required(ErrorMessage = "Tác giả không được để trống")]
        [StringLength(250, ErrorMessage = "Tác giả không vượt quá 250 kí tự")]
        [Display(Name = "Tác giả")]
        public string Author
        {
            get { return author; }
            set { author = value;}
        }
        public string Images_Cover
        {
            get { return images_cover; }
            set { images_cover = value; }
        }
    }
}