namespace BookShop.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUNHAP")]
    public partial class PHIEUNHAP
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? ID_NXB { get; set; }

        public DateTime? NGAYNHAP { get; set; }

        public int? SOLUONG { get; set; }

        public string TENSACH { get; set; }

        public string SOLUONGCT { get; set; }

        public bool? ISDELETE { get; set; }

        public virtual NHAXUATBAN NHAXUATBAN { get; set; }
    }
}
