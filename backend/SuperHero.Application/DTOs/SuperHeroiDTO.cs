using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace SuperHeroi.Application.DTOs
{
    public class SuperHeroiDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string NomeHeroi { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public double Altura { get; set; }
        [Required]
        public double Peso { get; set; }
        public ICollection<SuperPoderesDTO> SuperPoderes { get; set; }
    }
}
