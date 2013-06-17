using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcAppTwitter.Models
{
    [Table("Credential")]
    public class Credential
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ScreenName { get; set; }
        public string UserID { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string AccessToken { get; set; }
        public string OAuthToken { get; set; }
    }

    public class CredentialsContext : DbContext
    {
        public CredentialsContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Credential> Credentials { get; set; }

    }
}