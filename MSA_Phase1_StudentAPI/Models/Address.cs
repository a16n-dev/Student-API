using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Address
{
    //Key
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AddressId { get; set; }

    //Student ID
    [Required]
    public int StudentId { get; set; }

    //Street number
    [Required]
    public int StreetNumber { get; set; }

    //Street name
    [Required, MaxLength(100)]
    public string Street { get; set; }

    //Suburb
    [Required, MaxLength(100)]
    public string Suburb { get; set; }

    //City
    [Required, MaxLength(100)]
    public string City { get; set; }

    //Postcode
    [Required]
    public int Postcode { get; set; }

    //Country
    [Required, MaxLength(100)]
    public string Country { get; set; }
}