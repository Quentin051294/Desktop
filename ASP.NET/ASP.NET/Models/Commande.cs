//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Commande
    {
        public decimal idCommande { get; set; }
        public decimal quantiteDemandee { get; set; }
        public decimal codeIdentification { get; set; }
        public decimal numeroIdentification { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Materiau Materiau { get; set; }
    }
}