using System;

namespace Avr.Core.Auditing
{
    public class Entity : IEntity
    {
        public long Id { get; set; }
        public long KayitKullaniciId { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Ip { get; set; }
    }
}
