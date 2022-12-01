﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GuitarShop.Models
{
    public class Nft
    {
        // EF will instruct the database to automatically generate this value
        public int NftID { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryID { get; set; }  // foreign key property

        public Category Category { get; set; }

        [Required(ErrorMessage = "Please enter a nft code.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter a nft name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a nft price.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public decimal DiscountPercent => .20M;  // A discount of 20% is hard-coded for all nfts

        public decimal DiscountAmount => Price * DiscountPercent;

        public decimal DiscountPrice => Price - DiscountAmount;

        public string Slug {
            get {
                if (Name == null)
                    return "";
                else
                    return Name.Replace(' ', '-');
            }
        }
    }
}