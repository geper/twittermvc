//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRMnewm
{
    using System;
    using System.Collections.Generic;
    
    public partial class Credential
    {
        public int Id { get; set; }
        public string ScreenName { get; set; }
        public string UserTwitterId { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string AccessToken { get; set; }
        public string OAuthToken { get; set; }
        public Nullable<int> UserIdProfile { get; set; }
    }
}
