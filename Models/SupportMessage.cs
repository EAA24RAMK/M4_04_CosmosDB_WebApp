using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace M4_04_CosmosDB_WebApp.Models;

public class KontaktInfo
{
    [Required(ErrorMessage = "Navn skal udfyldes")]
    public string navn { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email skal udfyldes")]
    [EmailAddress(ErrorMessage = "Email skal udfyldes")]
    public string email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Telefon skal udfyldes")]
    public string telefon { get; set; } = string.Empty;
}

public class SupportMessage
{
    public string id { get; set; } = Guid.NewGuid().ToString();
    
    [Required]
    public KontaktInfo kontakt { get; set; } = new KontaktInfo();
    
    [Required(ErrorMessage = "Kategori skal udfyldes")]
    public string category { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Beskrivelse skal udfyldes")]   
    [StringLength(500, ErrorMessage = "Maks. 500 tegn")]
    public string beskrivelse { get; set; } = string.Empty;
    
    public DateTime datoTid { get; set; } = DateTime.UtcNow;
}