using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Data
{
    public class Bin
    {
        public int Id { get; set; }
        public byte[] Binaries { get; set; }
        public DateTime UploadDate { get; set; }
        public string UploadName { get; set; }
    }
}
