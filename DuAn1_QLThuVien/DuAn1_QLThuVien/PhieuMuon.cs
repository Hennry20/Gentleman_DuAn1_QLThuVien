//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DuAn1_QLThuVien
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhieuMuon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuMuon()
        {
            this.PhieuTras = new HashSet<PhieuTra>();
        }
    
        public int MaPhieuMuon { get; set; }
        public string MaND { get; set; }
        public string MaSach { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<System.DateTime> NgayMuon { get; set; }
        public Nullable<System.DateTime> NgayHenTra { get; set; }
        public Nullable<double> TienCoc { get; set; }
        public Nullable<int> SoGio { get; set; }
    
        public virtual NguoiDoc NguoiDoc { get; set; }
        public virtual Sach Sach { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuTra> PhieuTras { get; set; }
    }
}
