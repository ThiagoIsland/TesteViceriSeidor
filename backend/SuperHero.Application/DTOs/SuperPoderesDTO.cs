using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace SuperHeroi.Application.DTOs
{
    public class SuperPoderesDTO
    {
        public SuperPoderesDTO() { }
        
        public SuperPoderesDTO(int id, string superpoderNome, string descricao)
        {
            Id = id;
            SuperpoderNome = superpoderNome;
            Descricao = descricao;
        }
        
        [JsonIgnore]
        public int Id { get; set; }
        public string SuperpoderNome { get; set; }
        public string Descricao { get; set; }
    }
}
