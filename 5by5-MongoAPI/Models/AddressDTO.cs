﻿using Newtonsoft.Json;

namespace _5by5_MongoAPI.Models
{
    public class AddressDTO
    {
        #region Propriedades
        public int Id { get; set; }
        [JsonProperty("pais")]
        public string? Country { get; set; }
        [JsonProperty("cep")]
        public string CEP { get; set; }
        [JsonProperty("bairro")]
        public string Bairro { get; set; }
        [JsonProperty("localidade")]
        public string City { get; set; }
        [JsonProperty("uf")]
        public string State { get; set; }
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }
        [JsonProperty("gia")]
        public int Number { get; set; }
        [JsonProperty("complemento")]
        public string Complemento { get; set; }
        #endregion
    }
}