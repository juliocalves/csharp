using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoGames.InputModel
{
    public class GameInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do Game deve conter entre 3 e 100 caracteres")]
        public string Nome { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome da Produtora deve conter entre 3 e 100 caracteres")]
        public string Produtora { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "O preço do jogo deve ser de o minimo 1 e no máximo 1000 reais")]
        public double Preco { get; set; }

    }
}
